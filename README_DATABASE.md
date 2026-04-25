# Database Guide

## Canonical SQL script

- Script path:
  [docs/database-script.sql](/D:/Trung-tam-quan-ly-ngoai-ngu/docs/database-script.sql)
- Database name:
  `EnglishCenterDB`

The script now safely includes database creation/use statements before table creation.

## Connection string location

- Default runtime config:
  [appsettings.json](/D:/Trung-tam-quan-ly-ngoai-ngu/Trung-tam-quan-ly-ngoai-ngu/appsettings.json)
- Loader:
  [LanguageCenterDatabaseConfiguration.cs](/D:/Trung-tam-quan-ly-ngoai-ngu/TrungTamNgoaiNgu.Application/Configuration/LanguageCenterDatabaseConfiguration.cs)

Supported environment-variable overrides:

- `TTNN_SQL_CONNECTION_STRING`
- `TTNN_SQL_PASSWORD`

Do not hard-code database credentials inside forms.
`CommandTimeoutSeconds = 0` means the app does not override EF Core's SQL command timeout; use a positive value only when the team wants a fixed timeout.

## How to run the script

1. Open SQL Server Management Studio.
2. Connect to the target SQL Server instance.
3. Open `docs/database-script.sql`.
4. Execute the whole script.
5. Confirm `EnglishCenterDB` and all core tables were created.

If the database does not already exist, the script creates it before running `USE [EnglishCenterDB]`.

## Main table mapping

- `Accounts` -> `AccountEntity` -> `SqlAccountRepository` / `SqlLanguageCenterDataService`
- `Students` -> `StudentEntity` -> `SqlLanguageCenterDataService`
- `Teachers` -> `TeacherEntity` -> `SqlLanguageCenterDataService`
- `Courses` -> `CourseEntity` -> `SqlLanguageCenterDataService`
- `Classes` -> `ClassEntity` -> `SqlLanguageCenterDataService`
- `Enrollments` -> `EnrollmentEntity` -> `SqlLanguageCenterDataService`
- `Attendances` -> `AttendanceEntity` -> `SqlLanguageCenterDataService`
- `Receipts` -> `ReceiptEntity` -> `SqlLanguageCenterDataService`
- `Scores` -> `ScoreEntity` -> `SqlLanguageCenterDataService`

## Notes

- The application stores canonical database values such as `Active`, `Open`, `Cash`, and `BankTransfer`.
- The service layer is responsible for mapping UI display values such as `Dang hoc`, `Dang mo`, `Tien mat`, and `Chuyen khoan`.
- `PasswordHash` in SQL must stay hashed. Do not switch back to plain-text password storage.
