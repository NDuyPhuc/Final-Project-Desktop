# Giai thich tung dong: startup, runtime, config, login

File nay giai thich sat line number cho nhom file mo dau cua du an. De tranh tai lieu dai vo tan, toi giai thich tung dong co y nghia va gom chung nhung dong chi la `{`, `}`, xuong dong trang, hoac continuation cua cung mot lenh.

## 1. `Trung-tam-quan-ly-ngoai-ngu/Program.cs`

### Dung file nay de lam gi

Day la diem vao dau tien cua ung dung WinForms. Moi thu deu bat dau o day: setup giao dien Windows, tao service, fallback offline, dang ky logger loi, va mo form login.

### Giai thich theo dong

| Dong | Giai thich |
| --- | --- |
| 1 | Import `TrungTamNgoaiNgu.Application.Contracts` de file nay biet `ILanguageCenterDataService`, nghia la lam viec qua abstraction thay vi troi cung implementation cu the. |
| 2 | Import `Infrastructure` de goi `ErrorLogger` va `AppPaths` khi khoi tao that bai hoac co unhandled exception. |
| 3 | Import `Services` de tao `SqlLanguageCenterDataService` va `OfflineLanguageCenterDataService`. |
| 5-8 | Mo namespace UI va khai bao `Program` la class static noi chua ham `Main()`. |
| 9 | `[STAThread]` bat che do apartment don luong, day la yeu cau co dien cua WinForms/COM khi lam viec voi clipboard, dialog, UI thread. |
| 10-11 | Khai bao `Main()` la diem chay chinh cua app. |
| 12 | `Application.SetHighDpiMode(HighDpiMode.SystemAware);` noi app phai y thuc DPI cua he thong, tranh blur UI tren man hinh scale. |
| 13 | `EnableVisualStyles()` bat theme control cua Windows thay vi giao dien co dien. |
| 14 | `SetCompatibleTextRenderingDefault(false)` chon text rendering mac dinh theo GDI+ hien dai hon, tranh xung dot cu. |
| 16 | Tao service chinh cua he thong la `SqlLanguageCenterDataService`, nghia la mac dinh app muon chay voi SQL Server that. |
| 17-20 | Goi `TryInitializeRuntime(dataService)`; neu ham nay tra `false` thi dung app ngay. Trong code hien tai thuong no tra `true`, ke ca khi SQL loi, vi co fallback offline. |
| 22 | Bat che do bat exception tren UI thread thay vi de app vo ngay lap tuc. |
| 23 | Dang ky event `ThreadException` de moi loi tren UI thread deu qua `HandleUnhandledException()`. |
| 24-30 | Dang ky `AppDomain.CurrentDomain.UnhandledException` cho loi ngoai UI thread. Dong 26-29 ep `ExceptionObject` ve `Exception` neu co the, roi gui vao logger chung. |
| 32 | `Application.Run(new FrmLogin(AppRuntime.DataService));` mo form login va dua `DataService` da khoi tao vao form. App se song cho den khi form nay dong. |
| 35-40 | Bat dau helper `TryInitializeRuntime()`. Trong `try`, goi `AppRuntime.Initialize(dataService)` roi tra `true` neu khong co loi. |
| 42-45 | Neu SQL khoi tao loi, log ra file roi doi service toan cuc sang `OfflineLanguageCenterDataService`. Day la co che demo offline. |
| 47-54 | Tao chuoi thong bao dai noi ro: SQL that bai, app chuyen qua offline, va dua 3 tai khoan mau. Dong 54 chen duong dan file log thuc te. |
| 56 | Hien `MessageBox` canh bao cho nguoi dung biet app dang o che do demo offline. |
| 57 | Van tra `true` de app tiep tuc chay, chi la chay bang service offline thay vi service SQL. |
| 61-71 | `HandleUnhandledException()` la handler cuoi. Dau tien no co co hoi log loi va hien thong bao lich su log. |
| 65 | `ErrorLogger.Log(exception, "UnhandledException");` ghi exception kem nhan context de sau nay tim trong log de hon. |
| 67-71 | Hien duong dan log thay vi nhai toan bo stack trace, giup nguoi dung biet can tim file nao. |
| 73-79 | Neu ngay ca logger hay `MessageBox` chuan cung gap loi, code roi ve phuong an cuoi: hien `exception.ToString()` truc tiep. |

### Ket luan ngan cho file nay

`Program.cs` lam 4 viec: setup WinForms, tao service, fallback offline neu SQL loi, va bao ve app bang logging trung tam.

## 2. `Trung-tam-quan-ly-ngoai-ngu/Core/AppRuntime.cs`

### Dung file nay de lam gi

Day la "runtime singleton" tu lam. No giu service toan cuc va thong tin user dang login.

| Dong | Giai thich |
| --- | --- |
| 1-3 | Import interface service, service SQL mac dinh, va `AccountEntity` de luu current user. |
| 5 | Namespace file-scoped, ngan gon hon block namespace. |
| 7 | `AppRuntime` la class static nen khong can tao instance. |
| 9 | `_dataService` la bien private nullable, chua service that sau khi `Initialize()` duoc goi. |
| 11-12 | Property `DataService` tra ve `_dataService`; neu chua init thi throw ro rang thay vi tra `null` de loi ve sau. |
| 14 | `CurrentUser` luu session dang nhap hien tai. Setter private de chi class nay duoc doi. |
| 16-20 | `Initialize()` cho phep nhan service tu ngoai; neu khong truyen thi tu tao `SqlLanguageCenterDataService()`. Sau do goi `EnsureDatabaseReady()`, tuc la ngay luc init da test DB va seed neu can. |
| 22-25 | `SetCurrentUser()` chi don gian doi tai khoan hien tai. Moi dashboard va form role-based doc thong tin nay. |

### Y nghia thiet ke

- `Program.cs` chi init mot lan.
- Moi form khong can truyen service qua rat nhieu cap neu khong muon; chi can doc `AppRuntime.DataService`.
- Teacher form dung `AppRuntime.CurrentUser?.Id` de map account dang login sang teacher profile.

## 3. `TrungTamNgoaiNgu.Application/Security/PasswordHasher.cs`

### Dung file nay de lam gi

Hash mat khau bang SHA256 va xac minh mat khau dang nhap.

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Security.Cryptography` de dung `SHA256`. |
| 2 | Import `System.Text` de doi chuoi sang bytes UTF-8. |
| 4-6 | Khai bao class static utility, khong luu state. |
| 8-14 | Ham `Hash()`: nhan plain text, check rong o dong 10, doi chuoi sang bytes UTF-8, hash SHA256, roi chuyen hash thanh hex string in hoa. |
| 16-27 | Ham `Verify()`: neu password hoac hash rong thi fail ngay. Neu khong, hash lai plain text va so sanh voi hash luu trong DB theo `OrdinalIgnoreCase`. |

### Nuance quan trong

- Co hash mot chieu, nhung chua co salt.
- Du dung cho do an desktop demo, nhung chua phai muc bao mat production-grade.

## 4. `TrungTamNgoaiNgu.Application/Configuration/LanguageCenterDatabaseConfiguration.cs`

### Dung file nay de lam gi

Doc connection string tu env var hoac `appsettings.json`, normalize lai, va tra object options cho service SQL.

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Text.Json` de deserialize file JSON cau hinh. |
| 5-9 | Khai bao 3 constant: ten file settings, ten env var chua connection string, va env var password override. |
| 11-13 | `Load()` la ham chinh; dau tien no doc file settings neu co. |
| 15-19 | Thu uu tien dau tien la env var `TTNN_SQL_CONNECTION_STRING`; neu rong moi fallback sang file settings. |
| 21-25 | Neu cuoi cung van khong tim thay chuoi ket noi thi throw ro rang, khong de service SQL chay trong trang thai mo ho. |
| 27 | Normalize connection string de bo cac segment khong mong muon nhu `Command Timeout` neu bi chen trong raw string. |
| 28-33 | Neu co env var password va connection string chua co `Password=` thi noi them password vao cuoi. Cach nay giup khong commit password trong file. |
| 35-39 | Tra ve `LanguageCenterDatabaseOptions` gom connection string da normalize va timeout. Neu file khong noi timeout thi default 30s. |
| 42-57 | `LoadSettingsFile()` tim file `appsettings.json` ngay tai `AppContext.BaseDirectory`, doc no neu ton tai, va deserialize case-insensitive. |
| 59-68 | `NormalizeConnectionString()` cat chuoi theo `;`, bo segment `Command Timeout`, roi noi lai. |
| 70-79 | Hai class nested lam DTO doc JSON: `AppSettingsRoot` va `DatabaseSettingsSection`. |

## 5. `TrungTamNgoaiNgu.Application/Infrastructure/AppPaths.cs`

### Dung file nay de lam gi

Tap trung hoa duong dan file log, thu muc anh, va helper luu avatar.

| Dong | Giai thich |
| --- | --- |
| 3-7 | Khai bao 3 property: thu muc chay app, file `log.txt`, va thu muc `Images`. |
| 9-14 | `EnsureImagesSubFolder()` ghep thu muc con trong `Images`, tao folder neu chua co, roi tra ve path do. |
| 16-26 | `ResolveAbsolutePath()` nhan path tuong doi hoac tuyet doi. Neu rong thi `null`; neu da la root path thi tra nguyen; neu khong thi ghep voi `BaseDirectory`. |
| 28-37 | `SaveImage()` lay extension file nguon, tao ten file theo `entityId_timestamp`, tao folder con, copy file vao do, roi tra ve duong dan TUONG DOI de luu vao DB. |
| 39-53 | `GetWorkspaceRoot()` di nguoc len cay thu muc cho toi khi tim thay file `.sln`, dung khi muon biet goc workspace. Neu khong tim thay thi dung `BaseDirectory`. |

## 6. `TrungTamNgoaiNgu.Application/Infrastructure/ErrorLogger.cs`

### Dung file nay de lam gi

Ghi exception ra `log.txt` theo dinh dang de doc.

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Text` de dung `StringBuilder`. |
| 5-7 | Class static, co them `SyncLock` de nhieu thread cung log khong ghi de len nhau. |
| 9-10 | `Log(Exception exception, string context)` nhan exception va nhan context de biet no phat sinh o dau. |
| 11-20 | Trong `try`, build block log gom separator, time, context, message, va toan bo `exception.ToString()`. |
| 22-25 | `lock (SyncLock)` bao ve file append, roi ghi vao `AppPaths.LogFilePath`. |
| 27-29 | `catch { }` chu dong nuot loi logger. Ly do: logger khong duoc quang nem them exception moi de lam vo app. |

## 7. `TrungTamNgoaiNgu.Application/Localization/LanguageCenterValueMapper.cs`

### Dung file nay de lam gi

Chuyen doi 2 chieu giua:

- gia tri display tieng Viet tren UI
- gia tri canonical tieng Anh luu trong code/DB

### Giai thich theo nhom line

| Dong | Giai thich |
| --- | --- |
| 1 | Import enum `AccountStatus` de map account status typed thay vi string thuan. |
| 5-13 | `NormalizeCourseStatus()`: nhan text bat ky, trim, neu rong thi mac dinh `Active`, neu gap cac bien the Viet/Anh thi doi ve `Active` hoac `Inactive`. |
| 15-20 | `ToCourseStatusDisplay()`: doi tu canonical ve text hien thi tren UI. |
| 22-31 | `NormalizeStudentStatus()`: map `Dang hoc`, `Bao luu`, `Tam dung`, `Hoan thanh`, `Da nghi` ve `Active`, `Paused`, `Inactive`, `Completed`, `Dropped`. |
| 33-41 | `ToStudentStatusDisplay()`: chieu nguoc lai cho student. |
| 43-49 | `NormalizeTeacherStatus()`: teacher chi co 2 nhanh chinh la `Active` va `Inactive`. |
| 51-56 | `ToTeacherStatusDisplay()`: doi ve `Dang day` / `Tam nghi`. |
| 58-68 | `NormalizeClassStatus()`: map cac trang thai lop ve `Open`, `InProgress`, `Closed`, `Completed`, `Cancelled`. Chu y `Day` cung bi map ve `Open`, vi "day" la status suy dien UI hon la state DB chinh thuc. |
| 70-78 | `ToClassStatusDisplay()`: doi class status tu canonical ve display. |
| 80-89 | `NormalizeEnrollmentStatus()`: map trang thai ghi danh. |
| 91-99 | `ToEnrollmentStatusDisplay()`: chieu nguoc lai cho ghi danh. |
| 101-110 | `NormalizePaymentMethod()`: map `Tien mat`, `Chuyen khoan`, `The`, `Vi dien tu`, `Khac` ve `Cash`, `BankTransfer`, `Card`, `EWallet`, `Other`. |
| 112-120 | `ToPaymentMethodDisplay()`: doi phuong thuc thanh toan ve text UI. |
| 122-129 | `NormalizeAccountStatus()`: map string vao enum `AccountStatus`. Neu parse that bai thi fallback `Active`. |
| 131-137 | `ToAccountStatusDisplay()`: enum -> text UI. |

### Nuance rat quan trong

- File nay lam app chiu duoc du lieu co dau, khong dau, hoac gia tri English.
- Nhieu form dua text thang tu combo box vao service; service van luu dung vi co mapper nay.

## 8. `Trung-tam-quan-ly-ngoai-ngu/Forms/Common/FrmLogin.cs`

### Dung file nay de lam gi

Day la form dang nhap thuc te cua app. No vua co UI custom, vua co logic auth, vua co responsive layout.

### Giai thich theo line range sat code

| Dong | Giai thich |
| --- | --- |
| 1-4 | Import `System.ComponentModel`, service contract, logger infra, va `AccountRole` de switch dashboard theo role. |
| 8-14 | Danh dau form cho designer, khai bao class partial, va 4 field: service, duong dan logo, duong dan background, va `Image` background dang load. |
| 16-18 | Constructor khong tham so chi delegate sang constructor chinh bang `AppRuntime.DataService`. |
| 20-25 | Constructor chinh nhan service, gan vao field, goi `InitializeComponent()`, bat double buffering va user paint de ve UI muot hon. |
| 27-33 | Goi theme chung, set text localize, tat `AutoScroll`, va ep 2 label header can giua thay vi auto size tu do. |
| 34-41 | Neu khong o che do designer, tinh `workingArea` man hinh va co client size phu hop DPI, khong vuot qua man hinh that. |
| 42 | Dat mau nen tong the cho form login. |
| 44-45 | Tinh path tuyet doi toi anh logo va background login. |
| 47-48 | Gan nut Enter cho `btnLogin` va Esc cho `btnExit`. |
| 50-56 | Dang ky paint event cho panel container de tu ve nen trang va border xam, tao card login dep hon mac dinh. |
| 57-59 | Gan 3 paint handler rieng: ve header gradient, ve fallback logo, va ve icon error. |
| 61 | Check box show password chi dao nguoc `UseSystemPasswordChar`. |
| 62 | Nut thoat chi `Close()` form. |
| 63 | Nut login goi `HandleLogin()`. |
| 64-68 | Link "quen mat khau" mo `FrmStatusDialog` voi huong dan lien he admin va nhac cau hinh SQL nam trong `appsettings.json`. |
| 70-71 | Them tooltip cho 2 o input, giup user biet username va password se doi chieu voi bang `Accounts`. |
| 73-74 | Thu load anh logo/background neu file ton tai, sau do tinh layout lan dau. |
| 76-80 | Moi lan resize form, tinh lai layout va `Invalidate()` de background ve lai theo kich thuoc moi. |
| 81-85 | Khi form vua hien, tinh lai layout lan cuoi va focus vao o username. |
| 86-90 | Khi form dispose, giai phong anh background va anh logo tranh ro ri GDI object. |
| 93-109 | `ApplyLocalizedText()` dat text hien thi cho toan bo login form, dong thoi clear username/password. Day la noi "localization bang code". |
| 111-116 | `CenterLoginPanel()` can giua panel login trong cua so, co margin toi thieu de panel khong sat bien. |
| 118-182 | `ApplyResponsiveLayout()` la khoi logic responsive chinh. No tinh xem form co dang "compact" khong, set lai width/height container, header, footer, padding, vi tri logo, vi tri label, input, panel loi, va hai button. Cuoi cung no goi `CenterLoginPanel()`. |
| 184-187 | `IsInDesignMode()` dung `LicenseManager` de biet co dang mo designer hay khong; giup tranh mot so logic runtime gay loi designer. |
| 189-244 | `HandleLogin()` la logic auth that: clear error, check rong username/password, goi `_dataService.Authenticate()`, neu fail thi hien loi; neu dung thi set current user, switch dashboard theo role, `Hide()` login, mo dashboard bang `ShowDialog()`, khi dashboard dong thi xoa session va show lai login. |
| 247-258 | `SetErrorState()` chi bat/tat panel loi va tinh lai layout. Chu y dong 255 dang set text loi co dinh, khong su dung tham so `message` de hien text chi tiet. Nghia la tham so hien tai chi dong vai tro flag co/khong. |
| 260-276 | Override `OnPaintBackground()` de ve background cover image neu co, neu khong thi to mau xanh dam, roi phu them mot lop overlay trong suot de dam bao panel login noi bat. |
| 278-286 | `DrawLoginHeaderBackground()` ve gradient cho vung dau card login. |
| 288-318 | `DrawHeaderLogoFallback()` tu ve logo hinh hop/nep sach neu file logo that khong ton tai. Day la mot fallback UX rat tot. |
| 320-328 | `DrawErrorIcon()` ve icon tron do cham than trang cho panel bao loi. |
| 330-345 | `LoadLoginAssetsIfAvailable()` check file ton tai, load background/logo bang copy image, va `Invalidate()` de ve lai form. |
| 347-352 | `LoadImageCopy()` mo file stream share-read-write, load image roi copy sang `Bitmap` moi. Cach nay tranh khoa file anh goc. |
| 354-362 | `DrawCoverImage()` tinh ti le de anh phu kin rectangle ma khong meo ty le. |
| 365-390 | `LoginDrawingExtensions` them 2 extension methods de ve/fill rounded rectangle, va helper build path bo goc bang 4 cung tron. |

### Nuance rat can nho o `FrmLogin`

1. Login form khong truy cap DB truc tiep; no chi goi `_dataService.Authenticate()`.
2. Login form tu ve kha nhieu, khong chi dung designer.
3. Sau dang nhap thanh cong, no mo dashboard theo role va giu chinh login form song trong nen.
4. `SetErrorState()` hien tai khong hien `message` day du, ma luon dat ve cau "Sai ten tai khoan hoac mat khau".

## 9. Cach doc file nay cung 4 file sau

- File nay giai thich startup, runtime, config, logger, mapper, login.
- File tiep theo se giai thich domain + `DbContext`.
- 3 file sau chia nho `SqlLanguageCenterDataService.cs` theo line range, vi day la file lon nhat va quan trong nhat cua du an.
