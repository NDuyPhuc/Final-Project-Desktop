# Giai thich tung dong: `FrmAttendance.cs` va `FrmScoreEntry.cs`

File goc:

- `Trung-tam-quan-ly-ngoai-ngu/Forms/Teacher/FrmAttendance.cs`
- `Trung-tam-quan-ly-ngoai-ngu/Forms/Teacher/FrmScoreEntry.cs`

Hai form nay thuoc luong cong viec cua giao vien. Mot form ghi nhan chuyen can, mot form ghi nhan diem so. Tai lieu giai thich sat line number, nhung van gom nhung dong chi la ky hieu cau truc de de doc.

## 1. `FrmAttendance.cs`

### File nay dung de lam gi

Form diem danh cho giao vien:

- tai cac lop giao vien dang day
- tai cac buoi hoc cua lop do
- hien danh sach hoc vien de tick co mat/vang
- luu lai ket qua diem danh cho ngay da chon

### Giai thich theo dong

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Data` de dung `DataTable` va `DataRowView` khi bind du lieu vao grid va combobox. |
| 2 | Import `System.Globalization` de parse ngay theo dinh dang `dd/MM/yyyy`. |
| 3 | Import `Infrastructure` de log loi va dung helper giao dien. |
| 4 | Import `AttendanceSaveItem`, model trung gian dung khi luu diem danh. |
| 6-12 | Khai bao namespace, class, va 2 field du lieu. `_classTable` giu danh sach lop giao vien day. `_attendanceTable` giu bang diem danh cua buoi dang xem. |
| 13-20 | Constructor tao UI, gan tieu de module, chinh view, tai lop dang day, va gan event. |
| 22-29 | `ConfigureView()` ap style cho grid va 4 nut thao tac. |
| 30-35 | Dat lai text cho cac nut va tooltip cho nut luu. Tooltip giai thich nut luu se ghi lich su chuyen can vao database. |
| 36-42 | Cau hinh 2 combobox chi cho chon item co san, `DateTimePicker` dung format `dd/MM/yyyy`, grid tu tao cot va cot tu fill ngang. |
| 44-52 | `WireEvents()` noi su kien: doi lop thi tai session, doi session thi dong bo ngay, bam "xem danh sach" thi tai bang diem danh, bam 2 nut danh dau hang loat thi set toan bo co mat/vang, bam luu thi ghi DB. |
| 54-63 | `LoadTeachingClasses()` goi `GetTeachingClasses(AppRuntime.CurrentUser?.Id)`. Nghia la form lay dung cac lop cua tai khoan dang login. Sau do dat `DisplayMember = "Ten lop"` va `ValueMember = "Ma lop"` cho combobox, bind bang du lieu, roi tai session cua lop dau tien. |
| 64-67 | Neu tai danh sach lop that bai, form log loi va thong bao. |
| 71-82 | `LoadSessions()` lay `classId` dang chon, goi `GetSessions(classId)`, bind vao combobox buoi hoc, trong do text hien la `"Buoi"` con gia tri la `"Ngay hoc"`. Sau khi bind, no dong bo ngay tren `DateTimePicker` va tai luon bang diem danh. |
| 83-86 | Bat loi khi tai lich hoc/session. |
| 90-95 | `SyncDateFromSession()` chi tiep tuc neu item dang chon trong combobox session thuc su la `DataRowView`. Neu khong phai, khong co gi de dong bo. |
| 97-99 | Lay chuoi ngay tu cot `"Ngay hoc"` neu bang du lieu co cot do. Check `Columns.Contains(...)` giup code an toan hon khi cau truc bang thay doi. |
| 100-103 | Thu parse chuoi ngay theo dung dinh dang `dd/MM/yyyy` va culture `vi-VN`. Neu parse duoc thi gan vao `dtpAttendanceDate.Value`. |
| 106-114 | `LoadAttendanceList()` lay `classId`, goi `GetAttendanceList(classId, dtpAttendanceDate.Value.Date)`, bind vao grid, roi goi `ConfigureGrid()` de an/chen cac cot can thiet. |
| 115-118 | Bat loi khi tai bang diem danh. |
| 122-127 | `ConfigureGrid()` dau tien check grid co cot `EnrollmentId` khong. Neu khong co, ham return vi bang diem danh chua san sang. |
| 129 | An cot `EnrollmentId` vi day la khoa ky thuat, user khong can thay. |
| 131-133 | Thu tim cot `"Co mat"`. Neu bang du lieu da co cot nay thi dung cot co san. |
| 135-147 | Neu grid chua co cot `"Co mat"`, form tao them `DataGridViewCheckBoxColumn` va chen vao vi tri cua cot trang thai. `DataPropertyName = "Co mat"` noi checkbox nay voi truong du lieu cung ten trong bang. `HeaderText = "Co mat"` la ten cot hien tren UI. |
| 150-164 | `SetAllAttendanceStatus(bool present)` la nut "tat ca co mat/tat ca vang". No chi lam viec neu grid co cot `"Co mat"`, sau do duyet tung dong tru dong moi, va gan gia tri checkbox bang `present`. |
| 166-175 | `SaveAttendance()` mo dau bang lay `classId`. Neu user chua chon lop, `ErrorProvider` duoc gan vao combobox va ham dung. |
| 177-181 | Kiem tra grid da co 2 cot can thiet `EnrollmentId` va `Co mat` chua. Neu chua co thi thong bao "danh sach diem danh chua san sang de luu". |
| 183-194 | Xoa loi cu, sau do bien moi dong grid thanh mot `AttendanceSaveItem` bang LINQ. Quy trinh la: ep rows thanh enumerable, bo qua dong moi, tao object moi voi `EnrollmentId`, `Status`, `Note`, roi bo tiep nhung item khong co `EnrollmentId`. `Status` duoc quy doi tu checkbox: `true` thanh `"Present"`, nguoc lai thanh `"Absent"`. |
| 196-198 | Goi `SaveAttendance(classId, date, items)`, thong bao thanh cong, roi tai lai bang diem danh tu DB de phan anh ket qua vua luu. |
| 200-203 | Bat loi khi luu diem danh. |
| 207-214 | `GetSelectedClassId()` la ham nho nhung quan trong. No uu tien lay `SelectedValue` neu do la chuoi. Neu khong, no thu lay `SelectedItem` la `DataRowView`, check cot `"Ma lop"`, roi lay gia tri do. Day la mau "fallback" de lay ma lop ngay ca khi binding cua combobox chua on dinh. |

### Ket luan ngan cho `FrmAttendance`

Form nay la mot vong tron don gian:

- chon lop
- chon buoi
- chinh checkbox co mat/vang
- luu danh sach `AttendanceSaveItem`

No tan dung manh data binding cua WinForms de UI va `DataTable` noi voi nhau rat sat.

## 2. `FrmScoreEntry.cs`

### File nay dung de lam gi

Form nhap diem cho giao vien:

- tai lop giao vien dang day
- hien bang diem hoc vien trong lop
- cho sua diem giua ky/cuoi ky
- validate diem 0-10
- luu ket qua qua service

### Giai thich theo dong

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Data` de bind `DataTable` vao grid va combobox. |
| 2 | Import `System.Globalization` de parse so diem theo `InvariantCulture`. |
| 3 | Import `Infrastructure` de log loi va helper giao dien. |
| 4 | Import `ScoreSaveItem`, model dong goi du lieu luu diem. |
| 6-12 | Khai bao namespace, class, va 2 field du lieu: `_classTable` cho danh sach lop, `_scoreTable` cho bang diem. |
| 13-20 | Constructor tao UI, gan tieu de module, chinh view, tai lop dang day, va gan event. |
| 22-29 | `ConfigureView()` ap style cho grid va 2 nut, roi dat lai text cho nut tai danh sach va nut luu bang diem. |
| 31-37 | Phan `cboScoreType` cho thay 1 chi tiet thiet ke rat ro: he thong chua phan loai diem theo DB. Combobox bi xoa item cu, them duy nhat 1 item thong bao tinh trang nay, dat selected index 0, roi `Enabled = false` de user khong sua duoc. `txtScoreWeight` cung chi hien placeholder `0-10` va readonly. |
| 39-41 | Grid tu tao cot, cot tu fill ngang, va dong co chieu cao 42 de de nhap diem. |
| 44-49 | `WireEvents()` gan 3 su kien: bam tai danh sach, bam luu, va doi lop thi tai lai bang diem. |
| 51-60 | `LoadTeachingClasses()` giong form diem danh: lay danh sach lop cua giao vien dang login, bind vao combobox theo `Ten lop`/`Ma lop`, roi tai bang diem cua lop dau. |
| 61-64 | Bat loi khi tai lop giang day. |
| 68-76 | `LoadScoreList()` lay `classId`, goi `GetScoreList(classId)`, bind vao grid, roi chinh grid. |
| 77-80 | Bat loi khi tai bang diem. |
| 84-89 | `ConfigureGrid()` chi tiep tuc neu grid co cot `EnrollmentId`. Neu khong co cot khoa ky thuat nay, grid chua du du lieu de luu diem an toan. |
| 91 | An cot `EnrollmentId` vi user khong can thay khoa ky thuat. |
| 92-100 | Dat 2 cot `"Ma hoc vien"` va `"Ho ten"` thanh readonly neu chung ton tai. Muc dich la chi cho giao vien sua diem, khong sua danh tinh hoc vien. |
| 103-113 | `SaveScores()` dau tien clear loi cu, lay `classId`, va check user da chon lop chua. Neu chua, `ErrorProvider` duoc dat len combobox va ham dung. |
| 115-119 | Kiem tra grid co cot `EnrollmentId` khong. Neu khong co, thong bao danh sach chua san sang de luu. |
| 121-145 | Tao `List<ScoreSaveItem>`. Vong `foreach` duyet tung dong grid, bo qua dong moi, bo qua dong khong co `EnrollmentId`, roi doc 2 o diem qua `GetCellValue(...)`. Sau do no goi `ParseScore(...)` de kiem tra tung diem hop le, roi dong goi thanh `ScoreSaveItem` gom `EnrollmentId`, `MidtermScore`, `FinalScore`, `Note`. |
| 147-149 | Goi `SaveScores(classId, items)`, thong bao thanh cong, va tai lai bang diem. |
| 151-156 | `catch` co 1 chi tiet hay: neu loi la `InvalidOperationException` thi hien thang `ex.Message` cho user. Nghia la cac loi validation do `ParseScore(...)` nem ra se co thong diep ro rang, vi du "Diem giua ky phai la so". Neu loi khac, form moi hien thong diep chung. |
| 160-165 | `ParseScore(string? value, string fieldName)` cho phep o diem de trong. Neu rong thi tra `null`, nghia la chua co diem. |
| 167-170 | Neu co nhap gia tri, ham dung `decimal.TryParse(...)` voi `NumberStyles.Number` va `CultureInfo.InvariantCulture`. Neu parse that bai thi nem `InvalidOperationException` kem ten truong, de luong goi ben tren bat va hien dung thong diep. |
| 172-175 | Kiem tra diem nam trong khoang 0 den 10. Ngoai khoang thi cung nem `InvalidOperationException`. |
| 177 | Neu hop le, tra diem dang `decimal?`. Dung nullable vi o diem co the rong. |
| 180-187 | `GetSelectedClassId()` giong y het form diem danh: uu tien `SelectedValue`, neu chua co thi fallback ve `DataRowView` va cot `"Ma lop"`. |
| 189-194 | `GetCellValue(DataGridViewRow row, string columnName)` la helper nho de doc o trong grid mot cach an toan. No check row co gan vao grid khong va grid co cot do khong. Neu co thi tra text, neu khong thi tra `null`. |

### Ket luan ngan cho `FrmScoreEntry`

Form nay cho thay 2 lop validation:

- validation cau truc UI: co lop chon chua, grid co cot khoa ky thuat chua
- validation nghiep vu: diem phai la so va phai nam trong 0-10

No cung tiet lo hien trang he thong: phan loai loai diem/chung trong so chua duoc mo rong o DB, nen UI dang khoa combobox va chi cho nhap bang diem tong hop.
