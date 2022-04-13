# UniqueWords

To run this repo local. .NET 6 and MSSQl server is required

1. Run the migrations so the database and tabels will get added or run the following first
2. Creating the database

```
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220412124755_Initial-Migration')
BEGIN
    CREATE TABLE [UniqueWordList] (
        [Id] int NOT NULL IDENTITY,
        [UniqueWordName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_UniqueWordList] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220412124755_Initial-Migration')
BEGIN
    CREATE TABLE [WatchList] (
        [Id] int NOT NULL IDENTITY,
        [WatchedWord] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_WatchList] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220412124755_Initial-Migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220412124755_Initial-Migration', N'6.0.4');
END;
GO

COMMIT;
GO
```

