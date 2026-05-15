# Application layer va nghiep vu

Day la lop quan trong nhat cua du an. UI chi hien thi va nhan click; DB chi luu data; con `Application` moi quyet dinh:

- validate gi
- normalize gi
- thong ke gi
- cho phep thao tac gi
- tra ve `DataTable` nao de grid bind duoc

## 1. `ILanguageCenterDataService` la facade trung tam

File: `TrungTamNgoaiNgu.Application/Contracts/ILanguageCenterDataService.cs`

Interface nay gom gan nhu toan bo use case cua he thong:

- auth
- CRUD account
- CRUD student/teacher/course/class
- dashboard stats
- report points
- enrollment
- receipt
- attendance
- score
- avatar
- export DB script

Y nghia:

- Form khong can biet repo nao, `DbContext` nao, hay query nao.
- Moi man hinh chi can nho mot dependency: `AppRuntime.DataService`.

## 2. `SqlLanguageCenterDataService` tao ket noi SQL nhu the nao

Constructor:

1. Goi `LanguageCenterDatabaseConfiguration.Load()`
2. Lay connection string tu:
   - env `TTNN_SQL_CONNECTION_STRING`
   - hoac `appsettings.json`
3. Neu co `TTNN_SQL_PASSWORD` va connection string chua co password thi noi them vao.
4. Tao `DbContextOptions<LanguageCenterDbContext>`
5. Bat `EnableRetryOnFailure()`
6. Dat `CommandTimeout` neu co
7. Tao `_accountRepository = new SqlAccountRepository(_options)`

Y nghia:

- Connection string duoc tap trung hoa.
- SQL retry da duoc bat san cho loi tam thoi.
- Repository account tach rieng khoi service tong.

## 3. Khoi tao va auth

### 3.1 `EnsureDatabaseReady()`

Cong viec:

1. Goi `_accountRepository.CanConnect()`
2. Neu khong ket noi duoc -> throw
3. Tao context
4. Neu DB rong hoan toan -> `SeedData(context)`

No duoc goi duy nhat tu `AppRuntime.Initialize()`.

### 3.2 `Authenticate(username, password)`

Luong chay:

1. Repository tim tai khoan active, khong bi soft-delete, theo username lower-case.
2. `PasswordHasher.Verify()` hash lai plain password bang SHA256.
3. So sanh voi `PasswordHash` dang luu.
4. Dung thi tra `AccountEntity`, sai thi `null`.

`PasswordHasher` rat don gian:

- `Hash()` = SHA256 -> hex string
- `Verify()` = hash plain text -> so sanh case-insensitive

Luu y:

- Day la hash mot chieu, nhung chua co salt.
- Day du de demo do an desktop, nhung chua phai muc bao mat cao.

## 4. Repository account lam gi, service account lam gi

### `SqlAccountRepository`

Lam viec muc do data:

- `CanConnect()`
- `FindActiveByUsername()`
- `GetNextId()`
- `GetAccounts()`
- `Save()`
- `ToggleStatus()`
- `ResetPassword()`

### `SqlLanguageCenterDataService`

Them rule nghiep vu:

- `SaveAccount()` neu chua co password thi auto set `123456`
- `ResetAccountPassword()` bat buoc password moi khong duoc rong
- Log loi tap trung

Y nghia:

- Repository giong lop persistence.
- Service giong lop use case.

## 5. Nhom method "list + table" de phuc vu UI

Rat nhieu method trong service co chung mau:

1. Tao `context`
2. Query entity
3. `AsNoTracking()`
4. `Include(...)` neu can
5. Loc theo `keyword`, `status`, `date`, `course`, `class`
6. Convert thanh `DataTable`
7. Format date/money/display text

### Vi sao tra `DataTable`?

- `DataGridView` bind thang.
- Khong can custom model rieng cho tung form.
- Dung duoc cho export Excel/PDF.

### Vi sao van co `GetXxxById()`?

`DataTable` chi du cho grid. Khi can full detail de do vao editor, form goi:

- `GetStudentById()`
- `GetTeacherById()`
- `GetCourseById()`
- `GetClassById()`
- `GetEnrollmentById()`
- `GetReceiptById()`

## 6. CRUD va validation cho 4 entity chinh

### 6.1 `SaveStudent()`

Buoc:

1. `ValidateStudent()`:
   - bat buoc `FullName`
   - bat buoc `Phone`
2. Normalize `Status`
3. Tim entity theo `Id`
4. Neu chua co:
   - tao ID `HVxxx`
   - trim field
   - `IsDeleted = false`
5. Neu da co:
   - update field
6. `SaveChanges()`
7. Doi status ve display truoc khi tra ve

### 6.2 `SaveTeacher()`

Validate:

- `FullName`
- `Phone`
- `Email`

Ngoai ra no luu ca:

- `Specialization`
- `Gender`
- `Address`
- `AvatarPath`
- `AccountId`

### 6.3 `SaveCourse()`

Validate:

- `Name` khong rong
- `TuitionFee >= 0`

`Description` duoc dung linh hoat. UI `FrmCourseManagement` dang gop:

- `Level`
- `Description`

vao cung 1 chuoi theo mau:

- `A1 | Mo ta khoa hoc`

### 6.4 `SaveClass()`

Validate:

- `Name` khong rong
- `StartDate <= EndDate`
- `MaxStudents > 0`

Ngoai ra service con:

- `ResolveCourseId(context, rawValue)`
- `ResolveTeacherId(context, rawValue)`

Tuc la form co the dua vao:

- ma khoa / ten khoa
- ma GV / ten GV

service se tim ID that su truoc khi luu.

## 7. Ghi danh (`CreateEnrollment`) la flow nghiep vu trung tam

Ham: `CreateEnrollment(studentId, classId, enrollDate, status, note)`

Buoc chinh:

1. Tim hoc vien ton tai va chua bi xoa.
2. Tim lop ton tai, include `Enrollments`.
3. Kiem tra trung ghi danh bang `StudentAlreadyEnrolled()`.
4. Kiem tra con cho bang `ClassHasAvailableSlot()`.
5. Normalize trang thai ghi danh.
6. Tao `EnrollmentEntity` ID `GDxxx`.
7. Cap nhat `student.Status = normalizedStatus`.
8. `context.Enrollments.Add(enrollment)`
9. `SaveChanges()`

### `StudentAlreadyEnrolled()`

No khong chi check ton tai dong ghi danh, ma con chi dem nhung trang thai "con tinh la active":

- `Active`
- `Paused`

Ham helper:

- `IsEnrollmentCountedAsActive()` tra `true` cho `Active` va `Paused`

Y nghia:

- Hoc vien da bao luu van duoc xem la con gan voi lop, chua duoc ghi danh trung vao cung lop.

### `ClassHasAvailableSlot()`

No dua vao:

- trang thai lop sau normalize
- si so active hien tai
- `MaxStudents`

Chi khi lop `Open` hoac `InProgress` va chua day thi moi nhan ghi danh moi.

### Nuance rat quan trong

`FrmEnrollment` co o `discount` va `final fee`, nhung:

- discount KHONG duoc luu thanh field rieng trong DB
- no chi duoc ghep vao `note`
- `SaveReceipt()` van doi chieu voi `Course.TuitionFee` goc

Nghia la:

- "hoc phi tam tinh" tren UI hien tai la muc tham khao/ghi chu
- nghiep vu giam gia chua duoc model hoa day du trong DB

Day la diem rat nen noi ro khi giai thich code.

## 8. Thu hoc phi va bien lai

### 8.1 `GetEnrollmentReceiptContext()`

Muc dich:

- Lay thong tin tong hop de man `FrmTuitionReceipt` do len editor

No load:

- enrollment
- student
- class
- course
- receipts hien co

No tinh:

- `TuitionFee`
- `TotalPaid`
- `OutstandingBalance = max(0, tuition - paid)`

### 8.2 `GetLatestEnrollmentReceiptContextByStudentId()`

Dung khi nguoi dung nhap ma hoc vien thay vi di tu man ghi danh.

No:

- tim enrollment moi nhat cua hoc vien
- tinh lai context tu enrollment do

### 8.3 `SaveReceipt()`

Buoc:

1. Bat buoc `amountPaid > 0`
2. Normalize payment method
3. Tim enrollment va include class/course/student
4. Tinh `tuitionFee`
5. Tinh tong da thu, tru bien lai hien tai neu dang edit
6. Neu `paidExcludingCurrent + amountPaid > tuitionFee` -> throw
7. Neu receipt moi:
   - tao ID `PTxxx`
   - set `CreatedByStaffId`
8. Neu receipt cu:
   - update so tien, ngay, payment method, note
9. `SaveChanges()`
10. Doi `PaymentMethod` sang display text de tra ve form

Y nghia:

- Nghiep vu chong thu vuot hoc phi duoc enforce o service.
- Nguoi thu duoc gan bang `AppRuntime.CurrentUser?.Id`.

### 8.4 `GetReceiptPrintInfo()`

Day la ham phuc vu in/xem bien lai.

No tra ve object tong hop:

- thong tin hoc vien
- thong tin lop / khoa hoc
- hoc phi
- so tien dot nay
- tong da thu
- con lai
- ngay nop
- phuong thuc
- ten staff thu

Form `FrmTuitionReceipt` chi viec lay object nay roi ve lai bang `Graphics`.

## 9. Diem danh

### 9.1 `GetSessions(classId)`

Service khong co bang "Session" rieng trong DB. Thay vao do, no sinh lich hoc tu:

- `Class.StartDate`
- `Class.EndDate`
- `Class.Schedule`

`ParseScheduleDays()` doc cac token nhu:

- `2`, `3`, `4`, `5`, `6`, `7`
- `cn`
- `t2`, `t3`, ...
- mot vai token tieng Anh nhu `mon`, `wed`, `fri`

Sau do service:

1. Duyet tung ngay tu start -> end
2. Chon nhung ngay co `DayOfWeek` khop
3. Tao bang session voi:
   - `Buoi`
   - `Ngay hoc`
   - `Khung gio`
   - `Phong`
   - `Trang thai` (`Da hoc`, `Hom nay`, `Sap dien ra`)

Y nghia:

- App khong luu session that su.
- Session la du lieu suy dien tu `Class.Schedule`.

### 9.2 `GetAttendanceList(classId, attendanceDate)`

No chi load:

- enrollment active cua lop
- attendance cua ngay duoc chon

Tra bang co cot:

- `EnrollmentId`
- `Ma hoc vien`
- `Ho ten`
- `Co mat`
- `Trang thai`
- `Ghi chu`

### 9.3 `SaveAttendance()`

Buoc:

1. Tim `activeEnrollmentIds` cua lop
2. Duyet danh sach item tu form dua vao
3. Bo qua item khong thuoc enrollment active
4. Tim attendance theo `(EnrollmentId, Date)`
5. Neu chua co -> tao moi `DDxxx`
6. Neu da co -> update `Status`, `Note`
7. `SaveChanges()`

Y nghia:

- Attendance duoc upsert.
- Hoc vien khong active se khong bi ghi attendance.

## 10. Nhap diem

### 10.1 `GetScoreList(classId)`

No load:

- enrollment active cua lop
- score row neu da co

Tra bang:

- `EnrollmentId`
- `Ma hoc vien`
- `Ho ten`
- `Diem giua ky`
- `Diem cuoi ky`
- `Ghi chu`

### 10.2 `SaveScores()`

Buoc:

1. Tim enrollment active cua lop
2. Duyet item form gui len
3. `ValidateScore()` cho:
   - `MidtermScore`
   - `FinalScore`
4. Tim `ScoreEntity` theo `EnrollmentId`
5. Neu chua co -> tao `DSxxx`
6. Neu da co -> update
7. `SaveChanges()`

Rule diem:

- co the null
- neu co gia tri thi phai nam trong khoang `0..10`

## 11. Dashboard va bao cao

### 11.1 `GetAdminDashboardStats()`

Tra object `DashboardStats` gom:

- so staff
- so teacher
- so lop active
- tong hoc vien
- tong bien lai
- tong doanh thu
- tong cong no
- hoc vien moi trong thang

No dung:

- `BuildDebtRows()` de tinh no
- dem active class bang `GetEffectiveClassStatus()`

### 11.2 `GetTeacherDashboardStats(teacherAccountId)`

Service map:

- `teacherAccountId` -> `teacherId`

roi tinh:

- `TeachingClassCount`
- `TeachingStudentCount`
- `TodaySessionCount`
- `PendingScoreCount`

Nuance:

- `TodaySessionCount` hien tai KHONG thuc su dem "buoi hoc hom nay"
- No dang dem so lop cua giao vien ma trang thai lop chua dong

Khi giai thich code, nen noi ro day la ten KPI mang tinh UI/business naming, khong phai exact session count.

### 11.3 Bao cao chi tiet

`GetReportDetail(reportType, fromDate, toDate)` route sang 1 trong 3 builder:

- `BuildRevenueReportDetail()`
- `BuildEnrollmentReportDetail()`
- `BuildDebtReportDetail()`

`BuildDebtRows()` la ham rat quan trong:

1. Lay enrollment + student + class + course + receipts
2. Tinh:
   - `RequiredAmount`
   - `PaidAmount`
   - `Outstanding`
3. Xac dinh `ReferenceDate`
4. Gan `Status`:
   - `Da hoan thanh`
   - `Qua han`
   - `Sap den han`

### 11.4 Bao cao theo thang

Co 2 ham query truc tiep:

- `GetMonthlyRevenue()`
- `GetMonthlyEnrollmentCounts()`

Va 1 ham suy dien tu bang detail:

- `BuildMonthlySeriesFromTable()`

Y nghia:

- doanh thu va tuyen sinh lay tu DB thep group by thang
- cong no thi lay tu bang detail da build roi group lai

## 12. Helper nghiep vu noi bo

Nhung helper duoi day rat hay bi bo qua, nhung la cot song cua service:

- `GetNextCode()`: sinh ma
- `FormatMoney()`: format theo `vi-VN`
- `ExtractCourseLevel()`: tach level tu course description
- `GetActiveEnrollmentCount()`: dem si so thuc
- `ClassHasAvailableSlot(ClassEntity)`: check cho trong
- `GetEffectiveClassStatus()`: xac dinh status thuc te cua lop
- `ResolveCourseId()` / `ResolveTeacherId()`: map text UI sang ID
- `ParseScheduleDays()`: parse lich hoc
- `SoftDeleteEntity<TEntity>()`: xoa mem generic

## 13. Offline service dung de lam gi

`OfflineLanguageCenterDataService` implement cung interface voi service SQL, nhung:

- du lieu nam trong list in-memory
- khong can SQL Server
- seed san data demo
- cho UI van chay khi DB that co loi

No tot cho:

- demo giao dien
- test layout
- test event flow

No khong thay the hoan toan SQL vi:

- khong co ràng buoc DB that
- khong co performance / query behavior y chang EF

## 14. Cac nuance nen nho khi thuyet trinh

### 14.1 `DataTable` la contract giao tiep UI

Neu doi ten cot trong service, form co the hong ngay lap tuc.

### 14.2 Nhieu gia tri duoc normalize hai chieu

UI co the nhap tieng Viet, DB luu gia tri canonical tieng Anh.

### 14.3 Service da bao ve nghiep vu quan trong

Vi du:

- khong ghi danh trung
- khong vuot si so
- khong thu vuot hoc phi
- khong luu diem ngoai khoang 0..10

### 14.4 Van con vai diem "UI-only"

Vi du:

- discount khi ghi danh hien chi luu vao `note`
- session khong co bang DB rieng

Do do, khi mo rong he thong sau nay, day la 2 diem de model hoa them.
