namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmAttendance
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblAttendanceRoot;
    private Panel pnlAttendanceFilterCard;
    private Label lblAttendanceClass;
    private ComboBox cboAttendanceClass;
    private Label lblAttendanceSession;
    private ComboBox cboAttendanceSession;
    private Label lblAttendanceDate;
    private DateTimePicker dtpAttendanceDate;
    private FlowLayoutPanel flpAttendanceActions;
    private Button btnSearchAttendance;
    private Button btnCheckAllPresent;
    private Button btnCheckAllAbsent;
    private Button btnSaveAttendance;
    private DataGridView dgvAttendanceList;
    private ToolTip ttAttendance;
    private ErrorProvider errAttendance;

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
        components = new System.ComponentModel.Container();
        tblAttendanceRoot = new TableLayoutPanel();
        pnlAttendanceFilterCard = new Panel();
        flpAttendanceActions = new FlowLayoutPanel();
        btnSearchAttendance = new Button();
        btnCheckAllPresent = new Button();
        btnCheckAllAbsent = new Button();
        btnSaveAttendance = new Button();
        dtpAttendanceDate = new DateTimePicker();
        lblAttendanceDate = new Label();
        cboAttendanceSession = new ComboBox();
        lblAttendanceSession = new Label();
        cboAttendanceClass = new ComboBox();
        lblAttendanceClass = new Label();
        dgvAttendanceList = new DataGridView();
        ttAttendance = new ToolTip(components);
        errAttendance = new ErrorProvider(components);
        tblAttendanceRoot.SuspendLayout();
        pnlAttendanceFilterCard.SuspendLayout();
        flpAttendanceActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAttendanceList).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errAttendance).BeginInit();
        SuspendLayout();
        // 
        // tblAttendanceRoot
        // 
        tblAttendanceRoot.ColumnCount = 1;
        tblAttendanceRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAttendanceRoot.Controls.Add(pnlAttendanceFilterCard, 0, 0);
        tblAttendanceRoot.Controls.Add(dgvAttendanceList, 0, 1);
        tblAttendanceRoot.Dock = DockStyle.Fill;
        tblAttendanceRoot.Location = new Point(12, 12);
        tblAttendanceRoot.Name = "tblAttendanceRoot";
        tblAttendanceRoot.RowCount = 2;
        tblAttendanceRoot.RowStyles.Add(new RowStyle());
        tblAttendanceRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAttendanceRoot.Size = new Size(976, 616);
        tblAttendanceRoot.AutoScroll = false;
        tblAttendanceRoot.TabIndex = 0;
        // 
        // pnlAttendanceFilterCard
        // 
        pnlAttendanceFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlAttendanceFilterCard.Controls.Add(flpAttendanceActions);
        pnlAttendanceFilterCard.Controls.Add(dtpAttendanceDate);
        pnlAttendanceFilterCard.Controls.Add(lblAttendanceDate);
        pnlAttendanceFilterCard.Controls.Add(cboAttendanceSession);
        pnlAttendanceFilterCard.Controls.Add(lblAttendanceSession);
        pnlAttendanceFilterCard.Controls.Add(cboAttendanceClass);
        pnlAttendanceFilterCard.Controls.Add(lblAttendanceClass);
        pnlAttendanceFilterCard.Dock = DockStyle.Fill;
        pnlAttendanceFilterCard.Location = new Point(3, 3);
        pnlAttendanceFilterCard.Name = "pnlAttendanceFilterCard";
        pnlAttendanceFilterCard.Padding = new Padding(16, 14, 16, 14);
        pnlAttendanceFilterCard.Size = new Size(970, 90);
        pnlAttendanceFilterCard.AutoScroll = false;
        pnlAttendanceFilterCard.TabIndex = 0;
        // 
        // flpAttendanceActions
        // 
        flpAttendanceActions.AutoSize = true;
        flpAttendanceActions.Controls.Add(btnSearchAttendance);
        flpAttendanceActions.Controls.Add(btnCheckAllPresent);
        flpAttendanceActions.Controls.Add(btnCheckAllAbsent);
        flpAttendanceActions.Controls.Add(btnSaveAttendance);
        flpAttendanceActions.Location = new Point(574, 37);
        flpAttendanceActions.Name = "flpAttendanceActions";
        flpAttendanceActions.Size = new Size(381, 38);
        flpAttendanceActions.AutoScroll = false;
        flpAttendanceActions.WrapContents = true;
        flpAttendanceActions.TabIndex = 6;
        flpAttendanceActions.WrapContents = false;
        // 
        // btnSearchAttendance
        // 
        btnSearchAttendance.Location = new Point(3, 3);
        btnSearchAttendance.Name = "btnSearchAttendance";
        btnSearchAttendance.Size = new Size(90, 32);
        btnSearchAttendance.TabIndex = 0;
        btnSearchAttendance.Text = "Xem DS";
        btnSearchAttendance.UseVisualStyleBackColor = true;
        // 
        // btnCheckAllPresent
        // 
        btnCheckAllPresent.Location = new Point(99, 3);
        btnCheckAllPresent.Name = "btnCheckAllPresent";
        btnCheckAllPresent.Size = new Size(120, 32);
        btnCheckAllPresent.TabIndex = 1;
        btnCheckAllPresent.Text = "Tất cả có mặt";
        btnCheckAllPresent.UseVisualStyleBackColor = true;
        // 
        // btnCheckAllAbsent
        // 
        btnCheckAllAbsent.Location = new Point(225, 3);
        btnCheckAllAbsent.Name = "btnCheckAllAbsent";
        btnCheckAllAbsent.Size = new Size(120, 32);
        btnCheckAllAbsent.TabIndex = 2;
        btnCheckAllAbsent.Text = "Tất cả vắng";
        btnCheckAllAbsent.UseVisualStyleBackColor = true;
        // 
        // btnSaveAttendance
        // 
        btnSaveAttendance.Location = new Point(351, 3);
        btnSaveAttendance.Name = "btnSaveAttendance";
        btnSaveAttendance.Size = new Size(70, 32);
        btnSaveAttendance.TabIndex = 3;
        btnSaveAttendance.Text = "Lưu";
        btnSaveAttendance.UseVisualStyleBackColor = true;
        // 
        // dtpAttendanceDate
        // 
        dtpAttendanceDate.Format = DateTimePickerFormat.Short;
        dtpAttendanceDate.Location = new Point(404, 41);
        dtpAttendanceDate.Name = "dtpAttendanceDate";
        dtpAttendanceDate.Size = new Size(145, 27);
        dtpAttendanceDate.TabIndex = 5;
        // 
        // lblAttendanceDate
        // 
        lblAttendanceDate.AutoSize = true;
        lblAttendanceDate.Location = new Point(404, 18);
        lblAttendanceDate.Name = "lblAttendanceDate";
        lblAttendanceDate.Size = new Size(76, 28);
        lblAttendanceDate.AutoSize = true;
        lblAttendanceDate.TabIndex = 4;
        lblAttendanceDate.Text = "Ngày học";
        // 
        // cboAttendanceSession
        // 
        cboAttendanceSession.DropDownStyle = ComboBoxStyle.DropDownList;
        cboAttendanceSession.FormattingEnabled = true;
        cboAttendanceSession.Items.AddRange(new object[] { "Buổi 01", "Buổi 02", "Buổi 03" });
        cboAttendanceSession.Location = new Point(220, 41);
        cboAttendanceSession.Name = "cboAttendanceSession";
        cboAttendanceSession.Size = new Size(160, 28);
        cboAttendanceSession.TabIndex = 3;
        // 
        // lblAttendanceSession
        // 
        lblAttendanceSession.AutoSize = true;
        lblAttendanceSession.Location = new Point(220, 18);
        lblAttendanceSession.Name = "lblAttendanceSession";
        lblAttendanceSession.Size = new Size(55, 28);
        lblAttendanceSession.AutoSize = true;
        lblAttendanceSession.TabIndex = 2;
        lblAttendanceSession.Text = "Buổi học";
        // 
        // cboAttendanceClass
        // 
        cboAttendanceClass.DropDownStyle = ComboBoxStyle.DropDownList;
        cboAttendanceClass.FormattingEnabled = true;
        cboAttendanceClass.Items.AddRange(new object[] { "ENG-A1-01", "ENG-IELTS-02" });
        cboAttendanceClass.Location = new Point(16, 41);
        cboAttendanceClass.Name = "cboAttendanceClass";
        cboAttendanceClass.Size = new Size(180, 28);
        cboAttendanceClass.TabIndex = 1;
        // 
        // lblAttendanceClass
        // 
        lblAttendanceClass.AutoSize = true;
        lblAttendanceClass.Location = new Point(16, 18);
        lblAttendanceClass.Name = "lblAttendanceClass";
        lblAttendanceClass.Size = new Size(58, 28);
        lblAttendanceClass.AutoSize = true;
        lblAttendanceClass.TabIndex = 0;
        lblAttendanceClass.Text = "Lớp học";
        // 
        // dgvAttendanceList
        // 
        dgvAttendanceList.AllowUserToAddRows = false;
        dgvAttendanceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAttendanceList.BackgroundColor = Color.White;
        dgvAttendanceList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAttendanceList.Dock = DockStyle.Fill;
        dgvAttendanceList.Location = new Point(3, 99);
        dgvAttendanceList.Name = "dgvAttendanceList";
        dgvAttendanceList.RowHeadersVisible = false;
        dgvAttendanceList.RowHeadersWidth = 51;
        dgvAttendanceList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAttendanceList.Size = new Size(970, 514);
        dgvAttendanceList.TabIndex = 1;
        // 
        // errAttendance
        // 
        errAttendance.ContainerControl = this;
        // 
        // FrmAttendance
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1000, 640);
        Font = new Font("Segoe UI", 10F);
        Controls.Add(tblAttendanceRoot);
        MinimumSize = new Size(900, 600);
        Name = "FrmAttendance";
        Padding = new Padding(12);
        Text = "Điểm danh";
        tblAttendanceRoot.ResumeLayout(false);
        pnlAttendanceFilterCard.ResumeLayout(false);
        pnlAttendanceFilterCard.PerformLayout();
        flpAttendanceActions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvAttendanceList).EndInit();
        ((System.ComponentModel.ISupportInitialize)errAttendance).EndInit();
        AutoScroll = false;
        ResumeLayout(false);
    }
}

