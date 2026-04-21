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
    private Button btnSelectAllAttendance;
    private Button btnSaveAttendance;
    private Button btnClearAttendance;
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
        lblAttendanceClass = new Label();
        cboAttendanceClass = new ComboBox();
        lblAttendanceSession = new Label();
        cboAttendanceSession = new ComboBox();
        lblAttendanceDate = new Label();
        dtpAttendanceDate = new DateTimePicker();
        flpAttendanceActions = new FlowLayoutPanel();
        btnSearchAttendance = new Button();
        btnSelectAllAttendance = new Button();
        btnSaveAttendance = new Button();
        btnClearAttendance = new Button();
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
        tblAttendanceRoot.Size = new Size(956, 596);
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
        pnlAttendanceFilterCard.Size = new Size(950, 90);
        pnlAttendanceFilterCard.TabIndex = 0;
        // 
        // lblAttendanceClass
        // 
        lblAttendanceClass.AutoSize = true;
        lblAttendanceClass.Location = new Point(16, 18);
        lblAttendanceClass.Name = "lblAttendanceClass";
        lblAttendanceClass.Size = new Size(58, 20);
        lblAttendanceClass.TabIndex = 0;
        lblAttendanceClass.Text = "Lớp học";
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
        // lblAttendanceSession
        // 
        lblAttendanceSession.AutoSize = true;
        lblAttendanceSession.Location = new Point(220, 18);
        lblAttendanceSession.Name = "lblAttendanceSession";
        lblAttendanceSession.Size = new Size(54, 20);
        lblAttendanceSession.TabIndex = 2;
        lblAttendanceSession.Text = "Buổi số";
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
        // lblAttendanceDate
        // 
        lblAttendanceDate.AutoSize = true;
        lblAttendanceDate.Location = new Point(404, 18);
        lblAttendanceDate.Name = "lblAttendanceDate";
        lblAttendanceDate.Size = new Size(79, 20);
        lblAttendanceDate.TabIndex = 4;
        lblAttendanceDate.Text = "Ngày điểm";
        // 
        // dtpAttendanceDate
        // 
        dtpAttendanceDate.Format = DateTimePickerFormat.Short;
        dtpAttendanceDate.Location = new Point(404, 41);
        dtpAttendanceDate.Name = "dtpAttendanceDate";
        dtpAttendanceDate.Size = new Size(145, 27);
        dtpAttendanceDate.TabIndex = 5;
        // 
        // flpAttendanceActions
        // 
        flpAttendanceActions.AutoSize = true;
        flpAttendanceActions.Controls.Add(btnSearchAttendance);
        flpAttendanceActions.Controls.Add(btnSelectAllAttendance);
        flpAttendanceActions.Controls.Add(btnSaveAttendance);
        flpAttendanceActions.Controls.Add(btnClearAttendance);
        flpAttendanceActions.Location = new Point(575, 37);
        flpAttendanceActions.Name = "flpAttendanceActions";
        flpAttendanceActions.Size = new Size(370, 38);
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
        // btnSelectAllAttendance
        // 
        btnSelectAllAttendance.Location = new Point(99, 3);
        btnSelectAllAttendance.Name = "btnSelectAllAttendance";
        btnSelectAllAttendance.Size = new Size(120, 32);
        btnSelectAllAttendance.TabIndex = 1;
        btnSelectAllAttendance.Text = "Chọn tất cả";
        btnSelectAllAttendance.UseVisualStyleBackColor = true;
        // 
        // btnSaveAttendance
        // 
        btnSaveAttendance.Location = new Point(225, 3);
        btnSaveAttendance.Name = "btnSaveAttendance";
        btnSaveAttendance.Size = new Size(70, 32);
        btnSaveAttendance.TabIndex = 2;
        btnSaveAttendance.Text = "Lưu";
        btnSaveAttendance.UseVisualStyleBackColor = true;
        // 
        // btnClearAttendance
        // 
        btnClearAttendance.Location = new Point(301, 3);
        btnClearAttendance.Name = "btnClearAttendance";
        btnClearAttendance.Size = new Size(66, 32);
        btnClearAttendance.TabIndex = 3;
        btnClearAttendance.Text = "Xóa";
        btnClearAttendance.UseVisualStyleBackColor = true;
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
        dgvAttendanceList.Size = new Size(950, 494);
        dgvAttendanceList.TabIndex = 1;
        // 
        // errAttendance
        // 
        errAttendance.ContainerControl = this;
        // 
        // FrmAttendance
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(980, 620);
        Controls.Add(tblAttendanceRoot);
        Name = "FrmAttendance";
        Padding = new Padding(12);
        Text = "Điểm danh";
        tblAttendanceRoot.ResumeLayout(false);
        pnlAttendanceFilterCard.ResumeLayout(false);
        pnlAttendanceFilterCard.PerformLayout();
        flpAttendanceActions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvAttendanceList).EndInit();
        ((System.ComponentModel.ISupportInitialize)errAttendance).EndInit();
        ResumeLayout(false);
    }
}
