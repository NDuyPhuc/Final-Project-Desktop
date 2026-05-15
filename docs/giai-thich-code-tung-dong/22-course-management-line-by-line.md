# Giai thich tung dong: `FrmCourseManagement.cs`

File goc: `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmCourseManagement.cs`

Tai lieu nay giai thich theo line number, uu tien cach noi de nguoi moi thay duoc moi dong dang giai quyet viec gi.

## File nay dung de lam gi

Form nay quan ly khoa hoc. Moi khoa hoc co ma, ten, level, hoc phi, mo ta, trang thai, va danh sach lop lien quan.

## Giai thich theo dong

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Data` de chua bang du lieu danh sach khoa hoc va danh sach lop cua khoa hoc dang chon. |
| 2 | Import `System.Globalization` de format/parse so tien hoc phi theo kieu an toan. |
| 3 | Import `Infrastructure` de co logger va helper giao dien. |
| 4 | Import `CourseEntity`, model khoa hoc gui qua service. |
| 6-13 | Khai bao namespace, class, va 3 field. `_errCourse` la `ErrorProvider` hien loi ngay canh control. `_courseTable` giu du lieu grid ben trai. `_currentCourseStatus` ghi nho trang thai khoa hoc dang mo trong panel chi tiet. |
| 14-21 | Constructor tao UI, cau hinh host module, chinh view, tai danh sach khoa hoc ban dau, roi gan event. |
| 23-33 | `ConfigureView()` dau tien localize text, set minimum size va kich thuoc toi thieu cho 2 panel split. `SplitterWidth` va `Padding` duoc scale theo DPI qua `FormHostHelpers` de tren man hinh scale lon giao dien van can doi. |
| 34-41 | Ap theme cho 2 grid va nhom nut. Form co 2 grid: danh sach khoa hoc va danh sach lop thuoc khoa hoc dang chon. |
| 43-49 | Bat tu dong tao cot va auto fill be ngang cho ca 2 grid. `RowTemplate.Height` dat chieu cao dong cho de doc. `txtCourseDescription.ScrollBars = Vertical` vi mo ta co the dai. |
| 51-52 | Dat bo loc trang thai ve item dau va tat chieu nhap nhay cua `ErrorProvider` bang `NeverBlink` de UI bot roi. |
| 55-64 | `WireEvents()` noi cac thao tac UI voi ham xu ly. Ca `btnSaveCourse` va `btnUpdateCourse` deu tro ve cung mot ham `SaveCurrentCourse()`, nghia la service se quyet insert hay update dua vao ma khoa hoc. |
| 66-76 | `LoadCourses(...)` goi `GetCourseList(...)`. Neu `keyword` rong thi truyen `null`. Neu `status` rong, `"Tat ca"` hoac chuoi co dau tuong ung thi cung truyen `null`. Ket qua duoc bind vao grid, roi form tu chon dong dau tien. |
| 77-80 | Bat loi khi tai danh sach khoa hoc. |
| 84-91 | `StartCreateCourse()` reset editor, xin ma khoa hoc moi, dat trang thai tam mac dinh `"Con mo"`, focus vao ten khoa hoc, va bind `dgvCourseClassList` bang ket qua `GetClassList(courseId: "__empty__")`. Y nghia cua tham so `"__empty__"` la meo de buoc service tra bang rong, nham don sach grid lop khi dang tao khoa hoc moi. |
| 93-98 | `SaveCurrentCourse()` dau tien kiem tra editor hop le va lay duoc `tuitionFee`. Neu validation fail thi thoat. |
| 100-110 | Tao `CourseEntity` tu form. Chi tiet quan trong nhat nam o `Description`: form khong co cot rieng cho `Level` trong entity, nen no ghep `Level` va mo ta chung vao mot chuoi qua `BuildCourseDescription(...)`. `Status` duoc lay tu bien nho tam, neu rong thi mac dinh `"Con mo"`. |
| 112-116 | Goi `SaveCourse(course)`, cap nhat lai `_currentCourseStatus` bang gia tri service tra ve, tai lai danh sach theo bo loc hien tai, focus lai dung khoa hoc vua luu, roi thong bao thanh cong. |
| 118-121 | Bat loi khi luu khoa hoc. |
| 125-130 | `DeleteSelectedCourse()` bo qua neu chua co ma khoa hoc trong editor. |
| 132-136 | Mo `FrmConfirmDialog` de hoi lai nguoi dung. Neu khong bam `OK` thi khong xoa. |
| 138-143 | Goi `SoftDeleteCourse(...)`, tai lai danh sach, va reset panel chi tiet. "Soft delete" giu du lieu trong DB nhung danh dau la da xoa logic. |
| 144-147 | Bat loi khi xoa. |
| 151-156 | `PopulateDetailFromSelection()` kiem tra grid hien tai dang chon dong du lieu hop le hay khong. Neu khong co `DataRowView` thi khong co gi de nap. |
| 158-162 | Lay `courseId` tu cot dau tien cua dong dang chon. Neu rong thi dung. |
| 164-170 | Goi `GetCourseById(courseId)` de lay entity day du tu service. Neu `null` thi return. |
| 172-180 | Do du lieu len panel chi tiet: ma, ten, hoc phi, trang thai. Chuoi `Description` tu DB duoc tach nguoc lai bang `ParseCourseDescription(...)` thanh `level` va `description` de do vao 2 textbox rieng. Cuoi cung, grid lop phu duoc tai bang `GetClassList(courseId: course.Id)`. |
| 181-184 | Bat loi khi tai chi tiet khoa hoc. |
| 188-198 | `SelectFirstCourse()` co vai tro quen thuoc: neu co dong thi chon dong dau va nap chi tiet; neu grid rong thi reset editor. |
| 200-212 | `FocusCourse(string courseId)` duyet grid de tim lai dong co ma vua luu. Khi tim thay, no chon dong, dat `CurrentCell`, va nap lai panel chi tiet. |
| 214-240 | `ValidateEditor(out decimal tuitionFee)` xoa loi cu, reset `tuitionFee = 0`, roi kiem tra tung o. Ma khoa hoc va ten khoa hoc khong duoc rong. Hoc phi khong duoc rong va phai parse thanh `decimal` theo `InvariantCulture`, dong thoi `>= 0`. Ham tra `true` chi khi ca 3 control deu khong con message loi. |
| 243-253 | `ResetDetailEditor()` xoa error, xoa text o ma/ten/level/hoc phi/mo ta, reset `_currentCourseStatus`, va xoa `DataSource` cua grid lop lien quan. |
| 255-260 | `ResetFilters()` dua bo loc ve ban dau va tai lai toan bo danh sach. |
| 262-282 | `LocalizeLabels()` dat text cho label, placeholder, combobox item, va button. `cboCourseStatusFilter.Items.AddRange(...)` cho thay bo loc chi ho tro 3 gia tri: tat ca, con mo, tam dung. |
| 284-290 | `BuildCourseDescription(string level, string description)` la meo luu 2 y vao 1 field. Neu `level` rong thi mac dinh `"A1"`. Neu `description` rong thi chi tra `level`; neu co thi tra chuoi theo dang "level, roi ky tu pipe, roi mo ta". Nghia la ky tu pipe dang duoc dung nhu dau phan cach. |
| 292-299 | `ParseCourseDescription(...)` la chieu nguoc lai cua ham tren. Neu chuoi rong thi tra ve 2 chuoi rong. |
| 301-303 | Neu co noi dung, ham tach chuoi theo ky tu pipe dau tien bang `Split('|', 2, StringSplitOptions.TrimEntries)`, dat phan dau vao `level`, va neu co phan hai thi dat vao `description`. Day la ly do vi sao DB co ve chi co 1 cot mo ta nhung UI van tach duoc level rieng. |

## Ket luan ngan

`FrmCourseManagement` la form CRUD kha gon, nhung co 1 meo thiet ke can nhin ro:

- `Level` va `Mo ta` tren giao dien dang duoc dong goi chung vao `CourseEntity.Description`
- grid phu ben phai khong sua lop, no chi dong vai tro cho biet khoa hoc dang chon co nhung lop nao lien quan
