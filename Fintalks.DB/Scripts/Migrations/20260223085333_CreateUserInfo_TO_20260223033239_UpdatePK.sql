BEGIN TRANSACTION;
DROP TABLE [UserInfos];

DELETE FROM [__EFMigrationsHistory]
WHERE [MigrationId] = N'20260223085333_CreateUserInfo';

COMMIT;
GO

