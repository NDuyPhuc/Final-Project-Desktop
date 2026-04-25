namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmScoreEntry
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlScoreFilterCard;
    private Label lblScoreClass;
    private ComboBox cboScoreClass;
    private Label lblScoreType;
    private ComboBox cboScoreType;
    private Label lblScoreWeight;
    private TextBox txtScoreWeight;
    private Button btnLoadScoreList;
    private Button btnSaveScore;
    private DataGridView dgvScoreList;
    private ErrorProvider errScore;
    private TableLayoutPanel tblScoreRoot;

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
        pnlScoreFilterCard = new Panel();
        btnSaveScore = new Button();
        btnLoadScoreList = new Button();
        txtScoreWeight = new TextBox();
        lblScoreWeight = new Label();
        cboScoreType = new ComboBox();
        lblScoreType = new Label();
        cboScoreClass = new ComboBox();
        lblScoreClass = new Label();
        dgvScoreList = new DataGridView();
        errScore = new ErrorProvider(components);
        tblScoreRoot = new TableLayoutPanel();
        pnlScoreFilterCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvScoreList).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errScore).BeginInit();
        tblScoreRoot.SuspendLayout();
        SuspendLayout();
        // 
        // pnlScoreFilterCard
        // 
        pnlScoreFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlScoreFilterCard.Controls.Add(btnSaveScore);
        pnlScoreFilterCard.Controls.Add(btnLoadScoreList);
        pnlScoreFilterCard.Controls.Add(txtScoreWeight);
        pnlScoreFilterCard.Controls.Add(lblScoreWeight);
        pnlScoreFilterCard.Controls.Add(cboScoreType);
        pnlScoreFilterCard.Controls.Add(lblScoreType);
        pnlScoreFilterCard.Controls.Add(cboScoreClass);
        pnlScoreFilterCard.Controls.Add(lblScoreClass);
        pnlScoreFilterCard.Dock = DockStyle.Fill;
        pnlScoreFilterCard.Location = new Point(3, 3);
        pnlScoreFilterCard.Name = "pnlScoreFilterCard";
        pnlScoreFilterCard.Padding = new Padding(16, 14, 16, 14);
        pnlScoreFilterCard.Size = new Size(974, 90);
        pnlScoreFilterCard.TabIndex = 0;
        // 
        // btnSaveScore
        // 
        btnSaveScore.Location = new Point(792, 38);
        btnSaveScore.Name = "btnSaveScore";
        btnSaveScore.Size = new Size(120, 32);
        btnSaveScore.TabIndex = 7;
        btnSaveScore.Text = "LÆ°u Ä‘iá»ƒm";
        btnSaveScore.UseVisualStyleBackColor = true;
        // 
        // btnLoadScoreList
        // 
        btnLoadScoreList.Location = new Point(666, 38);
        btnLoadScoreList.Name = "btnLoadScoreList";
        btnLoadScoreList.Size = new Size(120, 32);
        btnLoadScoreList.TabIndex = 6;
        btnLoadScoreList.Text = "Táº£i danh sÃ¡ch";
        btnLoadScoreList.UseVisualStyleBackColor = true;
        // 
        // txtScoreWeight
        // 
        txtScoreWeight.Location = new Point(490, 41);
        txtScoreWeight.Name = "txtScoreWeight";
        txtScoreWeight.Size = new Size(150, 27);
        txtScoreWeight.TabIndex = 5;
        // 
        // lblScoreWeight
        // 
        lblScoreWeight.AutoSize = true;
        lblScoreWeight.Location = new Point(490, 18);
        lblScoreWeight.Name = "lblScoreWeight";
        lblScoreWeight.Size = new Size(44, 20);
        lblScoreWeight.TabIndex = 4;
        lblScoreWeight.Text = "Há»‡ sá»‘";
        // 
        // cboScoreType
        // 
        cboScoreType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboScoreType.FormattingEnabled = true;
        cboScoreType.Items.AddRange(new object[] { "Giá»¯a ká»³", "Cuá»‘i ká»³", "Thá»±c hÃ nh" });
        cboScoreType.Location = new Point(250, 41);
        cboScoreType.Name = "cboScoreType";
        cboScoreType.Size = new Size(210, 28);
        cboScoreType.TabIndex = 3;
        // 
        // lblScoreType
        // 
        lblScoreType.AutoSize = true;
        lblScoreType.Location = new Point(250, 18);
        lblScoreType.Name = "lblScoreType";
        lblScoreType.Size = new Size(73, 20);
        lblScoreType.TabIndex = 2;
        lblScoreType.Text = "Loáº¡i Ä‘iá»ƒm";
        // 
        // cboScoreClass
        // 
        cboScoreClass.DropDownStyle = ComboBoxStyle.DropDownList;
        cboScoreClass.FormattingEnabled = true;
        cboScoreClass.Items.AddRange(new object[] { "ENG-A1-01", "ENG-IELTS-02" });
        cboScoreClass.Location = new Point(16, 41);
        cboScoreClass.Name = "cboScoreClass";
        cboScoreClass.Size = new Size(210, 28);
        cboScoreClass.TabIndex = 1;
        // 
        // lblScoreClass
        // 
        lblScoreClass.AutoSize = true;
        lblScoreClass.Location = new Point(16, 18);
        lblScoreClass.Name = "lblScoreClass";
        lblScoreClass.Size = new Size(58, 20);
        lblScoreClass.TabIndex = 0;
        lblScoreClass.Text = "Lá»›p há»c";
        // 
        // dgvScoreList
        // 
        dgvScoreList.AllowUserToAddRows = false;
        dgvScoreList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvScoreList.BackgroundColor = Color.White;
        dgvScoreList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvScoreList.Dock = DockStyle.Fill;
        dgvScoreList.Location = new Point(3, 99);
        dgvScoreList.Name = "dgvScoreList";
        dgvScoreList.RowHeadersVisible = false;
        dgvScoreList.RowHeadersWidth = 51;
        dgvScoreList.Size = new Size(974, 514);
        dgvScoreList.TabIndex = 1;
        // 
        // errScore
        // 
        errScore.ContainerControl = this;
        // 
        // tblScoreRoot
        // 
        tblScoreRoot.ColumnCount = 1;
        tblScoreRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblScoreRoot.Controls.Add(pnlScoreFilterCard, 0, 0);
        tblScoreRoot.Controls.Add(dgvScoreList, 0, 1);
        tblScoreRoot.Dock = DockStyle.Fill;
        tblScoreRoot.Location = new Point(12, 12);
        tblScoreRoot.Name = "tblScoreRoot";
        tblScoreRoot.RowCount = 2;
        tblScoreRoot.RowStyles.Add(new RowStyle());
        tblScoreRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblScoreRoot.Size = new Size(980, 616);
        tblScoreRoot.TabIndex = 0;
        // 
        // FrmScoreEntry
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1004, 640);
        Controls.Add(tblScoreRoot);
        Name = "FrmScoreEntry";
        Padding = new Padding(12);
        Text = "Nháº­p Ä‘iá»ƒm";
        pnlScoreFilterCard.ResumeLayout(false);
        pnlScoreFilterCard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvScoreList).EndInit();
        ((System.ComponentModel.ISupportInitialize)errScore).EndInit();
        tblScoreRoot.ResumeLayout(false);
        ResumeLayout(false);
    }
}

