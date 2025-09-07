-- Database Schema for DoConnect
-- Generated from Entity Framework Migrations

USE [DoConnectDb];
GO

-- Create Users table
CREATE TABLE [dbo].[Users] (
    [UserId] INT IDENTITY(1,1) NOT NULL,
    [Username] NVARCHAR(450) NOT NULL,
    [PasswordHash] NVARCHAR(MAX) NOT NULL,
    [Role] NVARCHAR(MAX) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);
GO

-- Create unique index on Username
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username] ON [dbo].[Users] ([Username] ASC);
GO

-- Create Questions table
CREATE TABLE [dbo].[Questions] (
    [QuestionId] NVARCHAR(450) NOT NULL,
    [UserId] INT NOT NULL,
    [Title] NVARCHAR(MAX) NOT NULL,
    [Text] NVARCHAR(MAX) NOT NULL,
    [Status] NVARCHAR(MAX) NOT NULL,
    [ImageIDs] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([QuestionId] ASC),
    CONSTRAINT [FK_Questions_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE
);
GO

-- Create index on UserId in Questions
CREATE NONCLUSTERED INDEX [IX_Questions_UserId] ON [dbo].[Questions] ([UserId] ASC);
GO

-- Create Answers table
CREATE TABLE [dbo].[Answers] (
    [AnswerId] NVARCHAR(450) NOT NULL,
    [QuestionId] NVARCHAR(450) NOT NULL,
    [UserId] INT NOT NULL,
    [Text] NVARCHAR(MAX) NOT NULL,
    [Status] NVARCHAR(MAX) NOT NULL,
    [ImageIDs] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED ([AnswerId] ASC),
    CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Questions] ([QuestionId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Answers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);
GO

-- Create indexes on Answers
CREATE NONCLUSTERED INDEX [IX_Answers_QuestionId] ON [dbo].[Answers] ([QuestionId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Answers_UserId] ON [dbo].[Answers] ([UserId] ASC);
GO

-- Create Images table
CREATE TABLE [dbo].[Images] (
    [ImageID] NVARCHAR(450) NOT NULL,
    [Path] NVARCHAR(MAX) NOT NULL,
    [QuestionId] NVARCHAR(450) NULL,
    [AnswerId] NVARCHAR(450) NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([ImageID] ASC),
    CONSTRAINT [FK_Images_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Questions] ([QuestionId]),
    CONSTRAINT [FK_Images_Answers_AnswerId] FOREIGN KEY ([AnswerId]) REFERENCES [dbo].[Answers] ([AnswerId])
);
GO

-- Create indexes on Images
CREATE NONCLUSTERED INDEX [IX_Images_QuestionId] ON [dbo].[Images] ([QuestionId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Images_AnswerId] ON [dbo].[Images] ([AnswerId] ASC);
GO
