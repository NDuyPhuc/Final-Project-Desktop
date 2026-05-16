USE [EnglishCenterDB];
GO

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
        N'Nam', N'Nữ', N'Nu',
        N'Khác', N'Khac',
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

SELECT
    A.Id AS AccountId,
    A.Username,
    A.DisplayName,
    A.Email,
    A.Phone,
    T.Id AS TeacherId,
    T.FullName AS TeacherName,
    T.AccountId AS TeacherAccountId
FROM dbo.Accounts A
LEFT JOIN dbo.Teachers T
  ON T.AccountId = A.Id
  OR T.Email = A.Email
  OR T.Phone = A.Phone
WHERE A.Role = N'Teacher'
  AND A.IsDeleted = 0
ORDER BY A.Id, T.Id;
GO
