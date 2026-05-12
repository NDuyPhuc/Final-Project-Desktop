# Final-Project-Desktop

Ung dung quan ly trung tam ngoai ngu viet bang WinForms tren `.NET 8`.

## Cau truc project

- `Trung-tam-quan-ly-ngoai-ngu`: giao dien WinForms
- `TrungTamNgoaiNgu.Application`: service, repository, EF Core SQL Server
- `TrungTamNgoaiNgu.Domain`: entity, enum, model dung chung

## Yeu cau moi truong

- Windows 10 hoac Windows 11
- Visual Studio 2022
- Workload `Desktop development with .NET`
- `.NET 8 SDK`
- SQL Server 2019/2022 hoac SQL Server Express
- SQL Server Management Studio (SSMS)

Kiem tra SDK:

```powershell
dotnet --version
```

## Clone va mo solution

```powershell
git clone <repo-url>
cd Final-Project-Desktop
```

Mo file:

```text
Trung-tam-quan-ly-ngoai-ngu.sln
```

## NuGet packages dang dung

Project UI hien dang dung:

- `ClosedXML` `0.104.2`
- `PdfSharp` `1.51.5185`
- `WinForms.DataVisualization` `1.10.0`

Project Application dang dung:

- `Microsoft.EntityFrameworkCore.SqlServer` `8.0.17`

Restore package:

```powershell
dotnet restore
```

Hoac trong Visual Studio:

1. Right click solution
2. Chon `Restore NuGet Packages`

## Setup database

Script SQL nam tai:

- `docs/database-script.sql`

Lam theo cac buoc:

1. Mo SSMS
2. Ket noi vao SQL Server local hoac server duoc nhom cung cap
3. Mo file `docs/database-script.sql`
4. Run toan bo script
5. Kiem tra database `EnglishCenterDB` da duoc tao

Script nay da seed san 3 tai khoan:

- `Admin / 123456`
- `Staff / 123456`
- `Teacher / 123456`

## Cau hinh ket noi database

File cau hinh mac dinh:

- `Trung-tam-quan-ly-ngoai-ngu/appsettings.json`

Vi du:

```json
{
  "Database": {
    "ConnectionString": "Server=localhost;Database=EnglishCenterDB;User Id=sa;Password=your_password;TrustServerCertificate=True;",
    "CommandTimeoutSeconds": 0
  }
}
```

Project ho tro 2 bien moi truong:

- `TTNN_SQL_CONNECTION_STRING`
- `TTNN_SQL_PASSWORD`

Vi du PowerShell:

```powershell
$env:TTNN_SQL_CONNECTION_STRING="Server=localhost;Database=EnglishCenterDB;User Id=sa;TrustServerCertificate=True;"
$env:TTNN_SQL_PASSWORD="your_password"
```

Khuyen nghi:

- Khong commit password that len Git
- Neu co the, dung env var thay vi de password truc tiep trong file

## Chay du an

### Cach 1: Visual Studio

1. Set startup project la `Trung-tam-quan-ly-ngoai-ngu`
2. Nhan `F5` hoac `Ctrl + F5`

### Cach 2: Terminal

```powershell
dotnet build .\Trung-tam-quan-ly-ngoai-ngu\Trung-tam-quan-ly-ngoai-ngu.csproj
dotnet run --project .\Trung-tam-quan-ly-ngoai-ngu\Trung-tam-quan-ly-ngoai-ngu.csproj
```

## Neu SQL Server loi

Ung dung co fallback offline demo.

Neu khoi tao SQL that bai, app se chuyen sang che do offline demo de tiep tuc test giao dien.

Tai khoan demo offline:

- `admin / 123456`
- `staff / 123456`
- `teacher / 123456`

## Loi thuong gap

### 1. Build fail do chua restore package

```powershell
dotnet restore
dotnet build
```

### 2. Khong ket noi duoc SQL

Kiem tra lai:

- SQL Server da bat chua
- Connection string dung chua
- User/password dung chua
- Da run `docs/database-script.sql` chua

### 3. App chay vao offline demo

Nguyen nhan thuong la:

- Sai connection string
- SQL Server chua mo
- Tai khoan SQL khong dung

## Checklist setup nhanh

1. Cai Visual Studio 2022 + workload `.NET Desktop`
2. Cai `.NET 8 SDK`
3. Clone repo
4. Chay `dotnet restore`
5. Run `docs/database-script.sql`
6. Sua `appsettings.json` hoac dat env var
7. Mo solution
8. Chay project UI
