BEGIN TRANSACTION;

IF EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260220024934_UpdatePK'
)
BEGIN
    ALTER TABLE [Users] DROP CONSTRAINT [PK_Users];
    DROP INDEX [IX_Users_UserID] ON [Users];

    DECLARE @var nvarchar(max);
    SELECT @var = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'ID');
    
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT ' + @var + ';');
    
    ALTER TABLE [Users] DROP COLUMN [ID];

    ALTER TABLE [Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY ([UserID]);

    DELETE FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260220024934_UpdatePK';
END;

COMMIT;
GO