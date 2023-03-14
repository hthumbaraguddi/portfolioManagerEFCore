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

CREATE TABLE [Portfolios] (
    [PortfolioId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Portfolios] PRIMARY KEY ([PortfolioId])
);
GO

CREATE TABLE [Equity] (
    [EquityId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [PurchaseDate] datetime2 NOT NULL,
    [AcquiredPrice] float NOT NULL,
    [SoldPrice] float NULL,
    [isSold] bit NOT NULL,
    [OverallPnL] float NULL,
    [PortfolioID] int NOT NULL,
    CONSTRAINT [PK_Equity] PRIMARY KEY ([EquityId]),
    CONSTRAINT [FK_Equity_Portfolios_PortfolioID] FOREIGN KEY ([PortfolioID]) REFERENCES [Portfolios] ([PortfolioId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Equity_PortfolioID] ON [Equity] ([PortfolioID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230313122532_Initial', N'6.0.0');
GO

COMMIT;
GO

