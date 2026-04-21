namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmTeachingClasses
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlTeachingClassFilterCard;
    private TextBox txtTeachingClassKeyword;
    private ComboBox cboTeachingStatusFilter;
    private Button btnSearchTeachingClass;
    private Button btnRefreshTeachingClass;
    private Button btnOpenClassStudentList;
    private Button btnOpenAttendance;
    private Button btnOpenScoreEntry;
    private DataGridView dgvTeachingClassList;
    private TableLayoutPanel tblTeachingClassRoot;
    private Label lblTeachingClassKeyword;
    private Label lblTeachingClassStatus;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlTeachingClassFilterCard = new Panel();
        btnOpenScoreEntry = new Button();
        btnOpenAttendance = new Button();
        btnOpenClassStudentList = new Button();
        btnRefreshTeachingClass = new Button();
        btnSearchTeachingClass = new Button();
        cboTeachingStatusFilter = new ComboBox();
        lblTeachingClassStatus = new Label();
        txtTeachingClassKeyword = new TextBox();
        lblTeachingClassKeyword = new Label();
        dgvTeachingClassList = new DataGridView();
        tblTeachingClassRoot = new TableLayoutPanel();
        pnlTeachingClassFilterCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTeachingClassList).BeginInit();
        tblTeachingClassRoot.SuspendLayout();
        SuspendLayout();
        // 
        // pnlTeachingClassFilterCard
        // 
        pnlTeachingClassFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlTeachingClassFilterCard.Controls.Add(btnOpenScoreEntry);
        pnlTeachingClassFilterCard.Controls.Add(btnOpenAttendance);
        pnlTeachingClassFilterCard.Controls.Add(btnOpenClassStudentList);
        pnlTeachingClassFilterCard.Controls.Add(btnRefreshTeachingClass);
        pnlTeachingClassFilterCard.Controls.Add(btnSearchTeachingClass);
        pnlTeachingClassFilterCard.Controls.Add(cboTeachingStatusFilter);
        pnlTeachingClassFilterCard.Controls.Add(lblTeachingClassStatus);
        pnlTeachingClassFilterCard.Controls.Add(txtTeachingClassKeyword);
        pnlTeachingClassFilterCard.Controls.Add(lblTeachingClassKeyword);
        pnlTeachingClassFilterCard.Dock = DockStyle.Fill;
        pnlTeachingClassFilterCard.Location = new Point(3, 3);
        pnlTeachingClassFilterCard.Name = "pnlTeachingClassFilterCard";
        pnlTeachingClassFilterCard.Padding = new Padding(16, 14, 16, 14);
        pnlTeachingClassFilterCard.Size = new Size(974, 86);
        pnlTeachingClassFilterCard.TabIndex = 0;
        // 
        // btnOpenScoreEntry
        // 
        btnOpenScoreEntry.Location = new Point(842, 39);
        btnOpenScoreEntry.Name = "btnOpenScoreEntry";
        btnOpenScoreEntry.Size = new Size(110, 30);
        btnOpenScoreEntry.TabIndex = 8;
        btnOpenScoreEntry.Text = "Nhập điểm";
        btnOpenScoreEntry.UseVisualStyleBackColor = true;
        // 
        // btnOpenAttendance
        // 
        btnOpenAttendance.Location = new Point(716, 39);
        btnOpenAttendance.Name = "btnOpenAttendance";
        btnOpenAttendance.Size = new Size(120, 30);
        btnOpenAttendance.TabIndex = 7;
        btnOpenAttendance.Text = "Điểm danh";
        btnOpenAttendance.UseVisualStyleBackColor = true;
        // 
        // btnOpenClassStudentList
        // 
        btnOpenClassStudentList.Location = new Point(570, 39);
        btnOpenClassStudentList.Name = "btnOpenClassStudentList";
        btnOpenClassStudentList.Size = new Size(140, 30);
        btnOpenClassStudentList.TabIndex = 6;
        btnOpenClassStudentList.Text = "DS học viên";
        btnOpenClassStudentList.UseVisualStyleBackColor = true;
        // 
        // btnRefreshTeachingClass
        // 
        btnRefreshTeachingClass.Location = new Point(456, 39);
        btnRefreshTeachingClass.Name = "btnRefreshTeachingClass";
        btnRefreshTeachingClass.Size = new Size(108, 30);
        btnRefreshTeachingClass.TabIndex = 5;
        btnRefreshTeachingClass.Text = "Làm mới";
        btnRefreshTeachingClass.UseVisualStyleBackColor = true;
        // 
        // btnSearchTeachingClass
        // 
        btnSearchTeachingClass.Location = new Point(350, 39);
        btnSearchTeachingClass.Name = "btnSearchTeachingClass";
        btnSearchTeachingClass.Size = new Size(100, 30);
        btnSearchTeachingClass.TabIndex = 4;
        btnSearchTeachingClass.Text = "Tìm kiếm";
        btnSearchTeachingClass.UseVisualStyleBackColor = true;
        // 
        // cboTeachingStatusFilter
        // 
        cboTeachingStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTeachingStatusFilter.FormattingEnabled = true;
        cboTeachingStatusFilter.Items.AddRange(new object[] { "Đang dạy", "Sắp khai giảng", "Đã kết thúc" });
        cboTeachingStatusFilter.Location = new Point(350, 41);
        cboTeachingStatusFilter.Name = "cboTeachingStatusFilter";
        cboTeachingStatusFilter.Size = new Size(180, 28);
        cboTeachingStatusFilter.TabIndex = 3;
        // 
        // lblTeachingClassStatus
        // 
        lblTeachingClassStatus.AutoSize = true;
        lblTeachingClassStatus.Location = new Point(350, 18);
        lblTeachingClassStatus.Name = "lblTeachingClassStatus";
        lblTeachingClassStatus.Size = new Size(78, 20);
        lblTeachingClassStatus.TabIndex = 2;
        lblTeachingClassStatus.Text = "Trạng thái";
        // 
        // txtTeachingClassKeyword
        // 
        txtTeachingClassKeyword.Location = new Point(16, 41);
        txtTeachingClassKeyword.Name = "txtTeachingClassKeyword";
        txtTeachingClassKeyword.PlaceholderText = "Mã lớp hoặc tên lớp";
        txtTeachingClassKeyword.Size = new Size(300, 27);
        txtTeachingClassKeyword.TabIndex = 1;
        // 
        // lblTeachingClassKeyword
        // 
        lblTeachingClassKeyword.AutoSize = true;
        lblTeachingClassKeyword.Location = new Point(16, 18);
        lblTeachingClassKeyword.Name = "lblTeachingClassKeyword";
        lblTeachingClassKeyword.Size = new Size(95, 20);
        lblTeachingClassKeyword.TabIndex = 0;
        lblTeachingClassKeyword.Text = "Từ khóa tìm";
        // 
        // dgvTeachingClassList
        // 
        dgvTeachingClassList.AllowUserToAddRows = false;
        dgvTeachingClassList.AllowUserToDeleteRows = false;
        dgvTeachingClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvTeachingClassList.BackgroundColor = Color.White;
        dgvTeachingClassList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTeachingClassList.Dock = DockStyle.Fill;
        dgvTeachingClassList.Location = new Point(3, 95);
        dgvTeachingClassList.Name = "dgvTeachingClassList";
        dgvTeachingClassList.ReadOnly = true;
        dgvTeachingClassList.RowHeadersVisible = false;
        dgvTeachingClassList.RowHeadersWidth = 51;
        dgvTeachingClassList.Size = new Size(974, 518);
        dgvTeachingClassList.TabIndex = 1;
        // 
        // tblTeachingClassRoot
        // 
        tblTeachingClassRoot.ColumnCount = 1;
        tblTeachingClassRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblTeachingClassRoot.Controls.Add(pnlTeachingClassFilterCard, 0, 0);
        tblTeachingClassRoot.Controls.Add(dgvTeachingClassList, 0, 1);
        tblTeachingClassRoot.Dock = DockStyle.Fill;
        tblTeachingClassRoot.Location = new Point(12, 12);
        tblTeachingClassRoot.Name = "tblTeachingClassRoot";
        tblTeachingClassRoot.RowCount = 2;
        tblTeachingClassRoot.RowStyles.Add(new RowStyle());
        tblTeachingClassRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblTeachingClassRoot.Size = new Size(980, 616);
        tblTeachingClassRoot.TabIndex = 0;
        // 
        // FrmTeachingClasses
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(1004, 640);
        Controls.Add(tblTeachingClassRoot);
        Name = "FrmTeachingClasses";
        Padding = new Padding(12);
        Text = "Lớp đang dạy";
        pnlTeachingClassFilterCard.ResumeLayout(false);
        pnlTeachingClassFilterCard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTeachingClassList).EndInit();
        tblTeachingClassRoot.ResumeLayout(false);
        ResumeLayout(false);
    }
}
