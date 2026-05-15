# Giai thich tung dong: `SqlLanguageCenterDataService.cs` phan 2

Phan nay cover dong 756-1624 cua `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs`.

Trong phan nay bat dau xuat hien nhom code nghiep vu nang nhat:

- diem danh
- nhap diem
- dashboard stats
- `GetById`
- CRUD student/teacher/course/class
- ghi danh
- bien lai
- avatar

## 1. Attendance va score list (dong 756-820)

### `GetAttendanceList()` (dong 756-788)

| Dong | Giai thich |
| --- | --- |
| 758-760 | Chon `targetClassId`: neu ben ngoai khong dua vao thi lay lop dau tien. Chon `targetDate`: neu null thi mac dinh hom nay. |
| 761 | Tao schema bang attendance, co ca cot ky thuat `EnrollmentId` va cot UI `Co mat`. |
| 762-765 | Neu khong co lop nao thi tra bang rong ngay. |
| 767-773 | Lay enrollment active cua lop, include `Student` va `Attendances`, order theo ten hoc vien. Chu y chi nhan status ghi danh normalize la `Active`; `Paused` se khong duoc dua vao danh sach diem danh. |
| 775-784 | Moi enrollment tim attendance cua ngay dang chon. Neu chua co attendance thi mac dinh `Present` va checkbox `Co mat = true`. Nghia la UI xem "co mat" la gia tri default khi chua cham diem danh. |
| 787 | Tra `DataTable` cho form `FrmAttendance`. |

### `GetScoreList()` (dong 790-820)

| Dong | Giai thich |
| --- | --- |
| 792-794 | Tim lop muc tieu va tao schema bang diem. |
| 795-798 | Khong co lop thi tra bang rong. |
| 800-806 | Lay enrollment active cua lop, include `Student` va `Score`, order theo ten hoc vien. |
| 808-816 | Do tung hoc vien vao bang. Neu chua co diem thi de chuoi rong. Diem duoc format `0.##` theo `vi-VN`. |

## 2. Dieu huong report va dashboard stats (dong 822-942)

### `GetReportDetail()` (dong 822-830)

| Dong | Giai thich |
| --- | --- |
| 824 | Lowercase `reportType` de so sanh de hon. |
| 825-829 | Dieu huong theo keyword: co chu `tuyen` -> report tuyen sinh, co chu `no` -> cong no, con lai -> doanh thu tong hop. |

### `GetAdminDashboardStats()` (dong 832-857)

| Dong | Giai thich |
| --- | --- |
| 834 | Tao context. |
| 835 | Tong cong no duoc tinh bang tong `Outstanding` cua `BuildDebtRows(context)`. |
| 836 | `currentMonth` la ngay dau thang hien tai de tinh hoc vien moi trong thang. |
| 837-840 | `activeClassCount` khong dem truc tiep trong SQL vi can helper `GetEffectiveClassStatus()`, nen phai `Include(Enrollments)` roi `AsEnumerable()`. |
| 842-856 | Tra object `DashboardStats` voi 8 KPI tong hop: staff, teacher, lop active, hoc vien, bien lai, doanh thu, cong no, hoc vien moi thang nay. |

### `GetStaffDashboardStats()` (dong 859-874)

| Dong | Giai thich |
| --- | --- |
| 861 | Tao context, nhung bien `context` nay thuc te khong duoc dung tiep; no la mot du thua nho. |
| 862 | Lay lai toan bo admin stats. |
| 863-873 | Tao object moi va copy nguyen cac chi so qua. Nghia la dashboard staff va admin dang chia se chung bo KPI backend. |

### `GetTeacherDashboardStats()` (dong 876-902)

| Dong | Giai thich |
| --- | --- |
| 878-883 | Map account dang login sang teacher profile. Neu khong map duoc, tra object rong de UI teacher khong vo. |
| 884-887 | Lay toan bo lop cua giao vien, include enrollments. |
| 889 | Lay list `classIds` de query pending score. |
| 890 | `today` duoc tao ra nhung hien tai khong dung tiep. |
| 891-893 | `pendingScores` dem enrollment cua giao vien ma chua co `Score`. |
| 895-901 | Tao `TeacherDashboardStats`: so lop, tong hoc vien active, so "buoi hom nay" suy dien bang so lop chua dong, va so hoc vien chua co diem. Chu y KPI `TodaySessionCount` hien khong that su dem session hom nay, ma dem lop chua dong. |

### `GetMonthlyRevenue()` va `GetMonthlyEnrollmentCounts()` (dong 904-942)

| Dong | Giai thich |
| --- | --- |
| 906-908 / 926-928 | Chon khoang thoi gian, default tu dau nam toi hom nay. |
| 910-921 | Query receipts theo khoang ngay, group by nam-thang, order theo nam-thang, roi map sang `ReportPoint { Label = "MM/YYYY", Value = tong tien }`. |
| 930-941 | Query enrollments theo khoang ngay, group by nam-thang, roi map `Value = so luong ghi danh`. |

## 3. Nhom `GetById()` (dong 944-1020)

| Dong | Giai thich |
| --- | --- |
| 944-954 | `GetStudentById()`: doc student chua xoa, `AsNoTracking()`, neu tim thay thi doi status sang display text roi moi tra ve. |
| 956-966 | `GetTeacherById()`: tuong tu cho teacher. |
| 968-978 | `GetCourseById()`: tuong tu cho course. |
| 980-990 | `GetClassById()`: tuong tu cho class. |
| 992-1006 | `GetEnrollmentById()`: include `Student`, `Class`, `Course` vi form detail can du thong tin lien quan, roi doi status sang display. |
| 1008-1020 | `GetReceiptById()`: doc receipt roi doi payment method sang display text. |

## 4. CRUD student/teacher/course/class (dong 1022-1208)

### `SaveStudent()` (dong 1022-1066)

| Dong | Giai thich |
| --- | --- |
| 1026 | Goi `ValidateStudent(student)` de enforce `FullName` va `Phone`. |
| 1027 | Normalize status tu display text ve canonical text. |
| 1028-1029 | Tao context va tim student theo `Id`. |
| 1030-1045 | Neu chua ton tai: tao entity moi, neu `Id` rong thi tu sinh `HVxxx`, trim toan bo text field, cat `BirthDate` ve phan ngay, set `IsDeleted = false`, roi `Add()`. |
| 1046-1055 | Neu da ton tai: update lai field. Chu y code khong dong vao `CreatedAt`; EF/DB se giu nguyen. |
| 1057 | `SaveChanges()` commit vao DB. |
| 1058 | Doi `entity.Status` sang display text truoc khi tra ve form. Vi ly do nay, form sau khi luu co the bind thang gia tri display vao combo box. |

### `SaveTeacher()` (dong 1068-1116)

| Dong | Giai thich |
| --- | --- |
| 1072 | Validate teacher: full name, phone, email bat buoc. |
| 1073 | Normalize status teacher. |
| 1075-1076 | Tim entity teacher cu. |
| 1077-1093 | Neu moi: tao `GVxxx` neu can, trim field, luu ca `AccountId` de lien ket teacher login. |
| 1094-1105 | Neu cu: update lai field. |
| 1107-1109 | Luu DB, doi status sang display, tra entity ve form. |

### `SaveCourse()` (dong 1118-1156)

| Dong | Giai thich |
| --- | --- |
| 1122 | Validate course: `Name` khong rong, `TuitionFee >= 0`. |
| 1123 | Normalize status khoa hoc. |
| 1125-1126 | Tim course cu. |
| 1127-1138 | Neu moi: tao `KHxxx` neu can, trim text, luu hoc phi va status, add vao DB. |
| 1139-1145 | Neu cu: update lai ten, mo ta, hoc phi, status. |
| 1147-1149 | Luu DB, doi status sang display, tra ra. |

### `SaveClass()` (dong 1158-1208)

| Dong | Giai thich |
| --- | --- |
| 1162 | Validate class: ten, date range, max student. |
| 1163 | Normalize status lop. |
| 1165-1166 | Resolve `CourseId` va `TeacherId` that su tu input form. Day la ly do form co the dua vao `ID`, `ten`, hoac chuoi `ID - ten`. |
| 1167 | Tim class cu theo `Id`. |
| 1168-1185 | Neu moi: tao `LPxxx` neu can, cat date ve phan ngay, luu lich hoc/phong hoc/si so/status, add vao DB. |
| 1186-1197 | Neu cu: update toan bo field editable. |
| 1199-1201 | Luu DB, doi status lop sang display text, roi tra ra form. |

## 5. Soft-delete wrapper (dong 1210-1228)

| Dong | Giai thich |
| --- | --- |
| 1210-1213 | `SoftDeleteStudent()` chi goi helper generic `SoftDeleteEntity(...)` va truyen selector `context => context.Students`. |
| 1215-1218 | Tuong tu cho teacher. |
| 1220-1223 | Tuong tu cho course. |
| 1225-1228 | Tuong tu cho class. |

## 6. Ghi danh (dong 1230-1299)

### `CreateEnrollment()` (dong 1230-1276)

| Dong | Giai thich |
| --- | --- |
| 1234-1240 | Tim student va class ton tai, class phai include enrollments vi se check si so. Neu khong tim thay thi throw exception nghiep vu ro rang. |
| 1242-1245 | Goi `StudentAlreadyEnrolled(studentId, classId)`. Neu hoc vien da co ghi danh active/paused trong lop nay thi chan ghi danh trung. |
| 1247-1250 | Goi helper `ClassHasAvailableSlot(classItem)` de chan ghi danh vao lop het cho. |
| 1252 | Normalize status ghi danh. |
| 1254-1263 | Tao entity `EnrollmentEntity` moi, sinh ID `GDxxx`, luu ngay ghi danh chi lay phan date, trim note, `IsDeleted=false`. |
| 1265 | Dong y nghia nghiep vu: trang thai hoc vien duoc dong bo theo trang thai ghi danh moi. |
| 1266-1267 | Add enrollment vao DB va `SaveChanges()`. |
| 1268-1269 | Doi status enrollment sang display text truoc khi tra ve UI. |

### `StudentAlreadyEnrolled()` (dong 1278-1289)

| Dong | Giai thich |
| --- | --- |
| 1281-1286 | Query enrollment cua hoc vien trong lop do, chi lay record chua xoa. |
| 1287-1288 | Chuyen sang memory vi helper `IsEnrollmentCountedAsActive()` la C# method, roi check xem co enrollment nao con duoc tinh la active khong (`Active` hoac `Paused`). |

### `ClassHasAvailableSlot(string classId)` (dong 1291-1299)

| Dong | Giai thich |
| --- | --- |
| 1294-1298 | Tim class, include enrollments, roi dung overload helper `ClassHasAvailableSlot(classItem)` de tinh xem con cho trong khong. |

## 7. Bien lai va context hoc phi (dong 1301-1473)

### `GetEnrollmentReceiptContext()` (dong 1301-1330)

| Dong | Giai thich |
| --- | --- |
| 1303-1309 | Lay enrollment, include student, class->course, va receipts. |
| 1311-1314 | Neu thieu bat ky mat xich can thiet nao thi tra `null`, vi form thu hoc phi chi co y nghia khi du student + class + course. |
| 1316 | Lay hoc phi goc tu course. |
| 1317 | Tinh tong da thu bo qua bien lai da xoa mem. |
| 1318-1329 | Tao `EnrollmentReceiptContext` gom ma hoc vien, ten, ma lop, ten lop, ten khoa hoc, hoc phi, tong da thu, va cong no con lai. |

### `GetLatestEnrollmentReceiptContextByStudentId()` (dong 1332-1363)

| Dong | Giai thich |
| --- | --- |
| 1335-1342 | Tim enrollment moi nhat cua hoc vien theo `EnrollDate` giam dan. |
| 1344-1362 | Neu tim thay day du thong tin thi build context y chang ham tren. |

### `SaveReceipt()` (dong 1365-1436)

| Dong | Giai thich |
| --- | --- |
| 1376-1379 | Chan truong hop thu 0 dong hoac am. |
| 1381 | Normalize payment method ve canonical text. |
| 1383-1388 | Tim enrollment can thu tien, include class->course va student. Neu khong tim thay thi throw. |
| 1390 | Lay hoc phi goc cua khoa hoc. |
| 1391-1394 | Tinh tong da thu tru bien lai hien tai neu dang sua. Muc dich la de check overpayment dung ngay ca khi edit bien lai. |
| 1394-1397 | Neu so tien da thu + dot nay > hoc phi goc thi chan lai ngay. Day la rule nghiep vu cuc quan trong cua he thong. |
| 1399-1401 | Neu `receiptId` rong thi xem nhu tao moi; nguoc lai thu tim bien lai cu de cap nhat. |
| 1403-1417 | Neu tao moi: sinh `PTxxx`, luu enrollment, amount, ngay, payment method, note, staff tao, va add vao DB. |
| 1418-1425 | Neu cap nhat: chi doi amount, date, payment method, note, va staff tao. |
| 1427-1429 | Luu DB, doi payment method sang display text, tra receipt ve form. |

### `GetReceiptPrintInfo()` (dong 1438-1473)

| Dong | Giai thich |
| --- | --- |
| 1440-1447 | Tim bien lai can in, include staff tao, student, class, course. Neu khong tim thay thi throw. |
| 1449-1452 | Lay toan bo bien lai cung enrollment de tinh tong da thu. |
| 1454-1455 | Tinh hoc phi goc va tong da thu. |
| 1457-1472 | Tao `ReceiptPrintInfo` de form in/view preview co du lieu tong hop, khong phai query them nua. |

## 8. Luu diem danh, luu diem, avatar, va export script (dong 1475-1624)

### `SaveAttendance()` (dong 1475-1516)

| Dong | Giai thich |
| --- | --- |
| 1479-1483 | Lay tap `activeEnrollmentIds` cua lop. Chi enrollment active moi duoc cham diem danh. |
| 1485 | Duyet chi nhung `item` co `EnrollmentId` nam trong tap hop active vua tinh. |
| 1487-1488 | Tim attendance cua hoc vien do trong ngay do. |
| 1490-1501 | Neu chua co attendance thi tao moi `AttendanceEntity` ID `DDxxx`, luu ngay, status, note, roi add vao DB. |
| 1502-1506 | Neu da co thi update status/note. Day la mau upsert. |
| 1509 | Commit toan bo thay doi sau khi xu ly xong danh sach. |

### `SaveScores()` (dong 1518-1561)

| Dong | Giai thich |
| --- | --- |
| 1522-1526 | Lay tap enrollment active cua lop, giong attendance. |
| 1528 | Duyet chi item hop le thuoc lop va dang active. |
| 1530-1531 | Validate diem giua ky va cuoi ky nam trong `0..10` neu co gia tri. |
| 1533 | Tim `ScoreEntity` theo `EnrollmentId`. |
| 1534-1545 | Neu chua co diem thi tao moi `DSxxx`, luu 2 diem va note, add vao DB. |
| 1546-1551 | Neu da co diem thi update. |
| 1554 | Commit toan bo sau cung. |

### `SaveStudentAvatar()` va `SaveTeacherAvatar()` (dong 1563-1599)

| Dong | Giai thich |
| --- | --- |
| 1567-1569 | Tim student ton tai, neu khong thi throw. |
| 1570 | Goi `AppPaths.SaveImage(...)` de copy file anh that vao thu muc `Images/Students` va lay path tuong doi. |
| 1571-1573 | Ghi `AvatarPath` vao entity, save DB, tra ve path tuong doi cho UI. |
| 1586-1593 | Logic y chang cho teacher, chi khac thu muc con la `Teachers`. |

### `ResolveAbsoluteImagePath()` va `ExportDatabaseScript()` (dong 1601-1619)

| Dong | Giai thich |
| --- | --- |
| 1601-1604 | Wrapper don gian quanh `AppPaths.ResolveAbsolutePath()` de UI khong can biet helper infra goc. |
| 1606-1613 | Tao script tao DB bang `context.Database.GenerateCreateScript()` va ghi ra file duoc chi dinh. Truoc khi ghi, dam bao thu muc dich ton tai. |
| 1614-1617 | Moi loi export script deu duoc log trung tam. |

### `CreateContext()` (dong 1621-1624)

| Dong | Giai thich |
| --- | --- |
| 1621-1624 | Mot helper nho de tao `LanguageCenterDbContext` moi tu `_options`. Moi method doc/ghi cua service thuong tao context rieng de scope ro rang, tranh giu state qua lau. |

## 9. Tong ket phan 2

Dong 756-1624 la phan nghiep vu nang nhat cua he thong:

1. load/list attendance va score
2. tinh KPI dashboard
3. CRUD 4 entity chinh
4. ghi danh
5. thu hoc phi
6. luu diem danh, luu diem
7. avatar

Phan 3 se giai thich seed data, report builders, helper tinh cong no, helper parse lich hoc, helper soft-delete generic.
