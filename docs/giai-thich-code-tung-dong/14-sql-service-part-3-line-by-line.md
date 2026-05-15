# Giai thich tung dong: `SqlLanguageCenterDataService.cs` phan 3

Phan nay cover dong 1626-2262 cua `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs`.

Day la phan "hau truong":

- seed du lieu mau
- builder cho bao cao
- helper tinh si so, cong no, status
- parser lich hoc
- soft-delete generic

Neu phan 2 la noi "thao tac nghiep vu", thi phan 3 la noi "cung cap tinh toan nen" cho nhung thao tac do.

## 1. Seed du lieu mau (dong 1626-1845)

### Dau ham `SeedData()` (dong 1626-1632)

| Dong | Giai thich |
| --- | --- |
| 1626 | Bat dau ham seed. Ham nay chi duoc goi sau khi `ShouldSeedSampleData(context)` tra `true`. |
| 1628-1631 | Neu bang `Accounts` da co du lieu thi thoat ngay, tranh seed trung. |

### Seed account (dong 1633-1671)

| Dong | Giai thich |
| --- | --- |
| 1633-1671 | Tao mang `accounts` gom 3 account mau. |
| 1635-1646 | `ACC001/admin`: role `Admin`, password hash cua `123456`, display name "Admin Tong Quan". |
| 1647-1658 | `ACC002/staff`: role `Staff`, dung cho flow van hanh va bien lai. |
| 1659-1670 | `ACC003/teacher`: role `Teacher`, se lien ket voi teacher profile `GV001`. |

### Seed teacher (dong 1673-1712)

| Dong | Giai thich |
| --- | --- |
| 1673-1712 | Tao 3 giao vien mau. |
| 1675-1687 | `GV001` lien ket `AccountId = "ACC003"`, nghia la day la giao vien co the dang nhap vao teacher dashboard. |
| 1688-1699 | `GV002` la giao vien khong co account login. |
| 1700-1711 | `GV003` co status `Inactive` de dashboard/quan ly co du lieu test trang thai. |

### Seed course (dong 1714-1743)

| Dong | Giai thich |
| --- | --- |
| 1714-1743 | Tao 3 khoa hoc mau: co ban, IELTS, TOEIC. Muc dich la de bao cao, lop hoc, cong no co su da dang. |

### Seed class (dong 1745-1789)

| Dong | Giai thich |
| --- | --- |
| 1745-1789 | Tao 3 lop hoc mau. Moi lop gan course, teacher, lich hoc, phong hoc, si so, va status `Open`. |
| 1753-1758 / 1767-1773 / 1781-1787 | Cac line nay cung cap du lieu rat quan trong cho helper `GetSessions()`: no can `StartDate`, `EndDate`, `Schedule`, `Room`. |

### Seed student, enrollment, receipt, attendance, score (dong 1791-1833)

| Dong | Giai thich |
| --- | --- |
| 1791-1799 | Tao 6 hoc vien mau voi ngay sinh, phone, email, status khac nhau. Co 1 hoc vien status `Paused` de test business rule. |
| 1801-1809 | Tao 6 enrollment mau. Chu y `GD003` co status `Paused`, giup test logic active/paused trong nhieu helper. |
| 1811-1819 | Tao 6 bien lai mau, gom truong hop dong du va dong nhieu dot. |
| 1821-1826 | Tao 3 attendance mau. |
| 1828-1833 | Tao 3 score mau. |

### Commit seed (dong 1835-1845)

| Dong | Giai thich |
| --- | --- |
| 1835-1843 | `AddRange(...)` tung nhom entity vao context. |
| 1844 | `context.SaveChanges()` commit tat ca seed trong mot lan. |

## 2. Dieu kien duoc seed (dong 1847-1858)

| Dong | Giai thich |
| --- | --- |
| 1847-1858 | `ShouldSeedSampleData()` chi tra `true` khi TAT CA cac bang chinh deu rong. Nghia la neu DB moi tao nhung da co bat ky bang nao co du lieu, service se khong seed nua. Cach nay tranh tron du lieu that voi du lieu mau. |

## 3. Xay chi tiet report (dong 1860-1939)

### `BuildRevenueReportDetail()` (dong 1860-1887)

| Dong | Giai thich |
| --- | --- |
| 1862-1865 | Tao context, tinh `start/end`, va tao bang detail doanh thu. |
| 1867-1873 | Lay receipts trong khoang ngay, include student va class. |
| 1875-1883 | Moi bien lai duoc map thanh 1 dong report: ngay phat sinh, so bien nhan, hoc vien, lop, ghi chu khoan thu, so tien. Neu `Note` rong thi mac dinh "Thu hoc phi". |

### `BuildEnrollmentReportDetail()` (dong 1889-1916)

| Dong | Giai thich |
| --- | --- |
| 1891-1894 | Tao context, start/end, va schema report ghi danh. |
| 1896-1902 | Lay enrollments trong khoang ngay, include student va course qua class. |
| 1904-1912 | Map moi enrollment ra 1 dong report, trong do status duoc doi sang display text. |

### `BuildDebtReportDetail()` (dong 1918-1939)

| Dong | Giai thich |
| --- | --- |
| 1920-1924 | Tao schema cong no, context, va lay toan bo `DebtRow` tu helper `BuildDebtRows(context)`. |
| 1926-1935 | Loc theo khoang ngay doi soat, roi map ra bang detail cong no. |

## 4. Trung tam tinh cong no: `BuildDebtRows()` (dong 1941-1984)

| Dong | Giai thich |
| --- | --- |
| 1943-1949 | Lay toan bo enrollments chua xoa, include student, class->course, va receipts. |
| 1951 | Bat dau `Select` moi enrollment thanh 1 `DebtRow`. |
| 1953 | `tuitionFee` lay tu `Course.TuitionFee`. |
| 1954 | `paidAmount` la tong bien lai chua xoa mem. |
| 1955 | `outstanding = max(0, tuition - paid)`, nghia la khong bao gio cho cong no am. |
| 1956-1960 | Thu tim lan nop gan nhat trong receipt history. |
| 1961-1964 | Neu hoc vien chua tung nop dot nao thi lay `EnrollDate` lam `ReferenceDate`. |
| 1966-1968 | Xac dinh status cong no: `Da hoan thanh` neu het no, `Qua han` neu no lon hon nua hoc phi, con lai la `Sap den han`. Day la heuristic nghiep vu, khong phai due-date that su co trong DB. |
| 1970-1982 | Tao object `DebtRow` gom ma ghi danh, ma hoc vien, ten hoc vien, ten lop, ten khoa hoc, phai thu, da thu, con no, status, va ngay doi soat. |
| 1983 | Ket thuc `ToList()`, tra ve danh sach debt row cho dashboard, debt tracking, va bao cao. |

## 5. Helper sinh ma, format, tao bang, tach level (dong 1986-2039)

### `GetNextCode()` (dong 1986-1997)

| Dong | Giai thich |
| --- | --- |
| 1988-1994 | Loc cac ID co prefix, cat phan so o cuoi, parse thanh int, lay max, cong 1. |
| 1996 | Format ket qua thanh `PREFIX000`, vi du `HV007`, `PT012`. |

### `FormatMoney()` (dong 1999-2002)

| Dong | Giai thich |
| --- | --- |
| 1999-2002 | Chi format decimal sang chuoi theo `vi-VN`, khong them don vi `VND`. Form nao can `VND` se ghep them. |

### `CreateTable()` (dong 2004-2013)

| Dong | Giai thich |
| --- | --- |
| 2006 | Tao `DataTable` rong. |
| 2007-2010 | Duyet danh sach ten cot va add vao table. |
| 2012 | Tra table ra. Day la helper duoc goi khap file. |

### `ExtractCourseLevel()` (dong 2015-2039)

| Dong | Giai thich |
| --- | --- |
| 2017-2025 | Neu `description` khong rong thi thu split theo dau `|`. Neu tach duoc thi phan dau duoc xem la level. Neu khong thi tra ve ca description. |
| 2028-2036 | Neu description rong, fallback su doan level theo ten khoa hoc: co "IELTS" -> `IELTS 5.5+`, co "TOEIC" -> `TOEIC 500+`, con lai -> `A1`. |
| 2038 | Fallback cuoi cung la `A1`. |

## 6. Helper tinh si so va status lop (dong 2041-2070)

| Dong | Giai thich |
| --- | --- |
| 2041-2044 | `GetActiveEnrollmentCount(classItem)`: dem enrollment chua xoa ma duoc tinh la active qua helper `IsEnrollmentCountedAsActive()`. |
| 2046-2050 | `ClassHasAvailableSlot(classItem)`: chi xem lop con cho khi status canonical la `Open` hoac `InProgress`, va si so active < `MaxStudents`. |
| 2052-2064 | `GetEffectiveClassStatus(classItem)`: suy dien status thuc te cua lop. Neu DB status da dong/hoan thanh/huy, hoac `EndDate` da qua, thi tra "Da dong". Neu si so full thi tra "Day". Neu khong thi tra display text cua status canonical. |
| 2066-2070 | `IsEnrollmentCountedAsActive(status)`: coi `Active` va `Paused` deu con chiem cho trong lop. Day la quy tac quan trong anh huong si so va kiem tra ghi danh trung. |

## 7. Validation nghiep vu (dong 2072-2140)

| Dong | Giai thich |
| --- | --- |
| 2072-2083 | `ValidateStudent()`: hoc vien bat buoc co ten va so dien thoai. |
| 2085-2101 | `ValidateTeacher()`: giao vien bat buoc co ten, phone, email. |
| 2103-2114 | `ValidateCourse()`: khoa hoc bat buoc co ten va hoc phi khong am. |
| 2116-2132 | `ValidateClass()`: lop bat buoc co ten, ngay bat dau <= ngay ket thuc, va si so > 0. |
| 2134-2140 | `ValidateScore()`: neu co diem thi phai nam trong khoang 0 den 10. |

## 8. Resolve ID va parse lich hoc (dong 2142-2213)

### Resolve ID

| Dong | Giai thich |
| --- | --- |
| 2142-2148 | `ResolveCourseId()`: trim input, tim course chua xoa theo ID hoac ten. Neu khong tim thay thi throw. |
| 2150-2156 | `ResolveTeacherId()`: trim input, tim teacher chua xoa theo ID hoac ten. |
| 2158-2169 | `ResolveTeacherIdByAccount()`: map `AccountId` cua user dang login sang `Teacher.Id`; neu `teacherAccountId` rong thi tra `null`. |

### Parse lich hoc

| Dong | Giai thich |
| --- | --- |
| 2171-2174 | `ParseScheduleDays()` nhan chuoi lich hoc va 1 `fallbackDay`. Dau tien lower-case chuoi lich. |
| 2175-2198 | Tao dictionary map token van ban sang `DayOfWeek`. Co ca token so (`2`, `3`, `7`), Viet (`thu 2`, `t2`, `cn`), va mot vai token Anh (`mon`, `wed`, `fri`). |
| 2200 | Tim tat ca key nam trong chuoi lich va lay set `DayOfWeek` tuong ung. |
| 2201-2204 | Neu parse khong ra ngay nao thi them `fallbackDay` de UI van co du lieu lich hoc. |
| 2206 | Tra `HashSet<DayOfWeek>`. |

### `ResolveRequiredTeacherIdByAccount()` (dong 2209-2213)

| Dong | Giai thich |
| --- | --- |
| 2209-2213 | Wrapper nho quanh `ResolveTeacherIdByAccount()`. Muc dich la tra `null` ro rang neu teacherId rong/khong tim thay. Nhom method teacher dashboard dung helper nay. |

## 9. Soft-delete generic va expression tree (dong 2215-2247)

### `SoftDeleteEntity<TEntity>()`

| Dong | Giai thich |
| --- | --- |
| 2215-2219 | Ham generic nhan `id`, selector lay `DbSet<TEntity>`, va ten context log. Rang buoc `where TEntity : class` vi EF set lam viec voi entity class. |
| 2223-2226 | Tao context, lay set qua selector, tim entity theo predicate `Id == id`. Neu khong co thi throw. |
| 2228-2230 | Dung reflection tim property `IsDeleted` tren entity generic. Neu entity khong co property nay thi xem la khong ho tro soft-delete. |
| 2230-2231 | Dat `IsDeleted = true` va `SaveChanges()`. |
| 2233-2236 | Log moi loi kem `contextName` cu the, giup biet dang xoa student/course/class nao. |

### `CreateIdPredicate<TEntity>()`

| Dong | Giai thich |
| --- | --- |
| 2240-2246 | Dung expression tree de tao lambda `entity => entity.Id == id` cho entity generic. Cach nay cho phep goi `FirstOrDefault(...)` ma khong can biet kieu entity cu the luc compile. |

## 10. `DebtRow` noi bo (dong 2249-2262)

| Dong | Giai thich |
| --- | --- |
| 2249 | Khai bao class `DebtRow` private sealed, chi dung noi bo trong service. |
| 2251-2259 | Cac property bat buoc de mo ta 1 dong cong no: enrollment, student, lop, khoa, phai thu, da thu, con no, status. |
| 2260 | `ReferenceDate` la moc ngay dung de loc theo khoang ngay trong report/debt tracking. |
| 2261-2262 | Dong class va dong file. |

## 11. Tong ket toan bo `SqlLanguageCenterDataService.cs`

Neu phai giai thich file nay trong luc bao ve do an, co the chot ngan gon nhu sau:

1. Dong 1-39: khoi tao service SQL.
2. Dong 41-173: readiness + auth + account.
3. Dong 175-754: toan bo `DataTable` source cho UI.
4. Dong 756-1624: nghiep vu chinh CRUD, enrollment, receipt, attendance, score.
5. Dong 1626-2262: seed, report, helper tinh toan, parser lich hoc, soft-delete generic.

Noi ngan gon hon nua:

- `Forms` goi vao service nay.
- Service nay noi voi `DbContext`.
- Service nay vua query DB, vua enforce business rule, vua format data cho UI.
