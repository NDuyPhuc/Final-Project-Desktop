# Giai thich giao dien toan he thong, muc sieu chi tiet

## Muc tieu cua file nay

File nay khong giai thich nghiep vu theo kieu:

- hoc vien luu vao dau
- receipt query bang nao
- attendance save ra sao

File nay chi tap trung vao 1 chu de:

GIAO DIEN.

Cu the hon, no day nguoi moi:

- giao dien cua du an duoc to chuc theo lop nao
- mau sac, font, khoang cach, border, card, grid, button duoc dinh nghia o dau
- shell dashboard staff, teacher, admin duoc dung nhu the nao
- login screen duoc lap thanh bao nhieu panel
- report screen duoc che thanh 1 trang phuc hop ra sao
- dialog nho duoc dung de xac nhan va thong bao nhu the nao
- responsive trong WinForms duoc lam bang code ra sao
- cach designer file mo ta control tree nhu the nao
- cach 1 control di tu file `.Designer.cs` sang file `.cs` va tro thanh man hinh song

File nay co muc do chi tiet rat cao.

No se giai thich:

- ten control
- ly do control ton tai
- control nam trong panel nao
- panel nao nam trong shell nao
- shell nao phuc vu vai tro nao
- style nao duoc ap tu helper nao
- nguoi dung di chuot, click, chon row, resize form thi giao dien thay doi gi

## Scope code duoc dung de phan tich giao dien

File nay dua tren nhung nguon UI quan trong nhat:

- `Trung-tam-quan-ly-ngoai-ngu/Core/AppTheme.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Core/UiHelpers.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Common/BaseForms.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Common/FrmLogin.Designer.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Common/FrmLogin.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmStaffDashboard.Designer.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmStaffDashboard.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Teacher/FrmTeacherDashboard.Designer.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Teacher/FrmTeacherDashboard.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Admin/FrmAdminDashboard.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Admin/FrmAdminReports.Designer.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Admin/FrmAdminReports.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Dialogs/FrmConfirmDialog.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Dialogs/FrmStatusDialog.cs`

Va nhung module form tiep theo:

- `FrmStudentManagement.cs`
- `FrmTeacherManagement.cs`
- `FrmCourseManagement.cs`
- `FrmClassManagement.cs`
- `FrmEnrollment.cs`
- `FrmTuitionReceipt.cs`
- `FrmDebtTracking.cs`
- `FrmTeachingClasses.cs`
- `FrmAttendance.cs`
- `FrmScoreEntry.cs`

## Ban do lon: giao dien cua du an duoc chia thanh 4 lop

Neu nhin giao dien du an nhu mot toa nha,

thi co 4 lop chinh:

1. Lop style system.
2. Lop shell helpers.
3. Lop designer tree.
4. Lop behavior runtime.

### Lop 1: style system

No tra loi:

- mau nao la mau chinh
- font nao la font body
- button primary nhin ra sao
- button danger nhin ra sao
- grid co header mau nao
- card co border va padding nao

Lop nay nam chu yeu trong `AppTheme.cs`.

### Lop 2: shell helpers

No tra loi:

- module form duoc setup ra sao
- shell dashboard duoc setup ra sao
- dialog duoc setup ra sao
- child form duoc nhung vao panel host ra sao
- split container responsive doi orientation ra sao

Lop nay nam chu yeu trong `FormHostHelpers` o `BaseForms.cs`.

### Lop 3: designer tree

No tra loi:

- man hinh co nhung panel nao
- panel nao chua button nao
- button nao nam ben trai hay ben phai
- grid nam duoi card nao
- topbar va sidebar duoc ket noi ra sao

Lop nay nam trong cac file `.Designer.cs`.

### Lop 4: behavior runtime

No tra loi:

- luc mo form thi text nao bi dat lai
- luc resize thi bo cuc doi ra sao
- luc data bind thi grid hien cot nao
- luc active menu thi mau nut doi ra sao
- luc user click child module thi panel content bi thay nhu the nao

Lop nay nam trong cac file `.cs` logic.

## 1. Ngon ngu thi giac chung cua du an

Truoc khi di vao tung man hinh,

can nhin he mau va he font.

Do la DNA giao dien.

Neu khong thay DNA nay,

thi se chi thay "man hinh nay co panel, button, grid".

Nhung se khong thay tai sao nhin no giong nhau.

## 2. He mau sac trong `AppTheme.cs`

`AppTheme.cs` la noi dinh nghia palette.

Nhung mau chinh:

- `Sidebar = Color.FromArgb(230, 246, 255)`
- `SidebarHover = Color.FromArgb(224, 241, 250)`
- `Accent = Color.FromArgb(0, 110, 110)`
- `SidebarBrand = Color.FromArgb(0, 66, 118)`
- `SidebarActive = Color.FromArgb(144, 239, 239)`
- `SidebarText = Color.FromArgb(66, 71, 80)`
- `SidebarTitle = Color.FromArgb(7, 30, 39)`
- `Success = Color.FromArgb(41, 166, 124)`
- `Warning = Color.FromArgb(235, 179, 61)`
- `Danger = Color.FromArgb(224, 91, 97)`
- `Background = Color.FromArgb(245, 247, 251)`
- `Surface = Color.White`
- `Border = Color.FromArgb(225, 230, 239)`
- `TextPrimary = Color.FromArgb(42, 51, 64)`
- `TextMuted = Color.FromArgb(102, 112, 133)`

### `Background`

`Background` la mau nen mac dinh cua form.

No la xam xanh rat nhat.

Tac dung:

- tao cam giac sach
- lam card trang noi bat
- tranh form trang xoá quá gay

Neu tat ca form de trang tinh:

- card trang se khong tach duoc khoi nen
- nhin se phang hon

### `Surface`

`Surface` la mau trang.

No thuong dung cho:

- card
- group box
- vung noi dung ben trong

No tao cam giac "mat phang noi dung chinh".

### `Accent`

`Accent` la xanh ngoc dam.

No thuong duoc dung cho:

- primary button
- text nhan
- legend/chi tiet nhan manh

Y nghia giao dien:

- day la mau hanh dong chinh
- user se vo thuc nhin vao no de biet cho nao can bam

### `Danger`

`Danger` la do hong.

No duoc dung cho:

- button xoa
- KPI cong no hoac canh bao no nang

Y nghia:

- day la hanh dong/co so lieu co tinh canh bao

### `SidebarBrand` va `SidebarActive`

Day la 2 mau rat shell-based.

`SidebarBrand`

- xanh dam hon
- dung cho title, brand, text nhan manh

`SidebarActive`

- xanh ngoc nhat
- dung cho menu item dang active

Neu khong co `SidebarActive`:

- user kho thay dang o module nao

### `TextPrimary` va `TextMuted`

2 cap text nay rat quan trong.

`TextPrimary`

- text chinh
- tieu de
- noi dung can doc ro

`TextMuted`

- ghi chu
- subtitle
- helper text
- chu can de lui xuong

Y nghia:

- giao dien co do sau thong tin
- khong phai dong chu nao cung "giong nhau ve muc uu tien"

## 3. He font trong `AppTheme.cs`

Font duoc trung tam hoa:

- `FontBody = Segoe UI 10 regular`
- `FontBodyBold = Segoe UI 10 bold`
- `FontTitle = Segoe UI 20 bold`
- `FontSection = Segoe UI 11 bold`
- `FontKpi = Segoe UI 20 bold`
- `FontSidebarTitle = Segoe UI 12 bold`
- `FontSidebarMeta = Segoe UI 8.5 regular`
- `FontSidebarItem = Segoe UI 9.5 regular`
- `FontSidebarItemBold = Segoe UI 9.5 bold`

### Tai sao dung Segoe UI

Vi WinForms tren Windows rat hop `Segoe UI`.

No:

- de doc
- on dinh
- dong bo voi he thong
- ra tieng Viet kha on

### Phan cap typographic

Co 4 lop cap:

1. `FontTitle`
2. `FontSection`
3. `FontBodyBold`
4. `FontBody`

Va shell co 3 lop rieng:

1. `FontSidebarTitle`
2. `FontSidebarMeta`
3. `FontSidebarItem`

Nghia la:

- title man hinh khac title sidebar
- KPI khac text thuong
- button khac note text

Day la phan cap giao dien rat can thiet.

## 4. `AppTheme.ApplyFormStyle(...)` la nen tong quat cua form

Method nay dat:

- `Text`
- `StartPosition = CenterScreen`
- `BackColor = Background`
- `Font = FontBody`
- `AutoScaleMode = Dpi`
- `MinimumSize`

Y nghia:

- moi form co nen giong nhau
- moi form scale theo DPI
- moi form co kich thuoc toi thieu

Neu bo helper nay:

- moi form tu set rieng
- style de lech nhau

## 5. Style button la cot song cua action

### `StylePrimaryButton`

No set:

- `BackColor = Accent`
- `ForeColor = White`
- `FlatAppearance.BorderSize = 0`
- `FlatStyle = Flat`
- `Cursor = Hand`
- `Font = FontBodyBold`
- `Height = scale theo DPI`

Ban chat hinh anh:

- day la nut hanh dong chinh
- nen mau dam
- chu trang
- khong co border gan

Ung dung:

- `Luu`
- `Them`
- `Dang nhap`
- `Xem danh sach`
- `Mo attendance`

### `StyleSecondaryButton`

No set:

- nen trang
- chu `Accent`
- border 1 pixel theo `Accent`
- flat
- chuot tay
- font bold

Hinh anh:

- day la nut phu
- co vien
- van ro la clickable

Ung dung:

- `Lam moi`
- `Chon anh`
- `Xuat file`
- `Xem receipt`

### `StyleDangerButton`

No set:

- nen do
- chu trang
- border 0
- flat
- cursor hand
- font bold

Hinh anh:

- day la nut can can nhac

Ung dung:

- `Xoa mem`
- `Dang xuat` tren mot so shell

## 6. `StyleGroupBox` tao hop thong tin dong bo

No set:

- `BackColor = Surface`
- `ForeColor = TextPrimary`
- `Font = FontSection`
- `Padding = scale padding`

Tac dung:

- group box thanh 1 card thong tin mem hon
- title group box no hon body text

Ung dung:

- `grpStudentInfo`
- `grpEnrollmentSummary`
- `grpPaymentInfo`

## 7. `StyleCard` la DNA cua dashboard

No set:

- nen trang
- border fixed single
- padding 14
- margin 0,0,12,12 sau khi scale

Card trong du an duoc dung rat nhieu:

- KPI card
- warning card
- report chart card
- recent receipt card
- hero card

Card la "mat phang chua noi dung".

Nhin vao dashboard,

gan nhu toan bo cau truc lon deu la card.

## 8. `StyleGrid` la DNA cua DataGridView

Day la mot trong nhung method giao dien quan trong nhat.

No set:

- `BackgroundColor = White`
- `BorderStyle = None`
- `CellBorderStyle = SingleHorizontal`
- `ColumnHeadersBorderStyle = None`
- `EnableHeadersVisualStyles = false`
- header back color = xam xanh nhat
- header fore color = `TextPrimary`
- header font = `FontBodyBold`
- header wrap = true
- header height = scale
- row height = scale
- hide row header
- `SelectionMode = FullRowSelect`
- `MultiSelect = false`
- cam add/delete row truc tiep
- `AutoSizeColumnsMode = Fill`
- `GridColor = Border`
- selection back color = xanh rat nhat
- selection fore color = `TextPrimary`

Va quan trong hon:

- gan event `DataBindingComplete`
- gan event `CellFormatting`
- gan event `DataError`

### Nghia thi giac cua grid nay

Grid trong app co dac diem:

- header nhe
- row sach
- khong row header ben trai
- click 1 cai la chon full row
- selection khong gay mat

No khong theo style co dien mac dinh cua WinForms.

No duoc "hiện đại hóa" bang theme helper.

### Tai sao `SelectionMode = FullRowSelect` quan trong

Vi rat nhieu flow cua app la:

- chon hoc vien
- chon lop
- chon receipt
- chon row cong no

User khong lam viec tren tung cell rieng.

User lam viec tren doi tuong.

Nên full row select hop logic hon cell select.

### Tai sao `MultiSelect = false`

Vi nhieu form khong ho tro thao tac batch.

No muon:

- 1 row dang chon
- 1 panel detail tuong ung

Neu cho multi-select:

- panel detail se kho dinh nghia

### `DataBindingComplete`

Sau khi grid bind data xong,

`AppTheme` goi `ApplyGridHeaderText`.

No co nghia:

- grid co the sinh cot dong
- sau khi sinh xong moi sua header text

Day la ly do giao dien grid duoc Viet hoa/tieng Viet hoa dong bo.

### `CellFormatting`

No goi `LocalizeGridCellFormatting`.

Tac dung:

- bien text stored kiem ky thuat thanh text hien thi de doc

Vi du:

- `Con mo` thanh `Còn mở`
- `Dang hoc` thanh `Đang học`
- `Tien mat` thanh `Tiền mặt`

### `DataError`

Grid data error bi nuot va log UI trace.

Y nghia giao dien:

- tranh vang app vi mot cell bind loi
- user khong bi dump exception
- dev van co trace

## 9. `GridHeaderText` va `GridCellText` la bo tu dien giao dien

`GridHeaderText` la map ten cot sang ban hien thi tieng Viet dep hon.

Vi du:

- `Ma hoc vien` -> `Mã học viên`
- `Ho ten` -> `Họ tên`
- `Dien thoai` -> `Điện thoại`
- `Con no` -> `Còn nợ`
- `Phuong thuc` -> `Phương thức`
- `Diem tong` -> `Điểm tổng`

`GridCellText` la map gia tri cell sang text de doc.

Vi du:

- `Tat ca` -> `Tất cả`
- `Dang day` -> `Đang dạy`
- `Da dong` -> `Đã đóng`
- `Tien mat` -> `Tiền mặt`

Tac dung lon:

- service co the tra ve chuoi ASCII/plain de de code
- UI la noi chot hien chu co dau, dep, de doc

## 10. `RoundPanelCorners` dang de rong

Method `RoundPanelCorners(Panel panel, int radius = 10)` hien rong.

Day la chi tiet giao dien hay:

- du an co y dinh bo tron card
- nhung implementation hien tai chua co

No la dau vet cua mot huong thiet ke chua hoan tat.

## 11. `UiHelpers.cs` la hop do lego giao dien

Neu `AppTheme` la quy tac ve dep,

thi `UiHelpers` la bo vat lieu lap nhanh giao dien.

No co helper tao:

- panel
- label
- textbox
- combo
- date picker
- button
- button bar
- grid
- group box
- field grid
- labeled field
- content grid
- metric card
- picture box
- chart

## 12. `CreatePanel(...)`

No tao panel co:

- `Name`
- `Dock`
- `BackColor = Surface`

Y nghia:

- panel moi mac dinh la mat phang trang
- de tan dung lam card/container

## 13. `CreateLabel(...)`

No tao label co:

- text
- font optional
- mau optional
- `AutoSize = true`
- margin duoi 8

Y nghia:

- label tao bang helper thuong duoc stack theo chieu doc
- margin duoi 8 tao nhịp thở

## 14. `CreateTextBox(...)`

No tao textbox co:

- placeholder
- margin duoi 10
- width 220

Do cho thay:

- helper nay phu hop bo form field co do rong vua

## 15. `CreateComboBox(...)`

No:

- dat `DropDownStyle = DropDownList`
- width 220
- co the add item ngay
- neu co item thi auto select item 0

Y nghia giao dien:

- helper uu tien combo box chon tu danh sach
- tranh cho user go text tu do trong nhieu ngu canh

## 16. `CreateDateTimePicker(...)`

No:

- format short
- width 220

Dat nguon cho field ngay don gian.

## 17. `CreateButton(...)`

No cho phep:

- truyen `style = primary`
- `secondary`
- `danger`

Y nghia:

- helper button la wrapper cua `AppTheme`
- tao nhanh nut ma khong can viet 3 dong style moi lan

## 18. `CreateButtonBar(...)`

No tao `FlowLayoutPanel`:

- auto size
- dock fill
- left to right
- khong wrap
- transparent

Day la pattern nhom nut hanh dong.

## 19. `CreateGrid(...)`

No tao grid:

- dock fill
- bind thang data
- `ReadOnly = false`
- roi goi `AppTheme.StyleGrid`

Nghia la:

- helper nay uu tien mot grid da co style toan app

## 20. `CreateGroupBox(...)`

No tao group box va style ngay.

Muc dich:

- bo thong tin co vien/gioi han ro rang

## 21. `CreateFieldGrid(...)`

No tao `TableLayoutPanel`:

- fill
- row/column count co san
- moi cot chia deu phan tram
- moi row auto size

Y nghia:

- day la helper rat hop voi form data entry
- bo field co the xep 2 cot, 3 cot rat nhanh

## 22. `CreateLabeledField(...)`

No tao:

- panel cha
- flow stack top-down
- label o tren
- input o duoi

Day la pattern field UI co label-input co dien.

## 23. `CreateContentGrid(...)`

No tao `TableLayoutPanel` tu danh sach percent.

Vi du:

- 68F, 32F

thi ra 2 cot.

Do la pattern rat hop voi:

- list ben trai
- summary ben phai

nhu o enrollment.

## 24. `CreateMetricCard(...)`

Day la helper UI rat co gia tri.

No tao 1 KPI card co:

- panel chinh
- `StyleCard`
- thanh accent doc ben trai
- content table
- title
- value

Hinh anh:

- day la card KPI du kieu dashboard

No rat giong nhom card:

- so hoc vien moi
- so lop dang day
- doanh thu
- debt

## 25. `CreatePictureBox(...)`

No tao khung anh co:

- back color nhat
- border 1 net
- `Zoom`
- size 160x160

Pattern nay xuat hien ro o student avatar va teacher avatar.

## 26. `CreateChart(...)`

No tao chart:

- dock fill
- palette pastel
- chart area
- axisX khong major grid
- axisY co major grid mau border
- legend docking bottom

No cho thay du an co helper chart chung, du admin reports hien tai da co chart setup rieng phuc tap hon.

## 27. `BindRevenueSeries(...)`

No tao demo series:

- cot doanh thu
- mau accent
- diem Th1, Th2, Th3, Th4

Day giong helper mock/demo chart.

## 28. `ShowChildForm(...)` trong `UiHelpers`

No:

- dispose control cu
- clear host
- set child `TopLevel = false`
- `FormBorderStyle = None`
- `Dock = Fill`
- add vao host
- `Show()`

No la ban don gian hon `FormHostHelpers.OpenChildForm(...)`.

Y nghia:

- shell du an da trai qua hon 1 lop helper
- `FormHostHelpers` la helper shell nang hon, co log va optimized rendering

## 29. `FormHostHelpers` la bo khung shell toan app

Day la file giao dien cuc ky quan trong.

No khong ve mau.

No ve:

- quy tac host form
- mo child form
- responsive split
- DPI scaling
- menu active state
- rendering optimization
- dialog surface

## 30. `ConfigureModuleSurface(...)`

Day la setup cho module form thong thuong.

No set:

- title
- back color
- font
- `AutoScaleMode = Dpi`
- `AutoScroll = false`
- `StartPosition = CenterScreen`
- minimum size neu form chua co
- optimized rendering

Y nghia:

- tat ca module CRUD/list/read-only co mot nen chung

## 31. `ConfigureShellSurface(...)`

Day la setup cho shell dashboard.

No giong module surface nhung co diem khac:

- de designer mode thi `WindowState = Normal`
- runtime thi `WindowState = Maximized`
- minimum size 1200x720

Y nghia:

- shell duoc thiet ke de chay full-window
- module con o trong shell thi khong can maximize rieng

## 32. `ConfigureDialogSurface(...)`

Day la setup cho dialog.

No set:

- `BackColor = Surface`
- center parent
- minimum size theo tham so

Y nghia:

- dialog la vat the nho, noi tren form cha
- style gọn hon, trang hon

## 33. `OpenChildForm(...)` la xương sống cua navigation shell

Flow cua no:

1. log UI start
2. tat autoscroll host
3. suspend layout
4. duyet nguoc control cu
5. neu control cu la `Form` thi close + dispose
6. neu khong thi remove
7. clear hẳn host
8. set form con `TopLevel = false`
9. bo border
10. dock fill
11. add vao host
12. bat optimized rendering cho child
13. show child
14. log UI shown
15. resume layout

Y nghia:

- shell khong mo form con kieu popup
- shell nhung module vao content host
- user co cam giac app mot cua so, nhieu module

## 34. `OpenLoginAndClose(...)`

Day la luong dang xuat giao dien.

No:

- `Hide()` form hien tai
- xoa `CurrentUser`
- mo `FrmLogin` modal
- dong form cu

Y nghia:

- dang xuat khong phai chi close shell
- no quay ve login gate

## 35. `EnableAdaptiveScrolling(...)` hien dang no-op

Code comment noi ro:

- tung form se tu quyet co can scroll host that hay khong

Y nghia giao dien:

- tac gia da bi van de voi viec helper chung "vo tinh" pha scroll cua dashboard/report
- nen chon cach no-op de tung form tu chiu trach nhiem

Day la bai hoc UI rat thuc te:

- helper qua tong quat doi khi gay bug layout

## 36. `SetActiveMenu(...)`

Day la engine visual cua menu active.

Neu button la active:

- back color = `SidebarActive`
- fore color = `Accent`
- font = sidebar bold

Neu khong active:

- back color transparent
- fore color `SidebarText`
- font = sidebar regular

Y nghia:

- active state duoc thong nhat staff/teacher/admin

## 37. `EnableOptimizedRendering(...)`

No goi reflection set `DoubleBuffered` cho control.

Y nghia:

- giam nhap nhay
- giam flicker khi redraw
- rat can trong WinForms co nhieu panel/grid/split

No con:

- de quy qua child controls
- xu ly ca `SplitContainer.Panel1` va `Panel2`

Day la toi uu giao dien o muc rendering, khong chi thiet ke.

## 38. DPI scaling helpers

Co 3 helper:

- `ScaleForDpi`
- `ScaleSize`
- `ScalePadding`

Ban chat:

- mot kich thuoc logical duoc nhan theo `DeviceDpi / 96`

Y nghia:

- 1 button cao 36 tren man 96 DPI se lon len tuong ung tren 120/144/192 DPI

Neu khong scale:

- man hinh 150 phan tram co the trong chat

## 39. Split responsive helpers

Co:

- `EnsureSafeSplitOrientation(...)`
- `ApplySafeSplitterDistance(...)`
- `ApplyResponsiveSplit(...)`

Y nghia:

- khi doi orientation cua `SplitContainer`, neu lam tho co the bi vo `SplitterDistance`
- helper nay doi orientation an toan
- sau do clamp khoang cach giua 2 panel vao min/max hop le

Day la ky thuat giao dien rat thuc chien.

## 40. `LogUi(...)`

No ghi `ui-trace.log`.

Giao dien duoc trace theo message.

Tac dung:

- debug navigation
- debug grid data error
- debug child form open sequence

No cho thay:

- du an khong chi log loi nghiep vu
- no con log event giao dien quan trong

## 41. Biet doc `.Designer.cs` la biet doc bo xuong giao dien

Nguoi moi rat hay so file `.Designer.cs`.

Nhung UI WinForms song trong do.

Khi doc designer,

co 5 dieu can nhin:

1. danh sach control field o dau file
2. thu tu `InitializeComponent()`
3. `Controls.Add(...)`
4. `Dock`, `Anchor`, `Padding`, `Margin`
5. ten control

Ten control trong file nay rat giau nghia:

- `pnl` = panel
- `lbl` = label
- `txt` = textbox
- `btn` = button
- `dgv` = grid
- `tbl` = table layout
- `flp` = flow layout panel
- `grp` = group box
- `pic` = picture
- `ppd`/`prd` = print preview/print document

## 42. Login screen la giao dien doc, co card trung tam

`FrmLogin.Designer.cs` cho thay login co mot control cha cuc quan trong:

- `pnlLoginContainer`

Trong no co 3 lop:

- `pnlLoginHeader`
- `pnlLoginFormContent`
- `pnlLoginFooter`

Hinh dung de nhat:

- dau trang la hero/header
- giua la form nhap
- duoi la footer support/version

## 43. Cau truc control cua login

Login container:

- `pnlLoginHeader`
- `pnlLoginFormContent`
- `pnlLoginFooter`

Trong `pnlLoginHeader`:

- `pnlLoginHeaderOverlay`
- `picHeaderLogo`
- `lblHeaderTitle`
- `lblHeaderSubtitle`

Trong `pnlLoginFormContent`:

- `pnlErrorAlert`
- `lblUsername`
- `pnlUsernameInput`
- `lblPassword`
- `pnlPasswordInput`
- `pnlSubControls`
- `pnlActionButtons`

Trong `pnlSubControls`:

- `tblSubControls`
- `chkShowPassword`
- `lnkForgotPassword`

Trong `pnlActionButtons`:

- `btnExit`
- `btnLogin`

Trong `pnlLoginFooter`:

- `tblFooter`
- `lblFooterVersion`
- `lblFooterSupport`

Day la mot form login rat co y thuc cau truc.

## 44. `pnlLoginContainer` la card login that su

No co:

- back color white
- minimum size 448x678
- nam giua cua so

Y nghia:

- login khong trai rong full background
- no la 1 card trung tam
- user tap trung vao 1 khoi form ro rang

## 45. Footer login

`pnlLoginFooter`:

- mau xam rat nhat
- dock bottom
- cao 56

Trong no, `tblFooter` chia 2 cot 50/50.

Ben trai:

- version

Ben phai:

- support

Y nghia:

- footer khong chi de trang tri
- no cho user biet ban build va support context

## 46. Form content login

`pnlLoginFormContent`:

- back color xam nhat
- dock fill
- auto scroll true

Chi tiet auto scroll true cho thay:

- designer cho phep login content van cuon duoc neu scale lon

No chua:

- error alert
- username label/input
- password label/input
- helper row
- action buttons

## 47. Username input va password input khong dung textbox trần

Designer cho thay:

- `pnlUsernameInput`
- `pnlPasswordInput`

Moi panel input chua:

- icon panel ben trai
- textbox ben trong

Y nghia:

- input duoc "boc" trong panel de tao card mini
- border/background duoc dieu khien o panel
- textbox ben trong de `BorderStyle = None`

Day la ky thuat UI rat thuong gap de input nhin dep hon textbox mac dinh.

## 48. Action buttons cua login theo bo cuc 2 nut ngang

`pnlActionButtons` chua:

- `btnExit`
- `btnLogin`

Kich thuoc:

- 2 nut ngang
- rong 184 moi nut
- cao 44

Mau:

- `btnExit` xam
- `btnLogin` xanh dam

Y nghia:

- thoat la hanh dong phu
- dang nhap la hanh dong chinh

## 49. Link `Quen mat khau?` va checkbox `Hien mat khau`

Day la vi du giao dien rat de doc:

- ben trai: checkbox show password
- ben phai: forgot password link

No duoc xep bang `TableLayoutPanel` 58/42.

Y nghia:

- cot trai uu tien control thuc dung
- cot phai chua action text link

## 50. Staff dashboard la shell 3 lop

`FrmStaffDashboard.Designer.cs` cho thay 3 khoi lon:

- `pnlSidebarStaff`
- `pnlTopbarStaff`
- `pnlContentHostStaff`

Day la shell pattern co dien cua du an.

Neu nhin ben mat:

- trai la menu
- tren la topbar
- con lai la noi dung

## 51. Sidebar staff

Sidebar staff chua 3 phan:

- `pnlSidebarBrandStaff`
- `flpSidebarMenuStaff`
- `pnlSidebarFooterStaff`

Brand:

- `lblSidebarBrandLine1`
- `lblSidebarBrandLine2`
- `lblSidebarBrandSubtitle`

Menu:

- dashboard
- hoc vien
- giao vien
- khoa hoc
- lop hoc
- ghi danh
- thu hoc phi
- cong no

Footer:

- logout

Y nghia:

- day la shell operation control
- menu nhin la thay toan bo nghiep vu staff

## 52. Brand text cua staff dashboard

Designer:

- `LINGUISTIC`
- `ARCHITECT`
- subtitle `OPERATIONAL CONTROL`

Logic file `.cs` lai localize va style tiep.

Y nghia giao dien:

- shell staff mang tinh "he thong dieu phoi"
- brand duoc dua len rat ro, khong chi la ten form don thuan

## 53. Topbar staff

Topbar chua:

- `lblTopbarTitleStaff`
- `flpTopbarActionsStaff`
- `btnTopbarNotifyStaff`
- `btnTopbarSettingsStaff`
- `btnTopbarHelpStaff`
- `pnlTopbarProfileStaff`
- `lblCurrentUserStaff`
- `lblCurrentRoleStaff`
- `pnlTopbarAvatarStaff`
- `lblTopbarAvatarStaff`

Y nghia:

- topbar vua la title bar nghiep vu
- vua la profile zone
- vua la utility zone

## 54. Content host staff

`pnlContentHostStaff` chua:

- `pnlDashboardHome`

Khi mo child module,

chinh panel nay se bi clear va nhung form con vao.

Day la linh hon cua shell.

## 55. Dashboard home staff

Trong dashboard home co:

- `tblStaffDashboardRoot`

Trong root nay co:

- `tblStaffKpi`
- `tblStaffMain`
- card progress

KPI:

- new students
- available classes
- today receipts
- debt students

Main content:

- recent receipt card
- task card
- weekly progress card

Y nghia:

- staff dashboard nghiêng ve tong quan van hanh + task + phieu thu gan day

## 56. KPI card staff

Moi KPI card co cau truc:

- panel card
- panel accent doc
- title
- value
- badge

Mau accent thay doi theo KPI:

- new students: xanh
- available classes: xanh neutral
- receipts: xanh ngoc
- debt: do

Y nghia:

- khong chi khac text
- khac ca mui cam xuc thi giac

## 57. Recent receipts grid tren staff dashboard

Designer cho thay:

- `pnlRecentReceiptCard`
- `pnlRecentReceiptHeader`
- `lblRecentReceiptTitle`
- `lnkRecentReceiptAll`
- `dgvRecentReceipts`

Y nghia:

- card nay la du lieu dong
- header card co title + link xem tat ca
- grid duoc dung la bang preview nhanh, khong phai editor day du

## 58. Task card staff

Card task dung:

- `flpStaffTaskList`
- `btnAddTaskStaff`

Logic code tao card task bang code.

Nghia la:

- designer chi tao host
- runtime moi build card item

Day la phan giao dien semi-dynamic.

## 59. Weekly progress card staff

No chua:

- `flpWeeklyLegend`
- 2 panel legend
- `flpWeeklyProgressGrid`
- summary

Noi nay mang tinh infographics nhe.

No khong phai grid du lieu truyen thong.

## 60. Teacher dashboard la shell gon hon staff

Teacher dashboard cung 3 lop:

- sidebar
- topbar
- content host

Nhung menu gon hon staff:

- dashboard
- lop dang day
- ds hoc vien lop
- diem danh
- nhap diem

Y nghia:

- teacher shell pham vi hep hon
- tap trung vao lop duoc phan cong

## 61. Brand va subtitle teacher

Designer cho thay:

- title `TEACHER`
- subtitle `Tập trung vào lớp được giao`

Logic `.cs` sau do doi thanh bo brand mang phong cach:

- `LINGUISTIC`
- `ARCHITECT`
- `TEACHER PORTAL`

Day cho thay:

- designer dat khung/co so
- runtime co the localize va restyle de thanh phien ban cuoi

## 62. Topbar teacher

Don gian hon staff.

No chua:

- role
- current user
- logout

Khong co cum button notify/help giong staff.

Y nghia:

- teacher shell gian don hon
- tap trung vao nghiep vu day hoc hon utility

## 63. Dashboard home teacher

Root teacher chua:

- `pnlTeacherHeroCard`
- `tblTeacherKpi`
- `splTeacherDashboard`

Hero card:

- title dashboard
- subtitle mo ta pham vi

KPI:

- so lop dang day
- tong hoc vien
- session hom nay
- score pending

Split bottom:

- class overview card
- task card

Day la dashboard nghiêng giang day ro rang.

## 64. Hero card teacher

Hero card la card mo dau rong.

Nó:

- trang
- padding 24,20,24,20
- title lon 20pt bold
- subtitle muted

Tac dung:

- mo ta "cam canh" cua dashboard truoc khi user xuong KPI va grid

## 65. KPI teacher

Designer cho thay 4 cot deu 25%.

Moi card la panel trang co padding 18.

Value dock fill va can giua.

Y nghia:

- KPI teacher rat so lieu
- khong qua nhieu text phu
- nhan vao con so

## 66. `splTeacherDashboard`

Teacher dashboard dung `SplitContainer`.

No chia:

- trai: class overview
- phai: task card

Logic `.cs` doi orientation va splitter distance theo responsive.

Y nghia:

- desktop rong: 2 cot
- hep: co the stack doi orientation

## 67. Teacher class overview card

No chua:

- title
- hint
- `dgvTeacherClassOverview`

Y nghia:

- giao vien can 1 bang tong quan cac lop dang day
- tu day ho nhin nhanh duoc pham vi cong viec

## 68. Teacher task card

No dung:

- `lstTeacherTaskQueue`

Khac staff dung card task panel tu build tay.

Teacher dung list box.

Y nghia:

- 2 dashboard khong copy y nguyen
- shell giu giong, chi tiet noi dung khac

## 69. Admin dashboard khong co designer mo trong dot nay, nhung code logic da tiet lo hinh dang

Qua `FrmAdminDashboard.cs`, co the thay shell admin co:

- sidebar admin
- topbar admin
- content host admin
- user card
- KPI accounts/classes/revenue/debt
- warning grid
- snapshot grid

No la dashboard governance.

## 70. User card admin

Code cho thay:

- `pnlAdminUserCard`
- `lblAdminUserCardName`
- `lblAdminUserCardRole`

Va co `LayoutAdminUserCard()` tinh lai vi tri va chieu cao theo content.

Y nghia:

- user card admin la mot card riemg, khong chi la text trên topbar
- admin shell de cao danh tinh session va role ro rang

## 71. KPI admin khac KPI teacher/staff o thong diep

Admin KPI:

- tong account
- lop active
- doanh thu tong
- tong no

Staff KPI:

- hoc vien moi
- lop kha dung
- receipts
- debt count

Teacher KPI:

- teaching classes
- students
- today sessions
- pending scores

Y nghia giao dien:

- cung mot mo-tip KPI card
- nhung doi thong diep theo vai tro

## 72. Admin report screen la man hinh giao dien phuc tap nhat

Chi can nhin designer da thay no la mot report page that:

- header
- action button
- filter card
- KPI row
- chart card
- side insight cards
- detail grid

No la man hinh giao dien giau thong tin nhat trong du an.

## 73. Root layout cua admin reports

Designer cho thay:

- `tblAdminReportRoot`

No chua 5 dong lon:

1. `pnlAdminReportHeader`
2. `pnlAdminReportFilterCard`
3. `tblReportKpi`
4. `tblReportMiddle`
5. `pnlReportDetailCard`

Day la bo cuc page doc.

No giong 1 report canvas hon la 1 form CRUD.

## 74. Header report

Header card chua:

- title block
- meta flow
- action buttons flow

Title block:

- `lblAdminReportTitle`
- `flpAdminReportMeta`
- `lblAdminReportSession`
- `lblAdminReportStatus`

Action flow:

- `btnPrintReport`
- `btnRefreshData`
- `btnExportReportCsv`

Y nghia:

- header report khong chi co title
- no co "ngữ cảnh phiên"
- va utility action

## 75. Filter card report

Filter card chua:

- `lblReportType`
- `lblReportFromDate`
- `lblReportToDate`
- `cboReportType`
- `dtpReportFromDate`
- `dtpReportToDate`
- `btnViewReport`

O muc giao dien:

- no la bo loc report co cấu trúc rat ro
- title o tren
- input o duoi

## 76. KPI row report

KPI row report chua 4 card:

- revenue
- enrollment
- class count
- retention

Moi card lai co:

- accent panel
- title
- value
- trend
- icon

No giau hon KPI teacher/staff.

Ly do:

- report screen can show xu huong, khong chi con so.

## 77. Chart card

Chart card chua:

- `pnlReportChartHeader`
- `lblReportChartTitle`
- `flpChartLegend`
- `chtAdminRevenue`

Legend chua:

- `pnlChartLegendRevenue`
- `lblChartLegendRevenue`
- `pnlChartLegendTarget`
- `lblChartLegendTarget`

Y nghia:

- chart duoc boc trong card rieng
- legend custom khong phu thuoc 100 phan tram vao legend mac dinh cua chart

## 78. Side insight cards trong report

Ben canh chart co:

- `pnlReportHighlightCard`
- `pnlReportDistributionCard`

Highlight card:

- icon
- title
- body
- progress track
- progress fill

Distribution card:

- title
- bang mini top 3 khoa hoc

Day la report storytelling.

No khong chi hien chart va grid.

No con to narrative card.

## 79. Detail card report

No chua:

- `pnlReportDetailHeader`
- `lblReportDetailTitle`
- `lblReportDetailPaging`
- `flpReportDetailNavigation`
- prev/next button
- `dgvAdminReportDetail`

Y nghia:

- report chi tiet co phan heading rieng
- co paging indicator
- co navigation button
- grid detail la lop cuoi cung cua report

## 80. Report la vi du ro nhat cua "designer + runtime layout"

Designer chi dat khung:

- panel nao chua panel nao
- control nao ton tai

Runtime code lam:

- dat height row
- doi layout theo width
- doi text button theo width
- doi minimum size
- tinh scroll height
- doi header layout compact/normal

Day la man ket hop giao dien tinh va giao dien dong.

## 81. Dialog confirm va status co triet ly cuc ro

Confirm dialog:

- title
- message
- 2 nut

Status dialog:

- title
- message
- 1 nut dong

Ca hai:

- goi `ConfigureDialogSurface`
- scale chrome
- center parent

Y nghia:

- app khong dung `MessageBox` cho moi truong hop
- co dialog co thuong hieu rieng

## 82. `ScaleDialogChrome()` la tinh yeu cho DPI

Trong confirm/status dialog,

ham nay scale:

- padding root
- margin title
- margin action row
- size button

Tac dung:

- dialog nho van dep tren monitor scale lon

## 83. Pattern shell-module-dialog cua du an

Du an UI nay khong phang.

No co 3 tang hien thi:

Tang 1: Shell.

- staff dashboard
- teacher dashboard
- admin dashboard

Tang 2: Module.

- student management
- class management
- debt tracking
- attendance
- score entry
- reports

Tang 3: Dialog.

- confirm
- status
- image preview

Moi tang co quy tac style rieng,

nhung cung dung chung theme va helper.

## 84. Module form co cong thuc giao dien lap lai

Rat nhieu module CRUD/list co cong thuc:

1. `ConfigureModuleSurface`
2. `ConfigureView`
3. `LoadData`
4. `WireEvents`

Trong `ConfigureView`, thuong co:

- `AppTheme.StyleGrid`
- `AppTheme.StylePrimaryButton`
- `AppTheme.StyleSecondaryButton`
- dat `AutoGenerateColumns`
- dat `AutoSizeColumnsMode`
- dat placeholder
- dat `SelectedIndex`

Y nghia:

- module giao dien duoc lam theo mot khuon rat thong nhat

## 85. Student management la form module responsive dep nhat nhom staff

Ve mat giao dien, form nay co nhieu ky thuat:

- filter card dung lai bang code
- detail panel co avatar
- split container doi orientation
- address field chen dong

No cho thay:

- UI khong chi keo-tha Designer
- nhieu phan duoc "lap trinh hoa" de linh hoat hon

## 86. Enrollment va TuitionReceipt la 2 form module rat nghiep vu

Ve giao dien:

`FrmEnrollment`

- 2 grid song song logic
- summary pane ben phai
- course filter chen dong

`FrmTuitionReceipt`

- context thong tin ghi danh
- payment editor
- receipt history grid
- print preview flow

Y nghia:

- giao dien du an khong chi CRUD table
- no co nhung man phuc hop de dan user di theo quy trinh

## 87. Debt tracking la giao dien read-heavy

No nghieng ve:

- bo loc
- grid
- summary cards
- export

No khong nghieng ve data entry.

UI cua no phan biet ro:

- data input = filter
- data output = grid + KPI
- action = export / open receipt

## 88. Teacher modules co giao dien gọn hơn staff

Vi teacher flow hep hon.

Nhin vao:

- `FrmTeachingClasses`
- `FrmAttendance`
- `FrmScoreEntry`

de thay:

- it bo filter hon
- tap trung grid + vài nut
- khong dong dao helper CRUD field

No phu hop vai tro:

- giao vien khong can quan ly toan bo object
- chi can thao tac tren pham vi duoc giao

## 89. Visual language cua grid trong teacher module

Attendance:

- checkbox present/absent
- class/session combo

Score entry:

- score cell edit
- readonly ma hoc vien, ho ten

Teaching classes:

- filter tu khoa + status
- open module button

No cho thay grid khong chi de doc.

Grid co the la:

- selector
- editor
- preview list

## 90. Sidebars la ngon ngu dieu huong chinh cua du an

Ca 3 shell staff, teacher, admin deu dung sidebar trai.

Vi sao?

- desktop rong hop sidebar
- module trong app nhieu
- user can thay toan bo map module cung luc

So voi top menu ngang,

sidebar:

- chứa duoc nhieu muc hon
- co brand o tren
- co logout/footer o duoi

## 91. Topbars la ngon ngu ngu canh

Topbar cua shell thuong lo:

- title module hien tai
- utility buttons
- profile info
- logout mot so shell

Sidebar lo navigation.

Topbar lo context va identity.

## 92. Cards la ngon ngu tom tat

Trong du an nay, card thuong dung de:

- KPI
- hero introduction
- recent receipts
- task queue
- warning
- report insight
- distribution

Card giup:

- gom thong tin thanh cum
- tach bang border/padding
- tao nhịp thi giac

## 93. `Padding` va `Margin` la linh hon cua nhịp giao dien

Nguoi moi hay bo qua.

Nhung trong du an nay:

- card margin 12
- input margin 8/10
- sidebar padding 18/24/30
- topbar padding 24
- header card padding 20/24

Y nghia:

- khong gian trang duoc lap trinh co chu y
- UI de tho

## 94. `Dock` la vua cua layout WinForms

Trong du an nay, `Dock` xuat hien rat nhieu:

- `DockStyle.Left` cho sidebar
- `DockStyle.Top` cho topbar
- `DockStyle.Fill` cho content
- `DockStyle.Bottom` cho footer

Tai sao quan trong?

Vi WinForms khong co flexbox/auto layout hien dai nhu web.

`Dock` la cach chinh de lap khung lon.

## 95. `TableLayoutPanel` la bo xep canh thong minh nhat cua du an

Du an xai `TableLayoutPanel` cho:

- login footer
- login sub controls
- topbar
- dashboard root
- KPI row
- report root
- report filter
- report middle
- enrollment columns

Y nghia:

- giao dien co tinh he thong
- bo tri theo hang/cot ro rang

## 96. `FlowLayoutPanel` la bo xep nhom item chay

Du an xai `FlowLayoutPanel` cho:

- sidebar menu
- topbar action
- button actions
- task list
- legend
- meta tags

FlowLayoutPanel phu hop:

- item lap lai
- item co the wrap
- item thu tu trai-phai hoac tren-duoi

## 97. `SplitContainer` xuat hien o dashboard va module 2 cot

Split cho:

- teacher dashboard bottom
- admin dashboard bottom
- student module

No phu hop khi:

- can 2 vung co the keo/chinh ti le
- muon doi orientation khi responsive

## 98. `AutoScroll` duoc bat/tat co chu y, khong phai tuy hung

Rat nhieu form dat:

- shell content host `AutoScroll = false`
- card `AutoScroll = false`
- report root `AutoScroll = true`
- login content `AutoScroll = true`

Y nghia:

- tac gia biet cho nao can cuon that
- cho nao cuon se pha layout

## 99. Designer la khung, runtime la dao khac

Diem hay nhat cua UI du an nay:

designer file khong phai ban cuoi.

Runtime code con:

- doi text
- doi color
- doi width/height
- chen panel moi
- doi menu active
- doi header layout theo width
- build task card bang code
- build course filter bang code

Nghia la:

- UI khong bi dong cung trong Designer

## 100. Login screen va dashboards co 2 triet ly thi giac khac nhau

Login:

- card trung tam
- mot tac vu duy nhat
- doi xung
- tap trung

Dashboard:

- shell trai-phai
- nhieu thang thong tin
- navigation luon hien
- workflow dai hoi

Day la dung triet ly UX.

## 101. Giao dien theo vai tro

Staff:

- mau shell sang
- KPI van hanh
- task queue
- receipts/debt

Teacher:

- shell gon
- KPI day hoc
- class overview
- task queue day hoc

Admin:

- KPI governance
- warnings
- monitoring
- reporting

Y nghia:

- cung mot app
- 3 tinh cach giao dien theo role

## 102. Co su nhat quan thi giac giua 3 shell

Giong nhau:

- sidebar trai
- topbar tren
- content host phai/duoi
- card nen trang
- menu active xanh nhat
- font Segoe UI
- grid style chung

Khac nhau:

- text brand
- pham vi menu
- KPI loai gi
- topbar utility co nhieu hay it

## 103. Co su nhat quan giao dien giua module forms

Rat nhieu module:

- style grid chung
- button style chung
- placeholder text
- selected index = 0
- read only text box cho field tinh toan
- error provider cho validation
- message box cho feedback

No giup user doi form nhung khong doi "ngon ngu giao dien".

## 104. Giao dien va nghiep vu giao nhau o dau

UI khong chi dep.

No la noi nghiep vu lo ra ben ngoai.

Vi du:

- debt KPI mau do vi cong no la rui ro
- receipt amount read-only/noi con no cho staff biet han muc thu
- attendance checkbox thay vi text `Present/Absent`
- menu teacher it muc vi role hep
- login brand + subtitle tao boi canh he thong nghiem tuc

## 105. Nhung cho giao dien co tinh "lam bang code" thay vi "keo-tha"

Rieng du an nay co kha nhieu cho:

- student address field dong
- student filter layout dong
- teacher avatar host dong
- enrollment course filter dong
- teacher dashboard footer dong
- task cards build dong
- weekly progress build dong
- report responsive restructure dong

Day cho thay tac gia muon UI linh hoat hon kha nhieu so voi designer tĩnh.

## 106. Nhung cho giao dien con dau vet chua hoan tat

Co vai dau vet:

- `RoundPanelCorners(...)` rong
- `EnableAdaptiveScrolling(...)` de no-op
- mot so control ten cu nhung hanh vi da doi
- mot so helper chart demo chua duoc dung rong

Y nghia:

- UI da tien bo kha xa
- nhung van con cho de tinh chinh

## 107. Giao dien report la noi can giu on dinh nhat

Vi no:

- nhieu card
- nhieu panel
- chart
- grid
- responsive
- scroll
- export/print

Chi can sai 1 o:

- overlap
- cat chu
- button lech
- grid cao sai

Nen report form la noi UI ky thuat dam dac nhat.

## 108. Giao dien login la noi can giu tin cay nhat

Vi no la diem cham dau tien.

Neu login:

- roi
- style lech
- thong bao loi mo ho

thi user se co an tuong xau ngay dau.

Trong du an nay, login:

- co card trung tam
- co alert zone
- co helper row
- co nut primary ro rang

la kha on.

## 109. Giao dien dashboard la noi can giu dinh huong nhat

Vi shell ma roi:

- user lac module
- khong biet dang o dau
- khong biet quay lai dau

Du an giai quyet bang:

- active menu state
- topbar title
- content host 1 module tai 1 luc

## 110. Giao dien module la noi can giu hieu suat thao tac nhat

Module form nhieu nhat du an la CRUD/list.

Muốn nhanh,

thi phai co:

- grid ro
- filter ro
- button style ro
- detail panel ro
- nut mo luong tiep theo ro

Du an co xu huong nay ro.

## 111. Goc nhin tam ly thi giac

Login:

- trung tam
- an toan
- kiem soat

Staff dashboard:

- van hanh
- nhieu task
- nhieu ton dong

Teacher dashboard:

- tap trung
- pham vi hep
- tiep can day hoc nhanh

Admin dashboard/report:

- lanh dao
- quan sat
- tong hop

## 112. Goc nhin "de mo rong UI"

Neu muon them man hinh moi ma khong pha style,

nen:

1. `ConfigureModuleSurface(...)`
2. xai `AppTheme.StyleGrid`
3. xai `StylePrimary/Secondary/DangerButton`
4. xai `StyleCard`
5. neu la shell con, dung `OpenChildForm`
6. neu can bo cuc phuc hop, uu tien `TableLayoutPanel`
7. neu can responsive split, dung `ApplyResponsiveSplit`

## 113. Goc nhin "de sua UI dang co"

Neu muon doi:

- mau: vao `AppTheme`
- active menu state: vao `SetActiveMenu`
- shell open child: vao `OpenChildForm`
- DPI padding/size: vao `Scale...`
- card KPI chung: vao helper tao card
- grid header/cell localize: vao `GridHeaderText` va `GridCellText`

Khong nen sua tung form tung cho ngay lap tuc.

## 114. Goc nhin "designer va code-behind"

Designer:

- khai bao control
- dat vi tri co ban
- dat host

Code-behind:

- doi style
- bind data
- gan event
- doi layout runtime

Nguoi moi can hoc phan tach nay.

Neu khong:

- se sua logic trong Designer
- hoac sua khung control trong file logic mot cach roi

## 115. 10 quy luat ngam cua UI du an nay

Quy luat 1:

Shell dung sidebar trai.

Quy luat 2:

Card noi dung dung nen trang.

Quy luat 3:

Form nen dung background xam xanh rat nhat.

Quy luat 4:

Nut chinh dung `Accent`.

Quy luat 5:

Nut nguy hiem dung `Danger`.

Quy luat 6:

Grid full row select va single select.

Quy luat 7:

Header/grid text can localize.

Quy luat 8:

Responsive la trach nhiem tung form, helper chi ho tro.

Quy luat 9:

Dialog co shell rieng nho.

Quy luat 10:

UI shell va module phai noi nhau qua `OpenChildForm`.

## 116. Nhung diem giao dien manh

- theme trung tam hoa ro
- shell role-based ro
- dashboard card pattern nhat quan
- report screen co tham vong cao
- grid duoc localize header va cell
- responsive duoc quan tam that
- rendering toi uu de giam flicker
- nhieu cho dung panel bọc control thay vi control mac dinh tho

## 117. Nhung diem giao dien co the can cai tien

- `RoundPanelCorners` chua xong
- mot so cho mix text Anh/Viet trong brand
- mot so designer con text mojibake trong output dump do encoding, can check file goc neu can clean
- mot so topbar shell co utility khong dong deu giua role
- mot so layout dong tao luc runtime co the kho debug hon designer tinh

## 118. Goc doc giao dien cho nguoi moi

Khi mo 1 file UI,

hay tu hoi 10 cau:

1. Day la shell, module hay dialog?
2. Nen cua form la gi?
3. Sidebar/topbar/content host co khong?
4. Form dung card nao?
5. Form dung grid nao?
6. Nut nao la primary?
7. Nut nao la danger?
8. Co layout responsive khong?
9. Control nao tao trong designer, control nao tao dong?
10. Service data se chui vao grid/label nao?

## 119. Bang tom tat nhanh theo man hinh

`FrmLogin`

- card trung tam
- header hero
- 2 input boc panel
- subcontrol row
- 2 action button
- footer 2 cot

`FrmStaffDashboard`

- sidebar operation shell
- topbar utility + profile
- KPI 4 card
- recent receipts grid
- task cards
- weekly progress

`FrmTeacherDashboard`

- sidebar teacher shell
- topbar gon
- hero card
- KPI 4 card
- split class overview / task queue

`FrmAdminDashboard`

- governance shell
- user card
- KPI governance
- warnings
- quick snapshot

`FrmAdminReports`

- report page doc
- header + actions
- filter card
- KPI trend row
- chart + insight cards
- detail grid

`Dialogs`

- shell nho
- title/message
- action row

## 120. Ket luan cuc ngan

Giao dien cua du an nay khong phai mot dong panel ngau nhien.

No co bo xep rat ro:

- `AppTheme` lo DNA thi giac
- `FormHostHelpers` lo DNA shell va responsive
- `.Designer.cs` lo khung control
- file `.cs` lo hô hap runtime cua giao dien

Neu ban muon hoc UI cua du an nay that ky,

thi hay doc file nay theo thu tu:

1. palette va typography
2. shell helpers
3. login
4. staff shell
5. teacher shell
6. admin report
7. dialog

Sau file nay, neu ban muon, toi co the lam them 1 file nua chi rieng cho:

- `FrmLogin` giao dien line-by-line

hoac:

- `FrmAdminReports` giao dien line-by-line

hoac:

- `StaffDashboard + TeacherDashboard + AdminDashboard` giao dien line-by-line theo control tree.
