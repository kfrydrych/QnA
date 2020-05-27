IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Sessions] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(250) NOT NULL,
    [Login] nvarchar(50) NOT NULL,
    [Password] nvarchar(50) NOT NULL,
    [Status] int NOT NULL,
    [Owner] nvarchar(50) NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    CONSTRAINT [PK_Sessions] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Question] (
    [Id] uniqueidentifier NOT NULL,
    [SessionId] uniqueidentifier NOT NULL,
    [Text] nvarchar(750) NOT NULL,
    [Score] int NOT NULL,
    [DateAdded] datetime2 NOT NULL,
    [CreatedBy] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Question_Sessions_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [Sessions] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Vote] (
    [Id] uniqueidentifier NOT NULL,
    [QuestionId] uniqueidentifier NOT NULL,
    [DateAdded] datetime2 NOT NULL,
    [AddedBy] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Vote] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vote_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Question] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Question_SessionId] ON [Question] ([SessionId]);

GO

CREATE INDEX [IX_Vote_QuestionId] ON [Vote] ([QuestionId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200424201151_Init', N'3.1.3');

GO

ALTER TABLE [Question] DROP CONSTRAINT [FK_Question_Sessions_SessionId];

GO

ALTER TABLE [Vote] DROP CONSTRAINT [FK_Vote_Question_QuestionId];

GO

ALTER TABLE [Question] DROP CONSTRAINT [PK_Question];

GO

EXEC sp_rename N'[Question]', N'Questions';

GO

EXEC sp_rename N'[Questions].[IX_Question_SessionId]', N'IX_Questions_SessionId', N'INDEX';

GO

ALTER TABLE [Questions] ADD CONSTRAINT [PK_Questions] PRIMARY KEY ([Id]);

GO

ALTER TABLE [Questions] ADD CONSTRAINT [FK_Questions_Sessions_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [Sessions] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [Vote] ADD CONSTRAINT [FK_Vote_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200425220349_QuestionsTableNameUpdated', N'3.1.3');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sessions]') AND [c].[name] = N'Login');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Sessions] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Sessions] DROP COLUMN [Login];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sessions]') AND [c].[name] = N'Password');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Sessions] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Sessions] DROP COLUMN [Password];

GO

ALTER TABLE [Sessions] ADD [AccessCode] nvarchar(50) NOT NULL DEFAULT N'';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200427202002_LoginRemovedPasswordRenamedToAccessCode', N'3.1.3');

GO

