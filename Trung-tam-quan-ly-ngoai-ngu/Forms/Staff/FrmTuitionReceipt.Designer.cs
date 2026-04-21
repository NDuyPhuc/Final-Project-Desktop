using System.Drawing.Printing;

namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmTuitionReceipt
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblReceiptRoot;
    private TableLayoutPanel tblReceiptTop;
    private GroupBox grpEnrollmentInfo;
    private TableLayoutPanel tblEnrollmentInfo;
    private Label lblReceiptStudentCode;
    private TextBox txtReceiptStudentCode;
    private Label lblReceiptStudentName;
    private TextBox txtReceiptStudentName;
    private Label lblReceiptClassCode;
    private TextBox txtReceiptClassCode;
    private Label lblReceiptCourseName;
    private TextBox txtReceiptCourseName;
    private GroupBox grpPaymentInfo;
    private TableLayoutPanel tblPaymentInfo;
    private Label lblReceiptAmount;
    private TextBox txtReceiptAmount;
    private Label lblReceiptMethod;
    private ComboBox cboReceiptMethod;
    private Label lblReceiptNote;
    private TextBox txtReceiptNote;
    private FlowLayoutPanel flpReceiptActions;
    private Button btnCollectTuition;
    private Button btnSavePrintReceipt;
    private Button btnViewReceipt;
    private Button btnCancelReceipt;
    private DataGridView dgvReceiptHistory;
    private PrintPreviewDialog ppdTuitionReceiptPreview;
    private PrintDocument prdTuitionReceipt;
    private ToolTip ttTuitionReceipt;
    private ErrorProvider errTuitionReceipt;

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
        tblReceiptRoot = new TableLayoutPanel();
        tblReceiptTop = new TableLayoutPanel();
        grpEnrollmentInfo = new GroupBox();
        tblEnrollmentInfo = new TableLayoutPanel();
        lblReceiptStudentCode = new Label();
        txtReceiptStudentCode = new TextBox();
        lblReceiptStudentName = new Label();
        txtReceiptStudentName = new TextBox();
        lblReceiptClassCode = new Label();
        txtReceiptClassCode = new TextBox();
        lblReceiptCourseName = new Label();
        txtReceiptCourseName = new TextBox();
        grpPaymentInfo = new GroupBox();
        tblPaymentInfo = new TableLayoutPanel();
        lblReceiptAmount = new Label();
        txtReceiptAmount = new TextBox();
        lblReceiptMethod = new Label();
        cboReceiptMethod = new ComboBox();
        lblReceiptNote = new Label();
        txtReceiptNote = new TextBox();
        flpReceiptActions = new FlowLayoutPanel();
        btnCollectTuition = new Button();
        btnSavePrintReceipt = new Button();
        btnViewReceipt = new Button();
        btnCancelReceipt = new Button();
        dgvReceiptHistory = new DataGridView();
        ppdTuitionReceiptPreview = new PrintPreviewDialog();
        prdTuitionReceipt = new PrintDocument();
        ttTuitionReceipt = new ToolTip(components);
        errTuitionReceipt = new ErrorProvider(components);
        tblReceiptRoot.SuspendLayout();
        tblReceiptTop.SuspendLayout();
        grpEnrollmentInfo.SuspendLayout();
        tblEnrollmentInfo.SuspendLayout();
        grpPaymentInfo.SuspendLayout();
        tblPaymentInfo.SuspendLayout();
        flpReceiptActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvReceiptHistory).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errTuitionReceipt).BeginInit();
        SuspendLayout();
        // 
        // tblReceiptRoot
        // 
        tblReceiptRoot.ColumnCount = 1;
        tblReceiptRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblReceiptRoot.Controls.Add(tblReceiptTop, 0, 0);
        tblReceiptRoot.Controls.Add(dgvReceiptHistory, 0, 1);
        tblReceiptRoot.Dock = DockStyle.Fill;
        tblReceiptRoot.Location = new Point(12, 12);
        tblReceiptRoot.Name = "tblReceiptRoot";
        tblReceiptRoot.RowCount = 2;
        tblReceiptRoot.RowStyles.Add(new RowStyle());
        tblReceiptRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblReceiptRoot.Size = new Size(956, 596);
        tblReceiptRoot.TabIndex = 0;
        // 
        // tblReceiptTop
        // 
        tblReceiptTop.ColumnCount = 2;
        tblReceiptTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tblReceiptTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tblReceiptTop.Controls.Add(grpEnrollmentInfo, 0, 0);
        tblReceiptTop.Controls.Add(grpPaymentInfo, 1, 0);
        tblReceiptTop.Dock = DockStyle.Fill;
        tblReceiptTop.Location = new Point(3, 3);
        tblReceiptTop.Name = "tblReceiptTop";
        tblReceiptTop.RowCount = 1;
        tblReceiptTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblReceiptTop.Size = new Size(950, 214);
        tblReceiptTop.TabIndex = 0;
        // 
        // grpEnrollmentInfo
        // 
        grpEnrollmentInfo.Controls.Add(tblEnrollmentInfo);
        grpEnrollmentInfo.Dock = DockStyle.Fill;
        grpEnrollmentInfo.Location = new Point(3, 3);
        grpEnrollmentInfo.Name = "grpEnrollmentInfo";
        grpEnrollmentInfo.Padding = new Padding(12);
        grpEnrollmentInfo.Size = new Size(469, 208);
        grpEnrollmentInfo.TabIndex = 0;
        grpEnrollmentInfo.TabStop = false;
        grpEnrollmentInfo.Text = "Thông tin ghi danh";
        // 
        // tblEnrollmentInfo
        // 
        tblEnrollmentInfo.ColumnCount = 2;
        tblEnrollmentInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        tblEnrollmentInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblEnrollmentInfo.Controls.Add(lblReceiptStudentCode, 0, 0);
        tblEnrollmentInfo.Controls.Add(txtReceiptStudentCode, 1, 0);
        tblEnrollmentInfo.Controls.Add(lblReceiptStudentName, 0, 1);
        tblEnrollmentInfo.Controls.Add(txtReceiptStudentName, 1, 1);
        tblEnrollmentInfo.Controls.Add(lblReceiptClassCode, 0, 2);
        tblEnrollmentInfo.Controls.Add(txtReceiptClassCode, 1, 2);
        tblEnrollmentInfo.Controls.Add(lblReceiptCourseName, 0, 3);
        tblEnrollmentInfo.Controls.Add(txtReceiptCourseName, 1, 3);
        tblEnrollmentInfo.Dock = DockStyle.Fill;
        tblEnrollmentInfo.Location = new Point(12, 32);
        tblEnrollmentInfo.Name = "tblEnrollmentInfo";
        tblEnrollmentInfo.RowCount = 4;
        tblEnrollmentInfo.RowStyles.Add(new RowStyle());
        tblEnrollmentInfo.RowStyles.Add(new RowStyle());
        tblEnrollmentInfo.RowStyles.Add(new RowStyle());
        tblEnrollmentInfo.RowStyles.Add(new RowStyle());
        tblEnrollmentInfo.Size = new Size(445, 164);
        tblEnrollmentInfo.TabIndex = 0;
        // 
        // lblReceiptStudentCode
        // 
        lblReceiptStudentCode.Anchor = AnchorStyles.Left;
        lblReceiptStudentCode.AutoSize = true;
        lblReceiptStudentCode.Location = new Point(3, 6);
        lblReceiptStudentCode.Name = "lblReceiptStudentCode";
        lblReceiptStudentCode.Size = new Size(92, 20);
        lblReceiptStudentCode.TabIndex = 0;
        lblReceiptStudentCode.Text = "Mã học viên";
        // 
        // txtReceiptStudentCode
        // 
        txtReceiptStudentCode.Dock = DockStyle.Fill;
        txtReceiptStudentCode.Location = new Point(123, 3);
        txtReceiptStudentCode.Name = "txtReceiptStudentCode";
        txtReceiptStudentCode.Size = new Size(319, 27);
        txtReceiptStudentCode.TabIndex = 1;
        // 
        // lblReceiptStudentName
        // 
        lblReceiptStudentName.Anchor = AnchorStyles.Left;
        lblReceiptStudentName.AutoSize = true;
        lblReceiptStudentName.Location = new Point(3, 39);
        lblReceiptStudentName.Name = "lblReceiptStudentName";
        lblReceiptStudentName.Size = new Size(58, 20);
        lblReceiptStudentName.TabIndex = 2;
        lblReceiptStudentName.Text = "Họ tên";
        // 
        // txtReceiptStudentName
        // 
        txtReceiptStudentName.Dock = DockStyle.Fill;
        txtReceiptStudentName.Location = new Point(123, 36);
        txtReceiptStudentName.Name = "txtReceiptStudentName";
        txtReceiptStudentName.Size = new Size(319, 27);
        txtReceiptStudentName.TabIndex = 3;
        // 
        // lblReceiptClassCode
        // 
        lblReceiptClassCode.Anchor = AnchorStyles.Left;
        lblReceiptClassCode.AutoSize = true;
        lblReceiptClassCode.Location = new Point(3, 72);
        lblReceiptClassCode.Name = "lblReceiptClassCode";
        lblReceiptClassCode.Size = new Size(56, 20);
        lblReceiptClassCode.TabIndex = 4;
        lblReceiptClassCode.Text = "Mã lớp";
        // 
        // txtReceiptClassCode
        // 
        txtReceiptClassCode.Dock = DockStyle.Fill;
        txtReceiptClassCode.Location = new Point(123, 69);
        txtReceiptClassCode.Name = "txtReceiptClassCode";
        txtReceiptClassCode.Size = new Size(319, 27);
        txtReceiptClassCode.TabIndex = 5;
        // 
        // lblReceiptCourseName
        // 
        lblReceiptCourseName.Anchor = AnchorStyles.Left;
        lblReceiptCourseName.AutoSize = true;
        lblReceiptCourseName.Location = new Point(3, 105);
        lblReceiptCourseName.Name = "lblReceiptCourseName";
        lblReceiptCourseName.Size = new Size(65, 20);
        lblReceiptCourseName.TabIndex = 6;
        lblReceiptCourseName.Text = "Khóa học";
        // 
        // txtReceiptCourseName
        // 
        txtReceiptCourseName.Dock = DockStyle.Fill;
        txtReceiptCourseName.Location = new Point(123, 102);
        txtReceiptCourseName.Name = "txtReceiptCourseName";
        txtReceiptCourseName.Size = new Size(319, 27);
        txtReceiptCourseName.TabIndex = 7;
        // 
        // grpPaymentInfo
        // 
        grpPaymentInfo.Controls.Add(tblPaymentInfo);
        grpPaymentInfo.Dock = DockStyle.Fill;
        grpPaymentInfo.Location = new Point(478, 3);
        grpPaymentInfo.Name = "grpPaymentInfo";
        grpPaymentInfo.Padding = new Padding(12);
        grpPaymentInfo.Size = new Size(469, 208);
        grpPaymentInfo.TabIndex = 1;
        grpPaymentInfo.TabStop = false;
        grpPaymentInfo.Text = "Khối thu tiền";
        // 
        // tblPaymentInfo
        // 
        tblPaymentInfo.ColumnCount = 2;
        tblPaymentInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        tblPaymentInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblPaymentInfo.Controls.Add(lblReceiptAmount, 0, 0);
        tblPaymentInfo.Controls.Add(txtReceiptAmount, 1, 0);
        tblPaymentInfo.Controls.Add(lblReceiptMethod, 0, 1);
        tblPaymentInfo.Controls.Add(cboReceiptMethod, 1, 1);
        tblPaymentInfo.Controls.Add(lblReceiptNote, 0, 2);
        tblPaymentInfo.Controls.Add(txtReceiptNote, 1, 2);
        tblPaymentInfo.Controls.Add(flpReceiptActions, 0, 3);
        tblPaymentInfo.Dock = DockStyle.Fill;
        tblPaymentInfo.Location = new Point(12, 32);
        tblPaymentInfo.Name = "tblPaymentInfo";
        tblPaymentInfo.RowCount = 4;
        tblPaymentInfo.RowStyles.Add(new RowStyle());
        tblPaymentInfo.RowStyles.Add(new RowStyle());
        tblPaymentInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblPaymentInfo.RowStyles.Add(new RowStyle());
        tblPaymentInfo.Size = new Size(445, 164);
        tblPaymentInfo.TabIndex = 0;
        // 
        // lblReceiptAmount
        // 
        lblReceiptAmount.Anchor = AnchorStyles.Left;
        lblReceiptAmount.AutoSize = true;
        lblReceiptAmount.Location = new Point(3, 6);
        lblReceiptAmount.Name = "lblReceiptAmount";
        lblReceiptAmount.Size = new Size(58, 20);
        lblReceiptAmount.TabIndex = 0;
        lblReceiptAmount.Text = "Số tiền";
        // 
        // txtReceiptAmount
        // 
        txtReceiptAmount.Dock = DockStyle.Fill;
        txtReceiptAmount.Location = new Point(123, 3);
        txtReceiptAmount.Name = "txtReceiptAmount";
        txtReceiptAmount.Size = new Size(319, 27);
        txtReceiptAmount.TabIndex = 1;
        // 
        // lblReceiptMethod
        // 
        lblReceiptMethod.Anchor = AnchorStyles.Left;
        lblReceiptMethod.AutoSize = true;
        lblReceiptMethod.Location = new Point(3, 39);
        lblReceiptMethod.Name = "lblReceiptMethod";
        lblReceiptMethod.Size = new Size(91, 20);
        lblReceiptMethod.TabIndex = 2;
        lblReceiptMethod.Text = "Phương thức";
        // 
        // cboReceiptMethod
        // 
        cboReceiptMethod.Dock = DockStyle.Left;
        cboReceiptMethod.DropDownStyle = ComboBoxStyle.DropDownList;
        cboReceiptMethod.FormattingEnabled = true;
        cboReceiptMethod.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản" });
        cboReceiptMethod.Location = new Point(123, 36);
        cboReceiptMethod.Name = "cboReceiptMethod";
        cboReceiptMethod.Size = new Size(180, 28);
        cboReceiptMethod.TabIndex = 3;
        // 
        // lblReceiptNote
        // 
        lblReceiptNote.Anchor = AnchorStyles.Left;
        lblReceiptNote.AutoSize = true;
        lblReceiptNote.Location = new Point(3, 67);
        lblReceiptNote.Name = "lblReceiptNote";
        lblReceiptNote.Size = new Size(57, 20);
        lblReceiptNote.TabIndex = 4;
        lblReceiptNote.Text = "Ghi chú";
        // 
        // txtReceiptNote
        // 
        txtReceiptNote.Dock = DockStyle.Fill;
        txtReceiptNote.Location = new Point(123, 69);
        txtReceiptNote.Multiline = true;
        txtReceiptNote.Name = "txtReceiptNote";
        txtReceiptNote.Size = new Size(319, 49);
        txtReceiptNote.TabIndex = 5;
        // 
        // flpReceiptActions
        // 
        flpReceiptActions.AutoSize = true;
        tblPaymentInfo.SetColumnSpan(flpReceiptActions, 2);
        flpReceiptActions.Controls.Add(btnCollectTuition);
        flpReceiptActions.Controls.Add(btnSavePrintReceipt);
        flpReceiptActions.Controls.Add(btnViewReceipt);
        flpReceiptActions.Controls.Add(btnCancelReceipt);
        flpReceiptActions.Dock = DockStyle.Fill;
        flpReceiptActions.Location = new Point(3, 127);
        flpReceiptActions.Name = "flpReceiptActions";
        flpReceiptActions.Size = new Size(439, 34);
        flpReceiptActions.TabIndex = 6;
        flpReceiptActions.WrapContents = false;
        // 
        // btnCollectTuition
        // 
        btnCollectTuition.Location = new Point(3, 3);
        btnCollectTuition.Name = "btnCollectTuition";
        btnCollectTuition.Size = new Size(110, 28);
        btnCollectTuition.TabIndex = 0;
        btnCollectTuition.Text = "Thu học phí";
        btnCollectTuition.UseVisualStyleBackColor = true;
        // 
        // btnSavePrintReceipt
        // 
        btnSavePrintReceipt.Location = new Point(119, 3);
        btnSavePrintReceipt.Name = "btnSavePrintReceipt";
        btnSavePrintReceipt.Size = new Size(96, 28);
        btnSavePrintReceipt.TabIndex = 1;
        btnSavePrintReceipt.Text = "Lưu và in";
        btnSavePrintReceipt.UseVisualStyleBackColor = true;
        // 
        // btnViewReceipt
        // 
        btnViewReceipt.Location = new Point(221, 3);
        btnViewReceipt.Name = "btnViewReceipt";
        btnViewReceipt.Size = new Size(120, 28);
        btnViewReceipt.TabIndex = 2;
        btnViewReceipt.Text = "Xem biên nhận";
        btnViewReceipt.UseVisualStyleBackColor = true;
        // 
        // btnCancelReceipt
        // 
        btnCancelReceipt.Location = new Point(347, 3);
        btnCancelReceipt.Name = "btnCancelReceipt";
        btnCancelReceipt.Size = new Size(70, 28);
        btnCancelReceipt.TabIndex = 3;
        btnCancelReceipt.Text = "Hủy";
        btnCancelReceipt.UseVisualStyleBackColor = true;
        // 
        // dgvReceiptHistory
        // 
        dgvReceiptHistory.AllowUserToAddRows = false;
        dgvReceiptHistory.AllowUserToDeleteRows = false;
        dgvReceiptHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvReceiptHistory.BackgroundColor = Color.White;
        dgvReceiptHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvReceiptHistory.Dock = DockStyle.Fill;
        dgvReceiptHistory.Location = new Point(3, 223);
        dgvReceiptHistory.Name = "dgvReceiptHistory";
        dgvReceiptHistory.ReadOnly = true;
        dgvReceiptHistory.RowHeadersVisible = false;
        dgvReceiptHistory.RowHeadersWidth = 51;
        dgvReceiptHistory.Size = new Size(950, 370);
        dgvReceiptHistory.TabIndex = 1;
        // 
        // ppdTuitionReceiptPreview
        // 
        ppdTuitionReceiptPreview.AutoScrollMargin = new Size(0, 0);
        ppdTuitionReceiptPreview.AutoScrollMinSize = new Size(0, 0);
        ppdTuitionReceiptPreview.ClientSize = new Size(400, 300);
        ppdTuitionReceiptPreview.Document = prdTuitionReceipt;
        ppdTuitionReceiptPreview.Enabled = true;
        ppdTuitionReceiptPreview.Icon = null;
        ppdTuitionReceiptPreview.Name = "ppdTuitionReceiptPreview";
        ppdTuitionReceiptPreview.Visible = false;
        // 
        // errTuitionReceipt
        // 
        errTuitionReceipt.ContainerControl = this;
        // 
        // FrmTuitionReceipt
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(980, 620);
        Controls.Add(tblReceiptRoot);
        Name = "FrmTuitionReceipt";
        Padding = new Padding(12);
        Text = "Thu học phí / biên nhận";
        tblReceiptRoot.ResumeLayout(false);
        tblReceiptTop.ResumeLayout(false);
        grpEnrollmentInfo.ResumeLayout(false);
        tblEnrollmentInfo.ResumeLayout(false);
        tblEnrollmentInfo.PerformLayout();
        grpPaymentInfo.ResumeLayout(false);
        tblPaymentInfo.ResumeLayout(false);
        tblPaymentInfo.PerformLayout();
        flpReceiptActions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvReceiptHistory).EndInit();
        ((System.ComponentModel.ISupportInitialize)errTuitionReceipt).EndInit();
        ResumeLayout(false);
    }
}
