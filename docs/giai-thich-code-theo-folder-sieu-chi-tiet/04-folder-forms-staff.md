# Folder guide sieu chi tiet: `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff`

## Muc tieu cua file nay

Folder `Forms/Staff` la noi staff van hanh song nhieu nhat.

File huong dan nay day nguoi moi:

- dashboard staff dong vai tro gi
- quan ly hoc vien, giao vien, khoa hoc, lop hoc noi voi nhau ra sao
- ghi danh la buoc giao cua student va class nhu the nao
- thu hoc phi di sau ghi danh bang cach nao
- cong no la mat sau cua receipt ra sao

Noi ngan:

day la folder van hanh nghiep vu hang ngay.

## Danh sach file trong folder

- `FrmStaffDashboard.cs`
- `FrmStudentManagement.cs`
- `FrmTeacherManagement.cs`
- `FrmCourseManagement.cs`
- `FrmClassManagement.cs`
- `FrmEnrollment.cs`
- `FrmTuitionReceipt.cs`
- `FrmDebtTracking.cs`

Co them `.Designer.cs` va `.resx`.

Nhung file logic goc can doc nhat la 8 file tren.

## So do nghiep vu cua staff

Flow staff de hieu nhat la:

1. Mo dashboard.
2. Xem KPI tong quan.
3. Vao quan ly hoc vien de tao/chinh sua hoc vien.
4. Vao quan ly khoa hoc va lop neu can.
5. Mo `FrmEnrollment`.
6. Chon hoc vien.
7. Chon lop.
8. Tao ghi danh.
9. Mo `FrmTuitionReceipt`.
10. Thu tien.
11. Sau nay quay lai `FrmDebtTracking` de xem ai con no.

Neu nhin theo du lieu:

- `Student` di vao `Enrollment`
- `Class` di vao `Enrollment`
- `Enrollment` di vao `Receipt`
- `Receipt` tac dong `Debt`

## Thu tu doc folder nay

Thu tu doc rat hop ly:

1. `FrmStaffDashboard.cs`
2. `FrmStudentManagement.cs`
3. `FrmCourseManagement.cs`
4. `FrmClassManagement.cs`
5. `FrmEnrollment.cs`
6. `FrmTuitionReceipt.cs`
7. `FrmDebtTracking.cs`
8. `FrmTeacherManagement.cs`

Ly do:

- dashboard cho thay entry point staff
- student/course/class la du lieu dau vao
- enrollment ghep 2 ben lai
- tuition receipt thu tien tren enrollment
- debt tracking tong hop no con lai
- teacher management la CRUD doc lap, de bo vao sau van de hieu

## Inventory theo file

### `FrmStaffDashboard.cs`

Vai tro:

- shell chua menu staff
- KPI tong quan
- recent receipts
- task card
- open child form theo menu

No la man dieu phoi.

### `FrmStudentManagement.cs`

Vai tro:

- CRUD hoc vien
- avatar hoc vien
- reset editor
- mo nhanh enrollment theo student

No la cua vao du lieu hoc vien.

### `FrmTeacherManagement.cs`

Vai tro:

- CRUD giao vien
- avatar giao vien
- lien ket account giang vien

### `FrmCourseManagement.cs`

Vai tro:

- CRUD khoa hoc
- hoc phi
- level
- mo ta
- xem lop thuoc khoa

### `FrmClassManagement.cs`

Vai tro:

- CRUD lop
- gan khoa hoc
- gan giao vien
- xem hoc vien trong lop
- xem session cua lop
- mo nhanh ghi danh theo lop

### `FrmEnrollment.cs`

Vai tro:

- chon hoc vien
- chon lop
- check da ghi danh chua
- check con slot khong
- tao enrollment
- chuyen tiep sang receipt

Day la file staff rat quan trong.

### `FrmTuitionReceipt.cs`

Vai tro:

- nap context ghi danh
- hien no con lai
- luu phieu thu
- in preview phieu thu
- xem lich su receipt

Day la nut giao giua ghi danh va tai chinh.

### `FrmDebtTracking.cs`

Vai tro:

- loc cong no theo khoa hoc/lop/khoang ngay
- tong hop tong no
- mo nhanh receipt tu dong cong no
- export excel/pdf

## `FrmStudentManagement.cs`

File nay da co 2 tai lieu con:

- `20-student-management-line-by-line.md`
- `30-student-management-super-detailed-line-by-line.md`

Trong folder guide nay, can nho 5 y:

1. Form giu `_studentTable` lam data grid source.
2. Form giu `_pendingAvatarSourcePath` va `_currentAvatarPath` de tach "anh tam" va "anh hien hanh".
3. Form tu chen them control dia chi bang code.
4. Form co responsive layout bang `TableLayoutPanel` va `SplitContainer`.
5. Nut `OpenEnrollment` la cau noi tu student sang enrollment.

Nghia nghiep vu:

- student khong phai du lieu doc lap
- no duoc tao ra de sau do di vao lop, thu hoc phi, co attendance, co score

## `FrmTeacherManagement.cs`

File nay da co tai lieu:

- `21-teacher-management-line-by-line.md`

Nhung can ghim 4 y:

1. Form co avatar dong tao luc runtime.
2. Form nho `_currentTeacherAccountId` de noi giao vien voi account dang login.
3. Nut save va update dung cung mot flow save.
4. Xoa la xoa mem.

Chi tiet de y:

- textbox dat ten `txtTeacherNote` dang duoc dung lam gioi tinh

Day la mot dau vet thiet ke.

Nguoi moi can hoc cach nhan ra:

- ten control khong luc nao cung trung 100 phan tram voi nghia hien tai

## `FrmCourseManagement.cs`

File nay da co tai lieu:

- `22-course-management-line-by-line.md`

Can ghim 4 y:

1. `Description` dang gop ca level va mo ta.
2. `TuitionFee` la `decimal`, rat lien quan thu hoc phi ve sau.
3. Grid phu ben phai cho thay cac lop thuoc khoa hoc.
4. Xoa la xoa mem.

Y nghia nghiep vu:

- course la template
- class la ban mo cu the cua course

## `FrmClassManagement.cs`

File nay da co tai lieu:

- `23-class-management-line-by-line.md`

Can ghim 6 y:

1. Lop la noi giao nhau cua course va teacher.
2. `ResolveCourseId(...)` va `ResolveTeacherId(...)` cho phep user nhap ma, ten, hoac `id - name`.
3. Form co 2 grid phu: hoc vien va session.
4. Form mo nhanh `FrmEnrollment` theo class.
5. Form check start date <= end date.
6. Nut `btnGenerateSessions` hien dang ten cu, chuc nang that la xoa mem lop.

## Giai thich sieu chi tiet `FrmEnrollment.cs`

### Tai sao file nay la trung tam giao cua staff

Neu khong co enrollment:

- hoc vien chua vao lop
- chua the thu hoc phi dung ngu canh
- chua co enrollment id de noi attendance/score/receipt

Nen `FrmEnrollment` la ban le logic rat lon.

### Cac field cap lop

`_errEnrollment`

- la `ErrorProvider`
- giu loi validation gan control
- khong phai log he thong

`_studentTable`

- la bang nguon cho grid hoc vien

`_classTable`

- la bang nguon cho grid lop

`_selectedStudentId`

- nho hoc vien dang chon

`_selectedClassId`

- nho lop dang chon

`_currentEnrollmentId`

- nho id ghi danh vua tao hoac dang mo

`_preselectedStudentId`

- cho phep form khac mo enrollment va truyen san hoc vien

`_preselectedClassId`

- cho phep form khac mo enrollment va truyen san lop

`_cboEnrollmentCourseFilter`

- la combobox tao dong bang code
- dung de loc lop theo khoa hoc

### Constructor cua `FrmEnrollment`

Khi constructor nhan 2 tham so optional:

- `preselectedStudentId`
- `preselectedClassId`

thi y nghia la:

- form nay co the mo doc lap
- hoac mo tu file khac voi ngu canh san

Vi du:

- tu `FrmStudentManagement` mo ra voi hoc vien san
- tu `FrmClassManagement` mo ra voi lop san

Day la UX rat hop ly.

### `ConfigureView()`

Cum nay lam 3 viec:

1. localize chu
2. dung lai bo cuc
3. style grid va nut

No dat:

- grid student
- grid class
- summary box
- discount mac dinh = 0
- original/final fee read only
- note multiline
- nut mo receipt disable luc chua co enrollment

### `ConfigureEnrollmentLayout()`

Day la ham bo cuc khong don gian.

No xoa layout cu va dung lai bang code.

Ban chat:

- 1 cot ben trai chua stack chon hoc vien + chon lop
- 1 cot ben phai chua summary

Ben trai lai la:

- `grpEnrollmentStudentSelect`
- `grpEnrollmentClassSelect`

stack len nhau.

Y nghia UX:

- user chon nguon du lieu ben trai
- xem ket qua tong hop ben phai

### `WireEvents()`

Event quan trong nhat:

- doi dong student => `UpdateSelectedStudent()`
- doi dong class => `UpdateSelectedClass()`
- doi discount => `RecalculateFinalFee()`
- bam create => `CreateEnrollment()`
- bam receipt => `OpenTuitionReceipt()`

Thay event `TextChanged` tren discount la thay:

- final fee duoc tinh song ngay tren UI

### `LoadData()`

Flow:

1. lay bang hoc vien co the ghi danh
2. bind vao grid student
3. bind filter khoa hoc
4. load class data dua tren filter do
5. neu co preselected student thi focus dung dong
6. neu khong co thi chon dong dau
7. neu co preselected class thi focus dung dong
8. neu khong co thi chon dong dau
9. bat/tat nut receipt dua theo `_currentEnrollmentId`

No la vi du rat ro cua "form co context mo vao tu noi khac".

### `LoadClassData()`

Ham nay cho thay mot pattern hay:

- course filter co item `"ALL"`
- neu user dang de `"ALL"` thi convert thanh `null`
- service nhan `null` de hieu la khong loc theo khoa

Day la chuan hoa input UI.

### `InitializeCourseFilterUi()`

Combobox loc khoa hoc duoc tao dong.

Ban chat:

- form duoc noi rong ma khong can sua Designer
- panel host + label + combobox duoc chen luc runtime

### `BindCourseFilter()`

Ham nay:

1. lay danh sach course
2. tao `DataTable` filter rieng
3. chen dong `"ALL"`
4. chen tung course vao bang loc
5. bind vao combobox
6. neu co preselected class thi tim class entity de suy ra courseId

Chi tiet rat hay:

- form khong chi nhan class id
- no con tu class id suy ra khoa hoc de preselect bo loc

### `FocusRowById(...)`

Ham nay la helper UX kinh dien:

- duyet tung row
- so cot dau tien voi id can tim
- chon row dung
- dat current cell

No duoc dung de dua UI quay ve dung ngu canh khi mo context san.

### `UpdateSelectedStudent()`

Ham nay:

- lay row dang chon
- nho `_selectedStudentId`
- do summary student len textbox

Day la bo nho cau noi giua grid va summary.

### `UpdateSelectedClass()`

Ham nay:

- nho `_selectedClassId`
- build summary class
- do hoc phi goc vao textbox
- goi `RecalculateFinalFee()`

No cho thay:

- hoc phi cuoi phu thuoc lop dang chon
- discount va final fee la lop tinh toan UI

### `RecalculateFinalFee()`

Flow:

1. parse hoc phi goc
2. parse discount
3. neu discount am thi dua ve 0
4. final = max(0, original - discount)
5. format ra tieng Viet

Chi tiet quan trong:

- day la validation mem o UI
- no khong cho tong phi am

### `CreateEnrollment()`

Day la trai tim form.

Flow that su:

1. validate editor co du chon student/class chua
2. goi `StudentAlreadyEnrolled(...)`
3. neu trung thi canh bao
4. goi `ClassHasAvailableSlot(...)`
5. neu het cho thi canh bao
6. build `note`
7. neu co discount thi note duoc ghep them thong tin giam
8. goi `CreateEnrollment(...)`
9. nho `_currentEnrollmentId`
10. bat nut receipt
11. thong bao thanh cong
12. mo ngay `OpenTuitionReceipt()`

Y nghia nghiep vu:

- ghi danh va thu hoc phi duoc noi lien mach
- app khong bat user tu tuong nho sang man receipt

### Vi sao discount duoc chen vao note

Do du an hien tai co the chua co cot discount rieng trong DB receipt/enrollment.

Nen UI:

- tạm luu "discount tu van" vao note

Day la mot quyet dinh ky thuat de di tiep du an du DB chua mo rong.

## Giai thich sieu chi tiet `FrmTuitionReceipt.cs`

### Vai tro nghiep vu

Neu enrollment la "hoc vien vao lop",

thi tuition receipt la "ghi nhan tien da thu".

Form nay dung de:

- tim enrollment context
- hien hoc vien/lop/khoa/no con lai
- nhap so tien thu
- luu receipt
- in preview receipt
- xem lich su phieu thu

### Cac field cap lop

`_currentContext`

- model tong hop du lieu enrollment + hoc phi + no

`_currentPrintInfo`

- model rieng de in

`_currentEnrollmentId`

- enrollment dang thao tac

`_initialStudentId`

- student code duoc truyen san neu mo tu debt hay student side

`_lastReceiptId`

- nho receipt vua tao/chon de preview lai

`_isApplyingResponsiveLayout`

- guard chong de quy layout neu co

### Constructor

Form co 3 constructor overload.

Y nghia:

- mo khong context
- mo voi enrollment id
- mo voi enrollment id + student id

No tao nhieu diem vao linh hoat cho app.

### `ConfigureView()`

No style:

- 2 group box
- grid lich su receipt
- nut thu tien
- nut luu + in
- nut xem phieu
- nut huy

No con:

- gan tooltip
- gan `PrintPage` event
- cho note thanh multiline
- khoa cac textbox thong tin context

### `LoadInitialData()`

Neu co `_initialStudentId`:

- do vao textbox code hoc vien truoc

Sau do:

- load enrollment context
- load lich su receipt

### `LoadEnrollmentContext(...)`

Flow:

1. neu co `enrollmentId` thi goi `GetEnrollmentReceiptContext(...)`
2. neu ra `null` va textbox student code co gia tri thi thu resolve tu student code
3. neu van `null` thi xoa thong tin context tren form
4. neu co context thi do thong tin hoc vien, lop, khoa, hoc phi, cong no
5. set amount mac dinh = no con lai, neu no = 0 thi lay hoc phi goc

Ban chat:

- form uu tien context chinh xac theo enrollment
- neu khong co, no co co che tu tim context gan nhat theo hoc vien

### `TryResolveContextFromStudentCode()`

Day la flow mem cho staff.

Staff co the:

- go ma hoc vien
- roi roi form tu tim ghi danh gan nhat

No rat tien:

- khong can mo enrollment truoc trong moi truong hop

### `LoadReceiptHistory()`

Grid lich su nhan:

- enrollment id neu co
- student code neu co

Y nghia:

- co the xem receipt theo ghi danh cu the
- hoac theo hoc vien

### `SaveReceipt(bool openPreview)`

Day la trai tim form receipt.

Flow:

1. validate receipt
2. goi service `SaveReceipt(...)`
3. nho `_lastReceiptId`
4. nap `_currentPrintInfo`
5. load lai enrollment context de cap nhat no con lai
6. load lai lich su receipt
7. reset editor thanh toan
8. thong bao thanh cong
9. neu `openPreview = true` thi mo print preview

Day la flow "luu xong co the in ngay".

### `ValidateReceipt()`

No check:

- co enrollment hop le chua
- so tien > 0 chua
- neu co context va con no > 0 thi khong duoc thu vuot qua no hien tai

Chi tiet nghiep vu rat ro:

- app khong cho thu qua no con lai

### `PreviewSelectedReceipt()`

No uu tien:

1. receipt vua moi tao
2. neu khong co thi row dang chon trong grid
3. neu van khong co thi thong bao chua co receipt de xem

UX hop ly:

- staff vua tao receipt xong co the preview ngay
- staff chon receipt cu cung preview duoc

## Giai thich sieu chi tiet `FrmDebtTracking.cs`

### Vai tro nghiep vu

Debt tracking la mat tong hop cua tai chinh.

No khong tao debt bang tay.

No:

- doc debt tu service
- tong hop
- loc
- chuyen tiep staff sang thu tien neu can

### `LoadFilterSources()`

Ham nay:

- lay course list
- lay class list
- nap vao 2 combobox
- chen item `Tat ca`
- set khoang ngay mac dinh tu dau nam den hom nay

No la bo loc mac dinh kha hop ly cho xem cong no.

### `LoadDebtData()`

Flow:

1. chuyen `Tat ca` thanh `null`
2. goi `GetDebtList(...)`
3. bind vao grid
4. an cot `EnrollmentId` neu co
5. cap nhat summary card
6. cap nhat label updated at
7. cap nhat footer tong so ho so

No la man tong hop read-only co hanh dong tiep noi.

### `UpdateSummaryCards()`

Summary card tinh:

- tong ho so cong no
- tong tien no
- so luong due soon/qua han

Chi tiet hay:

- service tra bang chi tiet
- UI van tu tinh them KPI nho bang LINQ tren `DataTable`

### `OpenReceiptFromDebt()`

Flow:

1. lay row debt dang chon
2. lay `studentId`
3. lay `enrollmentId`
4. mo `FrmTuitionReceipt(enrollmentId, studentId)`
5. dong form receipt xong thi load lai debt

No cho thay:

- debt tracking khong sua debt truc tiep
- no dua staff den man thu tien dung ngu canh

### Export

`ExportDebtExcel()` va `ExportDebtPdf()` cho thay:

- staff flow khong chi xem
- con phai xuat bao cao ra file

No goi `ExportFileHelper`.

Tuc la folder staff van lien he folder core/helper.

## `FrmStaffDashboard.cs`

### Vai tro

Day la shell staff.

No:

- to menu ben trai
- to topbar
- to KPI card
- to recent receipt grid
- to task card
- mo child form trong content host

### Constructor

Flow:

1. nhan current user name
2. `InitializeComponent()`
3. `ConfigureShellSurface(...)`
4. `ApplyShellStyling()`
5. `BindDashboardData()`
6. `BuildTaskCards()`
7. `BuildWeeklyProgressGrid()`
8. `ShowDashboardHome()`

### `ApplyShellStyling()`

Ham nay rat day dac.

No xu ly:

- mau nen shell
- do rong sidebar
- chieu cao topbar
- topbar avatar
- style menu button
- style recent receipts grid
- style KPI accent
- gan event menu
- responsive layout

Ban chat:

- dashboard staff khong phai form CRUD
- no la form shell + navigation

### `BindDashboardData()`

No lay:

- `GetStaffDashboardStats()`
- `GetDebtList()`
- `GetRecentReceipts()`

roi do vao:

- KPI so hoc vien moi
- KPI lop active
- KPI receipts
- KPI debt count
- grid recent receipts

### `OpenModule(...)`

Day la helper cua dashboard shell.

No:

- doi title topbar
- log UI
- bat wait cursor
- tao child form
- mo child form vao `pnlContentHostStaff`
- set active menu

Neu loi:

- log UI
- log file
- thong bao cho user
- giu nguyen dashboard

Day la mau shell rat dang hoc.

## Moi quan he giua cac form trong folder

`FrmStaffDashboard`

- mo `FrmStudentManagement`
- mo `FrmTeacherManagement`
- mo `FrmCourseManagement`
- mo `FrmClassManagement`
- mo `FrmEnrollment`
- mo `FrmTuitionReceipt`
- mo `FrmDebtTracking`

`FrmStudentManagement`

- mo `FrmEnrollment`

`FrmClassManagement`

- mo `FrmEnrollment`

`FrmEnrollment`

- mo `FrmTuitionReceipt`

`FrmDebtTracking`

- mo `FrmTuitionReceipt`

Day la chuoi navigate chinh cua staff.

## Ban chat nghiep vu cua folder staff

Cum folder nay day mot bai hoc lon:

Staff khong song tren 1 object.

Staff song tren chain nghiep vu.

Chain do la:

- tao/sua student
- mo khoa hoc/lop
- tao enrollment
- thu hoc phi
- quay lai debt neu con no

## Phu luc chung cho nguoi moi

### Cac tu khoa staff flow

- `Dashboard` = man tong quan va dieu huong.
- `CRUD` = create, read, update, delete.
- `Enrollment` = ghi danh hoc vien vao lop.
- `Receipt` = phieu thu.
- `Debt` = cong no con lai.
- `Soft delete` = xoa mem.
- `Summary` = thong tin tong hop.
- `Context` = ngu canh du lieu hien tai.

### Goc nhin du lieu

- Student khong vao thang receipt.
- Student di qua enrollment.
- Class khong thu tien.
- Receipt thu tien theo enrollment.
- Debt la phan tong hop tu receipt va hoc phi.
- Course la template.
- Class la phien ban mo cua course.

### Goc nhin UI

- Dashboard la shell.
- Child form la module nghiep vu.
- Grid la noi chon du lieu.
- Summary box la noi tom tat du lieu da chon.
- ErrorProvider la noi bao loi nhap lieu.
- MessageBox la noi thong bao ket qua.

### Goc nhin validation

- Student can field bat buoc.
- Enrollment can student + class hop le.
- Enrollment phai check duplicate.
- Enrollment phai check available slot.
- Receipt phai check amount > 0.
- Receipt phai check khong vuot cong no.

### Goc nhin relationship

- `StudentId` noi student.
- `ClassId` noi class.
- `EnrollmentId` noi receipt/debt/attendance/score.
- `CourseId` noi class vao khoa hoc.
- `TeacherId` noi class vao giao vien.

### Goc nhin responsive

- Staff dashboard co responsive shell.
- Student form co responsive filter + split.
- Receipt form co responsive layout.
- Enrollment form tu dung lai bang code.

### Goc nhin helper

- `AppTheme` lo style.
- `FormHostHelpers` lo shell/module.
- `ExportFileHelper` lo xuat file.
- `ErrorLogger` lo log loi.
- `AppRuntime.DataService` lo nghiep vu.

### Cach doc 1 form staff

- tim constructor.
- tim `ConfigureView`.
- tim `LoadData`.
- tim `WireEvents`.
- tim ham save.
- tim ham open form ke.
- tim field `_current...` va `_selected...`.

### Cach debug form staff

- grid rong: xem service tra `DataTable`.
- button mo khoa: xem event `Click`.
- summary sai: xem ham `UpdateSelected...`.
- tien sai: xem `ParseMoney` va `Recalculate`.
- khong mo receipt: xem `_currentEnrollmentId`.
- export fail: xem `ExportFileHelper`.

### Dinh huong hoc tiep

- muon hieu student sau hon: doc file `30-*student*`.
- muon hieu course/class sau hon: doc `22-*course*` va `23-*class*`.
- muon hieu ghi danh, can tao file sieu chi tiet rieng cho `FrmEnrollment`.
- muon hieu thu hoc phi, can tao file sieu chi tiet rieng cho `FrmTuitionReceipt`.

## Ket thuc folder 04

Folder `Forms/Staff` la folder day nhat nghiep vu van hanh.

Neu doc chac folder nay,

ban se hieu:

- du lieu vao app tu dau
- hoc vien duoc gan vao lop ra sao
- tien duoc thu tren ghi danh nhu the nao
- cong no duoc tong hop tu dau
