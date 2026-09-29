# Fintalks User Management Backend

## What is it

A .NET 10 Web API backend for **Fintalks**, currently focused on user registration and user
management. It exposes REST endpoints to register a user (with associated personal/KYC info),
update a user's profile, list/fetch/delete users, and enforces validation, uniqueness checks,
and soft-deletion at the data layer.

## Architecture

The solution is split into layered class libraries plus a Web API host, following a fairly
classic n-tier / clean-ish architecture:

| Project | Responsibility |
|---|---|
| `Fintalks.Api` | ASP.NET Core Web API host — controllers, request validators, global exception handling, DI/composition root (`Program.cs`) |
| `Fintalks.Service` | Business logic (services) and AutoMapper mapping profiles between Commands ↔ domain Models ↔ DB Entities ↔ DTOs |
| `Fintalks.Repository` | Data-access layer — repository interfaces/implementations wrapping EF Core, including a generic repository |
| `Fintalks.DB` | EF Core `DbContext`, DB entities (`DBUser`, `DBUserInfo`), EF Core migrations, soft-delete extension |
| `Fintalks.Common` | Cross-cutting types shared across layers: Commands, DTOs, domain Models, Enums, custom Exceptions, Constants, Interfaces, Utils |

Data flows through distinct type "shapes" per layer:
**Command** (API input, e.g. `RegisterUserCommand`) → **domain Model** (e.g. `User`, `UserInfo`)
→ **DB Entity** (`DBUser`, `DBUserInfo`) for persistence, and back out through **DTOs**
(`UserResponseDTO`, `CreateUserResponseDTO`) for API responses. AutoMapper profiles
(`Fintalks.Service/Mappers`) handle all these conversions instead of manual mapping code.

## Key technologies / patterns used

- **ASP.NET Core Web API** (.NET 10, `net10.0`) with Swagger/OpenAPI (`Swashbuckle.AspNetCore`, `AddOpenApi`) for API docs.
- **Entity Framework Core (SQL Server provider)** for data access, with:
  - Code-first migrations (`Fintalks.DB/Migrations`).
  - **Fluent API configuration** in `ApplicationDBContext.OnModelCreating` (keys, unique indexes on `UserID`/`UserName`/`Email`, required fields, max lengths, one-to-one `DBUser` ↔ `DBUserInfo` relationship).
  - **Global query filter** for soft-deleted rows (`HasQueryFilter(e => e.DeletedAt == null)`).
  - **`NoTracking` query behavior** configured globally (`UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)`) for read performance, with explicit `_context.Update(...)` used where writes are needed.
  - **Database transactions** (`Database.BeginTransactionAsync` / commit / rollback) in `UserManagementRepository` to atomically create a `DBUser` + `DBUserInfo` together on registration, and to atomically update both together on profile update — if either half fails, the whole operation rolls back.
  - **LINQ** queries throughout the repositories (`Where`, `FirstOrDefaultAsync`, `AnyAsync`, `ToListAsync`) for filtering/querying users (e.g. checking if a username/email is already taken, fetching a user by GUID).
- **Generic repository pattern** (`GenericRepository<T>` / `IGenericRepository<T>`) providing reusable `Create`, `GetAll`, `GetById`, `Update`, `Delete` — the `Delete` method automatically soft-deletes if the entity implements `ISoftDeletable`, otherwise hard-deletes.
- **Soft delete** via an `ISoftDeletable` interface (`DeletedAt` property) implemented by `DBUser`, with a `DbSet<T>.SoftDelete()` extension method (`Fintalks.DB/Extensions/DBSetExtension.cs`) and enforced globally through the EF query filter.
- **Repository pattern** with per-entity repositories (`UserRepository`, `UserInfoRepository`) plus a composite `UserManagementRepository` that coordinates multi-entity operations under a transaction.
- **Service layer** (`UserService`, `UserInfoService`, `UserManagementService`) separating business rules (e.g. uniqueness checks, "user not found" handling) from controllers and repositories.
- **AutoMapper** for object-to-object mapping between Commands, Models, DB Entities, and DTOs (`RegisterUserMapperProfile`, `UpdateUserMapperProfile`, `UserMapperProfile`, `UserInfoMapperProfile`).
- **FluentValidation** (`FluentValidation.AspNetCore`) for request validation (`RegisterUserValidator`, `CreateUserValidator`, `UpdateUserValidator`), auto-registered from the assembly and hooked into the pipeline.
- **Custom validation pipeline**: `ApiBehaviorOptions.SuppressModelStateInvalidFilter` disables the default 400 behavior, and a custom `CustomValidationAttribute` (`ActionFilterAttribute`) formats validation failures into a consistent `ErrorResponse` shape.
- **Centralized exception handling**: `GlobalExceptionHandler` (`IExceptionHandler`, .NET's newer exception-handling middleware via `AddExceptionHandler`/`UseExceptionHandler`) maps custom exceptions (`AppException`, `ConflictException`, `NotFoundException`) to proper HTTP status codes and a uniform `ErrorResponse` JSON body (falls back to 500 for unknown exceptions).
- **Dependency Injection** — all services/repositories registered as scoped services in `Program.cs`.
- **Enum-as-string JSON serialization** (`JsonStringEnumConverter`) so enums like `UserRole` (`ADMIN`, `USER`) serialize as readable strings instead of integers.
- **Constants classes** (`UserConst`, `ErrorConst`) centralizing field length limits and user-facing messages instead of magic numbers/strings scattered in code.
- **Primary-constructor DI pattern** (C# 12 primary constructors) used consistently for controllers, services, and repositories (e.g. `public class UserService(IUserRepository _userRepository, IMapper _mapper) : IUserSevice`).
- **Serilog** package referenced (structured logging), though wiring isn't yet visible beyond the package reference.

## Data model

- **`DBUser`**: `ID` (internal PK, auto-generated), `UserID` (public-facing GUID, unique), `UserName` (unique), `FirstName`/`LastName`, `Email` (unique), `JoinDate`, `Role` (`UserRole` enum), `IsEmailConfirmed`, `Bio`, `ProfilePictureUrl`, `DeletedAt` (soft-delete marker), and a one-to-one navigation to `UserInfo`.
- **`DBUserInfo`**: `ID`, `FatherName`, `MotherName`, `Nid`, `PhoneNumber`, FK `DBUserID` back to the owning user.
- `FirstName`/`LastName` are derived server-side from a single `Name` field on input via `NameExtractor.FirstName`/`LastName` (splitting on whitespace).

## Functionality / API surface

**`POST /api/RegisterUser`** — Registers a new user.
- Validates uniqueness of username and email (`ConflictException` with combined error messages if either is taken).
- Maps the registration command into a `User` + `UserInfo`, then into `DBUser`/`DBUserInfo`.
- Persists both entities atomically in a single DB transaction.

**`PUT /api/RegisterUser/{id}`** — Updates an existing user's profile (`UpdateUserProfileCommand`).
- Looks up the user and their info by ID, maps updated fields onto both, and persists both changes atomically in a transaction.

**`GET /api/Users`** — Lists all (non-deleted) users as `UserResponseDTO`s.

**`GET /api/Users/{id}`** — Fetches a single user by GUID; throws `NotFoundException` (→ 404) if absent.

**`DELETE /api/Users/{id}`** — Deletes a user by GUID. Because `DBUser` implements `ISoftDeletable`, this is a **soft delete** (sets `DeletedAt`), and the global EF query filter then excludes it from all future queries.

A couple of endpoints (`POST /api/Users` create-user, `PUT /api/Users` update-user) are present in `UsersController` but currently commented out — the "create" and "update" flows are instead exposed through `RegisterUserController` (`RegisterUser` / `UpdateUserProfile`), which handle the combined user + user-info workflow.

## Error handling behavior

All API errors return a consistent JSON shape (`ErrorResponse`: `Success`, `Message`, `Errors`, `Stack`):
- Validation failures → `400 Bad Request` with a list of field error messages.
- Domain exceptions (`NotFoundException` → 404, `ConflictException` → 409, etc., all derived from `AppException`) → their mapped status code with a clean message.
- Any unhandled exception → `500 Internal Server Error` with a generic error message.
