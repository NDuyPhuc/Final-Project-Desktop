namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmClassStudentList
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlClassStudentFilterCard;
    private ComboBox cboClassStudentClass;
    private TextBox txtClassStudentKeyword;
    private Button btnSearchClassStudent;
    private Button btnRefreshClassStudent;
    private Button btnOpenAttendanceFromStudentList;
    private Button btnBackToTeachingClasses;
    private Panel pnlClassStudentCount;
    private Panel pnlClassStudentSchedule;
    private Label lblClassStudentCountValue;
    private Label lblClassStudentScheduleValue;
    private DataGridView dgvClassStudentList;
    private TableLayoutPanel tblClassStudentRoot;
    private Label lblClassStudentClass;
    private Label lblClassStudentContext;
    private ComboBox cboClassStudentContext;
    private SplitContainer splClassStudentContent;
    private Panel pnlClassStudentSummary;
    private Button btnOpenScoreFromStudentList;

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
        pnlClassStudentFilterCard = new Panel();
        btnBackToTeachingClasses = new Button();
        btnOpenScoreFromStudentList = new Button();
        btnOpenAttendanceFromStudentList = new Button();
        btnRefreshClassStudent = new Button();
        btnSearchClassStudent = new Button();
        txtClassStudentKeyword = new TextBox();
        cboClassStudentContext = new ComboBox();
        lblClassStudentContext = new Label();
        cboClassStudentClass = new ComboBox();
        lblClassStudentClass = new Label();
        pnlClassStudentCount = new Panel();
        lblClassStudentCountValue = new Label();
        pnlClassStudentSchedule = new Panel();
        lblClassStudentScheduleValue = new Label();
        dgvClassStudentList = new DataGridView();
        tblClassStudentRoot = new TableLayoutPanel();
        splClassStudentContent = new SplitContainer();
        pnlClassStudentSummary = new Panel();
        pnlClassStudentFilterCard.SuspendLayout();
        pnlClassStudentCount.SuspendLayout();
        pnlClassStudentSchedule.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClassStudentList).BeginInit();
        tblClassStudentRoot.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splClassStudentContent).BeginInit();
        splClassStudentContent.Panel1.SuspendLayout();
        splClassStudentContent.Panel2.SuspendLayout();
        splClassStudentContent.SuspendLayout();
        pnlClassStudentSummary.SuspendLayout();
        SuspendLayout();
        // 
        // pnlClassStudentFilterCard
        // 
        pnlClassStudentFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlClassStudentFilterCard.Controls.Add(btnBackToTeachingClasses);
        pnlClassStudentFilterCard.Controls.Add(btnOpenScoreFromStudentList);
        pnlClassStudentFilterCard.Controls.Add(btnOpenAttendanceFromStudentList);
        pnlClassStudentFilterCard.Controls.Add(btnRefreshClassStudent);
        pnlClassStudentFilterCard.Controls.Add(btnSearchClassStudent);
        pnlClassStudentFilterCard.Controls.Add(txtClassStudentKeyword);
        pnlClassStudentFilterCard.Controls.Add(cboClassStudentContext);
        pnlClassStudentFilterCard.Controls.Add(lblClassStudentContext);
        pnlClassStudentFilterCard.Controls.Add(cboClassStudentClass);
        pnlClassStudentFilterCard.Controls.Add(lblClassStudentClass);
        pnlClassStudentFilterCard.Dock = DockStyle.Fill;
        pnlClassStudentFilterCard.Location = new Point(3, 3);
        pnlClassStudentFilterCard.Name = "pnlClassStudentFilterCard";
        pnlClassStudentFilterCard.Padding = new Padding(16, 14, 16, 14);
        pnlClassStudentFilterCard.Size = new Size(1173, 86);
        pnlClassStudentFilterCard.TabIndex = 0;
        // 
        // btnBackToTeachingClasses
        // 
        btnBackToTeachingClasses.Location = new Point(268, 74);
        btnBackToTeachingClasses.Name = "btnBackToTeachingClasses";
        btnBackToTeachingClasses.Size = new Size(120, 30);
        btnBackToTeachingClasses.TabIndex = 9;
        btnBackToTeachingClasses.Text = "Quay lại lớp";
        btnBackToTeachingClasses.UseVisualStyleBackColor = true;
        // 
        // btnOpenScoreFromStudentList
        // 
        btnOpenScoreFromStudentList.Location = new Point(142, 74);
        btnOpenScoreFromStudentList.Name = "btnOpenScoreFromStudentList";
        btnOpenScoreFromStudentList.Size = new Size(120, 30);
        btnOpenScoreFromStudentList.TabIndex = 8;
        btnOpenScoreFromStudentList.Text = "Nhập điểm";
        btnOpenScoreFromStudentList.UseVisualStyleBackColor = true;
        // 
        // btnOpenAttendanceFromStudentList
        // 
        btnOpenAttendanceFromStudentList.Location = new Point(16, 74);
        btnOpenAttendanceFromStudentList.Name = "btnOpenAttendanceFromStudentList";
        btnOpenAttendanceFromStudentList.Size = new Size(120, 30);
        btnOpenAttendanceFromStudentList.TabIndex = 7;
        btnOpenAttendanceFromStudentList.Text = "Điểm danh";
        btnOpenAttendanceFromStudentList.UseVisualStyleBackColor = true;
        // 
        // btnRefreshClassStudent
        // 
        btnRefreshClassStudent.Location = new Point(756, 39);
        btnRefreshClassStudent.Name = "btnRefreshClassStudent";
        btnRefreshClassStudent.Size = new Size(90, 30);
        btnRefreshClassStudent.TabIndex = 6;
        btnRefreshClassStudent.Text = "Làm mới";
        btnRefreshClassStudent.UseVisualStyleBackColor = true;
        // 
        // btnSearchClassStudent
        // 
        btnSearchClassStudent.Location = new Point(660, 39);
        btnSearchClassStudent.Name = "btnSearchClassStudent";
        btnSearchClassStudent.Size = new Size(90, 30);
        btnSearchClassStudent.TabIndex = 5;
        btnSearchClassStudent.Text = "Tìm kiếm";
        btnSearchClassStudent.UseVisualStyleBackColor = true;
        // 
        // txtClassStudentKeyword
        // 
        txtClassStudentKeyword.Location = new Point(426, 41);
        txtClassStudentKeyword.Name = "txtClassStudentKeyword";
        txtClassStudentKeyword.PlaceholderText = "Tìm theo mã hoặc tên học viên";
        txtClassStudentKeyword.Size = new Size(220, 25);
        txtClassStudentKeyword.TabIndex = 4;
        // 
        // cboClassStudentContext
        // 
        cboClassStudentContext.DropDownStyle = ComboBoxStyle.DropDownList;
        cboClassStudentContext.FormattingEnabled = true;
        cboClassStudentContext.Items.AddRange(new object[] { "Buổi gần nhất", "Buổi hôm nay", "Danh sách tổng quát" });
        cboClassStudentContext.Location = new Point(216, 41);
        cboClassStudentContext.Name = "cboClassStudentContext";
        cboClassStudentContext.Size = new Size(190, 25);
        cboClassStudentContext.TabIndex = 3;
        // 
        // lblClassStudentContext
        // 
        lblClassStudentContext.AutoSize = true;
        lblClassStudentContext.Location = new Point(216, 18);
        lblClassStudentContext.Name = "lblClassStudentContext";
        lblClassStudentContext.Size = new Size(106, 19);
        lblClassStudentContext.TabIndex = 2;
        lblClassStudentContext.Text = "Buổi / ngữ cảnh";
        // 
        // cboClassStudentClass
        // 
        cboClassStudentClass.DropDownStyle = ComboBoxStyle.DropDownList;
        cboClassStudentClass.FormattingEnabled = true;
        cboClassStudentClass.Items.AddRange(new object[] { "ENG-A1-01", "ENG-IELTS-02" });
        cboClassStudentClass.Location = new Point(16, 41);
        cboClassStudentClass.Name = "cboClassStudentClass";
        cboClassStudentClass.Size = new Size(180, 25);
        cboClassStudentClass.TabIndex = 1;
        // 
        // lblClassStudentClass
        // 
        lblClassStudentClass.AutoSize = true;
        lblClassStudentClass.Location = new Point(16, 18);
        lblClassStudentClass.Name = "lblClassStudentClass";
        lblClassStudentClass.Size = new Size(58, 19);
        lblClassStudentClass.TabIndex = 0;
        lblClassStudentClass.Text = "Lớp học";
        // 
        // pnlClassStudentCount
        // 
        pnlClassStudentCount.BackColor = Color.White;
        pnlClassStudentCount.Controls.Add(lblClassStudentCountValue);
        pnlClassStudentCount.Dock = DockStyle.Left;
        pnlClassStudentCount.Location = new Point(0, 0);
        pnlClassStudentCount.Name = "pnlClassStudentCount";
        pnlClassStudentCount.Size = new Size(220, 63);
        pnlClassStudentCount.TabIndex = 0;
        // 
        // lblClassStudentCountValue
        // 
        lblClassStudentCountValue.Dock = DockStyle.Fill;
        lblClassStudentCountValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblClassStudentCountValue.Location = new Point(0, 0);
        lblClassStudentCountValue.Name = "lblClassStudentCountValue";
        lblClassStudentCountValue.Size = new Size(220, 63);
        lblClassStudentCountValue.TabIndex = 0;
        lblClassStudentCountValue.Text = "18";
        lblClassStudentCountValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlClassStudentSchedule
        // 
        pnlClassStudentSchedule.BackColor = Color.White;
        pnlClassStudentSchedule.Controls.Add(lblClassStudentScheduleValue);
        pnlClassStudentSchedule.Dock = DockStyle.Left;
        pnlClassStudentSchedule.Location = new Point(220, 0);
        pnlClassStudentSchedule.Name = "pnlClassStudentSchedule";
        pnlClassStudentSchedule.Size = new Size(220, 63);
        pnlClassStudentSchedule.TabIndex = 1;
        // 
        // lblClassStudentScheduleValue
        // 
        lblClassStudentScheduleValue.Dock = DockStyle.Fill;
        lblClassStudentScheduleValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblClassStudentScheduleValue.Location = new Point(0, 0);
        lblClassStudentScheduleValue.Name = "lblClassStudentScheduleValue";
        lblClassStudentScheduleValue.Size = new Size(220, 63);
        lblClassStudentScheduleValue.TabIndex = 0;
        lblClassStudentScheduleValue.Text = "2-4-6";
        lblClassStudentScheduleValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // dgvClassStudentList
        // 
        dgvClassStudentList.AllowUserToAddRows = false;
        dgvClassStudentList.AllowUserToDeleteRows = false;
        dgvClassStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassStudentList.BackgroundColor = Color.White;
        dgvClassStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvClassStudentList.Dock = DockStyle.Fill;
        dgvClassStudentList.Location = new Point(0, 0);
        dgvClassStudentList.Name = "dgvClassStudentList";
        dgvClassStudentList.ReadOnly = true;
        dgvClassStudentList.RowHeadersVisible = false;
        dgvClassStudentList.RowHeadersWidth = 51;
        dgvClassStudentList.Size = new Size(1173, 445);
        dgvClassStudentList.TabIndex = 0;
        // 
        // tblClassStudentRoot
        // 
        tblClassStudentRoot.ColumnCount = 1;
        tblClassStudentRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblClassStudentRoot.Controls.Add(pnlClassStudentFilterCard, 0, 0);
        tblClassStudentRoot.Controls.Add(splClassStudentContent, 0, 1);
        tblClassStudentRoot.Dock = DockStyle.Fill;
        tblClassStudentRoot.Location = new Point(12, 12);
        tblClassStudentRoot.Name = "tblClassStudentRoot";
        tblClassStudentRoot.RowCount = 2;
        tblClassStudentRoot.RowStyles.Add(new RowStyle());
        tblClassStudentRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblClassStudentRoot.Size = new Size(1179, 622);
        tblClassStudentRoot.TabIndex = 0;
        // 
        // splClassStudentContent
        // 
        splClassStudentContent.Dock = DockStyle.Fill;
        splClassStudentContent.Location = new Point(3, 95);
        splClassStudentContent.Name = "splClassStudentContent";
        splClassStudentContent.Orientation = Orientation.Horizontal;
        // 
        // splClassStudentContent.Panel1
        // 
        splClassStudentContent.Panel1.Controls.Add(pnlClassStudentSummary);
        // 
        // splClassStudentContent.Panel2
        // 
        splClassStudentContent.Panel2.Controls.Add(dgvClassStudentList);
        splClassStudentContent.Size = new Size(1173, 524);
        splClassStudentContent.SplitterDistance = 75;
        splClassStudentContent.TabIndex = 1;
        // 
        // pnlClassStudentSummary
        // 
        pnlClassStudentSummary.Controls.Add(pnlClassStudentSchedule);
        pnlClassStudentSummary.Controls.Add(pnlClassStudentCount);
        pnlClassStudentSummary.Dock = DockStyle.Fill;
        pnlClassStudentSummary.Location = new Point(0, 0);
        pnlClassStudentSummary.Name = "pnlClassStudentSummary";
        pnlClassStudentSummary.Padding = new Padding(0, 0, 0, 12);
        pnlClassStudentSummary.Size = new Size(1173, 75);
        pnlClassStudentSummary.TabIndex = 0;
        // 
        // FrmClassStudentList
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScroll = true;
        ClientSize = new Size(1203, 646);
        Controls.Add(tblClassStudentRoot);
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(900, 600);
        Name = "FrmClassStudentList";
        Padding = new Padding(12);
        Text = "Danh sách học viên lớp";
        pnlClassStudentFilterCard.ResumeLayout(false);
        pnlClassStudentFilterCard.PerformLayout();
        pnlClassStudentCount.ResumeLayout(false);
        pnlClassStudentSchedule.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvClassStudentList).EndInit();
        tblClassStudentRoot.ResumeLayout(false);
        splClassStudentContent.Panel1.ResumeLayout(false);
        splClassStudentContent.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splClassStudentContent).EndInit();
        splClassStudentContent.ResumeLayout(false);
        pnlClassStudentSummary.ResumeLayout(false);
        ResumeLayout(false);
    }
}

