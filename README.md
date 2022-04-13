# UniqueWords

To run this repo local. .NET 6 and MSSQl server is required
obs this project uses a free version of https://entityframework-extensions.net/ to handle high amount of bulk insert in milliseconds.
If this project is needed in for commercial use. Buy an licens for it or create your own bulk insert. An easy way would to just create a raw sql bulk insert
```
// connect to SQL
using (SqlConnection connection = new SqlConnection(connString))
{
    // make sure to enable triggers
    // more on triggers in next post
    SqlBulkCopy bulkCopy = new SqlBulkCopy(
        connection, 
        SqlBulkCopyOptions.TableLock | 
        SqlBulkCopyOptions.FireTriggers | 
        SqlBulkCopyOptions.UseInternalTransaction,
        null
        );

    // set the destination table name
    bulkCopy.DestinationTableName = this.tableName;
    connection.Open();

    // write the data in the "dataTable"
    bulkCopy.WriteToServer(dataTable);
    connection.Close();
}
// reset
this.dataTable.Clear();
```

1. Run the migrations so the database and tabels will get added by using the PMC and command update-datebase (this will skip all other steps)
2. or run the following first
3. Creating the database.
```
USE [master]
GO

CREATE DATABASE [UniqueWords]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniqueWords',  SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniqueWords_log', SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniqueWords].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [UniqueWords] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [UniqueWords] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [UniqueWords] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [UniqueWords] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [UniqueWords] SET ARITHABORT OFF 
GO

ALTER DATABASE [UniqueWords] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [UniqueWords] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [UniqueWords] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [UniqueWords] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [UniqueWords] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [UniqueWords] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [UniqueWords] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [UniqueWords] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [UniqueWords] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [UniqueWords] SET  ENABLE_BROKER 
GO

ALTER DATABASE [UniqueWords] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [UniqueWords] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [UniqueWords] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [UniqueWords] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [UniqueWords] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [UniqueWords] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [UniqueWords] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [UniqueWords] SET RECOVERY FULL 
GO

ALTER DATABASE [UniqueWords] SET  MULTI_USER 
GO

ALTER DATABASE [UniqueWords] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [UniqueWords] SET DB_CHAINING OFF 
GO

ALTER DATABASE [UniqueWords] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [UniqueWords] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [UniqueWords] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [UniqueWords] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [UniqueWords] SET QUERY_STORE = OFF
GO

ALTER DATABASE [UniqueWords] SET  READ_WRITE 
GO


```
3. Run the SQL snippet and all the migrations will be applied into the database
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

