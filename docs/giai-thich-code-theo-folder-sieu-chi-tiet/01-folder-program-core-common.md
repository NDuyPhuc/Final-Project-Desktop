# Folder guide sieu chi tiet: `Trung-tam-quan-ly-ngoai-ngu/Program.cs`, `Core`, `Forms/Common`

## Muc tieu cua file nay

File nay dung de day nguoi moi chua biet gi ve:

- diem vao cua app nam o dau
- form WinForms duoc khoi tao ra sao
- `Core` giu helper va runtime nhu the nao
- `Forms/Common` dong vai tro gi trong toan bo du an

File nay chia theo folder va theo luong chay.

Khong chi noi "dong nay lam gi".

No con noi:

- cu phap C# cua dong do la gi
- runtime WinForms se xu ly ra sao
- nghiep vu ung dung can dong do vi ly do nao
- neu bo dong do thi thuong se vo o dau

## Pham vi folder

Cum nay gom:

- `Trung-tam-quan-ly-ngoai-ngu/Program.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Core/AppRuntime.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Core/AppTheme.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Core/UiHelpers.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Core/ExportFileHelper.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Common/BaseForms.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Common/FrmLogin.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Common/FrmSidebarPreview.cs`

Toi khong di vao `bin` va `obj`.

Ly do:

- do la build artifact
- do khong phai source nguoi thuong sua
- do khong phai noi nghiep vu cua app dang song

## Ban do luong chay tong quat

Neu chay app tu dau den cuoi, luong chay thuong la:

1. Windows goi `Main()` trong `Program.cs`.
2. `Program.cs` bat giao dien WinForms.
3. `Program.cs` tao `DataService`.
4. `Program.cs` goi `AppRuntime.Initialize(...)`.
5. `Program.cs` gan global exception handler.
6. `Program.cs` mo `FrmLogin`.
7. `FrmLogin` nhan username va password.
8. `FrmLogin` goi `AppRuntime.DataService.Authenticate(...)`.
9. Neu dung, `FrmLogin` goi `AppRuntime.SetCurrentUser(...)`.
10. Sau do form dashboard tuong ung vai tro se mo ra.

## Cach doc cum folder nay

Thu tu doc de nhat:

1. `Program.cs`
2. `AppRuntime.cs`
3. `FrmLogin.cs`
4. `BaseForms.cs`
5. `AppTheme.cs`
6. `UiHelpers.cs`
7. `ExportFileHelper.cs`
8. `FrmSidebarPreview.cs`

Ly do:

- `Program.cs` tra loi "app bat dau o dau"
- `AppRuntime.cs` tra loi "service va user dang song o dau"
- `FrmLogin.cs` tra loi "user buoc vao he thong bang cach nao"
- `BaseForms.cs` tra loi "form trong du an co base chung hay khong"
- `AppTheme.cs` tra loi "style duoc dong bo bang cach nao"
- `UiHelpers.cs` tra loi "helper UI chay khap app la gi"
- `ExportFileHelper.cs` tra loi "xuat file dung helper nao"
- `FrmSidebarPreview.cs` tra loi "preview UI mau duoc lam ra sao"

## Inventory chi tiet theo file

### `Program.cs`

File nay la diem vao.

No giong cong tac tong cua ung dung.

Neu file nay hong:

- app khong mo
- logger co the khong gan
- fallback offline co the khong chay
- login co the khong xuat hien

### `Core/AppRuntime.cs`

File nay la runtime tam trung.

No giu:

- service toan cuc
- current user
- logic initialize 1 lan

No giong "noi treo state toan app".

### `Core/AppTheme.cs`

File nay la bo style chung.

No gom:

- mau
- font
- helper style button
- helper style card
- helper style grid

No giong bo quy tac thiet ke.

### `Core/UiHelpers.cs`

File nay thuong gom helper UI nho.

Vi du:

- canh le
- bo cuc
- helper tao control
- helper thao tac form

No giong hop do nghe UI.

### `Core/ExportFileHelper.cs`

File nay thuong la helper xuat file.

No dung khi:

- xuat CSV
- xuat script
- xuat noi dung ra dia

No giong cau noi tu object trong RAM ra file that.

### `Forms/Common/BaseForms.cs`

File nay co the la noi dat:

- base class cho form
- helper chung cho form
- rang buoc giao dien giong nhau

No giong bo xuong chung cho nhieu form.

### `Forms/Common/FrmLogin.cs`

File nay la cong vao he thong.

No xu ly:

- nhap username
- nhap password
- validate co ban
- goi authenticate
- mo dashboard dung vai tro

### `Forms/Common/FrmSidebarPreview.cs`

File nay nhieu kha nang la form phu de preview.

No giup:

- test layout
- xem sidebar
- kiem tra giao dien

No khong phai luong nghiep vu chinh.

## Giai thich sieu chi tiet `Program.cs`

### Cum dong import va khai bao

`Program.cs` thuong mo dau bang `using`.

Ban chat cua `using`:

- no khong chay nghiep vu
- no giup compiler tim type nhanh hon
- no giam canh phai viet ten day du cua class

Neu file co `using TrungTamNgoaiNgu.Application.Contracts;`

thi y nghia la:

- file nay can biet interface
- file nay khong muon troi chat vao implementation duy nhat
- file nay ton trong abstraction

Neu file co `using ... Infrastructure;`

thi y nghia la:

- file nay can logger
- file nay can helper duong dan
- file nay can utility tang ha tang

Neu file co `using ... Services;`

thi y nghia la:

- file nay se tao service that
- file nay se quyet dinh app dung online, offline, demo hay SQL

### Cum dong `namespace`

`namespace` la ho cua class.

No dung de:

- tranh trung ten
- sap xep code theo vung logic
- giup project lon bot roi

### Cum dong `static class Program`

`static class` nghia la:

- khong tao instance
- chi chua ham/field static
- dung nhu mot diem chay toan cuc

`Program` trong WinForms la ten rat quen.

No thuong chi chua `Main()`.

### Cum dong `[STAThread]`

Day la attribute.

No gan metadata len ham `Main()`.

Ban chat:

- WinForms va COM can apartment model phu hop
- clipboard, dialog, drag-drop va nhieu API UI can `STA`
- bo dong nay co the gay loi kho doan o mot so thao tac giao dien

### Cum dong `Main()`

`Main()` la ham dau tien duoc runtime .NET goi.

Khong co `Main()`, app desktop thuong khong biet bat dau tu dau.

Trong `Main()`, app thuong lam 4 viec:

- bat visual style
- cau hinh DPI
- tao service
- mo form dau tien

### `Application.SetHighDpiMode(...)`

Dong nay lien quan man hinh scale.

Neu may nguoi dung de 125 phan tram, 150 phan tram, 200 phan tram:

- control co the bi mo
- text co the bi nhoe
- khoang cach co the vo

High DPI mode giup app y thuc scale cua he thong.

### `Application.EnableVisualStyles()`

Neu bo dong nay:

- button
- textbox
- control

co the trong co dien hon.

No la lenh bat visual style cua Windows cho WinForms.

### `Application.SetCompatibleTextRenderingDefault(false)`

Dong nay thuong it nguoi moi hieu.

Ban chat:

- WinForms co nhieu che text rendering cu va moi
- dong nay chon che do mac dinh phu hop hon voi app hien tai

Nguoi moi khong can nho sau.

Chi can nho:

- day la cau hinh text rendering mac dinh
- no thuong duoc de sat `EnableVisualStyles()`

### Tao data service

Khi code viet `var dataService = new SqlLanguageCenterDataService();`

thi co 3 lop y nghia:

1. Lop ngon ngu.
   Day la tao object bang tu khoa `new`.

2. Lop kien truc.
   App muon nguon du lieu chinh la SQL Server.

3. Lop nghiep vu.
   Moi form ve sau se noi qua service nay de doc-ghi hoc vien, lop, thu hoc phi, diem danh, bao cao.

### `TryInitializeRuntime(dataService)`

Ham nay la lop bao ve som.

No giup:

- thu ket noi DB
- neu loi thi log
- neu can thi chuyen offline/demo

Ban chat:

- app khong vo ngay khi SQL co van de
- app co cach tu cuu nguoi dung

### Bat exception handler tong

Phan nay cuc quan trong.

Neu khong co:

- loi tren UI thread co the vang app
- nguoi dung mat form
- khong biet tim log o dau

Khi co:

- loi duoc ghi file
- user duoc thong bao
- kha nang debug cao hon

### `Application.Run(new FrmLogin(...))`

Day la dong mo lua chon cua so dau tien.

`Application.Run(...)` giu message loop cua WinForms song.

Neu form trong `Run(...)` dong:

- app thuong ket thuc

Neu mo `FrmLogin`:

- login la cua so goc cua session
- sau login moi quyet mo dashboard nao

## Giai thich sieu chi tiet `AppRuntime.cs`

`AppRuntime` la class static.

Nguoi moi co the hieu no la:

- mot cai tu dung do dung chung
- de bat ky form nao cung co the mo ra va lay do

Thu trong tu do gom:

- `DataService`
- `CurrentUser`

### Tai sao can `DataService` toan cuc

Neu khong co `AppRuntime.DataService`:

- moi form phai truyen service qua constructor lien tuc
- form cha lai truyen form con
- luong phu thuoc se dai va met

Khi co `AppRuntime`:

- form nho cung lay duoc service
- code gon hon
- doi lai la state toan cuc, can ky luat hon

### Tai sao `CurrentUser` nam o day

Vi rat nhieu noi can biet user dang dang nhap:

- teacher dashboard can biet teacher nao
- attendance can biet lop nao cua teacher do
- receipt can ghi ai tao phieu
- admin/staff menu can bat tat theo vai tro

### Guard khi chua initialize

Property `DataService` thuong check:

- neu `_dataService` null
- thi throw loi ro rang

Ly do:

- fail som
- de debug
- tranh null truyen di xa roi moi vo

## Giai thich sieu chi tiet `FrmLogin.cs`

### Vai tro cua form

`FrmLogin` la gate.

No khong chi la man nhap text.

No con:

- xac nhan user hop le
- gan session vao `AppRuntime`
- quyet dinh dashboard tiep theo
- bao loi than thien neu login sai

### Khi constructor chay

Thuong no se:

- `InitializeComponent()`
- style nut
- style textbox
- dat placeholder
- wire event

### Phan nhap username/password

TextBox password thuong co:

- `UseSystemPasswordChar = true`
- hoac `PasswordChar`

Ban chat:

- UI che mat ky tu
- khong lam password an toan hon o DB
- chi la bao ve nhin trom tren man hinh

### Phan nut dang nhap

Khi user bam:

1. Form lay text tu textbox.
2. Form `Trim()` space thua.
3. Form validate rong hay khong.
4. Form goi `Authenticate(...)`.
5. Neu ket qua null, login fail.
6. Neu co user, login thanh cong.

### `Authenticate(...)`

Form login khong tu so password.

No giao viec do cho service.

Ly do:

- UI khong nen giu logic hash password
- UI khong nen tu query DB
- service moi la noi biet cach xac thuc

### Sau khi login dung

Form thuong:

- `AppRuntime.SetCurrentUser(user)`
- kiem role
- mo dashboard
- an hoac dong login

### Neu role la Admin

App mo `FrmAdminDashboard`.

### Neu role la Staff

App mo `FrmStaffDashboard`.

### Neu role la Teacher

App mo `FrmTeacherDashboard`.

### Tai sao can tach dashboard theo role

Vi moi vai tro co:

- menu khac
- KPI khac
- permission khac
- flow cong viec khac

## `BaseForms.cs` nen duoc doc nhu the nao

File nay thuong khong lam nghiep vu cu the.

No thuong giai quyet van de "nhieu form giong nhau".

Vi du:

- cach dong form
- base style
- helper load child
- helper reuse code UI

Nguoi moi thuong nham:

- tuong file base la "khong quan trong"

Thuc ra:

- file base de quyet nhieu quy uoc toan du an
- doi mot helper trong base co the doi hanh vi nhieu form

## `AppTheme.cs` nen duoc doc nhu the nao

`AppTheme` la file thiet ke.

No khong can luu hoc vien.

No khong query DB.

Nhung no rat quan trong vi:

- quyet app dep hay roi
- quyet nut nguy hiem co de nhan ra hay khong
- quyet grid co de doc hay khong
- quyet card co thong nhat hay khong

Khi thay dong:

- `StylePrimaryButton(...)`
- `StyleSecondaryButton(...)`
- `StyleDangerButton(...)`
- `StyleCard(...)`
- `StyleGrid(...)`

thi hieu rang:

- tac gia dang trung tam hoa quy tac giao dien
- form con chi goi helper
- khong lap lai ca dong set color/font/padding o moi form

## `UiHelpers.cs` nen duoc doc nhu the nao

Day la file rat de danh gia thap.

Nhung no thuong giai quyet:

- scale theo DPI
- set active menu
- open child form
- dialog shell
- responsive split

Khi thay helper UI:

- dung nhin no la "code phu"
- hay xem no co duoc goi o bao nhieu form
- cang duoc goi nhieu, cang la diem anh huong lon

## `ExportFileHelper.cs` nen duoc doc nhu the nao

Day la file cau noi giua:

- object trong bo nho
- va file that tren dia

Nhung diem can canh bao khi doc helper xuat file:

- encoding
- duong dan
- overwrite hay khong
- file lock
- exception khi khong co quyen ghi

## `FrmSidebarPreview.cs` nen duoc doc nhu the nao

File nay khong phai login.

Khong phai thu hoc phi.

Khong phai bao cao.

No thuong la:

- playground UI
- form preview
- noi thu giao dien nhanh

Nguoi moi nen hieu:

- khong phai file nao cung la nghiep vu
- co file sinh ra de test giao dien
- co file sinh ra de thong nhat shell

## Ket noi giua cac file trong cum nay

`Program.cs` tao service.

`AppRuntime.cs` giu service.

`FrmLogin.cs` dung service do de authenticate.

`AppTheme.cs` va `UiHelpers.cs` lam dep va to chuc giao dien login.

`BaseForms.cs` va `FrmSidebarPreview.cs` ho tro tang UI chung.

`ExportFileHelper.cs` chuan bi cho cac tinh nang xuat file ve sau.

## Sai lam nguoi moi thuong gap khi doc cum nay

Sai lam 1:

Tuong `Program.cs` la file nho nen khong quan trong.

Sai.

No la diem vao.

Sai lam 2:

Tuong `AppRuntime` chi la cho dat bien.

Sai.

No la noi giu session va service.

Sai lam 3:

Tuong `FrmLogin` chi co 2 textbox.

Sai.

No la cua phan quyen vao dung dashboard.

Sai lam 4:

Tuong `AppTheme` la phan trang tri, bo cung duoc.

Sai.

Bo theme tap trung la bo kha nang UI thong nhat.

Sai lam 5:

Tuong helper UI khong can doc.

Sai.

Doc helper moi thay duoc vi sao nhieu form co hanh vi giong nhau.

## Phu luc chung cho nguoi moi

### C# co ban

- `class` la khuon de tao doi tuong.
- `object` la ban the duoc tao tu class.
- `public` la cho phep ben ngoai thay va dung.
- `private` la chi cho class hien tai dung.
- `static` la thuoc ve class, khong can tao object.
- `sealed` la khong cho class khac ke thua.
- `partial` la 1 class chia ra nhieu file.
- `interface` la hop dong.
- `inheritance` la ke thua.
- `property` la bien co getter/setter.
- `field` la bien cap lop.
- `method` la ham trong class.
- `constructor` la ham khoi tao object.
- `namespace` la nhom ten de tranh dung nhau.
- `using` namespace khac voi `using var`.
- `using namespace` giup compiler tim type.
- `using var` giup dispose object cuoi scope.
- `null` la khong tro toi object nao.
- `string?` la chuoi co the null.
- `?.` la dung neu ben trai null.
- `??` la lay gia tri phai neu ben trai null.
- `?:` la toan tu 3 ngoi.
- `var` van la kieu tinh o compile time.
- `new` la tao object moi.
- `return` la tra ket qua va thoat ham.
- `void` la ham khong tra ve.
- `bool` la dung/sai.
- `if` la re nhanh.
- `else` la nhanh con lai.
- `switch` la re nhanh nhieu huong.
- `foreach` la duyet tung phan tu.
- `for` la lap co chi so.
- `try` la khoi de bao loi.
- `catch` la khoi bat loi.
- `finally` la khoi chay du loi hay khong.
- `throw` la nem exception.
- `exception` la doi tuong mo ta loi.
- `nameof(X)` tra ve chuoi ten cua `X`.
- `default` la gia tri mac dinh cua kieu.
- `DateTime` la ngay gio.
- `enum` la tap gia tri ten hoa.
- `List<T>` la danh sach generic.
- `IReadOnlyList<T>` la danh sach chi doc.
- `DataTable` la bang du lieu trong RAM.
- `DataRow` la 1 dong trong `DataTable`.
- `DataRowView` la wrapper de binding.
- `lambda` la ham ngan viet bang `=>`.
- `event` la su kien.
- `delegate` la kieu tro den ham.
- `attribute` la metadata gan len class/ham.

### WinForms co ban

- `Form` la cua so.
- `Control` la thanh phan UI.
- `Button` la nut bam.
- `TextBox` la o nhap text.
- `Label` la text chi doc.
- `ComboBox` la hop chon.
- `DataGridView` la bang hien du lieu.
- `Panel` la khung chua control.
- `GroupBox` la nhom co tieu de.
- `TableLayoutPanel` la bo cuc hang cot.
- `FlowLayoutPanel` la bo cuc chay tu trai qua phai hoac nguoc lai.
- `SplitContainer` la khung chia doi.
- `Dock` la dan sat vao canh.
- `Anchor` la giu khoang cach voi canh.
- `Padding` la dem ben trong.
- `Margin` la khoang cach ben ngoai.
- `AutoSize` la tu gian theo noi dung.
- `MinimumSize` la kich thuoc toi thieu.
- `BackColor` la mau nen.
- `ForeColor` la mau chu.
- `Font` la kieu chu.
- `Click` la event bam.
- `Shown` la event hien xong.
- `Resize` la event doi kich thuoc.
- `SelectionChanged` la event doi dong dang chon.
- `DataSource` la nguon du lieu cua control bind.
- `DisplayMember` la cot hien ra cho user.
- `ValueMember` la cot gia tri that.
- `CurrentRow` la dong dang dung.
- `CurrentCell` la o dang dung.
- `Show()` la mo khong modal.
- `ShowDialog()` la mo modal.
- `MessageBox.Show()` la hop thong bao nhanh.
- `DialogResult.OK` la ket qua dong y.
- `PictureBox` la khung hien anh.
- `SizeMode.Zoom` la fit anh giu ti le.
- `OpenFileDialog` la hop chon file.
- `ErrorProvider` la icon hien loi canh control.
- `ToolTip` la text nho khi re chuot.

### Data binding va du lieu

- Grid khong can tu gan tung cell neu da co `DataSource`.
- `DataTable` co ten cot va dong du lieu.
- `AutoGenerateColumns = true` cho grid tu sinh cot.
- `AutoSizeColumnsMode.Fill` cho cot lap day be ngang.
- `Clone()` tao bang moi cung schema.
- `ImportRow()` copy 1 dong vao bang khac.
- UI thuong khong query SQL truc tiep.
- UI goi service.
- Service moi query DB.
- Nhieu form xai `DataTable` vi hop WinForms.
- `DataRowView` hay xuat hien khi bind `ComboBox`.
- `SelectedValue` la gia tri chinh.
- `SelectedItem` co the la `DataRowView`.
- `Trim()` loai space dau/cuoi.
- `IsNullOrWhiteSpace()` check null, rong, space.
- `ToString()` doi object thanh chuoi.
- `OrdinalIgnoreCase` so chuoi khong phan biet hoa thuong.

### Loi, dispose, va tai nguyen

- File stream nen dispose.
- Image GDI+ nen dispose.
- Dialog nen dispose.
- `using var` giup giai phong tai nguyen.
- Log loi som de khoi mat dau vet.
- Hien thong bao cho user khong thay cho log ky thuat.
- `catch` nen thong bao gon.
- `ErrorLogger` giu chi tiet ky thuat.
- UI khong nen nuot loi trong im lang.
- Fail som de de debug.

### Cach doc 1 dong code

- Nhin no dang o file nao.
- Nhin no dang o ham nao.
- Nhin ham do duoc ai goi.
- Nhin dong do doc du lieu gi.
- Nhin dong do sua state nao.
- Nhin dong do tac dong UI hay DB.
- Nhin dong do co the nem loi khong.
- Nhin dong do co phu thuoc helper nao.
- Nhin neu bo dong do thi UI/flow vo dau.
- Nhin no thuoc tang nao trong kien truc.

### Cach doc 1 ham

- Doc ten ham truoc.
- Doc tham so de biet ham can gi.
- Doc kieu tra ve de biet ham tra gi.
- Tim guard clause dau ham.
- Tim service call.
- Tim cho doi state field.
- Tim cho cap nhat UI.
- Tim catch/log.
- Tim ham helper no goi.
- Tim noi khac goi lai ham nay.

### Cach doc 1 event

- Hoi "event nay ban ra khi nao".
- Hoi "ai dang ky event nay".
- Hoi "event nay doi UI gi".
- Hoi "event nay co doi state gi".
- Hoi "event nay co mo form khac khong".
- Hoi "event nay co goi DB khong".
- Hoi "event nay co can debounce khong".
- Hoi "event nay co chay nhieu lan khong".
- Hoi "event nay co de sinh bug vong lap khong".
- Hoi "event nay co can disable button luc dang chay khong".

## Ket thuc folder 01

Neu ban muon doc du an theo cach chac chan nhat, hay doc file nay truoc tat ca cum khac.

Vi:

- no day diem vao
- no day session runtime
- no day login
- no day helper UI chung
- no day theme

Sau file nay, doc tiep folder `Domain` va `Application`.
