# Báo cáo đối chiếu tiêu chí đồ án Desktop

Ngày lập: 2026-04-28

## 1. Mục đích

Tài liệu này đối chiếu giữa:

- Đề tài được giao trong file `ĐỀ TÀI 6 (1).docx`
- Tiêu chí chấm kỹ thuật và mẫu báo cáo trong các file `MauBC_DA - PTUDDesktop...pdf`
- Dự án hiện tại `Trung-tam-quan-ly-ngoai-ngu`

Mục tiêu là xác định dự án đã đáp ứng được những gì, còn thiếu những gì, và những phần cần bổ sung để tăng độ hoàn thiện trước khi nộp và demo.

## 2. Tổng quan dự án hiện tại

Dự án hiện tại là ứng dụng WinForms dùng C# với kiến trúc tách lớp khá rõ:

- UI WinForms ở thư mục `Trung-tam-quan-ly-ngoai-ngu/Forms`
- Application layer ở `TrungTamNgoaiNgu.Application`
- Domain entities ở `TrungTamNgoaiNgu.Domain`
- SQL script ở `docs/database-script.sql`

Điểm mạnh lớn của dự án là đã có đủ các phân hệ chính:

- Đăng nhập và phân quyền `Admin / Staff / Teacher`
- Quản lý học viên
- Quản lý giáo viên
- Quản lý khóa học
- Quản lý lớp học
- Ghi danh
- Thu học phí và in biên lai
- Theo dõi công nợ
- Điểm danh
- Nhập điểm
- Báo cáo thống kê

Ngoài ra dự án đã có:

- Entity Framework với `LanguageCenterDbContext`
- Xóa mềm với trường `IsDeleted`
- Ghi log lỗi ra `log.txt`
- Lưu ảnh avatar vào thư mục `Images`
- In biên lai bằng `PrintDocument` và `PrintPreviewDialog`

## 3. Đối chiếu theo yêu cầu đề tài

### 3.1. Chức năng chính của đề tài

| Yêu cầu từ đề tài | Trạng thái | Nhận xét |
|---|---|---|
| Quản lý học viên và ghi danh | Đạt | Có form học viên và ghi danh, luồng chọn học viên -> chọn lớp -> tạo ghi danh -> mở thu học phí đã có. |
| Quản lý đào tạo: khóa học, lớp học, phân công giáo viên, lịch học | Đạt | Có quản lý khóa học, lớp học, giáo viên và lịch học. |
| Quản lý lớp học: điểm danh hằng ngày, nhập điểm giữa kỳ/cuối kỳ | Đạt một phần tốt | Có điểm danh và nhập điểm. Tuy nhiên điểm danh đang dùng `DataGridViewComboBoxColumn` thay vì checkbox đúng như mô tả gợi ý của đề tài. |
| Tài chính: thu học phí, in biên lai, thống kê công nợ | Đạt | Có form thu học phí, lịch sử biên lai, preview in, danh sách công nợ. |
| Xuất hóa đơn/báo cáo ra PDF hoặc Excel | Chưa đạt hoàn chỉnh | Hiện tại phần xuất chủ yếu là CSV. Nút PDF ở công nợ mới là thông báo placeholder, nút in báo cáo admin mới dừng ở mức gợi ý tính năng. |
| Upload hình ảnh và lưu vào thư mục `Images` | Đạt một phần | Học viên có upload avatar và lưu file vào `Images`. Tuy nhiên phần giáo viên/nhân viên chưa có UI dùng thật dù service đã hỗ trợ. |
| Ghi log lỗi ra `log.txt` | Đạt | Có `ErrorLogger` và đã gọi ở nhiều điểm quan trọng. |

### 3.2. Công nghệ áp dụng theo đề tài

| Yêu cầu công nghệ | Trạng thái | Nhận xét |
|---|---|---|
| WinForms Controls đa dạng | Đạt | Dự án dùng nhiều control: `Button`, `DataGridView`, `Panel`, `TabControl`, `Chart`, `ErrorProvider`, `ToolTip`, `PrintPreviewDialog`. |
| `TabControl` để chia phân hệ | Đạt một phần | Có `TabControl` trong form quản lý lớp. Các phân hệ lớn hiện chia theo dashboard và form con thay vì thuần tab. |
| `DataGridView` có Checkbox để điểm danh hàng loạt | Chưa khớp hoàn toàn | Điểm danh hiện dùng combobox trạng thái và nút “Tất cả có mặt / Tất cả vắng”. Chức năng vẫn có nhưng chưa đúng đúng mẫu checkbox của đề bài. |
| Xử lý nhiều-nhiều Student - Class qua EF | Đạt | Quan hệ đã được mô hình hóa qua `EnrollmentEntity`, phù hợp nghiệp vụ many-to-many. |
| LINQ `GroupBy` cho báo cáo doanh thu | Đạt | Có gom nhóm doanh thu theo tháng và số ghi danh theo tháng. |
| `System.Drawing.Printing` để in hóa đơn/biên lai | Đạt | Đã dùng `PrintDocument` và `PrintPreviewDialog` trong form biên lai. |

### 3.3. Cơ sở dữ liệu so với mô tả đề tài

Nhìn chung phần CSDL đang làm tốt hơn mức tối thiểu của đề tài:

- Có đủ các bảng chính: `Accounts`, `Courses`, `Teachers`, `Classes`, `Students`, `Enrollments`, `Receipts`, `Attendances`, `Scores`
- Có PK, FK, unique index, check constraint
- Có `CreatedAt`, `UpdatedAt`, `IsDeleted`

Tuy nhiên vẫn có một vài lệch nhỏ so với mô tả ban đầu:

- Đề tài nêu `Student` có trường `Address`, nhưng giao diện học viên hiện chưa cho nhập/sửa địa chỉ dù entity và database đã có cột này.
- Đề tài nêu upload hình cho “avatar nhân viên...”, nhưng giao diện hiện chỉ triển khai upload ảnh cho học viên.

## 4. Đối chiếu theo tiêu chí chấm phần mềm

### 4.1. Giao diện (UI/UX) - 2.0 điểm

Đánh giá: khá tốt, gần đạt trọn.

Phần đã có:

- Sử dụng đa dạng WinForms controls
- Có `ToolTip`, `ErrorProvider`, màu sắc cảnh báo
- Có nhiều dashboard theo vai trò
- Có layout responsive tương đối tốt trong nhiều form

Điểm cần lưu ý:

- Một số form/admin module còn dùng dữ liệu mock hoặc nút chưa hoàn thiện logic thật
- Text tiếng Việt trong source đang có dấu hiệu lỗi encoding ở nhiều file `.cs`; nếu hiện lên UI sai dấu khi chạy sẽ ảnh hưởng trực tiếp điểm UI/UX

Ước lượng nội bộ: `1.5 - 1.75 / 2.0`

### 4.2. Cơ sở dữ liệu và Entity Framework - 2.5 điểm

Đánh giá: tốt.

Phần đã có:

- SQL Server script khá đầy đủ
- `DbContext` khởi tạo rõ ràng
- CRUD qua service layer
- Có LINQ
- Có soft-delete
- Có quan hệ nhiều-nhiều qua bảng ghi danh

Điểm cần lưu ý:

- Chưa xác minh build/run end-to-end trong môi trường hiện tại vì lệnh `dotnet build` bị lỗi SDK/workload cục bộ, nên chưa kết luận được 100% trạng thái compile của solution

Ước lượng nội bộ: `2.25 / 2.5`

### 4.3. Logic nghiệp vụ và OOP - 2.0 điểm

Đánh giá: tốt.

Phần đã có:

- Tách lớp `Forms -> Services -> Repositories -> Data`
- Có interface `ILanguageCenterDataService`
- Có nhiều implementation: SQL, offline demo
- Có validation nghiệp vụ trước khi lưu
- Có luồng ghi danh -> thu học phí -> biên lai
- Có luồng giáo viên -> điểm danh -> nhập điểm

Điểm cần lưu ý:

- OOP chủ yếu mạnh ở tách lớp và polymorphism service layer; phần inheritance ở domain/form không nổi bật lắm để đem đi trình bày
- Một số màn hình admin thiên về trình diễn hơn là nghiệp vụ sâu

Ước lượng nội bộ: `1.5 - 1.75 / 2.0`

### 4.4. Xử lý ngoại lệ và File I/O - 1.5 điểm

Đánh giá: khá tốt.

Phần đã có:

- Bắt lỗi và log lỗi khá nhiều nơi
- Có `ErrorProvider`
- Có File I/O cho avatar
- Có ghi `log.txt`

Điểm cần lưu ý:

- File I/O cho avatar mới rõ ở học viên, chưa đồng đều cho giáo viên/nhân viên
- Nếu demo, nên chủ động tạo một tình huống lỗi để chụp được `log.txt` làm minh chứng cho báo cáo Word

Ước lượng nội bộ: `1.25 / 1.5`

### 4.5. Tổng ước lượng kỹ thuật

Ước lượng nội bộ, không phải điểm chính thức:

- Khoảng `6.5 - 7.0 / 8.0`

Nếu bổ sung được các mục còn thiếu ở phần xuất file, checkbox điểm danh, avatar giáo viên và hoàn thiện vài nút admin, dự án có thể tiến gần mức `7.5 - 8.0 / 8.0`.

## 5. Thiếu sót quan trọng cần ưu tiên bổ sung

### Mức ưu tiên cao

1. Xuất báo cáo/biên bản ra PDF hoặc Excel chưa hoàn chỉnh

- Hiện tại báo cáo admin xuất CSV là chính.
- Nút PDF ở công nợ chưa làm thật.
- Nút in báo cáo admin mới hiển thị thông báo.

Tác động:

- Đây là chỗ dễ mất điểm vì đề tài ghi rất rõ “xuất hóa đơn/báo cáo ra file PDF hoặc Excel”.

2. Điểm danh chưa dùng checkbox như mô tả đề tài

- Dự án hiện dùng combobox trạng thái và hai nút chọn hàng loạt.

Tác động:

- Chức năng nghiệp vụ có, nhưng chưa khớp sát phần công nghệ minh họa trong đề tài.

3. Upload ảnh mới rõ ở học viên, chưa rõ ở giáo viên/nhân viên

- Service đã có `SaveTeacherAvatar`, nhưng UI giáo viên hiện vẫn lưu `AvatarPath = null`.

Tác động:

- Có thể bị hỏi khi demo vì đề tài có nêu tính năng upload ảnh.

### Mức ưu tiên trung bình

4. Form học viên chưa nhập địa chỉ

- Entity và database có `Address`, nhưng form hiện không cho thao tác trường này.

5. Một số màn hình admin còn mang tính demo/mock

- `FrmSystemMonitor` có `BindMockData()`
- `FrmAccessMatrix` chỉ bind dữ liệu, nút export chưa thấy xử lý

Tác động:

- Không phá chức năng lõi, nhưng nếu giảng viên đi sâu phần admin sẽ lộ độ hoàn thiện chưa đồng đều.

6. Lỗi build hiện chưa xác minh được do môi trường SDK

- `dotnet build` đang fail ở bước restore với dấu hiệu lỗi SDK/workload của máy cục bộ, không phải lỗi source rõ ràng.

Tác động:

- Nên kiểm tra lại bằng Visual Studio trên máy làm đồ án trước khi nộp/demo.

## 6. Các minh chứng source code đáng chú ý

### Phần đã làm tốt

- `net8.0-windows`, WinForms, chart package:
  - `Trung-tam-quan-ly-ngoai-ngu/Trung-tam-quan-ly-ngoai-ngu.csproj:5`
  - `Trung-tam-quan-ly-ngoai-ngu/Trung-tam-quan-ly-ngoai-ngu.csproj:8`
  - `Trung-tam-quan-ly-ngoai-ngu/Trung-tam-quan-ly-ngoai-ngu.csproj:14`
- Ghi log lỗi:
  - `TrungTamNgoaiNgu.Application/Infrastructure/AppPaths.cs:6`
  - `TrungTamNgoaiNgu.Application/Infrastructure/ErrorLogger.cs:24`
  - `Trung-tam-quan-ly-ngoai-ngu/Program.cs:54`
  - `Trung-tam-quan-ly-ngoai-ngu/Program.cs:68`
- Lưu ảnh vào thư mục `Images`:
  - `TrungTamNgoaiNgu.Application/Infrastructure/AppPaths.cs:7`
  - `TrungTamNgoaiNgu.Application/Infrastructure/AppPaths.cs:34`
  - `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs:1533`
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmStudentManagement.cs:153`
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmStudentManagement.cs:200`
- In biên lai:
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmTuitionReceipt.Designer.cs:34`
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmTuitionReceipt.Designer.cs:35`
- LINQ `GroupBy` cho báo cáo:
  - `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs:892`
  - `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs:912`
- Soft-delete:
  - `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs:1189`
  - `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs:1194`
  - `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs:1199`
  - `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs:1204`

### Phần còn thiếu hoặc chưa hoàn thiện

- Điểm danh dùng combobox thay vì checkbox:
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Teacher/FrmAttendance.cs:136`
- Nút chọn hàng loạt có mặt/vắng:
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Teacher/FrmAttendance.cs:49`
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Teacher/FrmAttendance.cs:50`
- Giáo viên chưa có upload avatar ở UI:
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmTeacherManagement.cs:105`
  - `TrungTamNgoaiNgu.Application/Services/SqlLanguageCenterDataService.cs:1552`
- Xuất PDF công nợ mới là placeholder:
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Staff/FrmDebtTracking.cs:49`
- In báo cáo admin chưa làm thật:
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Admin/FrmAdminReports.cs:644`
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Admin/FrmAdminReports.cs:1037`
- `SystemMonitor` còn dùng dữ liệu mock:
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Admin/FrmSystemMonitor.cs:23`
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Admin/FrmSystemMonitor.cs:283`
- `AccessMatrix` chưa thấy xử lý nút export:
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Admin/FrmAccessMatrix.cs:21`
  - `Trung-tam-quan-ly-ngoai-ngu/Forms/Admin/FrmAccessMatrix.Designer.cs:654`

## 7. Những gì nên bổ sung vào báo cáo Word theo mẫu thầy

Nếu dùng mẫu báo cáo của thầy, bạn nên bổ sung các nội dung sau:

1. Chương 1

- Đổi toàn bộ ví dụ “cửa hàng sách” trong mẫu thành “trung tâm ngoại ngữ”
- Mô tả bối cảnh: quản lý học viên, lớp, giáo viên, học phí, công nợ bằng sổ tay dễ sai sót

2. Chương 2

- Trình bày quy trình: khảo sát yêu cầu -> thiết kế CSDL -> thiết kế giao diện -> code -> kiểm thử
- Nêu rõ dùng WinForms, SQL Server, Entity Framework, LINQ
- Nêu rõ kiến trúc phân lớp hiện tại

3. Chương 3

- Chèn ERD hoặc Database Diagram
- Chèn ảnh giao diện đăng nhập
- Chèn ảnh giao diện học viên, ghi danh, thu học phí, điểm danh, nhập điểm, báo cáo
- Chèn ảnh `PrintPreview` biên lai
- Chèn ảnh thư mục `Images`
- Chèn ảnh `log.txt`
- Chèn đoạn code ngắn cho:
  - soft-delete
  - lưu avatar
  - `GroupBy` báo cáo doanh thu
  - in biên lai

4. Chương 4

- Tự đánh giá mức hoàn thành
- Nêu rõ hạn chế hiện tại:
  - xuất PDF/Excel chưa đủ
  - điểm danh chưa dùng checkbox
  - admin monitor còn mock
- Nêu hướng phát triển:
  - xuất PDF/Excel thật
  - avatar cho giáo viên/nhân viên
  - báo cáo nâng cao
  - phân quyền sâu hơn

## 8. Kết luận

Dự án hiện tại đã có nền tảng khá tốt và đã chạm được phần lớn nghiệp vụ chính của đề tài. Các điểm mạnh rõ nhất là:

- kiến trúc phân lớp tương đối sạch
- CSDL và EF làm chắc tay
- có soft-delete, logging, in biên lai, báo cáo chart
- luồng nghiệp vụ chính của trung tâm ngoại ngữ đã khá đầy đủ

Tuy nhiên để nộp và demo ở trạng thái đẹp hơn, nên ưu tiên vá 3 chỗ:

1. Hoàn thiện xuất PDF/Excel thật
2. Đưa điểm danh về dạng checkbox hoặc bổ sung minh chứng giải thích hợp lý
3. Hoàn thiện upload ảnh cho giáo viên/nhân viên và rà lại các màn admin còn mock

Nếu chỉ xét theo mức “đủ để báo cáo và demo đồ án môn học”, dự án đã ở mức khá tốt. Nếu vá tiếp các điểm trên, khả năng trình bày và ăn điểm sẽ chắc hơn nhiều.
