/*
    Database script - fixed version
    Target DBMS: SQL Server

    Main changes compared to the original script:
    - Rename Accounts.Password to Accounts.PasswordHash.
    - Add DEFAULT 0 for IsDeleted columns.
    - Add CreatedAt / UpdatedAt audit fields to main tables.
    - Add CHECK constraints for Role, Status, Gender, score, fee, amount, max students, date range.
    - Add unique indexes for email/phone where appropriate.
    - Add unique filtered index to prevent duplicate active enrollment for the same student and class.
    - Change Scores/Attendances foreign keys from ON DELETE CASCADE to ON DELETE NO ACTION to avoid losing history.

    Note:
    - If your C# model currently has Password instead of PasswordHash, update the model and login code accordingly.
    - If your app does not use CreatedAt/UpdatedAt yet, either update the models or remove those columns.
*/

IF DB_ID(N'EnglishCenterDB') IS NULL
BEGIN
    CREATE DATABASE [EnglishCenterDB];
END
GO

USE [EnglishCenterDB];
GO

CREATE TABLE [Accounts] (
    [Id] nvarchar(20) NOT NULL,
    [Username] nvarchar(50) NOT NULL,
    [PasswordHash] nvarchar(255) NOT NULL,
    [DisplayName] nvarchar(120) NOT NULL,
    [Email] nvarchar(120) NOT NULL,
    [Phone] nvarchar(20) NOT NULL,
    [Role] nvarchar(20) NOT NULL,
    [Status] nvarchar(20) NOT NULL,
    [IsDeleted] bit NOT NULL CONSTRAINT [DF_Accounts_IsDeleted] DEFAULT 0,
    [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Accounts_CreatedAt] DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_Accounts_Role] CHECK ([Role] IN (N'Admin', N'Staff', N'Teacher')),
    CONSTRAINT [CK_Accounts_Status] CHECK ([Status] IN (N'Active', N'Inactive', N'Locked'))
);
GO

CREATE TABLE [Courses] (
    [Id] nvarchar(20) NOT NULL,
    [Name] nvarchar(150) NOT NULL,
    [Description] nvarchar(1000) NULL,
    [TuitionFee] decimal(18,2) NOT NULL,
    [Status] nvarchar(30) NOT NULL,
    [IsDeleted] bit NOT NULL CONSTRAINT [DF_Courses_IsDeleted] DEFAULT 0,
    [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Courses_CreatedAt] DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_Courses_TuitionFee] CHECK ([TuitionFee] >= 0),
    CONSTRAINT [CK_Courses_Status] CHECK ([Status] IN (N'Active', N'Inactive'))
);
GO

CREATE TABLE [Students] (
    [Id] nvarchar(20) NOT NULL,
    [FullName] nvarchar(120) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    [Phone] nvarchar(20) NOT NULL,
    [Email] nvarchar(120) NULL,
    [Address] nvarchar(300) NULL,
    [AvatarPath] nvarchar(260) NULL,
    [Status] nvarchar(30) NOT NULL,
    [IsDeleted] bit NOT NULL CONSTRAINT [DF_Students_IsDeleted] DEFAULT 0,
    [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Students_CreatedAt] DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id]),
    CONSTRAINT [CK_Students_Status] CHECK ([Status] IN (N'Active', N'Inactive', N'Paused', N'Completed', N'Dropped'))
);
GO

CREATE TABLE [Teachers] (
    [Id] nvarchar(20) NOT NULL,
    [FullName] nvarchar(120) NOT NULL,
    [Phone] nvarchar(20) NOT NULL,
    [Email] nvarchar(120) NOT NULL,
    [Specialization] nvarchar(120) NULL,
    [Gender] nvarchar(20) NULL,
    [Address] nvarchar(300) NULL,
    [AvatarPath] nvarchar(260) NULL,
    [AccountId] nvarchar(20) NULL,
    [Status] nvarchar(30) NOT NULL,
    [IsDeleted] bit NOT NULL CONSTRAINT [DF_Teachers_IsDeleted] DEFAULT 0,
    [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Teachers_CreatedAt] DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Teachers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Teachers_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [CK_Teachers_Gender] CHECK ([Gender] IS NULL OR [Gender] IN (N'Male', N'Female', N'Other')),
    CONSTRAINT [CK_Teachers_Status] CHECK ([Status] IN (N'Active', N'Inactive'))
);
GO

CREATE TABLE [Classes] (
    [Id] nvarchar(20) NOT NULL,
    [Name] nvarchar(120) NOT NULL,
    [CourseId] nvarchar(20) NOT NULL,
    [TeacherId] nvarchar(20) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [Schedule] nvarchar(120) NULL,
    [Room] nvarchar(50) NULL,
    [MaxStudents] int NOT NULL,
    [Status] nvarchar(30) NOT NULL,
    [IsDeleted] bit NOT NULL CONSTRAINT [DF_Classes_IsDeleted] DEFAULT 0,
    [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Classes_CreatedAt] DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Classes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Classes_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Classes_Teachers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [Teachers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Classes_DateRange] CHECK ([EndDate] >= [StartDate]),
    CONSTRAINT [CK_Classes_MaxStudents] CHECK ([MaxStudents] > 0),
    CONSTRAINT [CK_Classes_Status] CHECK ([Status] IN (N'Open', N'Closed', N'InProgress', N'Completed', N'Cancelled'))
);
GO

CREATE TABLE [Enrollments] (
    [Id] nvarchar(20) NOT NULL,
    [StudentId] nvarchar(20) NOT NULL,
    [ClassId] nvarchar(20) NOT NULL,
    [EnrollDate] datetime2 NOT NULL,
    [Status] nvarchar(30) NOT NULL,
    [Note] nvarchar(500) NULL,
    [IsDeleted] bit NOT NULL CONSTRAINT [DF_Enrollments_IsDeleted] DEFAULT 0,
    [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Enrollments_CreatedAt] DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Enrollments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enrollments_Classes_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [Classes] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Enrollments_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Students] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Enrollments_Status] CHECK ([Status] IN (N'Active', N'Paused', N'Completed', N'Dropped', N'Cancelled'))
);
GO

CREATE TABLE [Attendances] (
    [Id] nvarchar(20) NOT NULL,
    [EnrollmentId] nvarchar(20) NOT NULL,
    [AttendanceDate] datetime2 NOT NULL,
    [Status] nvarchar(20) NOT NULL,
    [Note] nvarchar(300) NULL,
    [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Attendances_CreatedAt] DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Attendances] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Attendances_Enrollments_EnrollmentId] FOREIGN KEY ([EnrollmentId]) REFERENCES [Enrollments] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Attendances_Status] CHECK ([Status] IN (N'Present', N'Absent', N'Late', N'Excused'))
);
GO

CREATE TABLE [Receipts] (
    [Id] nvarchar(20) NOT NULL,
    [EnrollmentId] nvarchar(20) NOT NULL,
    [AmountPaid] decimal(18,2) NOT NULL,
    [PayDate] datetime2 NOT NULL,
    [PaymentMethod] nvarchar(50) NOT NULL,
    [Note] nvarchar(500) NULL,
    [CreatedByStaffId] nvarchar(20) NULL,
    [IsDeleted] bit NOT NULL CONSTRAINT [DF_Receipts_IsDeleted] DEFAULT 0,
    [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Receipts_CreatedAt] DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Receipts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Receipts_Accounts_CreatedByStaffId] FOREIGN KEY ([CreatedByStaffId]) REFERENCES [Accounts] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Receipts_Enrollments_EnrollmentId] FOREIGN KEY ([EnrollmentId]) REFERENCES [Enrollments] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Receipts_AmountPaid] CHECK ([AmountPaid] > 0),
    CONSTRAINT [CK_Receipts_PaymentMethod] CHECK ([PaymentMethod] IN (N'Cash', N'BankTransfer', N'Card', N'EWallet', N'Other'))
);
GO

CREATE TABLE [Scores] (
    [Id] nvarchar(20) NOT NULL,
    [EnrollmentId] nvarchar(20) NOT NULL,
    [MidtermScore] decimal(4,2) NULL,
    [FinalScore] decimal(4,2) NULL,
    [Note] nvarchar(300) NULL,
    [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Scores_CreatedAt] DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Scores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Scores_Enrollments_EnrollmentId] FOREIGN KEY ([EnrollmentId]) REFERENCES [Enrollments] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [CK_Scores_MidtermScore] CHECK ([MidtermScore] IS NULL OR ([MidtermScore] >= 0 AND [MidtermScore] <= 10)),
    CONSTRAINT [CK_Scores_FinalScore] CHECK ([FinalScore] IS NULL OR ([FinalScore] >= 0 AND [FinalScore] <= 10))
);
GO

-- Accounts
CREATE UNIQUE INDEX [IX_Accounts_Username]
ON [Accounts] ([Username])
WHERE [IsDeleted] = 0;
GO

CREATE UNIQUE INDEX [IX_Accounts_Email]
ON [Accounts] ([Email])
WHERE [IsDeleted] = 0;
GO

CREATE UNIQUE INDEX [IX_Accounts_Phone]
ON [Accounts] ([Phone])
WHERE [IsDeleted] = 0;
GO

-- Students
CREATE UNIQUE INDEX [IX_Students_Email]
ON [Students] ([Email])
WHERE [Email] IS NOT NULL AND [IsDeleted] = 0;
GO

CREATE UNIQUE INDEX [IX_Students_Phone]
ON [Students] ([Phone])
WHERE [IsDeleted] = 0;
GO

-- Teachers
CREATE UNIQUE INDEX [IX_Teachers_Email]
ON [Teachers] ([Email])
WHERE [IsDeleted] = 0;
GO

CREATE UNIQUE INDEX [IX_Teachers_Phone]
ON [Teachers] ([Phone])
WHERE [IsDeleted] = 0;
GO

CREATE UNIQUE INDEX [IX_Teachers_AccountId]
ON [Teachers] ([AccountId])
WHERE [AccountId] IS NOT NULL AND [IsDeleted] = 0;
GO

-- Classes
CREATE INDEX [IX_Classes_CourseId] ON [Classes] ([CourseId]);
GO

CREATE INDEX [IX_Classes_TeacherId] ON [Classes] ([TeacherId]);
GO

-- Enrollments
CREATE INDEX [IX_Enrollments_ClassId] ON [Enrollments] ([ClassId]);
GO

CREATE INDEX [IX_Enrollments_StudentId] ON [Enrollments] ([StudentId]);
GO

CREATE UNIQUE INDEX [IX_Enrollments_StudentId_ClassId_NotDeleted]
ON [Enrollments] ([StudentId], [ClassId])
WHERE [IsDeleted] = 0;
GO

-- Attendances
CREATE UNIQUE INDEX [IX_Attendances_EnrollmentId_AttendanceDate]
ON [Attendances] ([EnrollmentId], [AttendanceDate]);
GO

-- Receipts
CREATE INDEX [IX_Receipts_CreatedByStaffId] ON [Receipts] ([CreatedByStaffId]);
GO

CREATE INDEX [IX_Receipts_EnrollmentId] ON [Receipts] ([EnrollmentId]);
GO

-- Scores
CREATE UNIQUE INDEX [IX_Scores_EnrollmentId]
ON [Scores] ([EnrollmentId]);
GO
