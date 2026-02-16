using System;
using System.Text.Json.Serialization;
using AutoMapper;
using Fintalks.Api.Validator;
using Fintalks.Common.Commands;
using Fintalks.DB;
using Fintalks.Repository.Repositories.UserRepository;
using Fintalks.Service.Mappers;
using Fintalks.Service.Services.UserService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();

builder.Services.AddScoped<IUserSevice, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => { }, typeof(UserMapperProfile));

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
