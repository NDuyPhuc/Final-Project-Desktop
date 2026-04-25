namespace Trung_tam_quan_ly_ngoai_ngu;

internal static class AppTheme
{
    private static readonly Dictionary<string, string> GridHeaderText = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Ma hoc vien"] = "Mã học viên",
        ["Ma giao vien"] = "Mã giáo viên",
        ["Ma khoa hoc"] = "Mã khóa học",
        ["Ma lop"] = "Mã lớp",
        ["Ma bien lai"] = "Mã biên lai",
        ["Ho ten"] = "Họ tên",
        ["Ho va ten"] = "Họ và tên",
        ["Ten hoc vien"] = "Tên học viên",
        ["Ten giao vien"] = "Tên giáo viên",
        ["Ten khoa hoc"] = "Tên khóa học",
        ["Ten lop"] = "Tên lớp",
        ["Ngay sinh"] = "Ngày sinh",
        ["Ngay hoc"] = "Ngày học",
        ["Ngay ghi danh"] = "Ngày ghi danh",
        ["Ngay nop"] = "Ngày nộp",
        ["Dien thoai"] = "Điện thoại",
        ["So dien thoai"] = "Số điện thoại",
        ["Dia chi"] = "Địa chỉ",
        ["Gioi tinh"] = "Giới tính",
        ["Trang thai"] = "Trạng thái",
        ["Khoa hoc"] = "Khóa học",
        ["Hoc phi"] = "Học phí",
        ["Con no"] = "Còn nợ",
        ["Cong no"] = "Công nợ",
        ["So tien"] = "Số tiền",
        ["So tien thu"] = "Số tiền thu",
        ["Phuong thuc"] = "Phương thức",
        ["Phuong thuc thanh toan"] = "Phương thức thanh toán",
        ["Ghi chu"] = "Ghi chú",
        ["Chuyen mon"] = "Chuyên môn",
        ["Lich hoc"] = "Lịch học",
        ["Phong hoc"] = "Phòng học",
        ["Si so"] = "Sĩ số",
        ["Diem danh"] = "Điểm danh",
        ["Diem"] = "Điểm",
        ["Diem nghe"] = "Điểm nghe",
        ["Diem noi"] = "Điểm nói",
        ["Diem doc"] = "Điểm đọc",
        ["Diem viet"] = "Điểm viết",
        ["Diem tong"] = "Điểm tổng",
        ["Nhan vien"] = "Nhân viên",
        ["Giao vien"] = "Giáo viên",
        ["Hoc vien"] = "Học viên"
    };

    private static readonly Dictionary<string, string> GridCellText = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Tat ca"] = "Tất cả",
        ["Con mo"] = "Còn mở",
        ["Tam dung"] = "Tạm dừng",
        ["Dang hoc"] = "Đang học",
        ["Bao luu"] = "Bảo lưu",
        ["Hoan thanh"] = "Hoàn thành",
        ["Da nghi"] = "Đã nghỉ",
        ["Dang day"] = "Đang dạy",
        ["Tam nghi"] = "Tạm nghỉ",
        ["Dang mo"] = "Đang mở",
        ["Da dong"] = "Đã đóng",
        ["Da huy"] = "Đã hủy",
        ["Day"] = "Đầy",
        ["Da hoc"] = "Đã học",
        ["Hom nay"] = "Hôm nay",
        ["Sap dien ra"] = "Sắp diễn ra",
        ["Qua han"] = "Quá hạn",
        ["Sap den han"] = "Sắp đến hạn",
        ["Da hoan thanh"] = "Đã hoàn thành",
        ["Tien mat"] = "Tiền mặt",
        ["Chuyen khoan"] = "Chuyển khoản"
    };

    public static readonly Color Sidebar = Color.FromArgb(230, 246, 255);
    public static readonly Color SidebarHover = Color.FromArgb(224, 241, 250);
    public static readonly Color Accent = Color.FromArgb(0, 110, 110);
    public static readonly Color SidebarBrand = Color.FromArgb(0, 66, 118);
    public static readonly Color SidebarActive = Color.FromArgb(144, 239, 239);
    public static readonly Color SidebarText = Color.FromArgb(66, 71, 80);
    public static readonly Color SidebarTitle = Color.FromArgb(7, 30, 39);
    public static readonly Color Success = Color.FromArgb(41, 166, 124);
    public static readonly Color Warning = Color.FromArgb(235, 179, 61);
    public static readonly Color Danger = Color.FromArgb(224, 91, 97);
    public static readonly Color Background = Color.FromArgb(245, 247, 251);
    public static readonly Color Surface = Color.White;
    public static readonly Color Border = Color.FromArgb(225, 230, 239);
    public static readonly Color TextPrimary = Color.FromArgb(42, 51, 64);
    public static readonly Color TextMuted = Color.FromArgb(102, 112, 133);

    public static readonly Font FontBody = new("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
    public static readonly Font FontBodyBold = new("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontTitle = new("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontSection = new("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontKpi = new("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontSidebarTitle = new("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontSidebarMeta = new("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
    public static readonly Font FontSidebarItem = new("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
    public static readonly Font FontSidebarItemBold = new("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);

    public static void ApplyFormStyle(Form form, string title)
    {
        form.Text = title;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.BackColor = Background;
        form.Font = FontBody;
        form.AutoScaleMode = AutoScaleMode.Dpi;
        form.MinimumSize = new Size(1024, 700);
    }

    public static void StylePrimaryButton(Button button)
    {
        button.BackColor = Accent;
        button.ForeColor = Color.White;
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;
        button.Cursor = Cursors.Hand;
        button.Font = FontBodyBold;
        button.Height = 36;
    }

    public static void StyleSecondaryButton(Button button)
    {
        button.BackColor = Color.White;
        button.ForeColor = Accent;
        button.FlatAppearance.BorderColor = Accent;
        button.FlatAppearance.BorderSize = 1;
        button.FlatStyle = FlatStyle.Flat;
        button.Cursor = Cursors.Hand;
        button.Font = FontBodyBold;
        button.Height = 36;
    }

    public static void StyleDangerButton(Button button)
    {
        button.BackColor = Danger;
        button.ForeColor = Color.White;
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;
        button.Cursor = Cursors.Hand;
        button.Font = FontBodyBold;
        button.Height = 36;
    }

    public static void StyleGroupBox(GroupBox groupBox)
    {
        groupBox.BackColor = Surface;
        groupBox.ForeColor = TextPrimary;
        groupBox.Font = FontSection;
        groupBox.Padding = new Padding(14, 12, 14, 14);
    }

    public static void StyleCard(Panel panel)
    {
        panel.BackColor = Surface;
        panel.BorderStyle = BorderStyle.FixedSingle;
        panel.Padding = new Padding(14);
        panel.Margin = new Padding(0, 0, 12, 12);
    }

    public static void StyleGrid(DataGridView grid)
    {
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 251);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
        grid.ColumnHeadersDefaultCellStyle.Font = FontBodyBold;
        grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        grid.ColumnHeadersHeight = 40;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        grid.RowTemplate.Height = 34;
        grid.RowHeadersVisible = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.GridColor = Border;
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(228, 237, 255);
        grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
        grid.DataBindingComplete -= LocalizeGridHeadersOnDataBindingComplete;
        grid.DataBindingComplete += LocalizeGridHeadersOnDataBindingComplete;
        grid.CellFormatting -= LocalizeGridCellFormatting;
        grid.CellFormatting += LocalizeGridCellFormatting;
        ApplyGridHeaderText(grid);
    }

    public static void RoundPanelCorners(Panel panel, int radius = 10)
    {
    }

    private static void LocalizeGridHeadersOnDataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (sender is DataGridView grid)
        {
            ApplyGridHeaderText(grid);
        }
    }

    private static void ApplyGridHeaderText(DataGridView grid)
    {
        foreach (DataGridViewColumn column in grid.Columns)
        {
            var key = string.IsNullOrWhiteSpace(column.HeaderText)
                ? column.DataPropertyName
                : column.HeaderText;

            if (GridHeaderText.TryGetValue(key, out var headerText))
            {
                column.HeaderText = headerText;
            }

            column.MinimumWidth = Math.Max(column.MinimumWidth, Math.Min(180, 36 + column.HeaderText.Length * 7));
        }
    }

    private static void LocalizeGridCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value is string text && GridCellText.TryGetValue(text, out var displayText))
        {
            e.Value = displayText;
            e.FormattingApplied = true;
        }
    }
}
