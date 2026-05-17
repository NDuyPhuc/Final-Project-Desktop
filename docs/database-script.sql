
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
    CONSTRAINT [CK_Teachers_Gender] CHECK ([Gender] IS NULL OR LTRIM(RTRIM([Gender])) IN (N'Nam', N'Nữ', N'Nu', N'Khác', N'Khac', N'Male', N'Female', N'Other')),
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

/*
    Sample login accounts
    Plain-text password for all 3 accounts: 123456
    SHA-256(123456) = 8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92
*/
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET QUOTED_IDENTIFIER ON;
SET NUMERIC_ROUNDABORT OFF;
GO

IF NOT EXISTS (SELECT 1 FROM [Accounts] WHERE [Id] = N'ACC001')
BEGIN
    INSERT INTO [Accounts] ([Id], [Username], [PasswordHash], [DisplayName], [Email], [Phone], [Role], [Status], [IsDeleted])
    VALUES
        (N'ACC001', N'admin',   N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'Admin Tong Quan',      N'admin@ttnn.local',   N'0909000001', N'Admin',   N'Active', 0),
        (N'ACC002', N'staff',   N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'Nhan Vien Van Hanh',  N'staff@ttnn.local',   N'0909000002', N'Staff',   N'Active', 0),
        (N'ACC003', N'teacher', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'Tran Minh An',        N'teacher@ttnn.local', N'0909000003', N'Teacher', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM [Accounts] WHERE [Id] = N'ACC001')
BEGIN
    INSERT INTO [Accounts] ([Id], [Username], [PasswordHash], [DisplayName], [Email], [Phone], [Role], [Status], [IsDeleted])
    VALUES (N'ACC001', N'admin', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'Admin Tong Quan', N'admin@ttnn.local', N'0909000001', N'Admin', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM [Accounts] WHERE [Id] = N'ACC002')
BEGIN
    INSERT INTO [Accounts] ([Id], [Username], [PasswordHash], [DisplayName], [Email], [Phone], [Role], [Status], [IsDeleted])
    VALUES (N'ACC002', N'staff', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'Nhan Vien Van Hanh', N'staff@ttnn.local', N'0909000002', N'Staff', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM [Accounts] WHERE [Id] = N'ACC003')
BEGIN
    INSERT INTO [Accounts] ([Id], [Username], [PasswordHash], [DisplayName], [Email], [Phone], [Role], [Status], [IsDeleted])
    VALUES (N'ACC003', N'teacher', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'Tran Minh An', N'teacher@ttnn.local', N'0909000003', N'Teacher', N'Active', 0);
END
GO

UPDATE dbo.Accounts
SET Username = LOWER(Username)
WHERE Id IN (N'ACC001', N'ACC002', N'ACC003');
GO

-- Compatibility patch for databases created before Teacher attendance/score flow.
IF COL_LENGTH(N'dbo.Teachers', N'AccountId') IS NULL
BEGIN
    ALTER TABLE dbo.Teachers ADD AccountId nvarchar(20) NULL;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.foreign_keys
    WHERE name = N'FK_Teachers_Accounts_AccountId'
      AND parent_object_id = OBJECT_ID(N'dbo.Teachers')
)
BEGIN
    ALTER TABLE dbo.Teachers WITH CHECK
    ADD CONSTRAINT FK_Teachers_Accounts_AccountId
    FOREIGN KEY (AccountId) REFERENCES dbo.Accounts(Id) ON DELETE SET NULL;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = N'IX_Teachers_AccountId'
      AND object_id = OBJECT_ID(N'dbo.Teachers')
)
BEGIN
    CREATE UNIQUE INDEX IX_Teachers_AccountId
    ON dbo.Teachers(AccountId)
    WHERE AccountId IS NOT NULL AND IsDeleted = 0;
END
GO

IF EXISTS (
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Teachers_Gender'
      AND parent_object_id = OBJECT_ID(N'dbo.Teachers')
)
BEGIN
    ALTER TABLE dbo.Teachers DROP CONSTRAINT CK_Teachers_Gender;
END
GO

ALTER TABLE dbo.Teachers WITH CHECK
ADD CONSTRAINT CK_Teachers_Gender
CHECK (
    Gender IS NULL
    OR LTRIM(RTRIM(Gender)) IN (
        N'Nam', N'Ná»¯', N'Nu',
        N'KhÃ¡c', N'Khac',
        N'Male', N'Female', N'Other'
    )
);
GO

IF OBJECT_ID(N'dbo.Attendances', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Attendances (
        Id nvarchar(20) NOT NULL,
        EnrollmentId nvarchar(20) NOT NULL,
        AttendanceDate datetime2 NOT NULL,
        Status nvarchar(20) NOT NULL,
        Note nvarchar(300) NULL,
        CreatedAt datetime2 NOT NULL CONSTRAINT DF_Attendances_CreatedAt DEFAULT SYSUTCDATETIME(),
        UpdatedAt datetime2 NULL,
        CONSTRAINT PK_Attendances PRIMARY KEY (Id),
        CONSTRAINT FK_Attendances_Enrollments_EnrollmentId
            FOREIGN KEY (EnrollmentId) REFERENCES dbo.Enrollments(Id) ON DELETE NO ACTION,
        CONSTRAINT CK_Attendances_Status
            CHECK (Status IN (N'Present', N'Absent', N'Late', N'Excused'))
    );
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = N'IX_Attendances_EnrollmentId_AttendanceDate'
      AND object_id = OBJECT_ID(N'dbo.Attendances')
)
BEGIN
    CREATE UNIQUE INDEX IX_Attendances_EnrollmentId_AttendanceDate
    ON dbo.Attendances(EnrollmentId, AttendanceDate);
END
GO

IF OBJECT_ID(N'dbo.Scores', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Scores (
        Id nvarchar(20) NOT NULL,
        EnrollmentId nvarchar(20) NOT NULL,
        MidtermScore decimal(4,2) NULL,
        FinalScore decimal(4,2) NULL,
        Note nvarchar(300) NULL,
        CreatedAt datetime2 NOT NULL CONSTRAINT DF_Scores_CreatedAt DEFAULT SYSUTCDATETIME(),
        UpdatedAt datetime2 NULL,
        CONSTRAINT PK_Scores PRIMARY KEY (Id),
        CONSTRAINT FK_Scores_Enrollments_EnrollmentId
            FOREIGN KEY (EnrollmentId) REFERENCES dbo.Enrollments(Id) ON DELETE NO ACTION,
        CONSTRAINT CK_Scores_MidtermScore
            CHECK (MidtermScore IS NULL OR (MidtermScore >= 0 AND MidtermScore <= 10)),
        CONSTRAINT CK_Scores_FinalScore
            CHECK (FinalScore IS NULL OR (FinalScore >= 0 AND FinalScore <= 10))
    );
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = N'IX_Scores_EnrollmentId'
      AND object_id = OBJECT_ID(N'dbo.Scores')
)
BEGIN
    CREATE UNIQUE INDEX IX_Scores_EnrollmentId
    ON dbo.Scores(EnrollmentId);
END
GO

-- Sample master data for Teacher flow.
IF NOT EXISTS (SELECT 1 FROM dbo.Teachers WHERE Id = N'GV001')
BEGIN
    INSERT INTO dbo.Teachers (Id, FullName, Phone, Email, Specialization, Gender, Address, AccountId, Status, IsDeleted)
    VALUES (N'GV001', N'Tran Minh An', N'0909000003', N'teacher@ttnn.local', N'IELTS', N'Nam', N'Da Nang', N'ACC003', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Teachers WHERE Id = N'GV002')
BEGIN
    INSERT INTO dbo.Teachers (Id, FullName, Phone, Email, Specialization, Gender, Address, Status, IsDeleted)
    VALUES (N'GV002', N'Pham Thao Vy', N'0909000004', N'vy@ttnn.local', N'TOEIC', N'Nu', N'Da Nang', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Teachers WHERE Id = N'GV003')
BEGIN
    INSERT INTO dbo.Teachers (Id, FullName, Phone, Email, Specialization, Gender, Address, Status, IsDeleted)
    VALUES (N'GV003', N'Ngo Gia Hung', N'0909000005', N'hung@ttnn.local', N'Tin hoc', N'Nam', N'Da Nang', N'Inactive', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Id = N'KH001')
BEGIN
    INSERT INTO dbo.Courses (Id, Name, Description, TuitionFee, Status, IsDeleted)
    VALUES (N'KH001', N'English Foundation', N'A1 co ban', 2400000, N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Id = N'KH002')
BEGIN
    INSERT INTO dbo.Courses (Id, Name, Description, TuitionFee, Status, IsDeleted)
    VALUES (N'KH002', N'IELTS Intensive', N'Luyen thi IELTS 5.5+', 6500000, N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Id = N'KH003')
BEGIN
    INSERT INTO dbo.Courses (Id, Name, Description, TuitionFee, Status, IsDeleted)
    VALUES (N'KH003', N'TOEIC But Pha', N'TOEIC 500+', 3200000, N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Classes WHERE Id = N'LP001')
BEGIN
    INSERT INTO dbo.Classes (Id, Name, CourseId, TeacherId, StartDate, EndDate, Schedule, Room, MaxStudents, Status, IsDeleted)
    VALUES (N'LP001', N'ENG-A1-01', N'KH001', N'GV001', '2026-01-05', '2026-04-30', N'2-4-6 18:00-19:30', N'P201', 20, N'Open', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Classes WHERE Id = N'LP002')
BEGIN
    INSERT INTO dbo.Classes (Id, Name, CourseId, TeacherId, StartDate, EndDate, Schedule, Room, MaxStudents, Status, IsDeleted)
    VALUES (N'LP002', N'IELTS-24A', N'KH002', N'GV001', '2026-02-10', '2026-06-30', N'3-5-7 18:00-19:30', N'P301', 18, N'Open', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Classes WHERE Id = N'LP003')
BEGIN
    INSERT INTO dbo.Classes (Id, Name, CourseId, TeacherId, StartDate, EndDate, Schedule, Room, MaxStudents, Status, IsDeleted)
    VALUES (N'LP003', N'TOEIC-09B', N'KH003', N'GV002', '2026-03-15', '2026-07-15', N'T7-CN 08:00-10:00', N'P105', 20, N'Open', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Id = N'HV001')
BEGIN
    INSERT INTO dbo.Students (Id, FullName, BirthDate, Phone, Email, Address, Status, IsDeleted)
    VALUES (N'HV001', N'Nguyen Hai Dang', '2010-03-12', N'0909123456', N'dang@example.com', N'Da Nang', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Id = N'HV002')
BEGIN
    INSERT INTO dbo.Students (Id, FullName, BirthDate, Phone, Email, Address, Status, IsDeleted)
    VALUES (N'HV002', N'Le Khanh Vy', '2011-07-03', N'0911222333', N'vy@example.com', N'Da Nang', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Id = N'HV003')
BEGIN
    INSERT INTO dbo.Students (Id, FullName, BirthDate, Phone, Email, Address, Status, IsDeleted)
    VALUES (N'HV003', N'Tran Ngoc Han', '2009-11-24', N'0988777666', N'han@example.com', N'Da Nang', N'Paused', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Id = N'HV004')
BEGIN
    INSERT INTO dbo.Students (Id, FullName, BirthDate, Phone, Email, Address, Status, IsDeleted)
    VALUES (N'HV004', N'Phan Duc Minh', '2012-09-15', N'0977666555', N'minh@example.com', N'Da Nang', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Id = N'HV005')
BEGIN
    INSERT INTO dbo.Students (Id, FullName, BirthDate, Phone, Email, Address, Status, IsDeleted)
    VALUES (N'HV005', N'Vu Gia Bao', '2011-01-22', N'0977222111', N'bao@example.com', N'Da Nang', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Id = N'HV006')
BEGIN
    INSERT INTO dbo.Students (Id, FullName, BirthDate, Phone, Email, Address, Status, IsDeleted)
    VALUES (N'HV006', N'Hoang Gia Bich', '2010-05-18', N'0917111222', N'bich@example.com', N'Da Nang', N'Active', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Enrollments WHERE Id = N'GD001')
BEGIN
    INSERT INTO dbo.Enrollments (Id, StudentId, ClassId, EnrollDate, Status, Note, IsDeleted)
    VALUES (N'GD001', N'HV001', N'LP001', '2026-01-06', N'Active', N'Dot 1', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Enrollments WHERE Id = N'GD002')
BEGIN
    INSERT INTO dbo.Enrollments (Id, StudentId, ClassId, EnrollDate, Status, Note, IsDeleted)
    VALUES (N'GD002', N'HV002', N'LP001', '2026-01-12', N'Active', N'Dong du', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Enrollments WHERE Id = N'GD003')
BEGIN
    INSERT INTO dbo.Enrollments (Id, StudentId, ClassId, EnrollDate, Status, Note, IsDeleted)
    VALUES (N'GD003', N'HV003', N'LP003', '2026-03-18', N'Paused', N'Bao luu 2 tuan', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Enrollments WHERE Id = N'GD004')
BEGIN
    INSERT INTO dbo.Enrollments (Id, StudentId, ClassId, EnrollDate, Status, Note, IsDeleted)
    VALUES (N'GD004', N'HV004', N'LP002', '2026-02-16', N'Active', N'', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Enrollments WHERE Id = N'GD005')
BEGIN
    INSERT INTO dbo.Enrollments (Id, StudentId, ClassId, EnrollDate, Status, Note, IsDeleted)
    VALUES (N'GD005', N'HV005', N'LP002', '2026-02-20', N'Active', N'', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Enrollments WHERE Id = N'GD006')
BEGIN
    INSERT INTO dbo.Enrollments (Id, StudentId, ClassId, EnrollDate, Status, Note, IsDeleted)
    VALUES (N'GD006', N'HV006', N'LP003', '2026-04-01', N'Active', N'', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Receipts WHERE Id = N'PT001')
BEGIN
    INSERT INTO dbo.Receipts (Id, EnrollmentId, AmountPaid, PayDate, PaymentMethod, Note, CreatedByStaffId, IsDeleted)
    VALUES (N'PT001', N'GD001', 1500000, '2026-01-06', N'Cash', N'Dot 1', N'ACC002', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Receipts WHERE Id = N'PT002')
BEGIN
    INSERT INTO dbo.Receipts (Id, EnrollmentId, AmountPaid, PayDate, PaymentMethod, Note, CreatedByStaffId, IsDeleted)
    VALUES (N'PT002', N'GD002', 2400000, '2026-01-12', N'BankTransfer', N'Dong du', N'ACC002', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Receipts WHERE Id = N'PT003')
BEGIN
    INSERT INTO dbo.Receipts (Id, EnrollmentId, AmountPaid, PayDate, PaymentMethod, Note, CreatedByStaffId, IsDeleted)
    VALUES (N'PT003', N'GD003', 800000, '2026-03-18', N'Cash', N'Dot 1', N'ACC002', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Receipts WHERE Id = N'PT004')
BEGIN
    INSERT INTO dbo.Receipts (Id, EnrollmentId, AmountPaid, PayDate, PaymentMethod, Note, CreatedByStaffId, IsDeleted)
    VALUES (N'PT004', N'GD004', 5000000, '2026-02-16', N'BankTransfer', N'Dot 1', N'ACC002', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Receipts WHERE Id = N'PT005')
BEGIN
    INSERT INTO dbo.Receipts (Id, EnrollmentId, AmountPaid, PayDate, PaymentMethod, Note, CreatedByStaffId, IsDeleted)
    VALUES (N'PT005', N'GD005', 6500000, '2026-02-20', N'Cash', N'Dong du', N'ACC002', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Receipts WHERE Id = N'PT006')
BEGIN
    INSERT INTO dbo.Receipts (Id, EnrollmentId, AmountPaid, PayDate, PaymentMethod, Note, CreatedByStaffId, IsDeleted)
    VALUES (N'PT006', N'GD006', 2000000, '2026-04-01', N'BankTransfer', N'Dot 1', N'ACC002', 0);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Attendances WHERE Id = N'DD001')
BEGIN
    INSERT INTO dbo.Attendances (Id, EnrollmentId, AttendanceDate, Status, Note)
    VALUES (N'DD001', N'GD001', '2026-04-20', N'Present', N'');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Attendances WHERE Id = N'DD002')
BEGIN
    INSERT INTO dbo.Attendances (Id, EnrollmentId, AttendanceDate, Status, Note)
    VALUES (N'DD002', N'GD002', '2026-04-20', N'Late', N'Tre 10 phut');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Attendances WHERE Id = N'DD003')
BEGIN
    INSERT INTO dbo.Attendances (Id, EnrollmentId, AttendanceDate, Status, Note)
    VALUES (N'DD003', N'GD004', '2026-04-21', N'Present', N'');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Scores WHERE Id = N'DS001')
BEGIN
    INSERT INTO dbo.Scores (Id, EnrollmentId, MidtermScore, FinalScore, Note)
    VALUES (N'DS001', N'GD001', 8.5, 9.0, N'');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Scores WHERE Id = N'DS002')
BEGIN
    INSERT INTO dbo.Scores (Id, EnrollmentId, MidtermScore, FinalScore, Note)
    VALUES (N'DS002', N'GD002', 7.0, 8.0, N'');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Scores WHERE Id = N'DS003')
BEGIN
    INSERT INTO dbo.Scores (Id, EnrollmentId, MidtermScore, FinalScore, Note)
    VALUES (N'DS003', N'GD004', 8.0, 8.5, N'');
END
GO

UPDATE T
SET AccountId = A.Id
FROM dbo.Teachers T
JOIN dbo.Accounts A
  ON A.Role = N'Teacher'
 AND A.IsDeleted = 0
 AND T.IsDeleted = 0
 AND (
        T.AccountId = A.Id
     OR T.Email = A.Email
     OR T.Phone = A.Phone
     OR T.FullName = A.DisplayName
 )
WHERE T.AccountId IS NULL;
GO
