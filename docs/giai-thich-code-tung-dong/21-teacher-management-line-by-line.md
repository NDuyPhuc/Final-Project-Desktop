# Giai thich tung dong: `FrmTeacherManagement.cs`

File goc: `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmTeacherManagement.cs`

Tai lieu nay giai thich theo line number va uu tien cach nhin cua nguoi moi. Nhung dong chi dong/moc cau truc se duoc gom lai de tap trung vao logic that.

## File nay dung de lam gi

Form nay quan ly giao vien. Ngoai CRUD co ban, no con co phan avatar dong duoc chen vao layout luc chay.

## Giai thich theo dong

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Data` de dung `DataTable` cho danh sach giao vien. |
| 2 | Import `Infrastructure` de su dung logger loi va helper giao dien. |
| 3 | Import `TeacherEntity`, model du lieu giao vien. |
| 5-16 | Khai bao namespace, class va cac bien cap lop. `_teacherTable` chua du lieu grid. `_currentTeacherStatus`, `_currentTeacherAccountId`, `_currentAvatarPath` giu trang thai ban ghi dang mo. `_pendingAvatarSourcePath` giu file anh vua chon nhung chua luu. `_picTeacherAvatar` va `_btnChooseTeacherAvatar` la control tao dong bang code, khong phai control co san tu Designer. |
| 17-24 | Constructor chay theo thu tu quen thuoc: tao UI tu Designer, gan khung module, chinh view, tai danh sach giao vien, roi gan event. |
| 26-35 | `ConfigureView()` dau tien goi `LocalizeLabels()` de dat caption, sau do set minimum size, panel min size, splitter width, chieu cao card filter, va padding cho action area. Muc tieu la giao dien nho van khong bi vo layout. |
| 36-42 | Ap theme cho grid va cac nut. Nut xoa duoc style danger de nguoi dung nhan ra day la thao tac co rui ro. |
| 43-47 | `InitializeAvatarControls()` tao `PictureBox` va button chon anh neu chung chua ton tai. Sau do, neu button da duoc tao thanh cong thi cung ap theme cho no. |
| 49-56 | Cau hinh grid va 2 textbox dai (`Address`, `Note`) cho phep scroll doc. `cboTeacherStatusFilter.SelectedIndex = 0` dat bo loc mac dinh. `txtTeacherNote.PlaceholderText = "Nam / Nu"` tiet lo mot dieu quan trong: bien ten `Note` thuc te dang bi dung de chua gioi tinh. Ten control va y nghia du lieu khong trung nhau. |
| 59-72 | `WireEvents()` gan tat ca su kien cho grid va nut. Neu `_btnChooseTeacherAvatar` ton tai, no duoc gan click de mo hop chon anh. Check null o day can thiet vi control nay duoc tao dong, khong chac da co neu qua trinh khoi tao thay doi. |
| 74-84 | `LoadTeachers(...)` goi service `GetTeacherList(...)`, dua `keyword/status` thanh tham so truy van, bind ket qua vao `dgvTeacherList`, roi chon dong dau tien neu co du lieu. |
| 85-89 | Mau xu ly loi quen thuoc: log ky thuat vao file, thong bao don gian tren form. |
| 92-98 | `StartCreateTeacher()` xoa editor cu, xin ma giao vien tiep theo, dat trang thai tam thoi la `"Dang day"`, roi focus vao o ten de nguoi dung nhap nhanh. |
| 100-105 | `SaveCurrentTeacher()` dung neu validation fail. Day la lop bao ve dau tien truoc khi dong goi entity. |
| 107-122 | Tao `TeacherEntity` tu noi dung dang nhap tren form. `Gender` dang lay tu `txtTeacherNote`, cho thay giao dien dat ten control chua thuc su sat nghia du lieu. `AvatarPath`, `AccountId`, `Status` duoc lay tu cac field dang nho trang thai cua form. `IsDeleted = false` vi day la ban ghi hoat dong. |
| 124 | Goi `SaveTeacher(teacher)` de insert/update ban ghi giao vien chinh. |
| 125-130 | Neu co avatar moi, form copy/lưu anh qua `SaveTeacherAvatar(...)`, gan duong dan moi vao `teacher.AvatarPath`, roi goi `SaveTeacher(...)` them lan nua de luu path vao DB. Sau cung xoa duong dan tam. Day la cung mau 2 buoc giong form hoc vien. |
| 132-138 | Dong bo lai cac field trang thai tren form voi ket qua moi nhat tra ve tu service, tai lai danh sach theo bo loc dang ap dung, focus lai giao vien vua luu, va bao thanh cong. |
| 140-143 | Bat loi khi luu giao vien. |
| 147-158 | `DeleteSelectedTeacher()` kiem tra co ma giao vien dang chon khong, sau do mo `FrmConfirmDialog`. `DialogResult.OK` moi cho phep xoa mem. |
| 160-165 | Neu xac nhan, goi `SoftDeleteTeacher(...)`, tai lai grid, va reset panel chi tiet. |
| 166-169 | Loi xoa cung duoc log va thong bao. |
| 173-183 | `PopulateDetailFromSelection()` check dong chon hien tai co la `DataRowView` khong, lay ma giao vien tu cot dau tien, va return ngay neu ma rong. |
| 186-192 | Goi `GetTeacherById(...)` de lay entity day du. Neu service tra `null` thi dung, tranh do du lieu rong len UI. |
| 194-205 | Day du lieu tu entity len control: ma, ten, sdt, email, chuyen mon, dia chi, gioi tinh. Sau do dong bo cac field avatar/status/account tren form. `LoadTeacherAvatarPreview(_currentAvatarPath)` co the nhan relative path hoac absolute path, xu ly o helper ben duoi. |
| 207-210 | Bat loi neu tai chi tiet giao vien that bai. |
| 214-224 | `SelectFirstTeacher()` co vai tro giong form hoc vien: neu grid co dong thi chon dong dau va nap chi tiet; neu rong thi reset editor. |
| 226-238 | `FocusTeacher(string teacherId)` duyet tung dong grid, tim dung ma giao vien, chon dong do, dat `CurrentCell`, va goi lai `PopulateDetailFromSelection()`. |
| 240-272 | `ValidateEditor()` xoa loi cu va check 4 truong bat buoc: ma, ten, sdt, email. Check email o day cung rat co ban: chi can co `@` va `.`. Ham tra `true` chi khi ca 4 control khong con thong diep loi. |
| 274-293 | `ResetDetailEditor()` xoa noi dung form, clear thong tin avatar tam/thuc, va neu `_picTeacherAvatar` dang co `Image` thi dispose roi dat ve `null`. `Dispose()` o day quan trong vi `Image` la tai nguyen GDI+, de lau co the gay ro tai nguyen neu khong giai phong. |
| 295-300 | `ResetFilters()` xoa tu khoa tim, dua bo loc ve item dau, va nap lai danh sach day du. |
| 302-324 | `LocalizeLabels()` dat caption cho bo loc, label chi tiet, va cac nut. `cboTeacherStatusFilter.Items.AddRange(...)` nap cac trang thai co the loc duoc. |
| 326-336 | `InitializeAvatarControls()` tao `PictureBox` bang code neu chua ton tai. `Dock = Top`, `Height = 120`, `BorderStyle.FixedSingle`, `BackColor` nhe, `SizeMode.Zoom`: tat ca giup vung avatar nhin gon va de xem. |
| 338-345 | Tao them button chon anh bang code. `Dock = Left` dat no sat trai trong panel avatar. |
| 347-350 | Neu `tblTeacherDetail` da co control ten `pnlTeacherAvatarHost` thi return ngay. Check nay tranh chen trung avatar host neu `ConfigureView()` hay ham init bi goi nhieu lan. |
| 352-359 | Tao `Panel` host cho avatar, dat ten, dock fill, set chieu cao, roi them button va picture box vao panel. |
| 361-367 | Tao `Label` dong ten `lblTeacherAvatar` de hien chu "Avatar" trong bang thong tin. |
| 369-372 | Tang so dong cua `tblTeacherDetail`, them style cho dong moi, roi chen label vao cot 0 va panel vao cot 1. Day la cach no "noi rong" layout cua Designer luc runtime. |
| 375-383 | `ChooseTeacherAvatar()` mo `OpenFileDialog`, loc cac duoi anh hop le, va dat title cho hop chon. |
| 385-388 | Neu user huy hop chon thi dung ngay. |
| 390-394 | Kiem tra file co ton tai that khong truoc khi dung. Neu khong, thong bao warning va dung. |
| 396-401 | Kiem tra lai extension bang tay. Dieu nay bo sung cho `Filter` vi `Filter` chi giup UI chon de hon, khong phai lop bao mat tuyet doi. |
| 403-404 | Luu duong dan anh nguon vao `_pendingAvatarSourcePath` va hien preview ngay. Chua co ghi DB hay copy file tai buoc nay. |
| 406-409 | Bat loi mo/chon anh. |
| 413-418 | `LoadTeacherAvatarPreview(string? avatarPath)` bao ve som: neu picture box chua duoc tao thi thoat. |
| 420-421 | Giai phong anh cu dang hien truoc khi nap anh moi. Day la thoi quen tot khi thay anh trong WinForms. |
| 423-426 | Neu `avatarPath` rong thi khong hien gi ca. |
| 428-430 | Xac dinh `absolutePath`: neu `avatarPath` da la file co that thi dung thang; neu khong thi nho service `ResolveAbsoluteImagePath(...)` bien relative path thanh duong dan tuyet doi trong thu muc anh cua ung dung. |
| 432-435 | Neu van khong co file hop le thi return, tranh `FileNotFoundException`. |
| 437-439 | Mo file bang `FileStream` voi `FileShare.ReadWrite`, tao `Image` tu stream, roi clone thanh `Bitmap` moi gan vao picture box. `FileShare.ReadWrite` giup doc duoc ca khi file dang duoc tien trinh khac mo. Clone sang `Bitmap` giup dong stream xong ma UI van giu duoc anh. |

## Ket luan ngan

`FrmTeacherManagement` la form CRUD giao vien co them mot lop logic avatar dong. Hai diem nguoi moi rat nen de y:

- ten control khong phai luc nao cung dung nghia du lieu, vi `txtTeacherNote` dang giu gioi tinh
- phan avatar duoc xu ly theo quy trinh "chon truoc -> preview -> luu entity -> copy anh -> luu entity lan 2"
