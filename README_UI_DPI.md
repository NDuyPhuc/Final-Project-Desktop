# Quy chuẩn UI / DPI cho WinForms

## Khi sửa bằng Visual Studio Designer

- Luôn chỉnh UI WinForms ở Windows Display Scale `100%` (`96 DPI`).
- Sau khi đổi Display Scale về `100%`, phải restart Visual Studio rồi mới mở `.Designer.cs`.
- Không để nhiều người cùng sửa một Form/UserControl trong cùng thời điểm.
- Thay đổi UI/layout phải commit riêng với thay đổi nghiệp vụ/database.
- Không sửa `Dispose()`, `components`, resource loading, namespace, tên class, tên field control, hoặc signature event handler trong Designer.

## Font và tiếng Việt

- Font chuẩn: `Segoe UI` ở Form/container cha; chỉ override từng control khi thật cần.
- Label tiếng Việt ngắn nên dùng `AutoSize = true`; nếu cần căn hàng/cột thì tăng vùng chứa thay vì cắt chữ.
- Button phải đủ rộng/cao để hiển thị dấu tiếng Việt ở `100%`, `125%`, `150%`.
- GroupBox/Panel có tiêu đề tiếng Việt cần đủ `Padding`/`Margin`.
- DataGridView phải bật header cao đủ, wrap được, và cột quan trọng không bị bóp quá nhỏ.
- Không rút gọn/bỏ dấu tiếng Việt chỉ để che lỗi layout.

## Layout an toàn

- Ưu tiên `TableLayoutPanel`, `FlowLayoutPanel`, `SplitContainer`, `Dock`, `Anchor`, `AutoScroll`.
- Root container nên `Dock.Fill`; header/filter/action/status tách vùng rõ ràng.
- Content chính như `DataGridView`, `ListView`, panel dữ liệu nên nằm trong vùng `Fill`.
- Không để nhiều control `Dock.Fill` cùng parent nếu chưa kiểm soát thứ tự `Controls.Add`.
- Hạn chế hard-code `Location`/`Size` ở vùng layout chính; nếu phải dùng thì set `MinimumSize` và kiểm tra resize.
- Form/module có nội dung dài cần `AutoScroll`.

## DPI policy

- DPI mode hiện tại: `SystemAware`.
- Source of truth: `Trung-tam-quan-ly-ngoai-ngu/Trung-tam-quan-ly-ngoai-ngu.csproj` với `<ApplicationHighDpiMode>SystemAware</ApplicationHighDpiMode>`.
- Chưa bật `PerMonitorV2` khi chưa test đủ layout chính ở nhiều DPI/multi-monitor.
- Nếu thử `PerMonitorV2` và gặp lệch layout, rollback bằng cách xóa mọi cấu hình `PerMonitorV2` trong `Program.cs`, manifest, app.config, csproj; giữ lại một cấu hình duy nhất là `SystemAware`, rebuild và test lại.

## Checklist trước khi merge UI

1. Mở từng Form/UserControl đã sửa trong Visual Studio Designer ở scale `100%`.
2. Build toàn solution.
3. Chạy app ở `100%`.
4. Chạy app ở `125%`.
5. Chạy app ở `150%`.
6. Resize từng form/module chính.
7. Kiểm tra toàn bộ text tiếng Việt, đặc biệt Label/Button/GroupBox/Panel title.
8. Kiểm tra DataGridView header và các cột quan trọng.
9. Kiểm tra không có panel/control chồng nhau.
10. Kiểm tra main form, form nhập liệu, dialog xác nhận/trạng thái.
11. Nếu bật `PerMonitorV2`, kéo app qua màn hình khác DPI và test lại các bước trên.
