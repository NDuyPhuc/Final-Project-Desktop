# Giai thich tung dong: `FrmClassManagement.cs`

File goc: `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmClassManagement.cs`

Tai lieu nay giai thich sat line number cho form quan ly lop hoc. Nhung dong chi mo/dong khoi hay dong trang se duoc gom voi dong logic lien quan de doc de hon.

## File nay dung de lam gi

Form nay quan ly lop hoc, nghia la noi trung gian giua khoa hoc, giao vien, lich hoc, si so, va danh sach hoc vien trong lop.

## Giai thich theo dong

| Dong | Giai thich |
| --- | --- |
| 1 | Import `System.Data` de xu ly `DataTable`, `DataRow`, va du lieu bind vao grid. |
| 2 | Import `Infrastructure` de goi logger va helper giao dien. |
| 3 | Import `ClassEntity`, model lop hoc duoc gui xuong service de luu. |
| 5-10 | Khai bao namespace, class, `ErrorProvider`, va `_classTable`. `_errClass` giup hien loi canh control. `_classTable` giu danh sach lop dang hien trong grid chinh. |
| 12-19 | Constructor khoi tao UI, gan khung module "Quan ly lop hoc", cau hinh giao dien, tai danh sach lop, va gan su kien. Thu tu nay giup form mo len da co du lieu va da san sang nhan thao tac. |
| 21-30 | `ConfigureView()` goi `LocalizeLabels()` de dat text tieng Viet, sau do dat minimum size, panel min size, splitter width, card height, va padding cho khu vuc nut. Nhieu gia tri di qua `FormHostHelpers.ScaleForDpi(...)` de giao dien khong bi be hoac vo tren may co ti le scale khac nhau. |
| 32-41 | Ap theme cho 3 grid va cac nut. Form nay co 3 bang: danh sach lop, danh sach hoc vien trong lop, va danh sach buoi hoc/session. |
| 43-48 | Bat tu tao cot va auto fill cho ca 3 grid. Nghia la cot se duoc sinh theo `DataTable` tra ve tu service, khong can khai bao cot bang tay trong code nay. |
| 50-54 | Dat placeholder cho 2 o nhap khoa hoc va giao vien. Day la goi y cho user rang ho co the nhap ma hoac ten. Hai combobox trang thai duoc dat item dau, va `ErrorProvider` bi tat nhap nhay de bot gay mat tap trung. |
| 57-65 | `WireEvents()` gan su kien cho selection cua grid va cac nut CRUD. Ca `btnSaveClass` va `btnUpdateClass` deu tro ve `SaveCurrentClass()`. |
| 65 | Chi tiet de y: nut co ten `btnGenerateSessions` nhung lai duoc gan vao `DeleteSelectedClass()`. Ten control va hanh vi hien tai khong trung nhau. |
| 66-71 | Su kien cho `btnOpenEnrollmentFromClass` mo `FrmEnrollment`. Form moi duoc truyen `classId` dang chon, con `studentId` la `null`. Muc dich la "mo ghi danh trong boi canh lop nay". |
| 74-84 | `LoadClasses(...)` goi `GetClassList(...)` tu service. `keyword` va `status` duoc chuan hoa: rong hoac "Tat ca" thi bien thanh `null` de service hieu la khong loc. Ket qua bind vao grid va form tu chon dong dau tien. |
| 85-88 | Bat loi khi tai danh sach lop. |
| 92-100 | `StartCreateClass()` reset editor, xin ma lop tiep theo, dat trang thai chi tiet mac dinh `"Dang mo"`, dat ngay bat dau la hom nay, ngay ket thuc la 2 thang sau, roi focus vao ten lop. Day la goi y du lieu ban dau cho user. |
| 102-107 | `SaveCurrentClass()` chi di tiep neu `ValidateEditor(...)` thanh cong va tra ve duoc `courseId`, `teacherId`, `maxStudents`. |
| 109-124 | Tao `ClassEntity` tu editor: ma, ten, khoa hoc, giao vien, ngay bat dau/ket thuc, lich hoc, phong hoc, si so, trang thai. `IsDeleted = false` vi day la ban ghi hoat dong. |
| 126-129 | Goi `SaveClass(entity)`, tai lai danh sach theo bo loc hien tai, focus lai dung lop vua luu, va thong bao thanh cong. |
| 131-134 | Bat loi khi luu lop hoc. |
| 138-143 | `DeleteSelectedClass()` bo qua neu chua co ma lop trong editor. |
| 145-149 | Mo dialog xac nhan xoa mem. Neu user khong bam `OK` thi huy. |
| 151-156 | Goi `SoftDeleteClass(...)`, tai lai grid, va reset editor. |
| 157-160 | Bat loi khi xoa lop. |
| 164-175 | `PopulateDetailFromSelection()` mo dau bang viec doc dong dang chon trong grid. Neu khong co `DataRowView` hop le hoac ma lop rong thi dung ngay. |
| 177-183 | Goi `GetClassById(classId)` de lay entity day du tu service. Neu khong tim thay thi return. |
| 185-192 | Do thong tin co ban cua lop len form: ma, ten, lich hoc, phong, si so, ngay bat dau, ngay ket thuc, trang thai. Hai dong date co check `default` de tranh hien gia tri `01/01/0001` vo nghia. |
| 194-197 | Lay them khoa hoc va giao vien thong qua `CourseId` va `TeacherId`. Neu tim thay, textbox hien dang `ID - Ten`; neu khong tim thay thi it nhat van hien duoc ma goc. |
| 199-200 | Tai 2 grid phu: hoc vien cua lop va cac session/buoi hoc cua lop. Day la cach form hien "chi tiet lien quan", khong chi thong tin lop don le. |
| 202-205 | Bat loi khi tai chi tiet lop. |
| 209-219 | `SelectFirstClass()` giup grid co du lieu thi dong dau duoc chon ngay; neu khong co du lieu thi editor bi reset. |
| 221-233 | `FocusClass(string classId)` duyet grid, so ma lop khong phan biet hoa thuong, roi chon va nap lai dong dung ma sau khi luu. |
| 235-240 | `ValidateEditor(...)` khoi tao lai toan bo bien out va xoa loi cu. `courseId`, `teacherId`, `maxStudents` deu duoc tra ve cho ham goi khi validation thanh cong. |
| 242-250 | Kiem tra ma lop va ten lop khong duoc de trong. |
| 252-256 | Goi `ResolveCourseId(txtClassCourse.Text.Trim())`. Nghia la textbox khoa hoc khong nhat thiet phai chua dung ma; user co the nhap ma, ten, hoac chuoi dang `ma - ten`, roi helper se co gang quy doi ve ma khoa hoc that. Neu khong quy doi duoc thi dat loi. |
| 258-262 | Cung logic tuong tu cho giao vien qua `ResolveTeacherId(...)`. |
| 264-267 | `txtClassSize` phai parse thanh so nguyen va lon hon 0. Neu khong thi thong bao loi "Si so toi da phai > 0". |
| 269-272 | Kiem tra quy tac nghiep vu co ban: ngay bat dau khong duoc sau ngay ket thuc. |
| 274-279 | Ham chi tra `true` khi 6 control quan trong deu khong con loi: ma lop, ten lop, khoa hoc, giao vien, si so, va ngay ket thuc. |
| 282-287 | `ResolveCourseId(string input)` bao ve truong hop rong. Neu user khong nhap gi thi khong the tim khoa hoc. |
| 289-293 | Cat phan truoc dau `-` lam `exactId`. Vi textbox co the dang la `KH01 - Tieng Anh A1`, cat nhu vay cho phep thu tim theo ma nhanh truoc. Neu `GetCourseById(exactId)` co ket qua thi tra ve ngay. |
| 295-305 | Neu khong tim thay theo ma truc tiep, form lay toan bo bang khoa hoc va duyet tung dong. Moi dong, no so `input` voi 3 kieu: dung ma, dung ten, hoac dung chuoi `id - name`. Tim thay thi tra ve `id`. |
| 308 | Neu duyet het ma van khong thay, ham tra chuoi rong de bao "khong resolve duoc". |
| 311-337 | `ResolveTeacherId(...)` la ban song song cua `ResolveCourseId(...)`, nhung lam tren danh sach giao vien. Logic giong het: uu tien cat ma, thu tim theo ma, neu khong duoc thi quet bang giao vien de so theo ma/ten/chuoi `id - name`. |
| 340-355 | `ResetDetailEditor()` xoa loi, xoa text cac o nhap, dat combobox trang thai ve item dau, reset 2 date ve hom nay, va xoa 2 grid phu. Day la trang thai "khong dang mo lop cu nao". |
| 357-362 | `ResetFilters()` xoa tu khoa, dua bo loc ve item dau, va tai lai danh sach lop day du. |
| 364-383 | `LocalizeLabels()` dat text cho bo loc, danh sach trang thai, nhan cua cac o nhap, va button. 2 danh sach trang thai can de y: bo loc co them `"Day"` va `"Da huy"` de truy van, con combobox chi tiet khong co `"Day"` vi do co the la trang thai do he thong tinh ra hon la nguoi dung nhap tay. |
| 385-391 | Gan text cho cac nut. Chi tiet quan trong: `btnGenerateSessions.Text = "Xoa mem lop"` xac nhan them lan nua rang ten bien cua nut da khong con phu hop voi chuc nang hien tai. |

## Ket luan ngan

`FrmClassManagement` la form ket noi nhieu thuc the nhat trong nhom staff:

- lop thuoc khoa hoc
- lop gan giao vien
- lop co hoc vien va session di kem

Hai diem can nho khi doc file:

- 2 textbox khoa hoc/giao vien khong luu truc tiep ma, no can helper resolve ve ID that
- `btnGenerateSessions` hien dang la ten control cu, nhung chuc nang that la xoa mem lop
