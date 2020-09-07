IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207014800_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200207014800_Initial', N'3.1.7');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [GenreTags] (
        [GenreTagID] int NOT NULL IDENTITY,
        [Tag] nvarchar(max) NULL,
        CONSTRAINT [PK_GenreTags] PRIMARY KEY ([GenreTagID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [Messages] (
        [MessageID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Date] datetime2 NOT NULL,
        [MessageTitle] nvarchar(max) NULL,
        [MessageBody] nvarchar(max) NULL,
        CONSTRAINT [PK_Messages] PRIMARY KEY ([MessageID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [MusicTracks] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [GenreTagID] int NULL,
        [FileName] nvarchar(max) NULL,
        CONSTRAINT [PK_MusicTracks] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_MusicTracks_GenreTags_GenreTagID] FOREIGN KEY ([GenreTagID]) REFERENCES [GenreTags] ([GenreTagID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [Comments] (
        [CommentID] int NOT NULL IDENTITY,
        [FK_MusicTrackID] int NOT NULL,
        [CommentText] nvarchar(max) NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentID]),
        CONSTRAINT [FK_Comments_MusicTracks_FK_MusicTrackID] FOREIGN KEY ([FK_MusicTrackID]) REFERENCES [MusicTracks] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [InstrumentTags] (
        [ID] int NOT NULL IDENTITY,
        [Tag] nvarchar(max) NULL,
        [MusicTrackID] int NULL,
        CONSTRAINT [PK_InstrumentTags] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_InstrumentTags_MusicTracks_MusicTrackID] FOREIGN KEY ([MusicTrackID]) REFERENCES [MusicTracks] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [MoodTags] (
        [ID] int NOT NULL IDENTITY,
        [Tag] nvarchar(max) NULL,
        [MusicTrackID] int NULL,
        CONSTRAINT [PK_MoodTags] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_MoodTags_MusicTracks_MusicTrackID] FOREIGN KEY ([MusicTrackID]) REFERENCES [MusicTracks] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [OtherTags] (
        [ID] int NOT NULL IDENTITY,
        [Tag] nvarchar(max) NULL,
        [MusicTrackID] int NULL,
        CONSTRAINT [PK_OtherTags] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_OtherTags_MusicTracks_MusicTrackID] FOREIGN KEY ([MusicTrackID]) REFERENCES [MusicTracks] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [Ratings] (
        [MusicTrackID] int NOT NULL,
        [UserID] nvarchar(450) NOT NULL,
        [RatingValue] int NOT NULL,
        CONSTRAINT [PK_Ratings] PRIMARY KEY ([UserID], [MusicTrackID]),
        CONSTRAINT [FK_Ratings_MusicTracks_MusicTrackID] FOREIGN KEY ([MusicTrackID]) REFERENCES [MusicTracks] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Ratings_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [MusicTrackInstrumentTags] (
        [MusicTrackID] int NOT NULL,
        [InstrumentTagID] int NOT NULL,
        CONSTRAINT [PK_MusicTrackInstrumentTags] PRIMARY KEY ([MusicTrackID], [InstrumentTagID]),
        CONSTRAINT [FK_MusicTrackInstrumentTags_InstrumentTags_InstrumentTagID] FOREIGN KEY ([InstrumentTagID]) REFERENCES [InstrumentTags] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_MusicTrackInstrumentTags_MusicTracks_MusicTrackID] FOREIGN KEY ([MusicTrackID]) REFERENCES [MusicTracks] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [MusicTrackMoodTags] (
        [MusicTrackID] int NOT NULL,
        [MoodTagID] int NOT NULL,
        CONSTRAINT [PK_MusicTrackMoodTags] PRIMARY KEY ([MusicTrackID], [MoodTagID]),
        CONSTRAINT [FK_MusicTrackMoodTags_MoodTags_MoodTagID] FOREIGN KEY ([MoodTagID]) REFERENCES [MoodTags] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_MusicTrackMoodTags_MusicTracks_MusicTrackID] FOREIGN KEY ([MusicTrackID]) REFERENCES [MusicTracks] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE TABLE [MusicTrackOtherTag] (
        [MusicTrackID] int NOT NULL,
        [OtherTagID] int NOT NULL,
        CONSTRAINT [PK_MusicTrackOtherTag] PRIMARY KEY ([MusicTrackID], [OtherTagID]),
        CONSTRAINT [FK_MusicTrackOtherTag_MusicTracks_MusicTrackID] FOREIGN KEY ([MusicTrackID]) REFERENCES [MusicTracks] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_MusicTrackOtherTag_OtherTags_OtherTagID] FOREIGN KEY ([OtherTagID]) REFERENCES [OtherTags] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE INDEX [IX_Comments_FK_MusicTrackID] ON [Comments] ([FK_MusicTrackID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE INDEX [IX_InstrumentTags_MusicTrackID] ON [InstrumentTags] ([MusicTrackID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE INDEX [IX_MoodTags_MusicTrackID] ON [MoodTags] ([MusicTrackID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE INDEX [IX_MusicTrackInstrumentTags_InstrumentTagID] ON [MusicTrackInstrumentTags] ([InstrumentTagID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE INDEX [IX_MusicTrackMoodTags_MoodTagID] ON [MusicTrackMoodTags] ([MoodTagID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE INDEX [IX_MusicTrackOtherTag_OtherTagID] ON [MusicTrackOtherTag] ([OtherTagID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE INDEX [IX_MusicTracks_GenreTagID] ON [MusicTracks] ([GenreTagID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE INDEX [IX_OtherTags_MusicTrackID] ON [OtherTags] ([MusicTrackID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    CREATE INDEX [IX_Ratings_MusicTrackID] ON [Ratings] ([MusicTrackID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200207024828_Version2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200207024828_Version2', N'3.1.7');
END;

GO

