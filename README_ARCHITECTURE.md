# Architecture Guide

## Layering rule

Use this direction for all new code:

`Forms / Views -> Services -> Repositories -> Data / Database`

`Models / Entities` live in the domain layer and are shared by service/repository code.

## Current project structure

- UI layer:
  [Forms](/D:/Trung-tam-quan-ly-ngoai-ngu/Trung-tam-quan-ly-ngoai-ngu/Forms)
- Service layer:
  [SqlLanguageCenterDataService.cs](/D:/Trung-tam-quan-ly-ngoai-ngu/TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs)
- Repository layer:
  [IAccountRepository.cs](/D:/Trung-tam-quan-ly-ngoai-ngu/TrungTamNgoaiNgu.Application/Repositories/IAccountRepository.cs)
  [SqlAccountRepository.cs](/D:/Trung-tam-quan-ly-ngoai-ngu/TrungTamNgoaiNgu.Application/Repositories/SqlAccountRepository.cs)
- Data access:
  [LanguageCenterDbContext.cs](/D:/Trung-tam-quan-ly-ngoai-ngu/TrungTamNgoaiNgu.Application/Data/LanguageCenterDbContext.cs)
- Domain entities:
  [Entities](/D:/Trung-tam-quan-ly-ngoai-ngu/TrungTamNgoaiNgu.Domain/Entities)

## Rules

- A Form may read user input, call service methods, bind tables, and show `MessageBox`.
- A Form must not open `SqlConnection`, `DbContext`, or execute SQL directly.
- Services must not reference `System.Windows.Forms`.
- Repositories must not reference `System.Windows.Forms`.
- Repositories own persistence details, EF queries, and database-side lookups.
- Services own validation, normalization, business rules, and UI-facing status mapping.

## Add a new screen / entity

1. Add or update the domain entity in `TrungTamNgoaiNgu.Domain`.
2. Add repository methods for CRUD/search in `TrungTamNgoaiNgu.Application/Repositories`.
3. Add service methods that validate input and translate UI values to canonical database values.
4. Call the service from the Form and bind the returned model/table.
5. Build the solution before moving to the next form.

## Merge checklist

1. No Form talks to the database directly.
2. No repository or service references WinForms.
3. Status/payment values are normalized before saving to SQL.
4. Connection string stays in centralized config.
5. Solution builds successfully after each change group.
6. Edited forms still open in Visual Studio Designer.
