# Folder guide sieu chi tiet: `TrungTamNgoaiNgu.Domain` va `TrungTamNgoaiNgu.Application` phan nen tang

## Muc tieu cua file nay

File nay day nguoi moi:

- Domain entity la gi
- Enum dung de lam gi
- Contract/service interface giu vai tro nao
- DbContext la gi
- Password hash chay ra sao
- Infrastructure helper giu app bang cach nao
- Model nho dung de dong goi du lieu ra sao

Day la tang duoi UI.

Neu UI la mat truoc cua quan ly trung tam,

thi folder nay la:

- xuong song
- loat the du lieu
- hop dong lam viec
- quy tac du lieu can ban

## Folder scope

`TrungTamNgoaiNgu.Domain` gom:

- `Entities/AccountEntity.cs`
- `Entities/TeacherEntity.cs`
- `Entities/StudentEntity.cs`
- `Entities/ScoreEntity.cs`
- `Entities/ReceiptEntity.cs`
- `Entities/EnrollmentEntity.cs`
- `Entities/CourseEntity.cs`
- `Entities/ClassEntity.cs`
- `Entities/AttendanceEntity.cs`
- `Enums/AccountStatus.cs`
- `Enums/AccountRole.cs`

`TrungTamNgoaiNgu.Application` phan nen tang gom:

- `Contracts/ILanguageCenterDataService.cs`
- `Data/LanguageCenterDbContext.cs`
- `Security/PasswordHasher.cs`
- `Infrastructure/AppPaths.cs`
- `Infrastructure/ErrorLogger.cs`
- `Localization/LanguageCenterValueMapper.cs`
- `Configuration/LanguageCenterDatabaseConfiguration.cs`
- `Configuration/LanguageCenterDatabaseOptions.cs`
- `Repositories/IAccountRepository.cs`
- `Models/*.cs`

Toi khong dua `Services` vao file nay.

Ly do:

- `Services` da duoc tach sang file folder rieng
- tang service can doc nhieu logic SQL hon

## Cach nghi ve Domain

Domain la "ngon ngu nghiep vu" cua he thong.

Neu nhin app nay nhu mot trung tam ngoai ngu that,

thi domain chinh la tap cau hoi:

- hoc vien la gi
- giao vien la gi
- lop la gi
- khoa hoc la gi
- ghi danh la gi
- phieu thu la gi
- diem danh la gi
- diem so la gi

Entity la hinh dang code cua nhung khai niem do.

## Cach nghi ve Application phan nen tang

Application layer phan nay khong phai UI.

No la lop:

- noi UI voi domain
- giu helper
- giu contract
- giu mapping gia tri
- giu context DB

## Giai thich sieu chi tiet `AccountRole.cs`

Enum `AccountRole` thuong la tap gia tri dong.

Neu co cac muc:

- `Admin`
- `Staff`
- `Teacher`

thi y nghia la:

- code muon rang role phai thuoc 1 tap da biet truoc
- tranh viec role la string tu do de viet sai chinh ta
- de `switch` hoac `if` tren role an toan hon

Tai sao enum tot hon string trong truong hop nay:

- `Adminn` se compile fail neu viet sai ten enum
- con `"Adminn"` la string sai nhung compiler khong biet

## Giai thich sieu chi tiet `AccountStatus.cs`

Enum status thuong giup:

- biet tai khoan active hay inactive
- bat/tat login
- hien trang thai tren UI

Neu login check `Status == Active`,

thi role dung ma status khoa van khong vao duoc.

Day la lop bao ve rieng.

## Cac entity can duoc doc nhu the nao

Nguoi moi thuong thay entity va bao:

"chi la bo property"

Noi vay nua dung nua sai.

Dung o cho:

- no thuong nhieu property
- no thuong khong co nhieu logic phuc tap

Sai o cho:

- property nao co mat cung mang nghia nghiep vu
- ten property quyet dinh cach toan bo app noi ve du lieu
- kieu du lieu cua property quyet dinh validation va mapping

## `AccountEntity.cs`

Khi doc `AccountEntity`, hay hoi:

- ma tai khoan luu o dau
- username la string hay khong
- password luu plain text hay hash
- role la enum hay string
- status la enum hay string
- created/updated co khong
- isDeleted co khong

Neu thay `PasswordHash`,

do la dau hieu tot.

Vi:

- khong luu password tho
- chi luu ket qua hash

Neu thay `Role` la enum,

do la dau hieu code muon role chat che.

## `StudentEntity.cs`

Entity hoc vien thuong gom:

- `Id`
- `FullName`
- `BirthDate`
- `Phone`
- `Email`
- `Address`
- `AvatarPath`
- `Status`
- `CreatedAt`
- `UpdatedAt`
- `IsDeleted`

Moi property co nghia:

- `Id` la khoa nghiep vu
- `FullName` la ten hien thi
- `BirthDate` la ngay sinh that
- `Phone` la lien he
- `Email` la lien he va co the dung cho thong bao
- `Address` la dia chi
- `AvatarPath` la noi luu duong dan anh, khong phai bytes anh
- `Status` la trang thai hoc tap
- `CreatedAt` la moc tao
- `UpdatedAt` la moc sua
- `IsDeleted` la co xoa mem hay chua

## `TeacherEntity.cs`

Entity giao vien thuong bo sung:

- `Specialization`
- `Gender`
- `AccountId`

`AccountId` quan trong.

Vi:

- user dang login bang account
- nhung nghiep vu teaching can teacher profile
- can cau noi tu account sang teacher

## `CourseEntity.cs`

Khi doc course, hay nhin:

- `Name`
- `Description`
- `TuitionFee`
- `Status`

O du an nay, `Description` dang gan them phan level o UI.

Do la quyet dinh thiet ke quan trong.

Vi:

- DB co ve chua co cot level rieng
- UI phai ghep level vao description

## `ClassEntity.cs`

Lop hoc la noi giao nhau cua:

- course
- teacher
- lich hoc
- phong hoc
- si so
- thoi gian mo dong

Day la entity de nhin thay nghiep vu phong phu hon.

## `EnrollmentEntity.cs`

Ghi danh la entity lien ket:

- student
- class

No thuong co:

- `EnrollDate`
- `Status`
- `Note`

No rat quan trong vi:

- receipt thuong gan theo enrollment
- diem danh va diem so thuong cung quy ve enrollment

## `ReceiptEntity.cs`

Phieu thu gom:

- `EnrollmentId`
- `AmountPaid`
- `PayDate`
- `PaymentMethod`
- `Note`
- `CreatedByStaffId`

Chi tiet quan trong:

- phieu thu khong can luu studentId truc tiep neu da co enrollment
- tu enrollment co the truy nguoc student va class

## `AttendanceEntity.cs` va `ScoreEntity.cs`

Hai entity nay la du lieu lop hoc theo thoi gian.

Attendance thuong mo ta:

- hoc vien nao trong lop
- ngay nao
- co mat hay vang
- ghi chu gi

Score thuong mo ta:

- hoc vien nao trong lop
- diem giua ky
- diem cuoi ky
- ghi chu gi

## `ILanguageCenterDataService.cs` la hop dong lon nhat

Interface nay noi ro tat ca UI duoc phep doi service lam gi.

Nhin vao interface nay,

co the doc duoc toan bo kha nang chinh cua he thong:

- authenticate
- tao ma tiep theo
- lay list
- lay dashboard stats
- lay entity theo id
- save student/teacher/course/class
- soft delete
- ghi danh
- thu hoc phi
- luu attendance
- luu score
- save avatar
- export script

Day la ly do interface nay rat quan trong.

No giong menu dich vu cua toan app.

### Cach doc 1 method trong interface

Vi du:

`StudentEntity SaveStudent(StudentEntity student);`

Hay tach nhu sau:

- dau vao la `StudentEntity`
- dau ra la `StudentEntity`
- nghia la service co the sua/chuan hoa object roi tra lai

`DataTable GetStudentList(string? keyword = null, string? status = null);`

Hay tach:

- UI se nhan `DataTable`
- co bo loc tu khoa
- co bo loc trang thai
- hai bo loc co the bo trong

`void SaveAttendance(string classId, DateTime attendanceDate, IEnumerable<AttendanceSaveItem> items);`

Hay tach:

- can ma lop
- can ngay diem danh
- can tap item diem danh
- service khong tra du lieu ve
- nghia la no ghi va ket thuc

## `IAccountRepository.cs`

Interface repository nho hon interface service.

Day la hop dong o muc hep:

- connect duoc khong
- tim account active theo username
- lay next id
- list account
- save account
- toggle status
- reset password

No cho thay mot mau kien truc:

- service rong hon
- repository hep hon
- repository lo 1 loai du lieu

## `LanguageCenterDbContext.cs`

DbContext la cua EF Core.

Nguoi moi co the hieu:

- day la ban do noi object C# voi bang database

Thuong no co:

- `DbSet<AccountEntity>`
- `DbSet<StudentEntity>`
- `DbSet<TeacherEntity>`
- ...

Va mot cho `OnModelCreating(...)`.

### `DbSet<T>` la gi

`DbSet<T>` giong nhu cong vao bang.

Vi du:

- `DbSet<StudentEntity>` la cong vao bang hoc vien
- `DbSet<CourseEntity>` la cong vao bang khoa hoc

Qua do:

- query
- add
- update
- delete

### `OnModelCreating(...)`

No la noi:

- dat key
- dat ten bang
- dat do dai chuoi
- dat relation
- dat precision

Neu entity la hinh dung nghiep vu,

thi `OnModelCreating` la ban do ky thuat de DB hieu nghiep vu do.

## `PasswordHasher.cs`

Day la file bao ve password.

Neu thay:

- `SHA256`
- `UTF8`
- `Verify`

thi no dang lam 2 viec:

- bien password nguoi dung nhap thanh hash
- so hash vua tao voi hash luu san

Chi tiet quan trong:

- app khong nen so password plain text
- app hash lai password user vua nhap
- sau do so hash voi hash trong DB

## `AppPaths.cs`

File nay giong bo quy tac duong dan.

No giup:

- biet log nam o dau
- biet images nam o dau
- biet export nam o dau

Neu khong co file nay:

- moi noi co the tu che duong dan
- project de rot duong dan cung
- kho doi cau truc luu tru

## `ErrorLogger.cs`

Day la file cuu mang debug.

No thuong lam:

- mo file log
- append thong tin
- ghi context
- ghi stack trace

Nguoi moi nen nho:

- `MessageBox` la cho user
- `ErrorLogger` la cho dev

## `LanguageCenterValueMapper.cs`

File nay rat hay bi bo qua.

No thuong dung de:

- doi enum sang text UI
- doi text UI nguoc lai
- map gia tri stored sang gia tri hien thi

Vi du:

- `Present` sang `Co mat`
- `Absent` sang `Vang`

No giup tranh viec moi form tu dich moi cach khac nhau.

## `LanguageCenterDatabaseConfiguration.cs`

File nay thuong doc config DB.

Nhin ten file da thay 3 y:

- no khong query nghiep vu
- no lo cau hinh ket noi
- no la tang infrastructure/config

Nguoi moi can doc ky:

- chuoi ket noi lay tu dau
- fallback gi
- option co default gi

## `LanguageCenterDatabaseOptions.cs`

Options class thuong la object nho chua:

- server
- database
- username
- password
- trusted connection
- file path

No giong hop chua gia tri config da duoc parse.

## `Models/*.cs`

Khac voi `Entities`.

Entity:

- la nghiep vu chinh
- thuong map manh hon voi DB

Model nho:

- la object phu de trao doi du lieu
- thuong dung cho dashboard, report, save form

Vi du:

- `AttendanceSaveItem`
- `ScoreSaveItem`
- `DashboardStats`
- `TeacherDashboardStats`
- `ReportPoint`
- `ReceiptPrintInfo`
- `EnrollmentReceiptContext`

## `AttendanceSaveItem.cs`

Model nay nho nhung rat dung cho teaching flow.

No gom:

- `EnrollmentId`
- `Status`
- `Note`

Tai sao khong gui ca `StudentEntity`?

Vi:

- save attendance khong can full student
- service chi can khoa enrollment va trang thai
- object nho hon va ro muc dich hon

## `ScoreSaveItem.cs`

Model nay gom:

- `EnrollmentId`
- `MidtermScore`
- `FinalScore`
- `Note`

Hai diem de y:

- diem co the nullable
- user co the chua nhap diem

## `DashboardStats.cs` va `TeacherDashboardStats.cs`

Hai model nay giup UI dashboard:

- khong phai tu tinh tong tung bang
- service tinh san
- UI chi bind ra label

No giong "goi KPI dong san".

## `ReportPoint.cs`

Model nay thuong dung cho chart.

No thuong gom:

- nhan truc X
- gia tri truc Y

Day la cau noi tu service sang chart control.

## Quan he giua cac file nay

Entity la hat nhan.

DbContext map entity vao DB.

Service interface mo ta nhung nghiep vu tren entity.

Model nho dong goi request/response phu.

Infrastructure giup:

- log
- path
- config

Security giup hash password.

Localization/value mapper giup doi text ky thuat sang text UI.

## Sai lam nguoi moi thuong gap

Sai lam 1:

Tuong entity va model la mot.

Khong phai luc nao cung vay.

Sai lam 2:

Tuong interface la code thua.

Sai.

Interface cho thay hop dong va giup doi implementation.

Sai lam 3:

Tuong DbContext la database.

Sai.

No la object C# dai dien map.

Sai lam 4:

Tuong hash password la ma hoa 2 chieu.

Sai.

Hash dung de so sanh, thuong khong giai nguoc.

Sai lam 5:

Tuong model nho khong quan trong.

Sai.

Model nho thuong la cau truc du lieu chuan de UI va service noi chuyen.

## Phu luc chung cho nguoi moi

### Khai niem tang kien truc

- `UI` la noi user nhin thay.
- `Application` la noi dieu phoi nghiep vu.
- `Domain` la ngon ngu nghiep vu cot loi.
- `Infrastructure` la log, file, config, DB support.
- `Repository` la lop truy cap du lieu hep.
- `Service` la lop xu ly nghiep vu rong hon.
- `Contract` la hop dong.
- `Model` la object trao doi du lieu phu.
- `Entity` la object nghiep vu chinh.
- `Enum` la tap gia tri co ten.

### Khai niem property/entity

- `Id` thuong la khoa nghiep vu.
- `CreatedAt` la moc tao.
- `UpdatedAt` la moc sua.
- `IsDeleted` la co xoa mem hay khong.
- `Status` thuong la trang thai nghiep vu.
- `Note` la ghi chu tu do.
- `AvatarPath` la duong dan, khong phai file bytes.
- `AccountId` la khoa noi tu account sang profile.
- `CourseId` la khoa noi tu lop sang khoa hoc.
- `TeacherId` la khoa noi tu lop sang giao vien.
- `EnrollmentId` la khoa noi tu diem/thu/diem danh sang ghi danh.

### Khai niem DB va EF

- `DbContext` la session lam viec voi DB.
- `DbSet<T>` la cua vao bang.
- `Key` la khoa chinh.
- `Foreign key` la khoa ngoai.
- `Required` la khong duoc null.
- `MaxLength` la gioi han do dai.
- `Precision` la do chinh xac so thap phan.
- `ToTable` dat ten bang.
- `HasIndex` tao index.
- `HasOne/WithMany` mo ta quan he.

### Khai niem password

- Password plain text la text user go.
- Password hash la ket qua bam 1 chieu.
- `Verify` la hash lai roi so.
- Hash khong phai encrypt 2 chieu.
- Khong nen luu password plain text.

### Khai niem config

- Config tach khoi code de de doi moi truong.
- Option class giu config da parse.
- Helper config doc xong moi tra object strongly typed.
- Duong dan file nen co helper trung tam.
- Log path nen co mot noi quy dinh.

### Khai niem model nho

- Model nho thuong cho 1 man hinh cu the.
- No khong can map 1-1 sang bang DB.
- No co the chi gom 2-4 field.
- No giup method signature ro rang hon.
- No giup UI khong phai gui ca object lon.

### Cach doc interface

- Doc ten method.
- Doc tham so.
- Doc kieu tra ve.
- Doan method nao tra `void` thi no chu yeu gay side effect.
- Doan method nao tra entity thi no co the vua luu vua tra ket qua moi.
- Doan method nao tra `DataTable` thi no nham toi grid/combo binding.
- Doan method nao tra `IReadOnlyList` thi no nham toi list typed.

### Cach doc 1 entity

- Nhom field nhan dien.
- Nhom field quan he.
- Nhom field nghiep vu.
- Nhom field audit.
- Nhom field xoa mem.
- Nhin field nao nullable.
- Nhin field nao enum.
- Nhin field nao `decimal`.
- Nhin field nao `DateTime`.
- Nhin field nao la string ma dang giu status.

### Cach doc 1 model save item

- Tim khoa chinh nghiep vu.
- Tim field user duoc sua.
- Tim field optional.
- Tim field note.
- Tim service nao nhan model do.

### Cach doc 1 helper infrastructure

- Xem helper do co state hay khong.
- Xem helper do co static khong.
- Xem helper do co dong vao file he thong khong.
- Xem helper do co the nem exception khong.
- Xem helper do co duoc goi khap du an khong.

## Ket thuc folder 02

Sau file nay, ban thuong da du kien thuc de doc folder `Services`.

Vi:

- da biet object nghiep vu la ai
- da biet interface muon lam gi
- da biet DB context map ra sao
- da biet model phu giup UI noi chuyen ra sao
