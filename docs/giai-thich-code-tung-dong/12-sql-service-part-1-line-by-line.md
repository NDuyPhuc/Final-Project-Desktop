# Giai thich tung dong: `SqlLanguageCenterDataService.cs` phan 1

Phan nay cover cac dong 1-754 cua `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs`.

Quy uoc doc:

- Toi bam sat line number.
- Nhung dong chi la dau ngoac mo/dong, xuong dong trang, hoac continuation thuong duoc gom voi dong lenh lien quan ngay truoc/sau no.
- Muc tieu la giai thich y nghia cua tung lenh nghiep vu, khong phai nhai lai syntax C# mot cach may moc.

## 1. Dau file va constructor (dong 1-39)

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Data` vi file nay tra ve rat nhieu `DataTable` cho WinForms bind grid. |
| 2 | Import `System.Globalization` de format ngay/tien theo `vi-VN`. |
| 3 | Import EF Core de dung `DbContextOptions`, `Include`, `AsNoTracking`, `UseSqlServer`... |
| 4-13 | Import toan bo config, contract, data, infra, mapper, model, repo, security, entity, enum. File nay la "bo nao tong", nen no can rat nhieu namespace. |
| 15-17 | Mo namespace service va khai bao class concrete implement `ILanguageCenterDataService`. |
| 19 | `_options` luu cau hinh tao `LanguageCenterDbContext`. |
| 20 | `_accountRepository` tach rieng thao tac bang `Accounts`. |
| 21 | `_culture = vi-VN` de tat ca format tien/ngay thong nhat. |
| 23 | Constructor cho phep truyen de connection string override, nhung thuong ben ngoai de null. |
| 25 | Doc config DB tap trung bang helper. |
| 26-37 | Tao `DbContextOptionsBuilder<LanguageCenterDbContext>()`, cau hinh `UseSqlServer(...)`, chon connection string override neu co, bat `EnableRetryOnFailure()`, va set command timeout neu timeout > 0. |
| 38 | Tao repository account bang cung `_options`, dam bao service va repository dung cung cau hinh DB. |

## 2. Khoi tao DB va auth (dong 41-78)

| Dong | Giai thich |
| --- | --- |
| 41-60 | `EnsureDatabaseReady()`: bao quanh toan bo logic bang `try/catch` de log trung tam. |
| 45-48 | Goi `_accountRepository.CanConnect()`. Neu SQL khong len thi throw ngay, khong cho app di sau vao cac query mu mo. |
| 50 | Tao context tam de xu ly seed/sample data. |
| 51-54 | Neu DB rong hoan toan theo logic `ShouldSeedSampleData(context)` thi seed du lieu mau. |
| 56-59 | Moi exception deu duoc ghi `ErrorLogger` voi context `EnsureDatabaseReady`, roi `throw` lai de `Program.cs` quyet dinh fallback offline. |
| 63-77 | `Authenticate()`: tim account active theo username qua repository, sau do verify password hash. Neu dung tra `AccountEntity`, neu sai tra `null`. Muc tieu la gom auth vao mot diem duy nhat. |

## 3. Sinh ma ID (dong 80-119)

| Dong | Giai thich |
| --- | --- |
| 80-83 | `GetNextAccountId()` uy quyen cho repository account. |
| 85-89 | `GetNextStudentId()` tao context, lay tat ca ID student, goi helper `GetNextCode(..., "HV")`. |
| 91-95 | Tuong tu cho teacher, prefix `GV`. |
| 97-101 | Tuong tu cho course, prefix `KH`. |
| 103-107 | Tuong tu cho class, prefix `LP`. |
| 109-113 | Tuong tu cho enrollment, prefix `GD`. |
| 115-119 | Tuong tu cho receipt, prefix `PT`. |

## 4. Nhom account nghiep vu (dong 121-173)

| Dong | Giai thich |
| --- | --- |
| 121-124 | `GetAccounts()` tra danh sach account tu repository, khong chen logic them. |
| 126-141 | `SaveAccount()`: neu `PasswordHash` rong thi tu dong hash mat khau mac dinh `123456`, sau do giao repository luu. Day la ly do form admin khong can co o nhap password khi tao moi. |
| 144-155 | `ToggleAccountStatus()`: service chi dong vai tro wrap repository + log loi. |
| 157-172 | `ResetAccountPassword()`: bat buoc mat khau moi khong rong, trim no, hash no, roi giao repository luu. |

## 5. Access matrix va admin warnings (dong 175-221)

| Dong | Giai thich |
| --- | --- |
| 175-184 | `GetAccessMatrix()` khong query DB. No tao `DataTable` hard-code de form `FrmAccessMatrix` hien vai tro va pham vi quyen. |
| 187-190 | `GetAdminWarnings()` tao context va bang canh bao. |
| 192-196 | `nearlyFull`: query cac lop chua xoa, include enrollments, doi sang memory bang `AsEnumerable()` vi helper `GetActiveEnrollmentCount()` la C# method khong translate SQL duoc, roi dem lop co si so gan day. |
| 197 | `debtCount`: dung `BuildDebtRows(context)` roi dem dong con no > 0. |
| 198 | `lockedCount`: dem account dang bi khoa. |
| 200-203 | Neu co lop sap day, them dong canh bao muc do cao. |
| 205-208 | Neu co hoc vien con no, them dong canh bao muc do trung binh. |
| 210-213 | Neu co tai khoan bi khoa, them dong canh bao muc do thap. |
| 215-218 | Neu khong co canh bao nao, them dong "he thong dang on dinh". |
| 220 | Tra bang ra UI. |

## 6. Monitor va quick snapshot (dong 223-325)

| Dong | Giai thich |
| --- | --- |
| 223-250 | `GetMonitorActivity()` tao bang 4 cot tong hop tinh hinh he thong. |
| 227 | `today = DateTime.Today` de dong bo tat ca chi so "trong ngay". |
| 229 | Dong hoc vien hien dang dung `BirthDate <= today` de tinh "Tong ho so hoat dong". Ve nghiep vu, dong nay thuc chat dang dem hoc vien hop le theo ngay sinh, khong phai hoc vien moi trong ngay. |
| 230-239 | Dong ghi danh dem enrollment co status normalize la `Active`. Chu y chu thich "Bao gom ca bao luu" khong hoan toan trung khop voi code, vi code chi dem `Active`, khong dem `Paused`. Day la nuance nen biet. |
| 240 | Dong tai chinh dem bien lai thu hom nay. |
| 241-249 | Dong dao tao dem lop chua dong theo `GetEffectiveClassStatus()`. Phai `AsEnumerable()` vi helper la C# method. |
| 253-276 | `GetMonitorDetailedLog()` lay 5 bien lai moi nhat, include student qua enrollment, va bien thanh dong log read-only cho man monitor. |
| 278-299 | `GetAccountList()` doc account chua xoa, order theo display name, roi do vao bang 4 cot. Chu y status hien thi chi chia `Active` va `Locked`, khong hien `Inactive`. |
| 301-325 | `GetRecentReceipts()` lay 10 bien lai moi nhat, include student va class, roi format so tien/ngay de dashboard hien. |

## 7. Danh sach hoc vien / giao vien / khoa hoc (dong 327-450)

### `GetStudentList()` (dong 327-367)

| Dong | Giai thich |
| --- | --- |
| 329-334 | Lay toan bo student chua xoa, `AsNoTracking()`, order theo ten. |
| 335-337 | Chuan hoa `status` filter: neu rong hoac "Tat ca" thi bo filter, neu khong thi normalize ve canonical status. |
| 339-346 | Neu co keyword thi loc local trong memory theo `Id`, `FullName`, hoac `Phone` khong phan biet hoa thuong. |
| 348-353 | Neu co normalized status thi loc tiep theo status canonical. |
| 355-364 | Tao `DataTable` 5 cot va do tung student vao bang, format ngay sinh va doi status sang display text. |

### `GetTeacherList()` (dong 369-409)

| Dong | Giai thich |
| --- | --- |
| 371-376 | Lay teacher chua xoa, order theo ho ten. |
| 377-379 | Chuan hoa status filter teacher. |
| 381-388 | Loc keyword theo ID, ten, phone. |
| 390-395 | Loc theo status canonical neu co. |
| 397-405 | Tao bang teacher va dua `Specialization` vao cot cuoi. |

### `GetCourseList()` (dong 411-450)

| Dong | Giai thich |
| --- | --- |
| 413-418 | Lay course chua xoa, order theo ten. |
| 419-421 | Chuan hoa status filter course. |
| 423-429 | Loc keyword theo ma khoa hoac ten khoa. |
| 431-436 | Loc theo status canonical neu co. |
| 438-446 | Tao bang 5 cot. Cot `Level` khong doc truc tiep tu field rieng, ma goi `ExtractCourseLevel(course.Name, course.Description)`. Cot hoc phi duoc format theo `vi-VN`. |

## 8. Danh sach lop, hoc vien lop, va lich hoc (dong 452-600)

### `GetClassList()` (dong 452-511)

| Dong | Giai thich |
| --- | --- |
| 454-462 | Lay class chua xoa, include `Course`, `Teacher`, `Enrollments` vi UI can ten khoa, ten giao vien, va si so. |
| 463-469 | Chuan hoa status filter. Chu y "Day" / "Day co dau loi encoding" duoc xem la mot truong hop dac biet, khong normalize thanh mot state DB doc lap. |
| 471-477 | Loc keyword theo ma lop hoac ten lop. |
| 479-485 | Neu co `courseId`, cho phep filter bang ca ID hoac ten khoa hoc. |
| 487-494 | Neu co status cu the, filter theo 2 cach: status "Day" thi goi `GetEffectiveClassStatus(classItem)`, con status binh thuong thi normalize va so sanh voi `classItem.Status`. |
| 496-507 | Tao bang 7 cot, tinh `activeCount` bang helper, dua si so ra dang `x/y`, va tra `GetEffectiveClassStatus(classItem)` thay vi status thuan trong DB. |

### `GetClassStudents()` (dong 513-550)

| Dong | Giai thich |
| --- | --- |
| 515-525 | Neu `classId` rong thi tu dong chon lop dau tien theo ten. |
| 527-531 | Tao bang rong 4 cot, va neu van khong co lop nao thi tra bang rong ngay. |
| 533-538 | Lay enrollment cua lop do, include `Student`, order theo ten hoc vien. |
| 540-546 | Do tung hoc vien trong lop vao bang, hien ngay ghi danh va status display. |

### `GetSessions()` (dong 552-600)

| Dong | Giai thich |
| --- | --- |
| 554-559 | Tim lop can xay lich hoc. Neu `classId` null thi chon lop dau tien theo ten. |
| 561-565 | Tao bang session rong. Neu khong tim thay lop thi tra bang rong. |
| 567 | Parse chuoi `Schedule` thanh tap cac `DayOfWeek`. |
| 568-577 | Duyet tung ngay tu `StartDate` den `EndDate`. Ngay nao co `DayOfWeek` nam trong lich thi add vao `sessionDates`. |
| 579-582 | Neu parse ra 0 session thi van fallback them ngay bat dau, tranh UI trang tron. |
| 584-596 | Duyet tung buoi da tinh, dat `status` suy dien la `Da hoc`, `Hom nay`, hoac `Sap dien ra`, roi ghi vao `DataTable`. |

## 9. Phuc vu ghi danh, bien lai, cong no, va danh sach lop giao vien (dong 602-754)

### `GetEnrollmentStudents()` (dong 602-605)

| Dong | Giai thich |
| --- | --- |
| 602-605 | Day chi la wrapper de tai su dung `GetStudentList(keyword, null)`. Nghia la grid chon hoc vien trong ghi danh dung cung nguon danh sach hoc vien. |

### `GetEnrollmentClasses()` (dong 607-648)

| Dong | Giai thich |
| --- | --- |
| 609-617 | Lay class chua xoa, include khoa hoc, giao vien, enrollments vi man ghi danh can hien du du lieu va tinh so cho trong. |
| 619-622 | Neu nguoi dung da filter theo khoa hoc thi loc bang `CourseId` hoac ten khoa. |
| 624-631 | Neu `onlyAvailable = true` thi chi giu lop con cho bang helper `ClassHasAvailableSlot`; neu `false` thi giu lop chua dong. |
| 633-644 | Tao bang 7 cot cho man ghi danh: co ca `Con cho` va `Hoc phi`. `Con cho = MaxStudents - activeCount`. |

### `GetReceiptHistory()` (dong 650-682)

| Dong | Giai thich |
| --- | --- |
| 652-658 | Lay receipts chua xoa, include student qua enrollment, order giam dan theo ngay nop. |
| 660-663 | Neu truyen `enrollmentId` thi loc theo ghi danh do. |
| 665-668 | Neu truyen `studentId` thi loc them theo hoc vien. |
| 670-678 | Tao bang lich su bien lai, convert payment method sang display text, format tien va ngay. |

### `GetDebtList()` (dong 684-722)

| Dong | Giai thich |
| --- | --- |
| 686-687 | Tao context va build toan bo debt rows bang helper trung tam. |
| 689-697 | Loc theo ten khoa hoc va ten lop neu form chon filter. |
| 699-704 | Loc them theo khoang ngay doi soat. |
| 706-718 | Tao bang cong no, nhung chi dua vao nhung dong `Outstanding > 0`, vi man theo doi cong no khong can hien hoc vien da dong du. |

### `GetTeachingClasses()` (dong 724-754)

| Dong | Giai thich |
| --- | --- |
| 726-731 | Map `teacherAccountId` sang `teacherId`. Neu khong map duoc thi tra bang rong co dung schema cho UI teacher. |
| 732-738 | Lay lop cua giao vien do, include khoa hoc va enrollments de hien si so. |
| 740-750 | Tao bang teacher class list. Cot cuoi `Thao tac` dang de `string.Empty`, vi UI hien tai tu xu ly thao tac bang nut ngoai grid hon la button trong grid. |

## 10. Tong ket phan 1

Tu dong 1-754, file nay dong vai tro:

1. Khoi tao service SQL
2. Auth va account
3. Cac danh sach `DataTable` cho UI
4. Dashboard snapshot read-only
5. Data source cho enrollment, receipt history, debt, va teacher class list

Phan 2 se vao cac dong 756-1624: attendance, score, dashboard stats, `GetById`, CRUD, enrollment, receipt, avatar, export DB script.
