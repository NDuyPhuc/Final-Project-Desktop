# Folder guide sieu chi tiet: `Forms/Teacher`, `Forms/Admin`, `Forms/Dialogs`

## Muc tieu cua file nay

File nay day nguoi moi:

- shell teacher dashboard chay ra sao
- giao vien xem lop, diem danh, nhap diem theo flow nao
- admin dashboard va admin reports dung service tong hop nhu the nao
- dialog xac nhan/thong bao dong vai tro gi

Day la cum folder cua:

- shell giao vien
- shell admin
- popup phu tro

## Danh sach file chinh

Teacher:

- `FrmTeacherDashboard.cs`
- `FrmTeachingClasses.cs`
- `FrmClassStudentList.cs`
- `FrmAttendance.cs`
- `FrmScoreEntry.cs`

Admin:

- `FrmAdminDashboard.cs`
- `FrmAdminReports.cs`
- `FrmSystemMonitor.cs`
- `FrmAccountManagement.cs`
- `FrmAccessMatrix.cs`

Dialogs:

- `FrmConfirmDialog.cs`
- `FrmStatusDialog.cs`
- `FrmImagePreviewDialog.cs`

## So do nghiep vu teacher

Teacher flow thuong la:

1. login
2. vao teacher dashboard
3. xem KPI cua lop dang day
4. mo danh sach lop dang day
5. mo danh sach hoc vien theo lop
6. mo attendance
7. mo score entry

Neu nhin theo data:

- teacher account -> teacher dashboard stats
- teacher account -> teaching classes
- class -> students
- class + date -> attendance
- class -> score list

## So do nghiep vu admin

Admin flow thuong la:

1. login
2. vao admin dashboard
3. xem canh bao he thong
4. xem account va phan quyen
5. xem monitor
6. xem report tong hop

Admin khong thao tac CRUD hoc vien hang ngay nhu staff.

Admin nghiêng ve:

- monitoring
- governance
- overview
- report

## Vai tro cua dialogs

Dialog la form nho phu.

No giup:

- xac nhan thao tac
- thong bao trang thai
- preview nhanh

Dialog tot giup:

- UI giam ro
- hanh vi lap lai co noi dung chung

## `FrmTeacherDashboard.cs`

### Vai tro

Day la shell giao vien.

No:

- to sidebar teacher
- to topbar
- to card KPI
- to class overview
- to task card
- mo child form teacher

### Cac field dac trung

`_currentUserName`

- ten user dang login

`_isApplyingResponsiveLayout`

- guard cho responsive

`_sidebarFooterPanel`

- panel dong chen vao footer sidebar

`_btnTeacherNewSession`

- nut tao buoi hoc moi trong footer

`_btnTeacherSettings`

- nut cai dat

`_topbarLayout`

- layout topbar

`_txtTopbarSearch`

- o tim tren topbar neu co

`_pnlProfileCard`

- card profile nguoi day

### Constructor

Form co constructor mac dinh va constructor nhan `currentUserName`.

Flow:

1. nho ten user
2. `InitializeComponent()`
3. `ConfigureShellSurface(...)`
4. `ApplyShellStyling()`
5. `BindDashboardData()`
6. `ShowDashboardHome()`

### `ApplyShellStyling()`

Ham nay chua rat nhieu UI state:

- minimum size
- mau nen shell
- kich thuoc sidebar va topbar
- text brand teacher
- text menu
- style tung button trong sidebar
- footer sidebar
- topbar chrome
- style logout
- style KPI card
- configure hero card
- configure class overview card
- gan menu event
- gan responsive resize

No la bang chung ro:

- dashboard shell khong phai CRUD
- shell la mot "bo may UI" rieng

### `BindDashboardData()`

No goi:

- `GetTeacherDashboardStats(AppRuntime.CurrentUser?.Id)`
- `GetTeachingClasses(AppRuntime.CurrentUser?.Id)`

No do vao:

- so lop dang day
- so hoc vien dang phu trach
- so session hom nay
- so muc pending score
- grid tong quan lop

### `OpenModule(...)`

Ham nay la mau shell chuan:

1. log UI start
2. bat wait cursor
3. tao form con tu `moduleFactory()`
4. open child form vao `pnlContentHostTeacher`
5. set active menu
6. log UI done
7. neu loi thi log va thong bao

Chi tiet cuc hay:

- dashboard teacher co logic "giu nguyen dashboard neu module loi"
- day la UX an toan

### `EnsureSidebarFooter()`

Ham nay tao dong footer.

Nhin vao no thay:

- panel footer duoc chen luc runtime
- nut tao buoi hoc moi duoc chen luc runtime
- nut settings duoc chen luc runtime
- logout button bi lay ra roi nhung vao footer panel

Day la ky thuat "cai tao layout Designer luc runtime".

## `FrmTeachingClasses.cs`

### Vai tro

Form nay la list lop dang day cua giao vien.

No:

- load teaching classes theo current user
- loc theo tu khoa
- loc theo status
- mo nhanh class student list
- mo nhanh attendance
- mo nhanh score entry

### `LoadTeachingClasses()`

Chi 1 dong service call da noi nhieu:

- service tu map `CurrentUser?.Id` thanh cac lop teacher nay duoc day

### `ApplyFilters()`

Ham nay clone `_sourceTable` roi import lai dong thoa dieu kien.

No la loc phia UI sau khi da co bang nguon.

Nguoi moi nen nho:

- khong phai luc nao bo loc cung query lai DB
- co luc service tra bang nguon
- UI loc tiep trong RAM

## `FrmAttendance.cs`

File nay da co tai lieu:

- `24-teacher-attendance-score-line-by-line.md`

Can ghim 6 y:

1. giao vien lay lop dang day theo account dang login
2. combo buoi hoc bind tu `GetSessions(classId)`
3. date picker dong bo theo buoi
4. grid diem danh co cot checkbox `Co mat`
5. nut all present/all absent chi la thao tac tren grid
6. save attendance dong goi `AttendanceSaveItem`

Y nghia nghiep vu:

- attendance bám theo `EnrollmentId`
- khong luu theo ten hoc vien thuần

## `FrmScoreEntry.cs`

File nay da co tai lieu:

- `24-teacher-attendance-score-line-by-line.md`

Can ghim 6 y:

1. grid score bind theo `GetScoreList(classId)`
2. chi cho sua diem, khong cho sua ma HV ho ten
3. `ParseScore(...)` check diem la so
4. `ParseScore(...)` check diem 0-10
5. save score dong goi `ScoreSaveItem`
6. score type combo hien dang bi khoa vi DB chua phan loai

Day la thong diep ky thuat rat gia tri:

- UI da san khung cho mo rong score type
- nhung du lieu nen chua ho tro day du

## `FrmClassStudentList.cs`

Du file nay chua co tai lieu rieng o dot nay,

co the doan vai tro cua no la:

- xem hoc vien trong lop dang day
- cho giao vien doc danh sach
- co the dung de support diem danh/nhap diem

Khi doc file that,

hay tim:

- class filter
- grid hoc vien
- co lookup theo class dang chon khong

## `FrmAdminDashboard.cs`

### Vai tro

Day la shell admin.

No:

- to sidebar admin
- to topbar
- to user card
- to KPI admin
- to warning grid
- to quick snapshot grid
- mo child form admin

### Constructor

Diem rat hay cua file nay la co 3 constructor overload.

No nhan:

- ten user
- va `ILanguageCenterDataService`

No cho thay admin dashboard:

- co the inject service
- de test/de preview/de dung abstraction tot hon

### `LicenseManager.UsageMode == Designtime`

Dong nay la guard cho Designer.

Ban chat:

- Visual Studio Designer mo form de ve preview
- nhung khong nen chay logic nghiep vu that
- guard nay tranh Designer bi vo vi service/runtime chua san

Day la chi tiet cuc thuc chien.

### `ApplyLocalizedText()`

Ham nay dat:

- brand title/subtitle
- header title/subtitle
- text menu
- text logout
- text KPI title/note
- text warning card
- text quick view card

Admin dashboard co ton trong localization giong teacher/staff.

### `ApplyShellStyling()`

No style:

- min size
- sidebar width
- topbar height
- padding shell
- user card
- card style
- warning grid
- snapshot grid
- sidebar button
- danger logout
- KPI value style

No la phien ban admin cua shell builder.

### `ConfigureResponsiveLayout()` va `ApplyResponsiveBreakpoints()`

Hai ham nay can doc ky.

No cho thay:

- root table layout duoc dieu chinh theo breakpoints
- bottom split co the doi horizontal/vertical
- KPI table duoc chuyen 4 cot -> 2x2 khi compact

Nguoi moi nen thay:

- responsive khong chi co web
- WinForms van lam responsive duoc
- nhung phai lam bang code, thuong rat thu cong

### `BindDashboardData()`

Ham nay goi:

- `GetAdminDashboardStats()`
- `GetAccounts()`
- `GetAdminWarnings()`
- `GetMonitorActivity()`

No cho thay admin dashboard nghien ve:

- tong so account
- active classes
- doanh thu tong
- tong no
- warning
- monitor snapshot

## `FrmAdminReports.cs`

### Vai tro

Day la form bao cao lon.

No co:

- chart
- KPI report
- filter khoang ngay
- filter loai report
- detail grid
- print
- refresh
- export CSV

### Cac field cap lop

`ReportCulture`

- culture `vi-VN`
- dung de format so/ngay/tien

`_dataService`

- service duoc inject

`_currentScenario`

- kich ban report dang xem

`_initialReportLoaded`

- guard tranh load default nhieu lan

### Constructor

Flow:

1. nho `_dataService`
2. `InitializeComponent()`
3. `ConfigureModuleSurface(...)`
4. localize text
5. style visual
6. chart surface
7. scrollable layout
8. adaptive scrolling
9. bind event
10. gan `Shown` de ensure report mac dinh
11. gan `Resize` va nhieu `Panel.Resize` de relayout

### `ConfigureScrollableLayout()`

Ham nay rat noi.

No thu cong:

- set `AutoScrollMinSize`
- set row height cho root table
- set filter layout cot
- set min size chart card
- set min size highlight/distribution card
- set width/height cho action button
- goi layout lai title, header, card, scroll height

No cho thay report form la mot "page" lon ben trong WinForms.

### `ApplyResponsiveLayout()`

No chia 3 muc:

- `compact`
- `narrow`
- `veryNarrow`

Sau do:

- doi row height root
- doi header layout
- doi filter layout
- doi KPI layout
- doi middle layout
- doi text nut view report

Day la responsive design rat ro.

### `UpdateReportScrollHeight()`

Ham nay tinh tong chieu cao content dua tren `RowStyles`.

Nguoi moi thuong khong nghi toi viec:

- form desktop scrollable page can tu tinh content height

Nhung report page o day dang lam dieu do.

### `ConfigureHeaderLayout(...)`

Khi compact:

- title va action xuong 2 dong

Khi rong:

- title va action nam 2 cot

### `ConfigureFilterLayout(...)`

Khi hep:

- bo loc chuyen 2 cot 4 dong

Khi rong:

- bo loc 4 cot 2 dong

Nghia la filter form tu doi dang theo be ngang.

### Nghiep vu report

Du chua doc het file,

co the chac:

- service se tra point cho chart
- service se tra detail `DataTable`
- form chi lo layout, chart, format, event

## `FrmSystemMonitor.cs`, `FrmAccountManagement.cs`, `FrmAccessMatrix.cs`

Dot nay chua co file sieu chi tiet rieng,

nhung chi can nhin ten la da doan duoc vai tro:

`FrmSystemMonitor.cs`

- xem activity
- xem log chi tiet
- nghieng read-only monitoring

`FrmAccountManagement.cs`

- CRUD account
- toggle status
- reset password

`FrmAccessMatrix.cs`

- hien ma tran quyen
- read-only hoac semi-read-only

Khi doc nhom nay,

hay tim:

- service methods `GetMonitorActivity`, `GetMonitorDetailedLog`
- service methods account list / save / toggle / reset password
- service method `GetAccessMatrix`

## `FrmConfirmDialog.cs`

Day la dialog xac nhan.

No rat nho nhung rat co ich.

Flow:

1. constructor mac dinh -> constructor co tham so
2. `InitializeComponent()`
3. `ConfigureDialogSurface(...)`
4. dat title
5. dat message
6. scale chrome

`ScaleDialogChrome()` thuong chi:

- padding root
- margin title
- margin action panel
- size button

Ban chat:

- dialog duoc trung tam hoa giao dien
- moi noi can xac nhan khong phai tu style lai tu dau

## `FrmStatusDialog.cs`

Rat giong confirm dialog.

Khac o vai tro:

- thong bao trang thai
- khong phai xac nhan phep tiep tuc

No la popup "thong bao xong viec" ngan.

## `FrmImagePreviewDialog.cs`

Ten file cho thay:

- dialog preview anh
- de xem hinh truoc khi xac nhan hoac trong qua trinh thao tac

Khi doc file nay sau,

hay tim:

- picture box
- zoom
- open image path
- dispose image

## Moi quan he giua teacher, admin, dialogs

Teacher dashboard mo:

- teaching classes
- class student list
- attendance
- score entry

Admin dashboard mo:

- system monitor
- account management
- reports

Cac form teacher/admin lai co the mo dialogs:

- confirm dialog
- status dialog
- image preview dialog

Day la mo hinh:

- shell
- module
- dialog phu tro

## Bai hoc kien truc tu cum folder nay

Bai hoc 1:

Teacher va Admin cung xai shell pattern.

Bai hoc 2:

Menu shell mo child form vao panel host.

Bai hoc 3:

Dashboard khong tu query tung bang thu cong khap noi.

No goi service tong hop.

Bai hoc 4:

Report form trong WinForms van co the responsive.

Bai hoc 5:

Dialog nho giup app thong nhat va giam lap code.

## Phu luc chung cho nguoi moi

### Shell pattern trong WinForms

- co sidebar
- co topbar
- co content host
- co menu button
- co ham `OpenModule`
- co ham set active menu

### Dashboard pattern

- load stats mot lan
- do vao label
- data detail vao grid
- menu dan den module sau

### Report pattern

- filter
- KPI
- chart
- detail grid
- print/export

### Dialog pattern

- constructor mac dinh
- constructor co tham so
- `ConfigureDialogSurface`
- title/message
- action button

### Vai tro cua service trong teacher/admin

- teacher dashboard can teacher stats
- teaching classes can list theo teacher account
- attendance can attendance list theo class/date
- score entry can score list theo class
- admin dashboard can admin stats
- admin reports can report points/detail
- account management can account list/save
- system monitor can monitor activity/log

### Cac ham service can nho

- `GetTeacherDashboardStats`
- `GetTeachingClasses`
- `GetAttendanceList`
- `SaveAttendance`
- `GetScoreList`
- `SaveScores`
- `GetAdminDashboardStats`
- `GetAdminWarnings`
- `GetMonitorActivity`
- `GetMonitorDetailedLog`
- `GetAccessMatrix`
- `GetReportDetail`
- `GetMonthlyRevenue`
- `GetMonthlyEnrollmentCounts`

### Dinh huong debug

- teacher dashboard sai so lieu: xem stats service.
- teaching class rong: xem current user id mapping sang teacher.
- attendance luu sai: xem `EnrollmentId` va ngay hoc.
- score save sai: xem parse 0-10 va service update-or-insert.
- admin KPI sai: xem service aggregate.
- report chart sai: xem `ReportPoint`.
- dialog vo layout: xem `ConfigureDialogSurface` va scale helper.

### Cac ky hieu nguoi moi can quen mat

- `ShowDialog(this)` = mo modal voi owner.
- `Resize += ...` = moi lan doi size thi chay ham.
- `Dock = Fill` = lap day container.
- `FlowDirection` = huong chay control.
- `RowStyles`/`ColumnStyles` = dinh nghia bang layout.
- `MinimumSize` = nguong khong cho nho hon.
- `AutoScroll` = bat cuon.

### Cach doc shell dashboard

- tim constructor.
- tim `ApplyShellStyling`.
- tim `BindDashboardData`.
- tim `OpenModule`.
- tim `ShowDashboardHome`.
- tim breakpoint responsive.

### Cach doc report form

- tim filter controls.
- tim chart config.
- tim method load default.
- tim method bind service data.
- tim export/print.
- tim responsive layout.

## Ket thuc folder 05

Cum folder nay day ban 3 thu:

- teacher shell va luong giang day
- admin shell va luong monitoring/report
- dialog nho de lam mem UI

Sau khi doc chac file nay,

ban se de noi teacher/admin shell voi service va helper chung cua app hon rat nhieu.
