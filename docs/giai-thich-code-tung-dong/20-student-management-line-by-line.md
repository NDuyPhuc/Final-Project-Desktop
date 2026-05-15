# Giai thich tung dong: `FrmStudentManagement.cs`

File goc: `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmStudentManagement.cs`

Tai lieu nay giai thich sat line number cho nguoi moi bat dau. De tranh bang dai vo nghia, cac dong chi la dau `{`, `}`, dong trang, hoac tiep noi cung mot y nho se duoc gom thanh mot muc.

## File nay dung de lam gi

Form nay la man hinh CRUD hoc vien. No cho phep:

- tai danh sach hoc vien len `DataGridView`
- tim kiem va loc theo trang thai
- tao moi, sua, xoa mem hoc vien
- chon va xem truoc avatar
- mo nhanh man hinh ghi danh cho hoc vien dang chon
- tu dieu chinh bo cuc khi cua so hep/rong

## Giai thich theo dong

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Data` de dung `DataTable`. `DataTable` la bang du lieu trong bo nho, rat hop voi WinForms vi co the bind thang vao `DataGridView`. |
| 2 | Import `System.Globalization` de xu ly ky tu Unicode va bo dau tieng Viet trong ham tao email demo. |
| 3 | Import `System.Text` de dung `StringBuilder`, mot cong cu ghep chuoi hieu qua hon noi chuoi lien tuc. |
| 4 | Import `Infrastructure` de goi `ErrorLogger` va mot vai helper UI khac cua tang application. |
| 5 | Import `StudentEntity`, tuc la model doi tuong hoc vien ma form tao ra de gui xuong service. |
| 7-16 | Khai bao namespace, class partial va cac field cap lop. `_studentTable` giu bang danh sach dang hien. `_pendingAvatarSourcePath` la duong dan anh nguon nguoi dung vua chon nhung chua copy vao he thong. `_currentAvatarPath` la duong dan avatar dang gan cho hoc vien hien tai. `_lblStudentAddress` va `_txtStudentAddress` la control duoc them bang code luc chay, khong co san trong Designer. |
| 17-25 | Constructor chay theo thu tu rat quan trong: `InitializeComponent()` tao toan bo control tu Designer; `ConfigureModuleSurface(...)` gan khung host/dau muc module; `ConfigureView()` chinh giao dien; `LoadStudents()` tai du lieu dau tien; `WireEvents()` gan su kien; `ApplyResponsiveLayout()` ep bo cuc thich nghi ngay tu lan ve dau. |
| 27-31 | `ConfigureView()` bat dau bang 3 helper lon. `BuildFilterLayout()` dung lai vung loc bang code. `EnsureAddressControls()` chen them o dia chi dong vao bang thong tin. `LocalizeLabels()` dat toan bo text tieng Viet cho label/button. |
| 33-34 | Dat item dau tien cho 2 combobox trang thai. Nghia la khi mo form, bo loc mac dinh la "Tat ca", con editor chi tiet mac dinh la trang thai dau tien trong danh sach. |
| 36-37 | Gan tooltip cho 2 nut de nguoi dung di chuot vao se thay giai thich. Tooltip nay la huong dan nho ngay tren giao dien. |
| 39-50 | Goi `AppTheme` de ap dung style chung cho group box, bang du lieu, va cac nut. Day la cach dong bo mau sac/khoang cach toan app thay vi set tung thuoc tinh bang tay. |
| 52-58 | Cau hinh `PictureBox` avatar. `BackColor` va `BorderStyle` giup khung anh de nhin. `SizeMode.Zoom` thu phong/thu nho anh ma van giu ty le. `MinimumSize`, `Size`, `Anchor`, `Margin` dinh hinh vi tri va kich thuoc tren form. |
| 60-64 | Chinh mau chon dong trong `DataGridView`, chieu cao dong, bat tu sinh cot tu `DataTable`, va cho cot tu co gian de lap day be ngang. |
| 66-68 | Dat kich thuoc toi thieu cho 2 panel cua `SplitContainer` va cho phep ca hai panel thay doi kich thuoc. |
| 70-80 | Cau hinh `FlowLayoutPanel` chua nhom nut thao tac. `AutoSize` cho panel tu no gian theo noi dung, `WrapContents` cho phep xuong hang neu khong du cho, `FlowDirection.LeftToRight` sap nut tu trai qua phai. Vong lap cuoi cung set `Margin` dong deu cho tung nut de layout dep hon. |
| 82-83 | Cot combobox trang thai trong vung chi tiet duoc dock ve trai va set rong co dinh 180 pixel de khong gian editor on dinh. |
| 86-105 | `WireEvents()` gan su kien cho form. Moi dong `+=` noi voi WinForms: "khi su kien nay xay ra thi chay ham kia". Form dung lambda ngan `(_, _) => ...` vi khong can ten `sender` va `EventArgs`. Dac biet: nut `OpenEnrollment` mo `FrmEnrollment` va truyen ma hoc vien dang chon; su kien `Resize` goi lai `ApplyResponsiveLayout()` de form tu doi bo cuc theo be ngang hien tai. |
| 107-117 | `LoadStudents(...)` la ham tai danh sach. No goi `AppRuntime.DataService.GetStudentList(...)` va chuyen `keyword/status` trong UI thanh tham so cho service. Neu o loc rong hoac dang o "Tat ca" thi truyen `null` de service hieu la khong loc theo dieu kien do. |
| 115-116 | Sau khi lay du lieu, form bind thang `DataTable` vao `dgvStudentList`, roi goi `SelectFirstStudentRow()` de neu co du lieu thi dong dau duoc chon ngay va panel chi tiet ben phai se duoc nap. |
| 118-122 | `catch` bat loi, log qua `ErrorLogger`, roi thong bao nguoi dung. Mau nay lap lai rat nhieu trong du an: log ky thuat vao file, hien thong diep gon gon tren UI. |
| 125-130 | `StartCreateStudent()` xoa editor cu bang `ResetDetailEditor()`, xin ma hoc vien moi tu service bang `GetNextStudentId()`, roi dua con tro vao o ten de nguoi dung go tiep ngay. |
| 132-137 | `SaveCurrentStudent()` mo dau bang buoc chan loi. Neu `ValidateEditor()` tra `false` thi dung ngay, tranh tao object sai. |
| 139-152 | Tao `StudentEntity` tu du lieu tren form. Moi property la cau noi giua UI va tang du lieu: `Id`, `FullName`, `BirthDate`, `Phone`, `Email`, `Address`, `AvatarPath`, `Status`. `IsDeleted = false` vi day la ban ghi dang ton tai binh thuong, chua bi xoa mem. |
| 148 | `Address = GetStudentAddressText()` khong doc truc tiep tu textbox cu the, ma di qua helper. Cach nay giup code ben tren khong can biet control dia chi la control dong duoc chen luc chay. |
| 154 | `SaveStudent(student)` la diem ghi chinh. Service co the insert neu ma chua ton tai, hoac update neu ma da co. |
| 155-160 | Neu nguoi dung vua chon avatar moi, form chay quy trinh 2 buoc: copy/lưu anh qua `SaveStudentAvatar(...)`, cap nhat `AvatarPath` moi vao object, sau do goi `SaveStudent(...)` lan 2 de cap nhat duong dan anh vao DB. `_pendingAvatarSourcePath = null` danh dau da xu ly xong. |
| 162-165 | Dong bo `_currentAvatarPath` voi du lieu vua luu, tai lai danh sach theo bo loc dang dung, focus lai dung hoc vien vua luu, roi bao thanh cong. Mau "reload + focus lai dong vua sua" giup UI phan anh DB moi nhat. |
| 167-170 | Neu luu that bai, log va bao loi. Form khong nuot loi am tham. |
| 174-179 | `DeleteSelectedStudent()` dau tien tu ve bang cach bo qua neu ma hoc vien dang rong. Khong co ma thi khong biet xoa ai. |
| 181-185 | Tao `FrmConfirmDialog` de hoi lai nguoi dung. `using var` co nghia la dialog se duoc dispose tu dong khi ra khoi block, tranh ro tai nguyen UI. Neu user khong bam `OK` thi huy thao tac. |
| 187-192 | Neu user xac nhan, goi `SoftDeleteStudent(...)` chu khong xoa cung. Sau do tai lai danh sach va xoa noi dung editor. "Soft delete" thuong la danh dau `IsDeleted` trong DB thay vi xoa mat du lieu. |
| 200-208 | `ChooseAvatar()` mo `OpenFileDialog`, chi loc cac file anh qua `Filter`, va dat tieu de cua hop chon. |
| 210-217 | Neu user bam Cancel thi dung. Neu da chon file, luu duong dan tam vao `_pendingAvatarSourcePath` va goi `LoadAvatarPreview(...)` de hien xem thuoc truoc khi thuc su luu vao DB/he thong. |
| 218-221 | Loi mo file anh cung duoc log va thong bao rieng. |
| 225-230 | `RemoveAvatar()` xoa ca trang thai "anh sap luu" va "anh hien tai", dong thoi bo hinh dang xem trong `PictureBox`. Day la thao tac UI, chua goi DB; DB chi doi khi user bam luu. |
| 232-242 | `SelectFirstStudentRow()` la helper sau khi bind grid. Neu co dong, no chon dong dau va nap chi tiet. Neu grid rong thi reset editor de tranh giu du lieu cu cua hoc vien truoc. |
| 244-256 | `FocusStudent(string studentId)` duyet tung dong cua grid, so sanh cot dau tien voi ma hoc vien can tim bang `OrdinalIgnoreCase`, roi chon dong, dat `CurrentCell`, va goi `PopulateDetailFromSelection()`. Day la cach dua UI quay lai dung ban ghi vua luu. |
| 258-263 | `PopulateDetailFromSelection()` mo dau bang kiem tra xem dong hien tai co dang bind vao `DataRowView` khong. `DataRowView` la lop bao quanh mot dong trong `DataTable` de data binding co the lam viec. |
| 265-269 | Lay ma hoc vien tu cot dau tien cua dong dang chon. Neu ma rong thi dung, vi service can ma hop le de lay ban ghi chi tiet. |
| 271-277 | Goi `GetStudentById(studentId)` de lay object day du tu service. Lam vay an toan hon viec tin toan bo du lieu dang hien tren grid, vi grid co the chi co cot rut gon. |
| 279-288 | Do du lieu tu entity len control. `Email ?? string.Empty` tranh null lam textbox loi. `SetStudentAddressText(...)` dung helper cho o dia chi dong. `Status` co gia tri mac dinh "Dang hoc" neu DB khong co. `BirthDate == default` thi thay bang `DateTime.Today` de tranh date ve `01/01/0001`. 2 field avatar duoc dong bo, roi goi `LoadAvatarPreview(...)` voi duong dan tuyet doi sau khi qua service `ResolveAbsoluteImagePath(...)`. |
| 290-293 | Bat loi khi tai chi tiet hoc vien. |
| 297-303 | `LoadAvatarPreview(string? imagePath)` dau tien check duong dan co rong hoac file co ton tai khong. Neu khong hop le thi xoa hinh hien tai va thoat. |
| 305-307 | Mo file anh bang `FileStream`, tao `Image` tu stream, roi clone thanh `new Bitmap(image)` truoc khi stream bi dong. Mau nay tranh khoa file anh khi `PictureBox` dang hien. |
| 310-342 | `ValidateEditor()` la gatekeeper cua du lieu nhap. No xoa loi cu, kiem tra tung o bat buoc (`Id`, `FullName`, `Phone`, `Email`), va dat loi len tung control qua `errStudent.SetError(...)`. Check email o day rat co ban: chi can co `@` va `.`. Cuoi ham, no chi tra `true` khi ca 4 control deu khong con thong diep loi. |
| 344-357 | `ResetDetailEditor()` dua vung nhap ve trang thai "tao moi": xoa text, reset dia chi, dua combobox ve item dau, dat ngay sinh la hom nay, xoa thong tin avatar dang treo, va xoa hinh preview. |
| 359-364 | `ResetFilters()` xoa tu khoa tim, dua combobox loc ve "Tat ca", roi tai lai danh sach day du. |
| 366-398 | `LocalizeLabels()` dat toan bo caption tieng Viet cho label, group box, combobox item, va button. Dong 380-383 check `_lblStudentAddress` khac null vi label nay duoc tao dong trong `EnsureAddressControls()`, khong chac da ton tai neu ham bi goi qua som. |
| 400-415 | `BuildFilterLayout()` tao mot `TableLayoutPanel` moi bang code. 3 cot co ty le 52% - 24% - 24%, 2 dong co `AutoSize`. Nghia la vung bo loc duoc kiem soat layout linh hoat hon so voi dat tay trong Designer. |
| 416-425 | Tao them `FlowLayoutPanel` ten `actionBar` de chua 2 nut tim va lam moi. `Margin = new Padding(0, 22, 0, 0)` day panel xuong mot chut cho can hang dep hon voi textbox/combobox. |
| 427-429 | Cho `txtStudentKeyword` va `cboStudentStatusFilter` dock fill de tu lap day o cua minh trong bang layout. |
| 430-440 | Xoa control cu trong `pnlStudentFilterCard`, chen `filterLayout` moi vao, set `Padding/Height/MinimumSize`, roi dat tung control dung o: label tu khoa, label trang thai, textbox, combobox, va thanh nut hanh dong. |
| 443-447 | `ApplyResponsiveLayout()` lay `actionBar` thong qua `btnSearchStudent.Parent`, sau do check panel bo loc hien co `TableLayoutPanel` hay khong truoc khi doi bo cuc. |
| 448-476 | Neu be ngang form nho hon 980, bo loc chuyen sang 2 cot 3 dong. Phan label nam tren, input o giua, `actionBar` xuong dong duoi cung va span 2 cot. Chieu cao card tang len 128 de du chua noi dung. |
| 477-505 | Neu form rong hon, bo loc quay lai bo cuc 3 cot 2 dong ban dau. Day la mau responsive layout thu cong trong WinForms. |
| 508-521 | Phan thu hai cua responsive layout xu ly `SplitContainer`. Neu form hep hon 940, panel danh sach va panel chi tiet xep tren-duoi (`Orientation.Horizontal`). Neu rong, chung xep trai-phai (`Orientation.Vertical`). `Math.Max(...)` dam bao vi tri chia khong qua be. |
| 524-529 | `EnsureAddressControls()` dam bao chi tao o dia chi mot lan. Neu `_txtStudentAddress` da ton tai thi return ngay. |
| 531-546 | Tao dong `Label` va `TextBox` cho dia chi. `Multiline = true` va `ScrollBars.Vertical` de dia chi dai van de nhap duoc. |
| 548-553 | Tang `RowCount` cua `tblStudentInfo`, them 1 `RowStyle` co chieu cao 58, chen label/textbox moi vao dong 7, roi day 2 control `lblStudentStatus` va `cboStudentStatus` xuong dong 8. Day la mot vi du "mo rong form Designer bang code" luc chay. |
| 556 | `GetStudentAddressText()` la expression-bodied member. No lay text tu control dong neu control co ton tai, neu khong thi tra chuoi rong. |
| 558-564 | `SetStudentAddressText(...)` la ham doi nghich cua helper tren: gan text vao o dia chi neu control da duoc tao. |
| 566-571 | `BuildDemoEmail(string fullName)` nhan ho ten va tra ve email mau. Neu ten rong thi tra chuoi rong. |
| 573-580 | Tao `StringBuilder`, chuan hoa chuoi sang `NormalizationForm.FormD`, duyet tung ky tu, va bo qua cac ky tu co `UnicodeCategory.NonSpacingMark`. De don gian: doan nay xoa dau trong tieng Viet. |
| 582-588 | Chuan hoa lai ve `FormC`, doi `d` dac biet, chuyen ve chu thuong, thay khoang trang bang dau cham, roi cong hau to `@demo.local`. Ket qua vi du: `Nguyen Van A` thanh `nguyen.van.a@demo.local`. |
| 566-589 | Trong file hien tai, ham `BuildDemoEmail(...)` chua duoc goi o dau ca. Nghia la no la helper du phong, hoac tung duoc dung roi de lai. Day la chi tiet quan trong cho nguoi doc code: khong phai ham nao co mat cung dang tac dong that. |

## Ket luan ngan

`FrmStudentManagement` phoi hop 4 nhom viec chinh:

- lay va bind du lieu hoc vien
- cho phep sua/xoa/them voi validation co ban
- xu ly avatar theo kieu "chon truoc, luu sau"
- dieu khien layout dong bang code de form de dung hon tren man hinh nho
