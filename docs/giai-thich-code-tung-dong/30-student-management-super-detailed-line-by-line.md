# Giai thich sieu chi tiet tung dong: `FrmStudentManagement.cs`

File goc: `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmStudentManagement.cs`

Tai lieu nay khong chi tra loi "dong nay lam gi". Muc tieu cua no la:

- giai thich cu phap C# o muc nguoi moi chua biet gi
- giai thich ly do tai sao dong do ton tai
- giai thich neu bo dong do di thi dieu gi co the xay ra
- giai thich moi khoi code dang tham gia vao luong chay nao cua form

Luu y:

- Cac dong trong, dong chi co dau `{` va `}` khong co logic rieng, nen duoc gop vao dong lien can de tranh tai lieu dai vo nghia.
- Phan "ban chat" co nghia la toi se giai thich ca ngon ngu, runtime, UI WinForms, data binding, va y do thiet ke.

## 1. Tam hinh tong quat truoc khi doc tung dong

Neu bo file nay ra nhin nhu mot cai may, thi no co 4 nhom bo phan chinh:

1. Phan nho trang thai tren form.
   Do la cac field nhu `_studentTable`, `_pendingAvatarSourcePath`, `_currentAvatarPath`.
   Chung giong nhu "so tay nho tam" cua form.

2. Phan khoi tao giao dien.
   Do la constructor va `ConfigureView()`.
   Chung bien form tu khung do WinForms tao ra thanh giao dien dep, co bo loc, co avatar, co bo cuc responsive.

3. Phan xu ly su kien nguoi dung.
   Do la `WireEvents()`.
   Chung noi "bam nut nao thi chay ham nao".

4. Phan nghiep vu.
   Do la cac ham nhu `LoadStudents()`, `SaveCurrentStudent()`, `DeleteSelectedStudent()`, `PopulateDetailFromSelection()`.
   Chung la noi form noi chuyen voi `AppRuntime.DataService`.

Neu chua quen UI desktop, co the hieu don gian:

- `Form` = mot cua so.
- `Control` = mot thanh phan tren cua so, vi du textbox, button, grid.
- `Event` = mot su kien, vi du bam nut, doi dong, resize.
- `DataSource` = nguon du lieu ma grid/combobox se lay de hien.
- `DataTable` = mot bang du lieu trong RAM, giong bang Excel mini.

## 2. Giai thich sieu chi tiet theo dong

| Dong | Giai thich sieu chi tiet |
| --- | --- |
| 1 | `using System.Data;` la lenh import namespace. `using` trong C# khong phai "nap thu vien vao RAM ngay lap tuc", ma la mo rong pham vi tim kiem ten lop trong file nay. `System.Data` chua cac kieu lien quan du lieu bang, nhu `DataTable`, `DataRow`, `DataRowView`. File nay can namespace nay vi danh sach hoc vien dang duoc luu tam va bind len grid duoi dang `DataTable`. Neu bo dong nay, compiler se khong biet `DataTable` la gi, tru khi viet day du `System.Data.DataTable`. |
| 2 | `using System.Globalization;` mo namespace chua cac kieu xu ly van de van hoa/ngon ngu, vi du phan loai ky tu Unicode. File nay dung namespace nay o ham `BuildDemoEmail()` de nhan biet dau thanh/dau tieng Viet va loai bo chung. Neu bo dong nay, `CharUnicodeInfo` va `UnicodeCategory` se khong duoc nhan dien. |
| 3 | `using System.Text;` mo namespace chua `StringBuilder`. `StringBuilder` dung khi muon ghep nhieu manh chuoi ma tranh tao qua nhieu object string trung gian. O file nay, no duoc dung de xay email demo tu ho ten. Neu bo dong nay, `StringBuilder` se khong compile duoc. |
| 4 | `using TrungTamNgoaiNgu.Application.Infrastructure;` import namespace noi bo cua du an. Trong namespace nay file dang dung `ErrorLogger`, co the ca `FormHostHelpers` va `AppTheme` tuy thuoc cach project to chuc. Y nghia thuc te: file UI nay dang xai cong cu ha tang cua ung dung, chu khong tu lam tat ca. |
| 5 | `using TrungTamNgoaiNgu.Domain.Entities;` import namespace chua entity thuoc tang domain. O day entity chinh la `StudentEntity`. "Entity" co the hieu la doi tuong du lieu chinh cua nghiep vu. UI do du lieu vao `StudentEntity`, roi dua object do xuong service de luu. |
| 7 | `namespace Trung_tam_quan_ly_ngoai_ngu;` dinh nghia file nay thuoc namespace nao. Namespace giong nhu ho cua class, giup tranh trung ten. Dau cham phay cuoi cho thay day la file-scoped namespace, mot cu phap ngan hon trong C# moi: thay vi mo block `{ ... }`, no ap dung namespace cho ca file. |
| 9 | `public partial class FrmStudentManagement : Form` la dong rat giau thong tin. `public` nghia la class nay co the duoc truy cap tu ben ngoai assembly/pham vi khac. `partial` nghia la class nay bi tach thanh nhieu manh, thuong 1 manh do nguoi viet tay (`.cs`) va 1 manh do WinForms Designer sinh (`.Designer.cs`). `class` la khai bao kieu doi tuong. `FrmStudentManagement` la ten class, thuong trung voi ten file. `: Form` nghia la class nay ke thua `System.Windows.Forms.Form`, tuc la no la mot cua so WinForms that su. Nho ke thua `Form`, class nay moi co cac thuoc tinh nhu `ClientSize`, su kien `Resize`, ham `ShowDialog`, va toan bo hanh vi cua cua so desktop. |
| 11 | `private DataTable _studentTable = new();` khai bao 1 field rieng tu (`private`) cap lop. Field la bien song chung voi doi song cua object form, khong phai bien tam cua 1 ham. `_studentTable` chua bang du lieu hoc vien dang hien trong grid. `new()` la target-typed new, nghia la compiler tu suy ra day la `new DataTable()`. Ban chat dong nay la: ngay khi form duoc tao, field nay da co 1 `DataTable` rong de tranh null. Neu de null, cac doan code sau co the phai check null nhieu hon. |
| 12 | `private string? _pendingAvatarSourcePath;` la field chua duong dan file anh nguoi dung vua chon tren may, nhung chua chinh thuc luu vao he thong. `string?` nghia la nullable reference type: bien nay co the la mot chuoi, hoac co the la `null`. Dau `?` o day khong phai toan tu hoi cham, ma la thong bao voi compiler rang "null la hop le". Ban chat nghiep vu: anh co 2 trang thai, "dang preview tam" va "da luu that". Bien nay giu phan "tam". |
| 13 | `private string? _currentAvatarPath;` la field nho duong dan avatar hien dang gan cho hoc vien dang mo. No khac dong 12 o cho dong 12 noi ve file nguon vua duoc user chon, con dong 13 noi ve path avatar dang duoc xem la gia tri hien hanh cua hoc vien. Hai bien nay tach rieng de phan biet "anh dang ton tai trong he thong" voi "anh nguoi dung sap cap nhat". |
| 14 | `private Label? _lblStudentAddress;` la field de giu tham chieu toi control `Label` duoc tao dong sau nay. Vi control nay khong chac duoc tao trong constructor truoc khi `EnsureAddressControls()` chay, nen kieu duoc khai bao nullable. `Label` la control hien text tinh, khong cho nhap. |
| 15 | `private TextBox? _txtStudentAddress;` tuong tu dong 14 nhung la `TextBox` de nhap dia chi. Day la control tao luc chay, khong co san o Designer. Y nghia thiet ke: form nay muon chen them 1 o "Dia chi" vao layout co san ma khong muon/chua sua Designer. |
| 17 | `public FrmStudentManagement()` la constructor. Constructor la ham dac biet chay khi tao object bang `new FrmStudentManagement()`. No khong co kieu tra ve, va ten phai trung ten class. Moi logic trong constructor se quyet dinh trang thai ban dau cua form. |
| 19 | `InitializeComponent();` la dong quan trong nhat trong moi form WinForms. Ham nay duoc sinh trong file `.Designer.cs` va chua lenh tao cac button, textbox, grid, panel..., set ten, kich thuoc, vi tri ban dau, va them chung vao cay control. Neu bo dong nay, gan nhu toan bo control se chua ton tai; cac dong sau nhu `btnSearchStudent` hay `dgvStudentList` se gay null reference hoac khong compile tuy cach designer sinh code. Vi the no gan nhu luon phai dung rat som trong constructor. |
| 20 | `FormHostHelpers.ConfigureModuleSurface(this, "Quan ly hoc vien");` goi helper noi bo de "trang diem" hoac cau hinh mat ngoai cua module. `this` la chinh instance form hien tai. Chuoi thu hai la ten module hien thi cho nguoi dung. Ban chat: form khong tu bien minh thanh module dong bo; no giao viec do cho helper chung cua du an. Neu helper nay set title, mau, padding, icon..., thi moi module se co cam giac thong nhat. |
| 21 | `ConfigureView();` goi ham rieng de cau hinh giao dien. Tach ra thanh ham rieng giup constructor ngan hon va de doc hon. Ban chat thiet ke: chia "khoi tao giao dien" thanh 1 buoc logic. |
| 22 | `LoadStudents();` goi tai du lieu hoc vien ngay khi form mo. Nghia la user khong can bam nut "Tim kiem" lan dau; danh sach da co san. Ban chat UX: giam so thao tac va giup form khong mo len trong tinh trang rong. |
| 23 | `WireEvents();` dang ky cac event handler. Luc nay control da duoc tao roi, du lieu co the cung da tai xong, nen la thoi diem hop ly de noi "khi user bam gi thi lam gi". |
| 24 | `ApplyResponsiveLayout();` ep bo cuc chay lai 1 lan ngay khi mo form. Neu khong goi dong nay, layout responsive chi co hieu luc sau khi user resize lan dau. Goi som giup form o trang thai dung ngay tu dau. |
| 27 | `private void ConfigureView()` khai bao 1 ham rieng chi de cau hinh giao dien. `private` nghia la chi dung duoc trong class nay. `void` nghia la ham khong tra ve gia tri nao. Ten ham mang tinh mo ta: "cau hinh view". |
| 29 | `BuildFilterLayout();` la buoc tao lai vung bo loc bang code. Ban chat: thay vi tin 100% vao layout keo-tha trong Designer, form nay chu dong dung `TableLayoutPanel` bang code de de responsive hon. |
| 30 | `EnsureAddressControls();` dam bao control "Dia chi" ton tai. Tu "Ensure" trong code thuong co nghia la "neu chua co thi tao". Day la pattern pho bien khi lam viec voi tai nguyen/co so du lieu/control tao dong. |
| 31 | `LocalizeLabels();` dat toan bo text giao dien. "Localize" o muc hien tai khong phai he thong da ngon ngu day du, ma la ham tap trung gan chu cho label/button/combobox item. Tinh to chuc: khi can doi text, co 1 noi chinh. |
| 33 | `cboStudentStatusFilter.SelectedIndex = 0;` chon item dau tien cho combobox loc trang thai. `SelectedIndex` la chi so item dang chon, tinh tu 0. Dong nay ngam noi: truoc do combobox da duoc nap item trong `LocalizeLabels()`. Neu chua nap item ma da set index 0, co the loi hoac khong co tac dung tuy control. |
| 34 | `cboStudentStatus.SelectedIndex = 0;` tuong tu dong 33 nhung la combobox trang thai trong panel chi tiet. Muc dich la khi tao/sua hoc vien ma chua co gi, form co mot trang thai mac dinh. |
| 36 | `ttStudentManagement.SetToolTip(btnOpenEnrollment, "...");` gan tooltip cho nut mo ghi danh. `ttStudentManagement` la `ToolTip` component. Tooltip la doan text nho hien khi user de chuot vao control. Ban chat UX: giai thich nhanh chuc nang ma khong can day giao dien bang qua nhieu text. |
| 37 | `ttStudentManagement.SetToolTip(btnChooseStudentAvatar, "...");` tooltip thu hai noi ro hanh vi cua nut chon anh: chon avatar va luu vao thu muc images. Chi tiet nay giup doc code hieu y do nghiep vu cua nut truoc khi xuong ham xu ly. |
| 39 | `AppTheme.StyleGroupBox(grpStudentInfo);` goi mot helper style chung cho `GroupBox`. Nghia la form nay dang dung design system noi bo. Neu muon doi bo theme, co the sua o `AppTheme` thay vi sua tung form. |
| 40 | `AppTheme.StyleGrid(dgvStudentList);` ap theme cho grid danh sach hoc vien. "Grid" o day la `DataGridView`, mot control manh cua WinForms de hien du lieu theo dang bang. |
| 41-46 | 6 dong nay ap style "secondary button" cho cac nut tim, refresh, chon anh, bo anh, dat lai, mo ghi danh. Y do giao dien: cac nut nay la hanh dong phu, khong phai thao tac chinh nhat cua form. |
| 47-49 | 3 dong nay ap style "primary button" cho them, luu, cap nhat. Day la cac hanh dong cot loi cua CRUD, nen duoc lam noi bat hon. |
| 50 | `AppTheme.StyleDangerButton(btnDeleteStudent);` nut xoa la hanh dong co rui ro, nen style nguy hiem thuong dung mau do, border manh hon, hoac icon canh bao. Day la quy tac UX pho bien. |
| 52 | `picStudentAvatar.BackColor = Color.FromArgb(233, 239, 248);` dat mau nen cho khung avatar. `Color.FromArgb(r, g, b)` tao mau tu 3 thanh phan do-luc-lam. Mau nen nhat giup khung avatar khong bi trong rat "chet" khi chua co anh. |
| 53 | `picStudentAvatar.BorderStyle = BorderStyle.FixedSingle;` ve vien 1 net quanh `PictureBox`. Ban chat: khung avatar co ranh gioi ro rang hon. |
| 54 | `picStudentAvatar.SizeMode = PictureBoxSizeMode.Zoom;` dat cach control hien anh. `Zoom` nghia la anh se phong/thu de vua khung nhung co gang giu ti le, tranh meo anh. Neu de `StretchImage`, anh co the bi keo meo. |
| 55 | `picStudentAvatar.MinimumSize = new Size(112, 112);` dat kich thuoc toi thieu de khi layout co co lai thi khung avatar van khong nho hon nguong nay. `Size` la struct gom width va height. |
| 56 | `picStudentAvatar.Size = new Size(128, 128);` dat kich thuoc mong muon ban dau. `MinimumSize` la gioi han, con `Size` la kich thuoc thuc te tai thoi diem setup. |
| 57 | `picStudentAvatar.Anchor = AnchorStyles.Top;` noi control "neo" vao canh tren cua container. Khi container gian theo chieu ngang/chieu doc, vi tri avatar se duoc tinh dua tren quy tac neo nay. |
| 58 | `picStudentAvatar.Margin = new Padding(0, 0, 0, 8);` dat khoang cach ben ngoai control, cu the khong cach tren/trai/phai, cach duoi 8 pixel. `Padding` o day la khoang cach voi hang xom trong layout container. |
| 60 | `dgvStudentList.DefaultCellStyle.SelectionBackColor = ...` dat mau nen khi user chon dong trong grid. Khong lien quan du lieu, chi lien quan cam nhan nhin. |
| 61 | `dgvStudentList.DefaultCellStyle.SelectionForeColor = ...` dat mau chu khi dong dang duoc chon. Neu chi doi mau nen ma khong doi mau chu, co the chu se kho doc. |
| 62 | `dgvStudentList.RowTemplate.Height = 42;` dat chieu cao mac dinh cho tung dong du lieu moi trong grid. Chieu cao lon hon mac dinh giup giao dien thoang hon va de click. |
| 63 | `dgvStudentList.AutoGenerateColumns = true;` noi grid hay tu sinh cot dua theo schema cua `DataSource`. Nghia la form nay khong tu khai bao cot bang tay trong code nay. Loi ich: nhanh. Nhuc diem: phu thuoc vao ten cot tra ve tu service. |
| 64 | `dgvStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;` noi grid tu chia cot de lap day be ngang san co. Neu khong set, cot co the hep/rong rat lech nhau. |
| 66 | `splStudentContent.Panel1MinSize = 320;` `splStudentContent` la `SplitContainer`. Dong nay dat do rong/cao toi thieu cho panel 1. Muc dich: khi keo splitter, panel ben trai khong bi ep qua nho. |
| 67 | `splStudentContent.Panel2MinSize = 340;` tuong tu cho panel 2. Thuong panel 2 la phan chi tiet, can do rong hop ly de textbox va label khong vo layout. |
| 68 | `splStudentContent.FixedPanel = FixedPanel.None;` noi rang khong panel nao la "co dinh". Khi container thay doi kich thuoc, ca hai panel co the duoc dieu chinh. |
| 70 | `flpStudentActions.AutoSize = true;` `flpStudentActions` la `FlowLayoutPanel` chua nhom nut thao tac. `AutoSize = true` cho phep panel gian theo noi dung ben trong. |
| 71 | `flpStudentActions.WrapContents = true;` neu khong du ngang, cac control con duoc phep xuong dong tiep. Day la mot phan cua responsive layout. |
| 72 | `flpStudentActions.Dock = DockStyle.Fill;` noi panel lap day o layout cha cua no. `Dock` khac `Anchor`: `Dock` la "dan sat vao canh/chiem toan bo", con `Anchor` la "giu khoang cach tu canh". |
| 73 | `flpStudentActions.FlowDirection = FlowDirection.LeftToRight;` quy dinh huong xep control con tu trai qua phai. |
| 74 | `flpStudentActions.Padding = new Padding(0, 4, 0, 0);` them khoang dem noi bo 4 pixel o tren. `Padding` khac `Margin`: `Padding` la khoang cach giua vien container va noi dung ben trong container. |
| 75 | `flpStudentActions.Margin = new Padding(0, 12, 0, 0);` dat khoang cach ben ngoai cho ca panel nhom nut, day no cach khoi ben tren 12 pixel. |
| 77 | `foreach (Control control in flpStudentActions.Controls)` bat dau vong lap qua tung control con trong panel nut. `Control` la lop co so cua gan nhu moi thanh phan UI WinForms. |
| 79 | `control.Margin = new Padding(0, 0, 10, 10);` dat khoang cach cho tung nut trong nhom. Cach viet nay cho thay tac gia muon dong bo spacing ma khong set tung nut. |
| 82 | `cboStudentStatus.Dock = DockStyle.Left;` dat combobox trang thai sat ben trai cua o layout no dang nam trong. |
| 83 | `cboStudentStatus.Width = 180;` dat rong co dinh 180 pixel cho combobox. Nhieu control co `Dock`, nhung van co the can kich thuoc co dinh tren mot truc nao do. |
| 86 | `private void WireEvents()` khai bao ham dang ky su kien. Form WinForms thuong co 2 cach gan event: gan trong Designer hoac gan bang code. Form nay chu y gan bang code de logic tap trung trong 1 cho. |
| 88 | `dgvStudentList.SelectionChanged += (_, _) => PopulateDetailFromSelection();` rat nhieu y trong 1 dong. `SelectionChanged` la event phat ra khi dong/cell dang chon trong grid doi. `+=` la them event handler. `(_, _) => ...` la lambda 2 tham so, o day tac gia bo qua ca `sender` va `EventArgs` bang cach dat ten `_`. Nghia ban chat: "moi khi user doi dong trong grid, nap lai panel chi tiet ben phai". Neu bo dong nay, click dong trong grid se khong doi thong tin chi tiet. |
| 89 | Nut tim kiem khi bam se goi `LoadStudents(...)` voi tu khoa da `Trim()` va text trong combobox loc. `Trim()` loai bo khoang trang o dau/cuoi, tranh user vo tinh nhap space lam sai dieu kien tim. |
| 90 | Nut lam moi goi `ResetFilters()`, nghia la tra bo loc ve mac dinh roi tai lai danh sach. |
| 91 | Nut dat lai khong dong vao DB; no chi goi `ResetDetailEditor()` de xoa noi dung dang nhap tren panel chi tiet. |
| 92-97 | Day la event handler dang block lambda nhieu dong. Khi bam nut `btnOpenEnrollment`, code lay `studentId` tu textbox ma hoc vien, kiem tra rong, tao `FrmEnrollment` voi tham so dau la `studentId` hoac `null`, tham so thu hai la `null`, roi `ShowDialog(this)`. `ShowDialog` mo form o che do modal, nghia la user phai dong form con truoc khi tro lai form cha. Truyen `this` vao lam owner giup quan he cua so dung hon. |
| 98 | Nut them hoc vien khong luu ngay; no chi chuyen form sang trang thai "tao moi" qua `StartCreateStudent()`. |
| 99 | Nut luu va... |
| 100 | ...nut cap nhat deu cung tro ve `SaveCurrentStudent()`. Day cho thay service ben duoi dang tu phan biet insert/update dua tren ma hoc vien hoac trang thai du lieu, thay vi UI tach 2 flow khac nhau. |
| 101 | Nut xoa goi `DeleteSelectedStudent()`. |
| 102 | Nut chon avatar goi `ChooseAvatar()`. |
| 103 | Nut bo avatar goi `RemoveAvatar()`. |
| 104 | Event `Resize` cua chinh form goi `ApplyResponsiveLayout()`. Moi lan cua so thay doi kich thuoc, form se xem nen xep layout dang ngang hay dang doc. |
| 107 | `private void LoadStudents(string? keyword = null, string? status = null)` la ham tai danh sach hoc vien. Hai tham so deu co gia tri mac dinh `null`, nen co the goi `LoadStudents()` khong can truyen gi. Day la cach C# ho tro optional parameters. |
| 109 | `try` bat dau khoi bao loi. Cac thao tac data service co the nem exception, vi du mat ket noi DB, loi SQL, loi mapping du lieu. |
| 111-113 | `AppRuntime.DataService.GetStudentList(...)` la cuoc goi quan trong. `AppRuntime` la noi luu service toan cuc cua app. `DataService` la abstraction cho nguon du lieu. `GetStudentList` nhan 2 dieu kien loc. Logic o day bien input UI thanh input nghiep vu: neu `keyword` rong thi thanh `null`; neu `status` rong hoac la "Tat ca" thi cung thanh `null`. Ban chat la: service chi nhan gia tri co nghia, UI khong bat no phai hieu chu "Tat ca". |
| 115 | `dgvStudentList.DataSource = _studentTable;` la lenh data binding. Grid khong tu chua du lieu theo kieu list don gian; no duoc noi voi `DataTable`. Tu do, grid doc schema, sinh cot, hien dong. `DataSource` giong nhu "cam day du lieu vao grid". |
| 116 | `SelectFirstStudentRow();` sau khi nap du lieu, form co gang chon dong dau tien. Neu khong lam dieu nay, panel chi tiet co the van trong du grid da co du lieu. |
| 118 | `catch (Exception ex)` bat moi exception kieu `Exception` tro xuong. `ex` la bien giu thong tin loi. |
| 120 | `ErrorLogger.Log(ex, nameof(FrmStudentManagement));` ghi loi vao file log. `nameof(FrmStudentManagement)` khong tra ve object/class, ma tra ve chuoi `"FrmStudentManagement"` o thoi diem compile. Loi ich cua `nameof` so voi viet chuoi tay la an toan khi doi ten class bang refactor. |
| 121 | `MessageBox.Show(...)` hien hop thong bao cho user. Tham so dau `this` lam owner. Chuoi tiep theo la noi dung. Chuoi sau nua la title. `MessageBoxButtons.OK` va `MessageBoxIcon.Error` quy dinh nut va icon. Ban chat: user khong thay stack trace, chi thay thong bao de hieu "co loi, xem log". |
| 125 | `private void StartCreateStudent()` la ham chuyen sang che do tao moi hoc vien. |
| 127 | `ResetDetailEditor();` xoa sach panel chi tiet truoc. Neu khong xoa, user co the vo tinh tao hoc vien moi dua tren du lieu con sot lai cua hoc vien cu. |
| 128 | `txtStudentId.Text = AppRuntime.DataService.GetNextStudentId();` xin ma hoc vien tiep theo tu service. Y nghia: UI khong tu che ma, ma de tang service quyet dinh quy tac danh ma. |
| 129 | `txtStudentFullName.Focus();` dua con tro nhap lieu vao o ho ten. `Focus()` la hanh dong UI nho nhung rat quan trong cho trainghiem: mo che do tao moi xong la co the go ten ngay. |
| 132 | `private void SaveCurrentStudent()` la ham luu hoc vien, dung cho ca tao moi lan cap nhat. |
| 134-137 | `if (!ValidateEditor()) { return; }` nghia la "neu du lieu tren form khong hop le, dung ngay". Dau `!` la phep phu dinh boolean. Pattern nay giup ngan ham chinh, tranh nesting sau. |
| 139 | Bat dau khoi `try` de bao ve thao tac luu. |
| 141 | `var student = new StudentEntity` tao object domain moi. `var` khong phai kieu dong; compiler van suy ra kieu cu the la `StudentEntity` tai compile time. |
| 143 | `Id = txtStudentId.Text.Trim(),` map ma hoc vien tu textbox vao entity. `Trim()` loai bo khoang trang du thua, tranh ma co space dau/cuoi. |
| 144 | `FullName = txtStudentFullName.Text.Trim(),` map ho ten. |
| 145 | `BirthDate = dtpStudentBirthDate.Value.Date,` lay ngay sinh tu `DateTimePicker`. `.Value` la `DateTime` day du, co ca gio/phut/giay. `.Date` cat ve 00:00:00 cung ngay do, nghia la form chi quan tam ngay, khong quan tam gio. |
| 146 | `Phone = txtStudentPhone.Text.Trim(),` map so dien thoai. |
| 147 | `Email = txtStudentEmail.Text.Trim(),` map email. |
| 148 | `Address = GetStudentAddressText(),` lay dia chi thong qua helper, khong doc thang tu `_txtStudentAddress`. Y nghia thiet ke: ham luu khong can biet control dia chi duoc tao dong nhu the nao. |
| 149 | `AvatarPath = _currentAvatarPath,` tam dua duong dan avatar hien hanh vao entity. Luu y: neu user moi chon anh ma chua copy, `_pendingAvatarSourcePath` moi la file nguon, con `_currentAvatarPath` co the van la path cu hoac null. Chinh vi the ben duoi co them mot pha luu avatar. |
| 150 | `Status = cboStudentStatus.Text,` lay text dang hien tren combobox lam trang thai hoc vien. Day cho thay DB dang luu trang thai duoi dang string de doc, thay vi enum. |
| 151 | `IsDeleted = false` noi day la ban ghi dang hoat dong. "Xoa mem" sau nay thuong chi doi field nay thanh true. |
| 154 | `student = AppRuntime.DataService.SaveStudent(student);` goi service luu object. Service tra ve entity sau luu. Gan de nguoc `student = ...` cho thay service co the bo sung/chuan hoa du lieu truoc khi tra ve, vi du chuan hoa path, sua status, hoac tra lai data moi nhat tu DB. |
| 155 | `if (!string.IsNullOrWhiteSpace(_pendingAvatarSourcePath))` kiem tra co anh moi dang cho xu ly khong. `IsNullOrWhiteSpace` tra true neu chuoi la null, rong, hoac chi toan space. Day la check an toan hon `== ""`. |
| 157 | `student.AvatarPath = AppRuntime.DataService.SaveStudentAvatar(student.Id, _pendingAvatarSourcePath);` goi service luu file anh vao noi luu chinh thuc. Service tra ve path moi, va path do duoc gan vao entity. Day la pha "xu ly file" tach rieng khoi pha "luu ban ghi hoc vien". |
| 158 | `student = AppRuntime.DataService.SaveStudent(student);` goi luu lan 2. Tai sao phai lan 2? Vi lan 1 luu ban ghi hoc vien chung, lan 2 cap nhat lai `AvatarPath` sau khi da co file anh that su. Day la diem rat quan trong khi day nguoi moi: nhieu khi 1 hanh dong UI "luu" thuc te co the gom nhieu buoc ky thuat. |
| 159 | `_pendingAvatarSourcePath = null;` danh dau khong con anh dang cho xu ly. Neu khong clear, lan luu sau co the vo tinh copy lai cung file. |
| 162 | `_currentAvatarPath = student.AvatarPath;` dong bo bo nho tam cua form voi ket qua moi nhat sau luu. Sau dong nay, form xem avatar vua luu la avatar hien hanh. |
| 163 | `LoadStudents(txtStudentKeyword.Text.Trim(), cboStudentStatusFilter.Text);` tai lai danh sach dua tren bo loc user dang dung. Tai sao khong chi update 1 dong grid? Vi reload toan bo don gian hon, dam bao du lieu tren UI khop 100% voi DB. Nhuc diem la co the ton them chi phi, nhung voi app desktop nho thuong chap nhan duoc. |
| 164 | `FocusStudent(student.Id);` sau khi reload grid, tim lai va chon dung hoc vien vua luu. Neu khong lam vay, user co the bi mat ngu canh va khong biet ban ghi nao vua duoc cap nhat. |
| 165 | Hop thong bao thanh cong cho user. |
| 167-170 | `catch` cua qua trinh luu. Neu bat ky buoc nao nem exception, loi duoc log va thong bao loi hien len. Form khong co rollback UI phuc tap; no chi thong bao va giu nguyen trang thai dang nhap hien tai de user co the sua. |
| 174 | `private void DeleteSelectedStudent()` la ham xoa mem hoc vien dang chon. |
| 176-179 | Neu `txtStudentId.Text` rong thi return ngay. Ban chat: khong co ma hoc vien nghia la khong co doi tuong muc tieu de xoa. |
| 181 | `using var dialog = new FrmConfirmDialog(...);` tao dialog xac nhan va dong thoi dam bao no duoc dispose sau khi dung xong. `using var` la cu phap ngan cua dispose pattern. Cac form/dialog la tai nguyen UI, nen dispose dung cach la thoi quen tot. |
| 182-185 | `dialog.ShowDialog(this)` mo dialog modal. Neu ket qua khong phai `DialogResult.OK` thi dung. Dong nay chinh la "lop bao ve nguoi dung" truoc thao tac co rui ro. |
| 187 | Bat dau `try` cho thao tac xoa. |
| 189 | `SoftDeleteStudent(txtStudentId.Text.Trim());` khong xoa cung, ma xoa mem. Nghia la service se danh dau ban ghi la da xoa hoac bo no khoi danh sach hoat dong, thay vi xoa han. Cach nay de phuc hoi/lich su va an toan hon. |
| 190 | Tai lai danh sach theo bo loc dang hien hanh. Neu hoc vien vua xoa khong con thoa dieu kien, no se bien mat khoi grid. |
| 191 | `ResetDetailEditor();` xoa panel chi tiet vi ban ghi dang mo vua bi xoa mem. Giup UI khong hien thong tin cua doi tuong khong con hop le nua. |
| 193-196 | Bat loi khi xoa. |
| 200 | `private void ChooseAvatar()` la ham mo hop chon anh. |
| 202 | `try` bat dau vi thao tac file va dialog deu co the loi. |
| 204 | `using var dialog = new OpenFileDialog` tao hop chon file cua Windows. `OpenFileDialog` la control/he thong dialog chuan cua desktop. |
| 206 | `Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp"` gioi han file hien thi. Chuoi filter cua WinForms co dinh dang "Nhan hien thi|mau file". Day la lọc giao dien, khong phai lop bao mat tuyet doi. |
| 207 | `Title = "Chon avatar hoc vien"` dat title cua hop chon de user biet minh dang chon gi. |
| 210-213 | `if (dialog.ShowDialog(this) != DialogResult.OK) { return; }` neu user bam Cancel hoac dong hop thoai, ham dung ngay. Day la flow rat binh thuong voi dialog chon file. |
| 215 | `_pendingAvatarSourcePath = dialog.FileName;` luu duong dan file nguon ma user vua chon. `FileName` la path day du den file da chon. |
| 216 | `LoadAvatarPreview(dialog.FileName);` hien xem truoc ngay. Diem nay cho thay luong chay duoc tach thanh "chon va preview" truoc, "copy va luu that" sau. |
| 218-221 | Bat loi mo/chon file anh. |
| 225 | `private void RemoveAvatar()` la thao tac bo avatar tren UI. |
| 227 | `_pendingAvatarSourcePath = null;` xoa anh dang cho luu. |
| 228 | `_currentAvatarPath = null;` xoa luon thong tin avatar hien hanh tren form. Neu user bam luu sau do, entity se di xuong voi `AvatarPath = null`. |
| 229 | `picStudentAvatar.Image = null;` xoa hinh dang hien. Dong nay chi tac dong UI, khong xoa file tren dia. |
| 232 | `private void SelectFirstStudentRow()` la helper UX sau moi lan bind grid. |
| 234-239 | Neu grid co it nhat 1 dong, chon dong dau (`Rows[0].Selected = true`), goi `PopulateDetailFromSelection()` de nap chi tiet, roi return. Day la mot pattern de dong bo grid ben trai va panel ben phai. |
| 241 | Neu grid rong, `ResetDetailEditor();` de panel chi tiet tro ve sach, tranh hien thong tin cu. |
| 244 | `private void FocusStudent(string studentId)` la ham tim va focus 1 hoc vien theo ma. |
| 246 | `foreach (DataGridViewRow row in dgvStudentList.Rows)` duyet tung dong grid. Day la grid row, khong phai `DataRow` trong `DataTable`. |
| 248 | So sanh gia tri cot dau tien voi `studentId`. `row.Cells[0].Value?.ToString() ?? string.Empty` co 2 y: `?.` chi goi `ToString()` neu `Value` khong null; `?? string.Empty` la neu ket qua van null thi thay bang chuoi rong. Sau do `.Equals(..., StringComparison.OrdinalIgnoreCase)` so chuoi khong phan biet hoa thuong theo kieu ordinal. |
| 250 | `row.Selected = true;` danh dau dong la dang duoc chon. |
| 251 | `dgvStudentList.CurrentCell = row.Cells[0];` set current cell ro rang. Trong WinForms, dong duoc select va current cell khong phai luc nao cung giong nhau, nen dat ca hai de UI nhat quan. |
| 252 | `PopulateDetailFromSelection();` nap lai panel chi tiet theo dong vua tim thay. |
| 253 | `return;` dung ngay khi da tim xong, tranh duyet phan con lai vo ich. |
| 258 | `private void PopulateDetailFromSelection()` la ham quan trong nhat cua luong "chon dong -> hien chi tiet". |
| 260 | `if (dgvStudentList.CurrentRow?.DataBoundItem is not DataRowView rowView)` la cu phap C# kha day dac. `CurrentRow` la dong grid hien tai. `?.` tranh null. `DataBoundItem` la object goc ma dong grid dang dai dien. `is not DataRowView rowView` vua kiem tra kieu, vua tao bien `rowView` neu thanh cong. Neu khong phai `DataRowView`, return ngay. |
| 265 | `var studentId = rowView.Row[0]?.ToString();` lay gia tri cot dau tien tu dong du lieu goc. `Row[0]` la cot dau tien theo index, khong theo ten. |
| 266-269 | Neu ma hoc vien rong hoac chi toan space thi return. Khong co ma thi khong the truy van chi tiet. |
| 271 | Bat dau `try` de bao ve qua trinh tai chi tiet. |
| 273 | `var student = AppRuntime.DataService.GetStudentById(studentId);` khong doc thang thong tin tu grid ma truy van lai service. Day la lua chon dung khi grid co the chi chua ban tom tat, con panel chi tiet can object day du. |
| 274-277 | Neu service tra `null` thi return. Nghia la du lieu tren grid co the da cu, hoac hoc vien vua bi xoa/doi o noi khac. |
| 279 | `txtStudentId.Text = student.Id;` do ma hoc vien len UI. |
| 280 | `txtStudentFullName.Text = student.FullName;` do ten len UI. |
| 281 | `txtStudentPhone.Text = student.Phone;` do sdt len UI. |
| 282 | `txtStudentEmail.Text = student.Email ?? string.Empty;` neu email null thi thay bang chuoi rong vi `TextBox.Text` mong 1 chuoi dung de hien thi. |
| 283 | `SetStudentAddressText(student.Address);` gan dia chi thong qua helper. Neu control dia chi la dynamic control, helper nay la diem truu tuong hoa dung. |
| 284 | `cboStudentStatus.Text = string.IsNullOrWhiteSpace(student.Status) ? "Dang hoc" : student.Status;` neu DB khong co trang thai, form fallback ve "Dang hoc". Toan tu `?:` la ternary operator, cu phap rut gon cua `if else` khi chi can chon 1 trong 2 gia tri. |
| 285 | `dtpStudentBirthDate.Value = student.BirthDate == default ? DateTime.Today : student.BirthDate;` `default` voi `DateTime` thuong la `01/01/0001 00:00:00`. Gia tri nay gan nhu khong co y nghia nghiep vu, nen form thay bang hom nay de UI khong hien mot ngay ky la. |
| 286 | `_currentAvatarPath = student.AvatarPath;` dong bo path avatar hien hanh vao bo nho tam cua form. |
| 287 | `_pendingAvatarSourcePath = null;` vua chon dong moi xong, form coi nhu khong con "anh dang cho luu". Rat hop ly vi luc nay dang xem du lieu that tu DB, khong phai du lieu tam user vua chon ma chua save. |
| 288 | `LoadAvatarPreview(AppRuntime.DataService.ResolveAbsoluteImagePath(student.AvatarPath));` goi 2 tang helper lien tiep. `ResolveAbsoluteImagePath(...)` bien path co the la tuong doi thanh duong dan tuyet doi tren dia. Sau do `LoadAvatarPreview(...)` doc file va hien anh. Tach 2 buoc nay giup UI khong can biet logic duong dan anh duoc luu nhu the nao. |
| 290-293 | Bat loi khi tai chi tiet hoc vien. |
| 297 | `private void LoadAvatarPreview(string? imagePath)` la ham hien xem truoc avatar. |
| 299 | `if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))` check 2 dieu: duong dan co hop le khong, va file co ton tai that tren dia khong. Dau `||` la phep OR. Chi can 1 dieu dung thi vao block. |
| 301 | `picStudentAvatar.Image = null;` neu path khong hop le thi xoa hinh hien hanh. Day giup UI trung thuc: khong co file thi khong hien anh cu. |
| 305 | `using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);` mo file anh o che do doc. `FileStream` la luong byte doc file. `using var` dam bao stream duoc dong/dispose sau khi xong, tranh khoa file. |
| 306 | `using var image = Image.FromStream(stream);` tao object `Image` tu stream byte. Day van con la object su dung tai nguyen GDI+, nen cung duoc dispose sau khi dung xong. |
| 307 | `picStudentAvatar.Image = new Bitmap(image);` clone `image` thanh mot `Bitmap` moi va gan vao picture box. Tai sao khong gan truc tiep `image`? Vi `image` se bi dispose khi ra khoi ham do dung `using var`. Clone sang `Bitmap` giup picture box giu mot ban sao song doc lap. Day la chi tiet rat hay bi nguoi moi bo qua. |
| 310 | `private bool ValidateEditor()` la ham kiem tra du lieu nhap. Tra ve `bool` vi ham chi can noi "hop le hay khong". |
| 312 | `errStudent.Clear();` xoa tat ca thong bao loi cu cua `ErrorProvider`. Neu khong xoa, loi cu co the van treo du user da sua dung. |
| 314-317 | Kiem tra ma hoc vien co rong khong. Neu rong, `SetError` gan thong diep loi vao chinh control `txtStudentId`. `ErrorProvider` thuong hien icon nho canh control va cho phep hover de doc loi. |
| 319-322 | Kiem tra ho ten khong duoc rong. |
| 324-327 | Kiem tra so dien thoai khong duoc rong. Luu y: code hien tai chua validate format phone, chi validate co nhap hay khong. Day la mot ghi chu quan trong cho nguoi hoc: validation khong luc nao cung day du. |
| 329-336 | Kiem tra email. Dau tien, neu rong thi bao loi. Neu co nhap nhung khong chua ky tu `@` hoac `.` thi bao "Email khong hop le". Day la validate rat co ban, chua xac thuc RFC hay regex phuc tap. |
| 338-341 | `return string.IsNullOrWhiteSpace(errStudent.GetError(...)) && ...` la cach tong hop ket qua validation. `GetError(control)` tra chuoi thong diep loi cua control do. Neu chuoi rong, nghia la control khong co loi. Dong return yeu cau ca 4 control deu khong loi thi moi tra `true`. |
| 344 | `private void ResetDetailEditor()` la ham dua panel chi tiet ve trang thai sach. |
| 346 | `errStudent.Clear();` xoa loi cu khi reset. |
| 347-350 | Xoa text 4 o co ban bang `.Clear()`. `Clear()` la ham tien dung cua textbox, tuong duong gan `Text = ""` nhung ro nghia hon. |
| 351 | `SetStudentAddressText(string.Empty);` xoa o dia chi qua helper. |
| 352 | `cboStudentStatus.SelectedIndex = 0;` dat trang thai ve item dau. Dieu nay phu thuoc vao `LocalizeLabels()` da nap item dung thu tu. |
| 353 | `dtpStudentBirthDate.Value = DateTime.Today;` dua ngay sinh ve hom nay. Voi nguoi dung, day co the chi la gia tri tam cho tao moi; validation file nay chua bat buoc ngay sinh. |
| 354 | `_pendingAvatarSourcePath = null;` xoa path avatar tam. |
| 355 | `_currentAvatarPath = null;` xoa path avatar hien hanh. |
| 356 | `picStudentAvatar.Image = null;` xoa anh dang hien. Luu y: khong co `Dispose()` anh cu o day, nen neu thay doi anh nhieu lan co the can xem lai quan ly tai nguyen; tuy nhien trong file nay tac gia khong xu ly them o cho nay. |
| 359 | `private void ResetFilters()` la ham reset vung bo loc. |
| 361 | `txtStudentKeyword.Clear();` xoa tu khoa tim kiem. |
| 362 | `cboStudentStatusFilter.SelectedIndex = 0;` dua bo loc trang thai ve item dau, thuong la "Tat ca". |
| 363 | `LoadStudents();` tai lai danh sach khong dieu kien. |
| 366 | `private void LocalizeLabels()` la ham tap trung toan bo text giao dien. |
| 368 | `lblStudentKeyword.Text = "Tu khoa tim kiem";` dat text cho label. `Text` la thuoc tinh hien noi dung tren da so control text-based. |
| 369 | `txtStudentKeyword.PlaceholderText = "...";` placeholder la chu mo nhat hien trong textbox khi rong, chi mang tinh goi y, khong phai gia tri that. |
| 370 | `lblStudentStatusFilter.Text = "Trang thai";` dat text cho label bo loc. |
| 371 | `cboStudentStatusFilter.Items.Clear();` xoa item cu truoc khi nap lai. Day la cach tranh lap du lieu neu ham bi goi nhieu lan. |
| 372 | `Items.AddRange([...])` nap danh sach item bo loc. Cu phap `[...]` la collection expression/C# moi de tao tap gia tri ngan gon. Ban chat UI: combobox filter cho phep "Tat ca", "Dang hoc", "Bao luu", "Hoan thanh", "Da nghi". |
| 374-379 | Dat text cho `GroupBox` va cac label co ban: ma hoc vien, ho ten, ngay sinh, dien thoai, email. Day la phan thuong boi nhat nhung can tap trung trong 1 cho de de bao tri. |
| 380-383 | `if (_lblStudentAddress is not null)` check vi label dia chi duoc tao dong. Neu ton tai thi dat text "Dia chi". Tien trinh doc code cho nguoi moi: day la dau hieu control nay khong phai control co san tu Designer ma duoc chen ve sau. |
| 384-386 | Dat label trang thai va nap item cho combobox trang thai chi tiet. Khac bo loc o cho khong co muc "Tat ca", vi day la gia tri cua mot hoc vien cu the, khong phai tieu chi tim. |
| 388-397 | Dat text cho toan bo nut. Cac dong nay ban chat khong phuc tap, nhung la noi quyet dinh ngon ngu giao tiep voi user. |
| 400 | `private void BuildFilterLayout()` la ham tu xay layout bo loc bang code. Day la phan kho nhat cua file neu nguoi doc chua quen WinForms layout. |
| 402 | `var filterLayout = new TableLayoutPanel` tao 1 container dang bang. `TableLayoutPanel` xep control theo hang cot, giong bang HTML nhung linh hoat hon cho desktop. |
| 404 | `Dock = DockStyle.Fill` nghia la container nay lap day phan khung ma no duoc dat vao. |
| 405 | `ColumnCount = 3` khai bao co 3 cot. |
| 406 | `RowCount = 2` khai bao co 2 dong. |
| 407 | `BackColor = Color.Transparent` dat nen trong suot, de panel cha tu quyet mau. |
| 408 | `Margin = Padding.Empty` bo margin mac dinh. `Padding.Empty` la shorthand cho tat ca 0. |
| 410-412 | Them 3 `ColumnStyle` theo ti le phan tram 52, 24, 24. Tong 100%. Nghia la cot 1 rong nhat de chua tu khoa tim, 2 cot sau hep hon. |
| 413-414 | Them 2 `RowStyle(SizeType.AutoSize)`. `AutoSize` nghia la chieu cao dong se dua theo noi dung ben trong. |
| 416 | `var actionBar = new FlowLayoutPanel` tao 1 panel chuyen dung de chua cac nut hanh dong ben trong vung filter. |
| 418 | `Dock = DockStyle.Fill` de panel nut lap day o cua no trong bang. |
| 419 | `FlowDirection = LeftToRight` xep nut tu trai qua phai. |
| 420 | `WrapContents = true` cho phep nut xuong dong neu can. |
| 421 | `AutoSize = true` giup panel co kich thuoc phu hop voi noi dung. |
| 422 | `Margin = new Padding(0, 22, 0, 0)` day panel xuong duoi 22 pixel, co le de canh cho dep voi label/textbox ke ben. |
| 424-425 | `actionBar.Controls.Add(...)` chen 2 nut tim va refresh vao panel. Thu tu them quyet dinh thu tu hien thi. |
| 427-428 | `txtStudentKeyword.Dock = Fill` va `cboStudentStatusFilter.Dock = Fill` de 2 control nay tu gian ra vua o cua chung trong bang layout. |
| 430 | `pnlStudentFilterCard.Controls.Clear();` xoa moi control cu trong panel card. Y nghia: ham nay dang toan quyen xay lai noi dung ben trong panel. |
| 431 | `pnlStudentFilterCard.Controls.Add(filterLayout);` chen bang layout moi tao vao panel card. |
| 432 | `Padding = new Padding(18, 16, 18, 14)` dat khoang dem noi bo cho card. Nhieu khi UI dep hon chi nho padding. |
| 433 | `Height = 112` dat chieu cao mong muon cua card filter o bo cuc rong. |
| 434 | `MinimumSize = new Size(0, 112)` dam bao card khong thap hon 112 pixel, con be ngang thi khong gioi han (`0`). |
| 436-440 | Day la cac lenh dat tung control vao o cu the trong bang: label tu khoa vao cot 0 dong 0, label trang thai vao cot 1 dong 0, textbox vao cot 0 dong 1, combobox vao cot 1 dong 1, actionBar vao cot 2 dong 1. Ban chat: day la sơ do layout ban dau cua khu filter. |
| 443 | `private void ApplyResponsiveLayout()` la ham quyet dinh bo cuc theo kich thuoc cua so hien tai. |
| 445 | `var actionBar = btnSearchStudent.Parent;` lay container cha cua nut tim. Sau khi build filter, nut tim nam trong `actionBar`, nen lay cach nay giup tham chieu lai panel hanh dong ma khong can giu field rieng. |
| 446 | Check xem `pnlStudentFilterCard` co control nao khong va control dau tien co phai `TableLayoutPanel` khong. Neu dung, ep kieu thanh `filterLayout`. Day la pattern `is Type variable` cua C#. |
| 448 | `if (ClientSize.Width < 980)` la nguong responsive thu nhat. `ClientSize` la kich thuoc ben trong form, khong tinh border/title bar. Neu rong nho hon 980, form coi la hep. |
| 450-458 | O che do hep, bang layout doi thanh 2 cot 3 dong. Dong thoi xoa `ColumnStyles`/`RowStyles` cu roi tao lai. Muc dich la tai cau truc bang, khong chi doi vi tri tung control. |
| 460-467 | Dat lai vi tri cho 4 control label/textbox/combobox trong layout moi. |
| 468-473 | Neu `actionBar` ton tai, dua no xuong dong thu 3, cot 0, va `SetColumnSpan(actionBar, 2)` de no chiem ca 2 cot. Day la ky thuat cho hang nut nam duoi ca khu filter. |
| 475 | `pnlStudentFilterCard.Height = 128;` khi form hep, card can cao hon vi nut da xuong dong duoi. |
| 477-505 | Nhanh `else` la bo cuc rong. Layout duoc tra lai 3 cot 2 dong ban dau, styles duoc tao lai, control duoc tra lai vi tri cu, va card cao 112. Day la phan doi xung cua bo cuc hep. |
| 508 | `if (ClientSize.Width < 940)` la nguong responsive thu hai, ap cho `SplitContainer` chua danh sach va panel chi tiet. |
| 510-513 | `FormHostHelpers.ApplyResponsiveSplit(...)` duoc goi voi `Orientation.Horizontal` khi form hep. Nghia la panel ben trai va ben phai se chuyen thanh tren va duoi. `Math.Max(220, (int)(... * 0.42))` tinh khoang chia hop ly, nhung khong bao gio nho hon 220. Day la cach dam bao layout van su dung duoc o cua so nho. |
| 515-520 | Neu form rong, helper duoc goi voi `Orientation.Vertical`, nghia la quay lai bo cuc trai-phai. Vi tri chia la 47% be ngang, nhung khong nho hon 420. |
| 524 | `private void EnsureAddressControls()` la ham dam bao vung dia chi da duoc chen vao form. |
| 526-529 | Neu `_txtStudentAddress` da khac null, nghia la control da duoc tao tu truoc, thi return ngay. Day la "idempotent guard": goi lai ham nhieu lan van an toan. |
| 531 | `_lblStudentAddress = new Label` tao label dong. |
| 533 | `Name = "lblStudentAddressDynamic"` dat ten control. Ten nay huu ich khi debug, tim control, hoac khi can truy cap theo key. |
| 534 | `Text = "Dia chi"` la text mac dinh. Sau nay `LocalizeLabels()` co the dat lai. |
| 535 | `Anchor = AnchorStyles.Left` de label bam ben trai trong o layout. |
| 536 | `AutoSize = true` cho label tu gian theo noi dung chu. |
| 539 | `_txtStudentAddress = new TextBox` tao textbox dong. |
| 541 | `Name = "txtStudentAddressDynamic"` dat ten cho textbox. |
| 542 | `Dock = DockStyle.Fill` de textbox lap day o cua no trong bang thong tin. |
| 543 | `Multiline = true` cho phep nhap nhieu dong, hop voi dia chi dai. |
| 544 | `Height = 52` dat chieu cao hop ly cho textbox nhieu dong. |
| 545 | `ScrollBars = ScrollBars.Vertical` bat thanh cuon doc neu dia chi qua dai. |
| 548 | `tblStudentInfo.RowCount += 1;` tang so dong cua bang thong tin len 1. `+= 1` la toan tu cong don va gan. |
| 549 | Them `RowStyle` moi co chieu cao tuyet doi 58 pixel. `SizeType.Absolute` nghia la khong co gian theo phan tram/noi dung, ma dung gia tri co dinh. |
| 550-551 | Them label va textbox dia chi vao dong 7, cot 0 va 1 cua `tblStudentInfo`. Y nghia: chen 1 cap label-input moi vao bang co san. |
| 552-553 | Day 2 control `lblStudentStatus` va `cboStudentStatus` xuong dong 8. Neu khong day, status va dia chi co the de len nhau. Chi tiet nay cho thay: them dong vao layout khong chi them control moi, ma con phai sap xep lai control cu. |
| 556 | `private string GetStudentAddressText() => _txtStudentAddress?.Text.Trim() ?? string.Empty;` la expression-bodied method, mot cu phap ngan cho ham 1 dong. No co 3 lop an toan: neu textbox null thi `?.` tra null; `Trim()` loai space; `?? string.Empty` dam bao ket qua cuoi cung luon la chuoi khong null. |
| 558 | `private void SetStudentAddressText(string? value)` la ham set gia tri nguoc lai cho dia chi. Tham so `value` cho phep null vi du lieu DB co the null. |
| 560-563 | Neu textbox dia chi da ton tai thi gan text. `value ?? string.Empty` tranh truyen null vao `Text`. |
| 566 | `private static string BuildDemoEmail(string fullName)` la helper tao email mau tu ho ten. `static` nghia la ham nay khong dung field/instance state cua form; no chi lam viec voi input va output. Day la dau hieu mot helper thuan tuy. |
| 568-571 | Neu `fullName` rong/space/null thi tra chuoi rong. Day la guard clause, tranh xu ly chuoi vo nghia o cac buoc sau. |
| 573 | `var builder = new StringBuilder();` tao bo dem chuoi co the mo rong. Vi duoi se duyet tung ky tu va them vao dan, `StringBuilder` hieu qua hon cong string lien tuc. |
| 574 | `foreach (var character in fullName.Normalize(NormalizationForm.FormD))` co y rat sau. `Normalize(FormD)` tach ky tu co dau thanh ky tu goc + dau thanh tach rieng. Vi du chu cai co dau co the thanh "a" + dau. Lam vay thi vong lap sau moi co the nhan ra dau thanh nhu mot ky tu rieng de bo no di. |
| 576 | `if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)` kiem tra loai Unicode cua ky tu hien tai. `NonSpacingMark` thuong la dau thanh/dau phu di kem ky tu chinh. Neu ky tu hien tai KHONG phai loai dau do, moi giu lai. Ban chat: day la co che "bo dau tieng Viet". |
| 578 | `builder.Append(character);` them ky tu hop le vao chuoi ket qua. |
| 582-588 | Day la chuoi bien doi cuoi cung. `builder.ToString()` doi bo dem thanh string. `.Normalize(FormC)` hop nhat chuoi lai dang chuan thong thuong. `.Replace("\\u0111", "d")` va `.Replace("\\u0110", "d")` doi ky tu `d` dac biet thanh `d` thuong khong dau. `.ToLowerInvariant()` ha chu thuong theo kieu khong phu thuoc locale. `.Replace(" ", ".")` doi khoang trang thanh dau cham. Cuoi cung cong them `@demo.local`. Ket qua la email mau nhu `nguyen.van.a@demo.local`. |
| 566-588 | Mot chi tiet cuc quan trong cho nguoi hoc doc code: trong file hien tai, `BuildDemoEmail(...)` khong duoc goi o dau ca. Nghia la day la helper du phong, helper dang cho tuong lai, hoac da tung duoc dung roi de lai. Khi doc code, khong phai moi ham xuat hien deu dang tham gia luong chay hien tai. |
| 590 | Dong `}` cuoi cung ket thuc class. Ban than dau ngoac dong mo khong lam nghiep vu, nhung no xac dinh pham vi cua toan bo field va method trong class nay. |

## 3. Luong chay that su cua file nay

Neu muon hieu file nay o muc "song" thay vi "chet", co the doc nhu sau:

1. Form duoc tao.
   Constructor chay.
   `InitializeComponent()` tao control.
   `ConfigureView()` lam dep, chen them layout dong, chen them o dia chi dong.
   `LoadStudents()` tai danh sach hoc vien.
   `WireEvents()` noi hanh vi user.
   `ApplyResponsiveLayout()` quyet dinh bo cuc.

2. User click 1 dong trong grid.
   Event `SelectionChanged` ban ra.
   `PopulateDetailFromSelection()` chay.
   Form goi service lay `StudentEntity` day du.
   Du lieu do len textbox, combobox, date picker, avatar.

3. User sua thong tin va bam Luu.
   `SaveCurrentStudent()` chay.
   `ValidateEditor()` chan loi input.
   Form tao `StudentEntity`.
   Service luu entity.
   Neu co avatar moi, service luu anh roi luu entity lan 2.
   Form tai lai grid va focus lai hoc vien vua luu.

4. User bam Xoa mem.
   Dialog xac nhan mo ra.
   Neu dong y, service danh dau xoa mem.
   Grid tai lai.
   Panel chi tiet reset.

5. User resize cua so.
   Event `Resize` ban ra.
   `ApplyResponsiveLayout()` doi bo cuc filter va splitcontainer.

## 4. Nhung khai niem nguoi moi rat de bi nham

### `partial class` khong phai la "class nua mua"

No chi la cach tach 1 class thanh nhieu file.
WinForms Designer sinh code rat dai, nen nguoi ta tach phan keo-tha giao dien ra file `.Designer.cs`.
File ban dang doc la phan logic.

### `DataTable` khong phai database

`DataTable` chi la bang du lieu trong bo nho.
No co hang, cot, ten cot, gia tri.
Service lay du lieu tu DB roi co the dong goi vao `DataTable` de grid xai.

### `DataSource` khong "copy tung cell" vao grid

Khi gan `DataSource`, grid duoc noi voi nguon du lieu.
Grid doc schema va noi dung tu nguon do de hien.
Day goi la data binding.

### `using var` o day khong lien quan `using namespace`

`using System.Data;` la import namespace.
`using var dialog = ...;` la co che dam bao object duoc dispose khi ra khoi scope.
Hai chu `using` giong nhau nhung nghia khac nhau.

### `null`, `?`, `?.`, `??` la 4 y khac nhau

- `string?` = bien nay duoc phep null.
- `?.` = neu ben trai null thi dung, khong nem loi.
- `??` = neu ben trai null thi lay gia tri ben phai.
- `null` = khong tro toi object nao ca.

### "Luu hoc vien" va "luu avatar" la 2 viec khac nhau

Hoc vien la du lieu logic.
Avatar la file vat ly tren o dia.
Vi the code phai co buoc luu entity va buoc luu file.

## 5. Ket luan cuc ngan

Neu phai tom file nay thanh 1 cau:

`FrmStudentManagement.cs` la bo dieu khien UI cho man hinh hoc vien, vua lo giao dien WinForms, vua noi voi service de doc-ghi du lieu, vua giu mot vai trang thai tam de xu ly avatar va layout dong.

Neu ban muon, toi se lam tiep cung muc do "sieu tinh vi" nay cho 1 trong 3 file sau:

- `FrmTeacherManagement.cs`
- `FrmEnrollment.cs`
- `Program.cs`
