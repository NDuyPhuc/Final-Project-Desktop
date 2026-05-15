# Giai thich tung dong: domain, enum, DbContext, repository account

File nay giai thich nhom code mo hinh du lieu. Day la lop quy dinh du lieu nao ton tai, bang nao duoc tao, quan he nao duoc rang buoc, va repository account truy cap bang `Accounts` ra sao.

## 1. `TrungTamNgoaiNgu.Domain/Enums/AccountRole.cs`

| Dong | Giai thich |
| --- | --- |
| 1 | Mo namespace enum trong domain. |
| 3-7 | Khai bao enum `AccountRole` voi 3 role he thong: `Admin`, `Staff`, `Teacher`. Vi dung enum nen trong code switch role an toan hon string. |

## 2. `TrungTamNgoaiNgu.Domain/Enums/AccountStatus.cs`

| Dong | Giai thich |
| --- | --- |
| 1 | Mo namespace enum trong domain. |
| 3-8 | Khai bao enum `AccountStatus` gom `Active`, `Inactive`, `Locked`. Role va status duoc tach rieng vi mot account co role co dinh nhung status co the bat/tat/khoa. |

## 3. Nhom entity domain

Nhom file nay rat gon, nen toi giai thich theo tung property chinh thay vi nhac lai tung dong `{`, `}`, namespace.

### 3.1 `AccountEntity.cs`

| Dong / property | Giai thich |
| --- | --- |
| `Id` | Ma tai khoan theo quy uoc `ACCxxx`, khong dung auto increment. |
| `Username` | Ten dang nhap duy nhat de auth. |
| `PasswordHash` | Chuoi hash SHA256 cua mat khau. |
| `DisplayName` | Ten hien thi trong dashboard, bien lai, account card. |
| `Email` | Email account, cung duoc unique index trong DB. |
| `Phone` | So dien thoai account, cung duoc unique index. |
| `Role` | Enum role: `Admin`, `Staff`, `Teacher`. |
| `Status` | Enum status: cho phep khoa account ma khong xoa. |
| `IsDeleted` | Co che xoa mem. |
| `CreatedAt` / `UpdatedAt` | Moc audit thoi gian. |
| `TeacherProfile` | Navigation 1-1 optional sang `TeacherEntity`; dung khi account nay la giao vien. |
| `CreatedReceipts` | Navigation 1-n sang cac `ReceiptEntity` ma account staff nay da tao. |

### 3.2 `StudentEntity.cs`

| Property | Giai thich |
| --- | --- |
| `Id` | Ma hoc vien `HVxxx`. |
| `FullName` | Ten day du hoc vien. |
| `BirthDate` | Ngay sinh, duoc dashboard/service co the dung de hien thong tin. |
| `Phone` | SDT hoc vien, unique khi chua xoa. |
| `Email` | Email co the null trong domain, du UI hien tai bat buoc. |
| `Address` | Dia chi hoc vien. |
| `AvatarPath` | Duong dan tuong doi toi avatar trong `Images/Students`. |
| `Status` | String trang thai hoc vien, vi du `Active`, `Paused`, `Completed`. |
| `Enrollments` | Danh sach cac lan ghi danh cua hoc vien. |

### 3.3 `TeacherEntity.cs`

| Property | Giai thich |
| --- | --- |
| `Id` | Ma giao vien `GVxxx`. |
| `FullName` / `Phone` / `Email` | Thong tin lien he chinh. |
| `Specialization` | Chuyen mon: IELTS, TOEIC... |
| `Gender` | Gioi tinh, UI co the hien thi. |
| `Address` | Dia chi giao vien. |
| `AvatarPath` | Duong dan anh giao vien. |
| `AccountId` | FK optional sang account login. Rat quan trong cho teacher dashboard. |
| `Status` | String trang thai giang day. |
| `Account` | Navigation nguoc ve account. |
| `Classes` | Danh sach lop giao vien phu trach. |

### 3.4 `CourseEntity.cs`

| Property | Giai thich |
| --- | --- |
| `Id` | Ma khoa hoc `KHxxx`. |
| `Name` | Ten khoa hoc. |
| `Description` | Mo ta khoa hoc; UI hien dang nhung ca level vao day. |
| `TuitionFee` | Hoc phi goc cua khoa hoc. |
| `Status` | Trang thai khoa hoc. |
| `Classes` | Danh sach lop mo tu khoa hoc nay. |

### 3.5 `ClassEntity.cs`

| Property | Giai thich |
| --- | --- |
| `Id` | Ma lop `LPxxx`. |
| `Name` | Ten lop. |
| `CourseId` | FK toi khoa hoc. |
| `TeacherId` | FK toi giao vien. |
| `StartDate` / `EndDate` | Khoang thoi gian lop hoc. |
| `Schedule` | Chuoi lich hoc, service se parse ra danh sach session. |
| `Room` | Phong hoc. |
| `MaxStudents` | Si so toi da. |
| `Status` | Trang thai lop trong DB. |
| `Course` / `Teacher` | Navigation toi khoa hoc va giao vien. |
| `Enrollments` | Toan bo ghi danh cua lop. |

### 3.6 `EnrollmentEntity.cs`

| Property | Giai thich |
| --- | --- |
| `Id` | Ma ghi danh `GDxxx`. |
| `StudentId` | Hoc vien nao duoc ghi danh. |
| `ClassId` | Lop nao duoc ghi danh vao. |
| `EnrollDate` | Ngay ghi danh. |
| `Status` | Trang thai ghi danh. |
| `Note` | Ghi chu nghiep vu. |
| `Student` / `Class` | Navigation sang 2 dau lien quan. |
| `Receipts` | Nhieu dot dong hoc phi. |
| `Attendances` | Nhieu buoi diem danh. |
| `Score` | Toi da 1 bang diem tong hop. |

### 3.7 `ReceiptEntity.cs`

| Property | Giai thich |
| --- | --- |
| `Id` | Ma bien lai `PTxxx`. |
| `EnrollmentId` | Bien lai thuoc ve ghi danh nao. |
| `AmountPaid` | So tien thu dot nay. |
| `PayDate` | Ngay nop tien. |
| `PaymentMethod` | Cash / BankTransfer / Card... |
| `Note` | Ghi chu dot thu. |
| `CreatedByStaffId` | Staff nao tao bien lai. |
| `Enrollment` / `CreatedByStaff` | Navigation den ghi danh va account staff. |

### 3.8 `AttendanceEntity.cs`

| Property | Giai thich |
| --- | --- |
| `Id` | Ma diem danh `DDxxx`. |
| `EnrollmentId` | Ghi danh nao duoc diem danh. |
| `AttendanceDate` | Buoi hoc ngay nao. |
| `Status` | `Present`, `Absent`, `Late`... |
| `Note` | Ghi chu diem danh. |
| `Enrollment` | Navigation nguoc ve ghi danh. |

### 3.9 `ScoreEntity.cs`

| Property | Giai thich |
| --- | --- |
| `Id` | Ma diem `DSxxx`. |
| `EnrollmentId` | Ghi danh nao co bang diem nay. |
| `MidtermScore` | Diem giua ky. |
| `FinalScore` | Diem cuoi ky. |
| `Note` | Ghi chu diem. |
| `Enrollment` | Navigation nguoc. |

## 4. `TrungTamNgoaiNgu.Application/Data/LanguageCenterDbContext.cs`

### Dung file nay de lam gi

File nay la ban do giua entity C# va bang SQL Server. Neu entity la "mo hinh logic", thi `DbContext` la "luat map xuong DB that".

### Giai thich sat line number

| Dong | Giai thich |
| --- | --- |
| 1 | Import EF Core. |
| 2 | Import toan bo entity domain de map. |
| 4-6 | Namespace data va class `LanguageCenterDbContext` dung primary-constructor syntax cua C# moi: nhan `DbContextOptions` ngay tai dau class va truyen len `DbContext`. |
| 8-16 | Moi dong khai bao mot `DbSet<T>`, tuc la mot tap ban ghi/bang ma service se query. |
| 18-19 | Override `OnModelCreating()` de custom schema thay vi chi phu thuoc convention. |
| 20-38 | Block map `AccountEntity`: ten bang `Accounts`, khoa chinh `Id`, gioi han do dai chuoi, convert enum `Role`/`Status` sang string, default `IsDeleted=false`, default `CreatedAt=SYSUTCDATETIME()`, va unique index cho `Username`/`Email`/`Phone` chi ap dung cho ban ghi chua xoa mem. |
| 40-52 | Block map `CourseEntity`: ten bang `Courses`, `TuitionFee` la `decimal(18,2)`, co audit columns, va status la string. |
| 54-78 | Block map `TeacherEntity`: dat max length cho tung field, unique index cho `Email`, `Phone`, `AccountId`; dong 74-77 tao quan he 1-1 optional voi `AccountEntity`, khi account bi xoa thi `AccountId` cua teacher duoc set null. |
| 80-106 | Block map `ClassEntity`: map FK `CourseId`, `TeacherId`, datetime columns, lich hoc/phong hoc, index tren 2 FK, va 2 quan he `HasOne().WithMany()` den `Course` va `Teacher`, deu `Restrict` khi xoa. |
| 108-125 | Block map `StudentEntity`: field co do dai, email co unique index nhung co filter `IS NOT NULL`, phone unique neu chua xoa. |
| 127-151 | Block map `EnrollmentEntity`: day la block rat quan trong. Dong 142 tao unique composite index `(StudentId, ClassId)` tren record chua xoa mem, nghia la 1 hoc vien khong duoc ghi danh trung cung lop. Dong 143-150 map 2 FK den `Student` va `Class`, deu `Restrict`. |
| 153-177 | Block map `ReceiptEntity`: amount la `decimal(18,2)`, co index tren `CreatedByStaffId` va `EnrollmentId`, map FK den `Enrollment` va `AccountEntity` (staff tao bien lai). |
| 179-195 | Block map `AttendanceEntity`: unique index `(EnrollmentId, AttendanceDate)` bao ve moi hoc vien chi co 1 dong diem danh cho 1 buoi. |
| 197-213 | Block map `ScoreEntity`: unique `EnrollmentId` va quan he 1-1 voi `EnrollmentEntity`, nghia la moi ghi danh co toi da 1 bang diem tong hop. |
| 214-215 | Dong block method va dong class. |

### 3 y nghia lon cua `DbContext`

1. Kiem soat duoc rang buoc data ngay tai lop EF Core, khong chi trong code UI.
2. Giup service query co navigation ro rang (`Include`, `ThenInclude`) vi quan he da duoc map day du.
3. Dong bo voi nghiep vu xoa mem va unique index co filter.

## 5. `TrungTamNgoaiNgu.Application/Repositories/SqlAccountRepository.cs`

### Dung file nay de lam gi

Tach phan persistence cua account khoi service tong.

### Giai thich theo line/chuc nang

| Phan | Giai thich |
| --- | --- |
| Constructor primary (dong dau class) | Nhan `DbContextOptions<LanguageCenterDbContext>` tu ben ngoai, de repository tao context moi khi can. |
| `CanConnect()` | Tao context tam, goi `Database.CanConnect()` de kiem tra SQL co len khong. |
| `FindActiveByUsername()` | Trim + lowercase username dau vao, roi tim account khong xoa mem, status `Active`, username khop. Dung `AsNoTracking()` vi chi doc. |
| `GetNextId()` | Lay toan bo ID account, goi helper `GetNextCode(..., "ACC")`. |
| `GetAccounts()` | Tra danh sach account chua xoa, order theo role roi display name. |
| `Save()` | Neu chua ton tai thi tao moi `AccountEntity`, gan field da trim, va add vao context. Neu da ton tai thi update field, chi doi password neu `account.PasswordHash` khong rong. |
| `ToggleStatus()` | Tim account chua xoa, roi dao `Active <-> Locked`. |
| `ResetPassword()` | Tim account chua xoa va ghi de `PasswordHash`. |
| `CreateContext()` | Gom 1 dong de tao `LanguageCenterDbContext` moi. |
| `GetNextCode()` | Tach so tu suffix cua ID, tim max, cong 1, format ve `ACC000`. |

### Tai sao chi account co repository rieng?

Vi account co auth, password, status, role. Day la bang nhay cam nhat, nen duoc tach rieng ra khoi service tong de structure code ro hon.

## 6. Cach doc tiep 3 file service

Sau file nay, 3 file tiep theo se giai thich `SqlLanguageCenterDataService.cs`:

- phan 1: constructor, auth, account, list, dashboard read-only
- phan 2: stats, CRUD, enrollment, receipt, attendance, score
- phan 3: seed, report builders, helper methods, soft-delete generic
