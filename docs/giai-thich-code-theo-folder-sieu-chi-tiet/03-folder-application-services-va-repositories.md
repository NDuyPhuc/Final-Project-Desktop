# Folder guide sieu chi tiet: `TrungTamNgoaiNgu.Application/Services` va `Repositories`

## Muc tieu cua file nay

File nay day:

- repository giai quyet viec gi
- service giai quyet viec gi
- offline service khac SQL service ra sao
- demo service thuc chat la gi
- vi sao `SqlLanguageCenterDataService` la trai tim nghiep vu cua app

Neu `Domain` la tap tu vung,

thi `Services` la noi ghep cau va hanh dong.

## Scope file

Cum nay gom:

- `Repositories/IAccountRepository.cs`
- `Repositories/SqlAccountRepository.cs`
- `Services/OfflineLanguageCenterDataService.cs`
- `Services/DemoLanguageCenterDataService.cs`
- `Services/SqlLanguageCenterDataService.cs`

## Cach nghi ve repository va service

Repository thuong hep hon service.

Repository:

- lo 1 tap bang/1 loai du lieu
- query va save o muc ky thuat hon

Service:

- lo nghiep vu rong hon
- ghep nhieu repository/bang/logic
- tra data cho UI theo dung hinh dang can dung

## `IAccountRepository.cs`

Interface nay la hop dong cap hep cho account.

Method trong do cho thay:

- connect kiem tra duoc hay khong
- tim account active theo username
- lay next id
- list account
- save account
- toggle status
- reset password

Nguoi moi nen so voi `ILanguageCenterDataService`.

Se thay:

- service rong hon nhieu
- repository la mot manh nho ben duoi

## `SqlAccountRepository.cs`

File nay la implementation SQL cua repository.

Neu doc file nay,

hay tim cac cum:

- connect string
- command
- parameter
- select
- insert/update
- map reader thanh entity

Ban chat:

- day la noi query tai khoan gan DB that hon
- service o tren co the goi repository nay de authenticate hoac quan ly account

## `DemoLanguageCenterDataService.cs`

File nay cuc ngan.

Do la chi tiet thiet ke hay.

Neu no chi ke thua `SqlLanguageCenterDataService` ma khong override gi,

thi y nghia co the la:

- ten class nay de danh dau ngu canh demo
- hien tai no van xai logic SQL goc
- tuong lai co the them override

Nguoi moi rat hay nham file ngan la vo nghia.

Khong dung.

No co the la diem moc kien truc.

## `OfflineLanguageCenterDataService.cs`

Day la phao cuu sinh cua app.

Khi SQL loi,

app van co the chay nhung bang data trong bo nho.

### Tai sao file nay ton tai

- tranh app mo len roi vo ngay
- tranh nguoi demo bi ket
- tranh nguoi hoc mat moi truong thuc hanh

### Dau hieu nhan biet service offline

- dung `List<T>` trong RAM
- seed san vai account, student, teacher, class
- nhieu method tra `DataTable` tu list
- save/update la sua truc tiep list trong memory

### Khoi constructor seed du lieu

Khi thay:

- `var now = DateTime.Now`
- `_accounts = [ ... ]`
- `_students = [ ... ]`
- `_teachers = [ ... ]`
- `_courses = [ ... ]`
- `_classes = [ ... ]`
- `_enrollments = [ ... ]`
- `_receipts = [ ... ]`

thi ban chat la:

- service dang tao database gia trong RAM
- moi object seeded la mot ban ghi demo
- login demo co san la nhung account nay

### Tai sao password van hash trong offline

Vi:

- du offline nhung van muon giu flow authenticate giong that
- UI va service khong phai doi logic vi moi truong

### `EnsureDatabaseReady()` rong

Trong offline mode,

khong co DB that de khoi tao.

Nen method nay co the rong.

Nhung no van ton tai vi interface bat buoc.

Day la suc manh cua interface:

- cung mot hop dong
- moi implementation tu thuc hien cach rieng

### `Authenticate(...)` trong offline

Method nay thuong:

- loc account khong bi xoa
- loc account active
- so username khong phan biet hoa thuong
- verify password hash

No cho thay login flow khong doi du online hay offline.

### `GetNextXxxId()`

Nhung method nay rat dang hoc.

Vi no cho thay app co quy tac sinh ma:

- `TK` cho account
- `HV` cho hoc vien
- `GV` cho giao vien
- `KH` cho khoa hoc
- `LP` cho lop
- `GD` cho ghi danh
- `PT` cho phieu thu

Neu doc method sinh ma,

hay hoi:

- no tach phan so ra sao
- no tim max hien tai ra sao
- no pad so 0 o dau hay khong

### `SaveAccount(...)`

Day la mau insert/update trong service offline.

Thuong flow la:

1. tim account cu theo id
2. neu id rong thi cap id moi
3. neu password hash rong thi set default
4. neu chua ton tai thi add vao list
5. neu da ton tai thi update field tung cai

Nguoi moi nen hoc mau nay.

Vi no xuat hien nhieu o CRUD.

### `ToggleAccountStatus(...)`

Method nay hay o cho:

- khong xoa account
- chi dao qua dao lai active/inactive

No cho thay nghiep vu muon khoa mo mem.

### `ResetAccountPassword(...)`

Method nay:

- tim account
- hash password moi
- cap nhat updated time

No cho thay service co the chua logic an toan, UI khong can biet cach hash.

### Cac method tra `DataTable`

Offline service tra `DataTable` rat nhieu.

Tai sao khong tra `List<T>` cho UI?

Vi:

- WinForms grid/combo hop DataTable
- ten cot UI muon hien thi bang tieng Viet
- DataTable linh hoat de dung voi nhieu man hinh

### Cac method save student/teacher/course/class

Dung nhin chung nhu "CRUD cho co".

Moi method thuong phai lo:

- id moi hay id cu
- createdAt/updatedAt
- isDeleted
- data default
- relation hop le

### `SoftDelete...`

Xoa mem la quy tac lap lai.

No giup:

- giu lich su
- tranh mat lien ket receipt/enrollment
- an toan hon xoa cung

### `SaveAttendance(...)`

Method nay trong offline mode thuong khong can DB.

Nhung no van phai:

- nhan classId
- nhan ngay
- nhan danh sach item
- luu ket qua vao bo nho nao do

Ban chat:

- interface la mot
- implementation thay doi

### `SaveScores(...)`

Tuong tu attendance.

Chi khac field luu la diem so.

### `SaveStudentAvatar(...)` va `SaveTeacherAvatar(...)`

Ca 2 method nay thuong:

- nhan duong dan anh nguon
- copy vao thu muc images cua app
- tra ve path tuong doi hoac tuyet doi

No cho thay service khong chi lo DB.

No con lo file system.

## `SqlLanguageCenterDataService.cs`

Day la file lon nhat va nang nhat.

No la dong co nghiep vu trung tam.

Nhin ten method trong `ILanguageCenterDataService`,

gan nhu method nao quan trong cung phai co o `SqlLanguageCenterDataService`.

### Cach doc file sieu dai nay

Khong doc tu dong 1 den dong cuoi trong 1 hoi.

Hay chia cum:

1. khoi tao va database ready
2. authenticate va account
3. list cho UI
4. dashboard/report
5. CRUD student/teacher/course/class
6. enrollment/receipt
7. attendance/score
8. avatar/export

### Cum khoi tao

Thuong co:

- db config
- db context
- ensure created/seed

Day la cum tra loi "service SQL dung ket noi nao va chuan bi DB ra sao".

### Cum authenticate

Thuong co:

- tim account theo username
- check status
- verify password hash

Y nghia:

- login UI chi can goi 1 method
- moi logic account hop le nam o service/repository

### Cum list cho UI

Nhom method tra `DataTable` la noi rat quan trong voi WinForms:

- `GetStudentList`
- `GetTeacherList`
- `GetCourseList`
- `GetClassList`
- `GetClassStudents`
- `GetSessions`
- `GetReceiptHistory`
- `GetDebtList`
- `GetAttendanceList`
- `GetScoreList`

No la vung bridge:

- DB entity o duoi
- DataGridView o tren

Service phai:

- query
- loc
- join
- map ten cot de user de doc

### Tai sao ten cot DataTable hay la tieng Viet

Vi UI muon hien:

- `Ma lop`
- `Ten lop`
- `Trang thai`

thay vi:

- `ClassId`
- `ClassName`
- `Status`

Service dang chuyen tu ngon ngu code sang ngon ngu nguoi dung.

### Cum dashboard

Method nhu:

- `GetAdminDashboardStats()`
- `GetStaffDashboardStats()`
- `GetTeacherDashboardStats(...)`

co vai tro:

- tong hop nhanh
- de UI khong tu tinh
- de dashboard mo nhanh va ro trach nhiem

### Cum report

Method nhu:

- `GetMonthlyRevenue(...)`
- `GetMonthlyEnrollmentCounts(...)`
- `GetReportDetail(...)`

thuong phai lo:

- khoang ngay
- group theo thang
- sum doanh thu
- dem ghi danh
- tra `ReportPoint` cho chart
- tra `DataTable` cho grid chi tiet

### Cum CRUD hoc vien

Method `SaveStudent(...)` thuong:

- validate id neu can
- insert neu chua co
- update neu da co
- giu createdAt
- doi updatedAt

Method `GetStudentById(...)` thuong:

- query bang student
- bo qua ban ghi xoa mem

Method `SoftDeleteStudent(...)` thuong:

- khong xoa row khoi DB
- set `IsDeleted`
- cap nhat time neu can

### Cum CRUD giao vien

Tuong tu hoc vien.

Nhung co them:

- `AccountId`
- `Specialization`
- `AvatarPath`

### Cum CRUD khoa hoc

Can chu y:

- hoc phi la `decimal`
- status co the string
- description co the bi UI nhung level vao

### Cum CRUD lop

Can chu y hon vi lop lien quan:

- course
- teacher
- start/end date
- room
- max students

Day la noi service phai kiem tra relation hop le.

### Cum enrollment

Method `CreateEnrollment(...)` thuong la flow ghep:

- check student ton tai
- check class ton tai
- check da ghi danh chua
- check lop con slot khong
- tao enrollment

Day la nghiep vu that su, khong con la CRUD don gian.

### `StudentAlreadyEnrolled(...)`

Method nay la guardian.

No tranh:

- 1 hoc vien vao 1 lop 2 lan

### `ClassHasAvailableSlot(...)`

Method nay so:

- si so toi da
- so enrollment dang active

Day la quy tac suc chua lop.

### Cum receipt

Method `SaveReceipt(...)` thuong:

- tao id neu can
- validate enrollment
- validate amount
- set payment method
- set createdByStaffId

No la cum tai chinh.

Method `GetReceiptPrintInfo(...)` tra model de in.

No cho thay service khong chi luu.

No con dong goi du lieu phuc vu in.

### Cum attendance

`SaveAttendance(...)` trong SQL service thuong can:

- map `AttendanceSaveItem`
- tim enrollment tuong ung
- ghi theo ngay
- update neu da co
- insert neu chua co

Nguy hiem thuong gap:

- luu trung cho cung 1 enrollment + 1 ngay

Nen service thuong phai co quy tac update-or-insert.

### Cum score

`SaveScores(...)` thuong can:

- map `ScoreSaveItem`
- luu midterm/final
- update neu da co
- validate khoang diem tu UI ho tro, nhung service co the van nen phong thu

### Cum avatar

`SaveStudentAvatar(...)` va `SaveTeacherAvatar(...)` trong SQL service thuong:

- tao thu muc neu chua co
- dat ten file
- copy file
- tra path luu

### Cum `ResolveAbsoluteImagePath(...)`

Method nay rat can cho UI.

Vi DB/service co the luu relative path.

UI thi can absolute path de `File.Exists` va `PictureBox` doc duoc.

### Cum export

`ExportDatabaseScript(string outputPath)` la bridge tu DB sang file script.

No thuong:

- goi helper export
- ghi file ra dia
- co the dump schema/data

## Quan he giua repository va service

Co the doc nhu sau:

- repository account lo account o muc hep
- service rong hon, lo toan trung tam
- service co the goi repository
- service co the dung thang DbContext o nhieu cho khac

## Khi nao doc `OfflineLanguageCenterDataService` truoc `SqlLanguageCenterDataService`

Nen doc offline truoc neu:

- ban moi vao du an
- ban muon thay nghiep vu ma khong bi SQL lam roi

Offline service la ban miniature.

SQL service la ban full scale.

## Khi nao doc `SqlLanguageCenterDataService` truoc

Nen doc SQL truoc neu:

- ban can sua bug that
- ban can biet UI dang query ten cot nao
- ban can biet report tinh sum ra sao

## Bai hoc kien truc quan trong cua folder nay

Bai hoc 1:

Interface truoc.

Implementation sau.

Bai hoc 2:

Offline va SQL cung mot hop dong.

Bai hoc 3:

UI chi biet `ILanguageCenterDataService`.

Bai hoc 4:

Service tra `DataTable` khi UI can grid.

Bai hoc 5:

Model nho duoc dung cho save flow de method signature ro rang hon.

## Phu luc chung cho nguoi moi

### Service thinking

- Service la noi ghep nhieu buoc nghiep vu.
- Repository thuong khong nen biet giao dien.
- UI thuong khong nen biet SQL string.
- Service la noi hop ly de check rule.
- Service giup UI gon hon.
- Service giup test nghiep vu de hon.
- Interface giup doi implementation de hon.

### CRUD khong phai luc nao cung don gian

- Create co the can sinh ma.
- Create co the can check trung.
- Update co the can giu `CreatedAt`.
- Delete co the la soft delete.
- Read list co the can join.
- Read detail co the can map model.

### Offline service day ta dieu gi

- list trong RAM cung la nguon du lieu hop le cho demo.
- rule nghiep vu co the giu nguyen du UI online/offline.
- interface giup doi nguon du lieu khong doi UI.

### SQL service day ta dieu gi

- nghiep vu that su thuong nam o service lon.
- method list cho UI rat hay tra `DataTable`.
- report la tong hop, khong phai CRUD tho.
- quan he entity lam service phuc tap hon.

### Rule thuong gap

- khong cho ghi danh trung.
- khong cho vuot si so.
- khong cho login tai khoan inactive.
- khong cho mat password plain text.
- khong xoa cung cac du lieu co lien ket tai chinh.

### DataTable trong service

- ten cot nen de UI de doc.
- schema on dinh giup form on dinh.
- doi ten cot co the vo form.
- list UI thuong phu thuoc manh vao ten cot.

### Model save item

- item nho de gui lo du lieu can thiet.
- it field hon entity lon.
- de UI build tu grid.
- de service luu loat ban ghi.

### Goc debug

- loi login: xem authenticate va password hasher.
- loi list khong hien: xem DataTable schema.
- loi image khong len: xem path relative/absolute.
- loi report sai tong: xem service sum/group.
- loi ghi danh trung: xem check duplicate.

### Cach doc method SQL lon

- tim input.
- tim query.
- tim mapping.
- tim guard.
- tim save changes.
- tim log neu co.
- tim ten cot DataTable tra ve.

## Ket thuc folder 03

File nay la tam do de sau do ban nhay vao `SqlLanguageCenterDataService` ma khong bi choang.

Neu can hoc sau hon nua,

hay doc song song voi 3 file da co san:

- `12-sql-service-part-1-line-by-line.md`
- `13-sql-service-part-2-line-by-line.md`
- `14-sql-service-part-3-line-by-line.md`
