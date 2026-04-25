namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmAccessMatrix
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblAccessRoot;
    private Panel pnlAccessHeader;
    private Label lblAccessTitle;
    private Label lblAccessSubtitle;
    private TableLayoutPanel tblAccessCards;
    private Panel pnlAdminRoleCard;
    private Panel pnlStaffRoleCard;
    private Panel pnlTeacherRoleCard;
    private Label lblAdminRoleCaption;
    private Label lblAdminRoleTitle;
    private Label lblAdminRoleBody;
    private Label lblAdminRoleTagPrimary;
    private Label lblAdminRoleTagSecondary;
    private FlowLayoutPanel flpAdminRoleTags;
    private Label lblAdminRoleGlyph;
    private Label lblStaffRoleCaption;
    private Label lblStaffRoleTitle;
    private Label lblStaffRoleBody;
    private Label lblStaffRoleTagPrimary;
    private Label lblStaffRoleTagSecondary;
    private FlowLayoutPanel flpStaffRoleTags;
    private Label lblStaffRoleGlyph;
    private Label lblTeacherRoleCaption;
    private Label lblTeacherRoleTitle;
    private Label lblTeacherRoleBody;
    private Label lblTeacherRoleTagPrimary;
    private Label lblTeacherRoleTagSecondary;
    private FlowLayoutPanel flpTeacherRoleTags;
    private Label lblTeacherRoleGlyph;
    private Panel pnlAccessMatrixCard;
    private TableLayoutPanel tblAccessMatrixLayout;
    private Panel pnlAccessMatrixHeader;
    private TableLayoutPanel tblAccessMatrixHeaderLayout;
    private Label lblAccessMatrixHeader;
    private FlowLayoutPanel flpAccessLegend;
    private Panel pnlLegendFull;
    private Label lblLegendFull;
    private Panel pnlLegendNone;
    private Label lblLegendNone;
    private DataGridView dgvAccessMatrix;
    private Panel pnlAccessMatrixFooter;
    private Button btnExportAccessMatrix;

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
        tblAccessRoot = new TableLayoutPanel();
        pnlAccessHeader = new Panel();
        lblAccessSubtitle = new Label();
        lblAccessTitle = new Label();
        tblAccessCards = new TableLayoutPanel();
        pnlAdminRoleCard = new Panel();
        lblAdminRoleTagPrimary = new Label();
        flpAdminRoleTags = new FlowLayoutPanel();
        lblAdminRoleTagSecondary = new Label();
        lblAdminRoleBody = new Label();
        lblAdminRoleTitle = new Label();
        lblAdminRoleCaption = new Label();
        lblAdminRoleGlyph = new Label();
        pnlStaffRoleCard = new Panel();
        lblStaffRoleTagPrimary = new Label();
        flpStaffRoleTags = new FlowLayoutPanel();
        lblStaffRoleTagSecondary = new Label();
        lblStaffRoleBody = new Label();
        lblStaffRoleTitle = new Label();
        lblStaffRoleCaption = new Label();
        lblStaffRoleGlyph = new Label();
        pnlTeacherRoleCard = new Panel();
        lblTeacherRoleTagPrimary = new Label();
        lblTeacherRoleTagSecondary = new Label();
        flpTeacherRoleTags = new FlowLayoutPanel();
        lblTeacherRoleBody = new Label();
        lblTeacherRoleTitle = new Label();
        lblTeacherRoleCaption = new Label();
        lblTeacherRoleGlyph = new Label();
        pnlAccessMatrixCard = new Panel();
        tblAccessMatrixLayout = new TableLayoutPanel();
        pnlAccessMatrixHeader = new Panel();
        flpAccessLegend = new FlowLayoutPanel();
        pnlLegendFull = new Panel();
        lblLegendFull = new Label();
        pnlLegendNone = new Panel();
        lblLegendNone = new Label();
        lblAccessMatrixHeader = new Label();
        dgvAccessMatrix = new DataGridView();
        pnlAccessMatrixFooter = new Panel();
        btnExportAccessMatrix = new Button();
        tblAccessMatrixHeaderLayout = new TableLayoutPanel();
        tblAccessRoot.SuspendLayout();
        pnlAccessHeader.SuspendLayout();
        tblAccessCards.SuspendLayout();
        pnlAdminRoleCard.SuspendLayout();
        pnlStaffRoleCard.SuspendLayout();
        pnlTeacherRoleCard.SuspendLayout();
        pnlAccessMatrixCard.SuspendLayout();
        tblAccessMatrixLayout.SuspendLayout();
        pnlAccessMatrixHeader.SuspendLayout();
        flpAccessLegend.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAccessMatrix).BeginInit();
        pnlAccessMatrixFooter.SuspendLayout();
        SuspendLayout();
        // 
        // tblAccessRoot
        // 
        tblAccessRoot.ColumnCount = 1;
        tblAccessRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAccessRoot.Controls.Add(pnlAccessHeader, 0, 0);
        tblAccessRoot.Controls.Add(tblAccessCards, 0, 1);
        tblAccessRoot.Controls.Add(pnlAccessMatrixCard, 0, 2);
        tblAccessRoot.Dock = DockStyle.Fill;
        tblAccessRoot.Location = new Point(16, 16);
        tblAccessRoot.Name = "tblAccessRoot";
        tblAccessRoot.RowCount = 3;
        tblAccessRoot.RowStyles.Add(new RowStyle());
        tblAccessRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
        tblAccessRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAccessRoot.Size = new Size(1146, 618);
        tblAccessRoot.TabIndex = 0;
        // 
        // pnlAccessHeader
        // 
        pnlAccessHeader.Controls.Add(lblAccessSubtitle);
        pnlAccessHeader.Controls.Add(lblAccessTitle);
        pnlAccessHeader.Dock = DockStyle.Fill;
        pnlAccessHeader.Location = new Point(3, 3);
        pnlAccessHeader.Name = "pnlAccessHeader";
        pnlAccessHeader.Padding = new Padding(0, 4, 0, 10);
        pnlAccessHeader.Size = new Size(1140, 82);
        pnlAccessHeader.TabIndex = 0;
        // 
        // lblAccessSubtitle
        // 
        lblAccessSubtitle.AutoSize = true;
        lblAccessSubtitle.Font = new Font("Segoe UI", 11F);
        lblAccessSubtitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblAccessSubtitle.Location = new Point(3, 50);
        lblAccessSubtitle.Name = "lblAccessSubtitle";
        lblAccessSubtitle.Size = new Size(731, 30);
        lblAccessSubtitle.TabIndex = 1;
        lblAccessSubtitle.Text = "Cáº¥u hÃ¬nh phÃ¢n quyá»n há»‡ thá»‘ng vÃ  phÃ¢n cáº¥p kiáº¿n trÃºc trung tÃ¢m ngoáº¡i ngá»¯.";
        // 
        // lblAccessTitle
        // 
        lblAccessTitle.AutoSize = true;
        lblAccessTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblAccessTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblAccessTitle.Location = new Point(0, 0);
        lblAccessTitle.Name = "lblAccessTitle";
        lblAccessTitle.Size = new Size(614, 54);
        lblAccessTitle.TabIndex = 0;
        lblAccessTitle.Text = "Tá»”NG QUAN QUYá»€N TRUY Cáº¬P";
        // 
        // tblAccessCards
        // 
        tblAccessCards.ColumnCount = 3;
        tblAccessCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblAccessCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblAccessCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblAccessCards.Controls.Add(pnlAdminRoleCard, 0, 0);
        tblAccessCards.Controls.Add(pnlStaffRoleCard, 1, 0);
        tblAccessCards.Controls.Add(pnlTeacherRoleCard, 2, 0);
        tblAccessCards.Dock = DockStyle.Fill;
        tblAccessCards.Location = new Point(3, 91);
        tblAccessCards.Name = "tblAccessCards";
        tblAccessCards.RowCount = 1;
        tblAccessCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAccessCards.Size = new Size(1140, 214);
        tblAccessCards.TabIndex = 1;
        // 
        // pnlAdminRoleCard
        // 
        pnlAdminRoleCard.BackColor = Color.White;
        pnlAdminRoleCard.BorderStyle = BorderStyle.FixedSingle;
        pnlAdminRoleCard.Controls.Add(lblAdminRoleTagPrimary);
        pnlAdminRoleCard.Controls.Add(flpAdminRoleTags);
        pnlAdminRoleCard.Controls.Add(lblAdminRoleTagSecondary);
        pnlAdminRoleCard.Controls.Add(lblAdminRoleBody);
        pnlAdminRoleCard.Controls.Add(lblAdminRoleTitle);
        pnlAdminRoleCard.Controls.Add(lblAdminRoleCaption);
        pnlAdminRoleCard.Controls.Add(lblAdminRoleGlyph);
        pnlAdminRoleCard.Dock = DockStyle.Fill;
        pnlAdminRoleCard.Location = new Point(3, 3);
        pnlAdminRoleCard.Name = "pnlAdminRoleCard";
        pnlAdminRoleCard.Padding = new Padding(18);
        pnlAdminRoleCard.Size = new Size(374, 208);
        pnlAdminRoleCard.TabIndex = 0;
        // 
        // lblAdminRoleTagPrimary
        // 
        lblAdminRoleTagPrimary.AutoSize = true;
        lblAdminRoleTagPrimary.BackColor = Color.FromArgb(144, 239, 239);
        lblAdminRoleTagPrimary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblAdminRoleTagPrimary.ForeColor = Color.FromArgb(0, 110, 110);
        lblAdminRoleTagPrimary.Location = new Point(20, 171);
        lblAdminRoleTagPrimary.Margin = new Padding(0);
        lblAdminRoleTagPrimary.Name = "lblAdminRoleTagPrimary";
        lblAdminRoleTagPrimary.Padding = new Padding(8, 4, 8, 4);
        lblAdminRoleTagPrimary.Size = new Size(119, 29);
        lblAdminRoleTagPrimary.TabIndex = 4;
        lblAdminRoleTagPrimary.Text = "QUYá»€N Gá»C";
        // 
        // flpAdminRoleTags
        // 
        flpAdminRoleTags.AutoSize = true;
        flpAdminRoleTags.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flpAdminRoleTags.Location = new Point(20, 171);
        flpAdminRoleTags.Margin = new Padding(0);
        flpAdminRoleTags.Name = "flpAdminRoleTags";
        flpAdminRoleTags.Size = new Size(0, 0);
        flpAdminRoleTags.TabIndex = 4;
        flpAdminRoleTags.WrapContents = false;
        // 
        // lblAdminRoleTagSecondary
        // 
        lblAdminRoleTagSecondary.AutoSize = true;
        lblAdminRoleTagSecondary.BackColor = Color.FromArgb(225, 237, 246);
        lblAdminRoleTagSecondary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblAdminRoleTagSecondary.ForeColor = Color.FromArgb(42, 51, 64);
        lblAdminRoleTagSecondary.Location = new Point(133, 171);
        lblAdminRoleTagSecondary.Margin = new Padding(6, 0, 0, 0);
        lblAdminRoleTagSecondary.Name = "lblAdminRoleTagSecondary";
        lblAdminRoleTagSecondary.Padding = new Padding(8, 4, 8, 4);
        lblAdminRoleTagSecondary.Size = new Size(113, 29);
        lblAdminRoleTagSecondary.TabIndex = 5;
        lblAdminRoleTagSecondary.Text = "KIá»‚M TOÃN";
        // 
        // lblAdminRoleBody
        // 
        lblAdminRoleBody.Font = new Font("Segoe UI", 9.5F);
        lblAdminRoleBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblAdminRoleBody.Location = new Point(20, 88);
        lblAdminRoleBody.Name = "lblAdminRoleBody";
        lblAdminRoleBody.Size = new Size(255, 76);
        lblAdminRoleBody.TabIndex = 3;
        lblAdminRoleBody.Text = "ToÃ n quyá»n Ä‘iá»u hÃ nh há»‡ thá»‘ng. GiÃ¡m sÃ¡t phÃ¢n quyá»n, nhÃ¢n viÃªn vÃ  tÃ­nh toÃ n váº¹n dá»¯ liá»‡u.";
        // 
        // lblAdminRoleTitle
        // 
        lblAdminRoleTitle.AutoSize = true;
        lblAdminRoleTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblAdminRoleTitle.ForeColor = Color.FromArgb(0, 66, 118);
        lblAdminRoleTitle.Location = new Point(20, 51);
        lblAdminRoleTitle.Name = "lblAdminRoleTitle";
        lblAdminRoleTitle.Size = new Size(215, 32);
        lblAdminRoleTitle.TabIndex = 2;
        lblAdminRoleTitle.Text = "Quáº£n lÃ½ & GiÃ¡m sÃ¡t";
        // 
        // lblAdminRoleCaption
        // 
        lblAdminRoleCaption.AutoSize = true;
        lblAdminRoleCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblAdminRoleCaption.ForeColor = Color.FromArgb(7, 30, 39);
        lblAdminRoleCaption.Location = new Point(20, 18);
        lblAdminRoleCaption.Name = "lblAdminRoleCaption";
        lblAdminRoleCaption.Size = new Size(147, 25);
        lblAdminRoleCaption.TabIndex = 1;
        lblAdminRoleCaption.Text = "QUáº¢N TRá»Š VIÃŠN";
        // 
        // lblAdminRoleGlyph
        // 
        lblAdminRoleGlyph.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblAdminRoleGlyph.Font = new Font("Segoe UI Symbol", 42F);
        lblAdminRoleGlyph.ForeColor = Color.FromArgb(227, 232, 239);
        lblAdminRoleGlyph.Location = new Point(303, 18);
        lblAdminRoleGlyph.Name = "lblAdminRoleGlyph";
        lblAdminRoleGlyph.Size = new Size(49, 70);
        lblAdminRoleGlyph.TabIndex = 0;
        lblAdminRoleGlyph.Text = "â—”";
        lblAdminRoleGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlStaffRoleCard
        // 
        pnlStaffRoleCard.BackColor = Color.White;
        pnlStaffRoleCard.BorderStyle = BorderStyle.FixedSingle;
        pnlStaffRoleCard.Controls.Add(lblStaffRoleTagPrimary);
        pnlStaffRoleCard.Controls.Add(flpStaffRoleTags);
        pnlStaffRoleCard.Controls.Add(lblStaffRoleTagSecondary);
        pnlStaffRoleCard.Controls.Add(lblStaffRoleBody);
        pnlStaffRoleCard.Controls.Add(lblStaffRoleTitle);
        pnlStaffRoleCard.Controls.Add(lblStaffRoleCaption);
        pnlStaffRoleCard.Controls.Add(lblStaffRoleGlyph);
        pnlStaffRoleCard.Dock = DockStyle.Fill;
        pnlStaffRoleCard.Location = new Point(383, 3);
        pnlStaffRoleCard.Name = "pnlStaffRoleCard";
        pnlStaffRoleCard.Padding = new Padding(18);
        pnlStaffRoleCard.Size = new Size(374, 208);
        pnlStaffRoleCard.TabIndex = 1;
        // 
        // lblStaffRoleTagPrimary
        // 
        lblStaffRoleTagPrimary.AutoSize = true;
        lblStaffRoleTagPrimary.BackColor = Color.FromArgb(225, 237, 246);
        lblStaffRoleTagPrimary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStaffRoleTagPrimary.ForeColor = Color.FromArgb(0, 110, 110);
        lblStaffRoleTagPrimary.Location = new Point(20, 171);
        lblStaffRoleTagPrimary.Margin = new Padding(0);
        lblStaffRoleTagPrimary.Name = "lblStaffRoleTagPrimary";
        lblStaffRoleTagPrimary.Padding = new Padding(8, 4, 8, 4);
        lblStaffRoleTagPrimary.Size = new Size(113, 29);
        lblStaffRoleTagPrimary.TabIndex = 4;
        lblStaffRoleTagPrimary.Text = "Váº¬N HÃ€NH";
        // 
        // flpStaffRoleTags
        // 
        flpStaffRoleTags.AutoSize = true;
        flpStaffRoleTags.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flpStaffRoleTags.Location = new Point(20, 171);
        flpStaffRoleTags.Margin = new Padding(0);
        flpStaffRoleTags.Name = "flpStaffRoleTags";
        flpStaffRoleTags.Size = new Size(0, 0);
        flpStaffRoleTags.TabIndex = 4;
        flpStaffRoleTags.WrapContents = false;
        // 
        // lblStaffRoleTagSecondary
        // 
        lblStaffRoleTagSecondary.AutoSize = true;
        lblStaffRoleTagSecondary.BackColor = Color.FromArgb(225, 237, 246);
        lblStaffRoleTagSecondary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblStaffRoleTagSecondary.ForeColor = Color.FromArgb(42, 51, 64);
        lblStaffRoleTagSecondary.Location = new Point(128, 171);
        lblStaffRoleTagSecondary.Margin = new Padding(6, 0, 0, 0);
        lblStaffRoleTagSecondary.Name = "lblStaffRoleTagSecondary";
        lblStaffRoleTagSecondary.Padding = new Padding(8, 4, 8, 4);
        lblStaffRoleTagSecondary.Size = new Size(99, 29);
        lblStaffRoleTagSecondary.TabIndex = 5;
        lblStaffRoleTagSecondary.Text = "Háº¬U Cáº¦N";
        // 
        // lblStaffRoleBody
        // 
        lblStaffRoleBody.Font = new Font("Segoe UI", 9.5F);
        lblStaffRoleBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblStaffRoleBody.Location = new Point(20, 88);
        lblStaffRoleBody.Name = "lblStaffRoleBody";
        lblStaffRoleBody.Size = new Size(255, 76);
        lblStaffRoleBody.TabIndex = 3;
        lblStaffRoleBody.Text = "Thá»±c hiá»‡n nghiá»‡p vá»¥ ghi danh, thanh toÃ¡n vÃ  háº­u cáº§n. LÃ  Ä‘áº§u má»‘i váº­n hÃ nh toÃ n trung tÃ¢m.";
        // 
        // lblStaffRoleTitle
        // 
        lblStaffRoleTitle.AutoSize = true;
        lblStaffRoleTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblStaffRoleTitle.ForeColor = Color.FromArgb(0, 110, 110);
        lblStaffRoleTitle.Location = new Point(20, 51);
        lblStaffRoleTitle.Name = "lblStaffRoleTitle";
        lblStaffRoleTitle.Size = new Size(233, 32);
        lblStaffRoleTitle.TabIndex = 2;
        lblStaffRoleTitle.Text = "Quy trÃ¬nh váº­n hÃ nh";
        // 
        // lblStaffRoleCaption
        // 
        lblStaffRoleCaption.AutoSize = true;
        lblStaffRoleCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStaffRoleCaption.ForeColor = Color.FromArgb(7, 30, 39);
        lblStaffRoleCaption.Location = new Point(20, 18);
        lblStaffRoleCaption.Name = "lblStaffRoleCaption";
        lblStaffRoleCaption.Size = new Size(114, 25);
        lblStaffRoleCaption.TabIndex = 1;
        lblStaffRoleCaption.Text = "NHÃ‚N VIÃŠN";
        // 
        // lblStaffRoleGlyph
        // 
        lblStaffRoleGlyph.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblStaffRoleGlyph.Font = new Font("Segoe UI Symbol", 36F);
        lblStaffRoleGlyph.ForeColor = Color.FromArgb(227, 232, 239);
        lblStaffRoleGlyph.Location = new Point(305, 20);
        lblStaffRoleGlyph.Name = "lblStaffRoleGlyph";
        lblStaffRoleGlyph.Size = new Size(47, 60);
        lblStaffRoleGlyph.TabIndex = 0;
        lblStaffRoleGlyph.Text = "âš™";
        lblStaffRoleGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTeacherRoleCard
        // 
        pnlTeacherRoleCard.BackColor = Color.White;
        pnlTeacherRoleCard.BorderStyle = BorderStyle.FixedSingle;
        pnlTeacherRoleCard.Controls.Add(lblTeacherRoleTagPrimary);
        pnlTeacherRoleCard.Controls.Add(lblTeacherRoleTagSecondary);
        pnlTeacherRoleCard.Controls.Add(flpTeacherRoleTags);
        pnlTeacherRoleCard.Controls.Add(lblTeacherRoleBody);
        pnlTeacherRoleCard.Controls.Add(lblTeacherRoleTitle);
        pnlTeacherRoleCard.Controls.Add(lblTeacherRoleCaption);
        pnlTeacherRoleCard.Controls.Add(lblTeacherRoleGlyph);
        pnlTeacherRoleCard.Dock = DockStyle.Fill;
        pnlTeacherRoleCard.Location = new Point(763, 3);
        pnlTeacherRoleCard.Name = "pnlTeacherRoleCard";
        pnlTeacherRoleCard.Padding = new Padding(18);
        pnlTeacherRoleCard.Size = new Size(374, 208);
        pnlTeacherRoleCard.TabIndex = 2;
        // 
        // lblTeacherRoleTagPrimary
        // 
        lblTeacherRoleTagPrimary.AutoSize = true;
        lblTeacherRoleTagPrimary.BackColor = Color.FromArgb(255, 236, 217);
        lblTeacherRoleTagPrimary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblTeacherRoleTagPrimary.ForeColor = Color.FromArgb(124, 45, 18);
        lblTeacherRoleTagPrimary.Location = new Point(18, 171);
        lblTeacherRoleTagPrimary.Margin = new Padding(0);
        lblTeacherRoleTagPrimary.Name = "lblTeacherRoleTagPrimary";
        lblTeacherRoleTagPrimary.Padding = new Padding(8, 4, 8, 4);
        lblTeacherRoleTagPrimary.Size = new Size(117, 29);
        lblTeacherRoleTagPrimary.TabIndex = 4;
        lblTeacherRoleTagPrimary.Text = "Há»ŒC THUáº¬T";
        // 
        // lblTeacherRoleTagSecondary
        // 
        lblTeacherRoleTagSecondary.AutoSize = true;
        lblTeacherRoleTagSecondary.BackColor = Color.FromArgb(225, 237, 246);
        lblTeacherRoleTagSecondary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblTeacherRoleTagSecondary.ForeColor = Color.FromArgb(42, 51, 64);
        lblTeacherRoleTagSecondary.Location = new Point(138, 171);
        lblTeacherRoleTagSecondary.Margin = new Padding(6, 0, 0, 0);
        lblTeacherRoleTagSecondary.Name = "lblTeacherRoleTagSecondary";
        lblTeacherRoleTagSecondary.Padding = new Padding(8, 4, 8, 4);
        lblTeacherRoleTagSecondary.Size = new Size(87, 29);
        lblTeacherRoleTagSecondary.TabIndex = 5;
        lblTeacherRoleTagSecondary.Text = "Cá» Váº¤N";
        // 
        // flpTeacherRoleTags
        // 
        flpTeacherRoleTags.AutoSize = true;
        flpTeacherRoleTags.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flpTeacherRoleTags.Location = new Point(20, 171);
        flpTeacherRoleTags.Margin = new Padding(0);
        flpTeacherRoleTags.Name = "flpTeacherRoleTags";
        flpTeacherRoleTags.Size = new Size(0, 0);
        flpTeacherRoleTags.TabIndex = 4;
        flpTeacherRoleTags.WrapContents = false;
        // 
        // lblTeacherRoleBody
        // 
        lblTeacherRoleBody.Font = new Font("Segoe UI", 9.5F);
        lblTeacherRoleBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblTeacherRoleBody.Location = new Point(20, 88);
        lblTeacherRoleBody.Name = "lblTeacherRoleBody";
        lblTeacherRoleBody.Size = new Size(257, 76);
        lblTeacherRoleBody.TabIndex = 3;
        lblTeacherRoleBody.Text = "Trá»±c tiáº¿p giáº£ng dáº¡y, táº­p trung cháº¥m Ä‘iá»ƒm, theo dÃµi tiáº¿n Ä‘á»™ vÃ  Ä‘Ã¡nh giÃ¡ há»c sinh.";
        // 
        // lblTeacherRoleTitle
        // 
        lblTeacherRoleTitle.AutoSize = true;
        lblTeacherRoleTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTeacherRoleTitle.ForeColor = Color.FromArgb(124, 45, 18);
        lblTeacherRoleTitle.Location = new Point(20, 51);
        lblTeacherRoleTitle.Name = "lblTeacherRoleTitle";
        lblTeacherRoleTitle.Size = new Size(245, 32);
        lblTeacherRoleTitle.TabIndex = 2;
        lblTeacherRoleTitle.Text = "Giáº£ng dáº¡y & ÄÃ¡nh giÃ¡";
        // 
        // lblTeacherRoleCaption
        // 
        lblTeacherRoleCaption.AutoSize = true;
        lblTeacherRoleCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTeacherRoleCaption.ForeColor = Color.FromArgb(7, 30, 39);
        lblTeacherRoleCaption.Location = new Point(20, 18);
        lblTeacherRoleCaption.Name = "lblTeacherRoleCaption";
        lblTeacherRoleCaption.Size = new Size(105, 25);
        lblTeacherRoleCaption.TabIndex = 1;
        lblTeacherRoleCaption.Text = "GIÃO VIÃŠN";
        // 
        // lblTeacherRoleGlyph
        // 
        lblTeacherRoleGlyph.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblTeacherRoleGlyph.Font = new Font("Segoe UI Symbol", 38F);
        lblTeacherRoleGlyph.ForeColor = Color.FromArgb(227, 232, 239);
        lblTeacherRoleGlyph.Location = new Point(304, 18);
        lblTeacherRoleGlyph.Name = "lblTeacherRoleGlyph";
        lblTeacherRoleGlyph.Size = new Size(49, 60);
        lblTeacherRoleGlyph.TabIndex = 0;
        lblTeacherRoleGlyph.Text = "âŒ‚";
        lblTeacherRoleGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlAccessMatrixCard
        // 
        pnlAccessMatrixCard.BackColor = Color.White;
        pnlAccessMatrixCard.BorderStyle = BorderStyle.FixedSingle;
        pnlAccessMatrixCard.Controls.Add(tblAccessMatrixLayout);
        pnlAccessMatrixCard.Dock = DockStyle.Fill;
        pnlAccessMatrixCard.Location = new Point(3, 311);
        pnlAccessMatrixCard.Name = "pnlAccessMatrixCard";
        pnlAccessMatrixCard.Size = new Size(1140, 304);
        pnlAccessMatrixCard.TabIndex = 2;
        // 
        // tblAccessMatrixLayout
        // 
        tblAccessMatrixLayout.ColumnCount = 1;
        tblAccessMatrixLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAccessMatrixLayout.Controls.Add(pnlAccessMatrixHeader, 0, 0);
        tblAccessMatrixLayout.Controls.Add(dgvAccessMatrix, 0, 1);
        tblAccessMatrixLayout.Controls.Add(pnlAccessMatrixFooter, 0, 2);
        tblAccessMatrixLayout.Dock = DockStyle.Fill;
        tblAccessMatrixLayout.Location = new Point(0, 0);
        tblAccessMatrixLayout.Margin = new Padding(0);
        tblAccessMatrixLayout.Name = "tblAccessMatrixLayout";
        tblAccessMatrixLayout.RowCount = 3;
        tblAccessMatrixLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        tblAccessMatrixLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAccessMatrixLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        tblAccessMatrixLayout.Size = new Size(1138, 302);
        tblAccessMatrixLayout.TabIndex = 0;
        // 
        // pnlAccessMatrixHeader
        // 
        pnlAccessMatrixHeader.BackColor = Color.FromArgb(205, 229, 245);
        pnlAccessMatrixHeader.Controls.Add(flpAccessLegend);
        pnlAccessMatrixHeader.Controls.Add(lblAccessMatrixHeader);
        pnlAccessMatrixHeader.Dock = DockStyle.Fill;
        pnlAccessMatrixHeader.Location = new Point(0, 0);
        pnlAccessMatrixHeader.Margin = new Padding(0);
        pnlAccessMatrixHeader.Name = "pnlAccessMatrixHeader";
        pnlAccessMatrixHeader.Size = new Size(1138, 52);
        pnlAccessMatrixHeader.TabIndex = 0;
        // 
        // flpAccessLegend
        // 
        flpAccessLegend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        flpAccessLegend.Controls.Add(pnlLegendFull);
        flpAccessLegend.Controls.Add(lblLegendFull);
        flpAccessLegend.Controls.Add(pnlLegendNone);
        flpAccessLegend.Controls.Add(lblLegendNone);
        flpAccessLegend.Location = new Point(807, 14);
        flpAccessLegend.Name = "flpAccessLegend";
        flpAccessLegend.Size = new Size(311, 24);
        flpAccessLegend.TabIndex = 1;
        flpAccessLegend.WrapContents = false;
        // 
        // pnlLegendFull
        // 
        pnlLegendFull.BackColor = Color.FromArgb(0, 110, 110);
        pnlLegendFull.Location = new Point(3, 6);
        pnlLegendFull.Margin = new Padding(3, 6, 4, 0);
        pnlLegendFull.Name = "pnlLegendFull";
        pnlLegendFull.Size = new Size(14, 14);
        pnlLegendFull.TabIndex = 0;
        // 
        // lblLegendFull
        // 
        lblLegendFull.AutoSize = true;
        lblLegendFull.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblLegendFull.ForeColor = Color.FromArgb(42, 51, 64);
        lblLegendFull.Location = new Point(24, 2);
        lblLegendFull.Margin = new Padding(3, 2, 0, 0);
        lblLegendFull.Name = "lblLegendFull";
        lblLegendFull.Size = new Size(119, 23);
        lblLegendFull.TabIndex = 1;
        lblLegendFull.Text = "TOÃ€N QUYá»€N";
        // 
        // pnlLegendNone
        // 
        pnlLegendNone.BackColor = Color.FromArgb(235, 241, 247);
        pnlLegendNone.Location = new Point(163, 6);
        pnlLegendNone.Margin = new Padding(20, 6, 4, 0);
        pnlLegendNone.Name = "pnlLegendNone";
        pnlLegendNone.Size = new Size(14, 14);
        pnlLegendNone.TabIndex = 2;
        // 
        // lblLegendNone
        // 
        lblLegendNone.AutoSize = true;
        lblLegendNone.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblLegendNone.ForeColor = Color.FromArgb(42, 51, 64);
        lblLegendNone.Location = new Point(184, 2);
        lblLegendNone.Margin = new Padding(3, 2, 0, 0);
        lblLegendNone.Name = "lblLegendNone";
        lblLegendNone.Size = new Size(158, 23);
        lblLegendNone.TabIndex = 3;
        lblLegendNone.Text = "KHÃ”NG TRUY Cáº¬P";
        // 
        // lblAccessMatrixHeader
        // 
        lblAccessMatrixHeader.AutoSize = true;
        lblAccessMatrixHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblAccessMatrixHeader.ForeColor = Color.FromArgb(7, 30, 39);
        lblAccessMatrixHeader.Location = new Point(20, 14);
        lblAccessMatrixHeader.Name = "lblAccessMatrixHeader";
        lblAccessMatrixHeader.Size = new Size(353, 28);
        lblAccessMatrixHeader.TabIndex = 0;
        lblAccessMatrixHeader.Text = "MA TRáº¬N PHÃ‚N QUYá»€N Há»† THá»NG";
        // 
        // dgvAccessMatrix
        // 
        dgvAccessMatrix.AllowUserToAddRows = false;
        dgvAccessMatrix.AllowUserToDeleteRows = false;
        dgvAccessMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAccessMatrix.BackgroundColor = Color.White;
        dgvAccessMatrix.BorderStyle = BorderStyle.None;
        dgvAccessMatrix.ColumnHeadersHeight = 42;
        dgvAccessMatrix.Dock = DockStyle.Fill;
        dgvAccessMatrix.Location = new Point(0, 52);
        dgvAccessMatrix.Margin = new Padding(0);
        dgvAccessMatrix.MultiSelect = false;
        dgvAccessMatrix.Name = "dgvAccessMatrix";
        dgvAccessMatrix.ReadOnly = true;
        dgvAccessMatrix.RowHeadersVisible = false;
        dgvAccessMatrix.RowHeadersWidth = 51;
        dgvAccessMatrix.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAccessMatrix.Size = new Size(1138, 208);
        dgvAccessMatrix.TabIndex = 1;
        // 
        // pnlAccessMatrixFooter
        // 
        pnlAccessMatrixFooter.Controls.Add(btnExportAccessMatrix);
        pnlAccessMatrixFooter.Dock = DockStyle.Fill;
        pnlAccessMatrixFooter.Location = new Point(0, 260);
        pnlAccessMatrixFooter.Margin = new Padding(0);
        pnlAccessMatrixFooter.Name = "pnlAccessMatrixFooter";
        pnlAccessMatrixFooter.Size = new Size(1138, 42);
        pnlAccessMatrixFooter.TabIndex = 2;
        // 
        // btnExportAccessMatrix
        // 
        btnExportAccessMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnExportAccessMatrix.FlatAppearance.BorderSize = 0;
        btnExportAccessMatrix.FlatStyle = FlatStyle.Flat;
        btnExportAccessMatrix.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnExportAccessMatrix.ForeColor = Color.FromArgb(0, 66, 118);
        btnExportAccessMatrix.Location = new Point(913, 7);
        btnExportAccessMatrix.Name = "btnExportAccessMatrix";
        btnExportAccessMatrix.Size = new Size(223, 28);
        btnExportAccessMatrix.TabIndex = 0;
        btnExportAccessMatrix.Text = "XUáº¤T NHáº¬T KÃ KIá»‚M TOÃN";
        btnExportAccessMatrix.UseVisualStyleBackColor = true;
        // 
        // tblAccessMatrixHeaderLayout
        // 
        tblAccessMatrixHeaderLayout.Location = new Point(0, 0);
        tblAccessMatrixHeaderLayout.Name = "tblAccessMatrixHeaderLayout";
        tblAccessMatrixHeaderLayout.Size = new Size(200, 100);
        tblAccessMatrixHeaderLayout.TabIndex = 0;
        // 
        // FrmAccessMatrix
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(244, 251, 255);
        ClientSize = new Size(1178, 650);
        Controls.Add(tblAccessRoot);
        Name = "FrmAccessMatrix";
        Padding = new Padding(16);
        Text = "Tá»•ng quan quyá»n truy cáº­p";
        tblAccessRoot.ResumeLayout(false);
        pnlAccessHeader.ResumeLayout(false);
        pnlAccessHeader.PerformLayout();
        tblAccessCards.ResumeLayout(false);
        pnlAdminRoleCard.ResumeLayout(false);
        pnlAdminRoleCard.PerformLayout();
        pnlStaffRoleCard.ResumeLayout(false);
        pnlStaffRoleCard.PerformLayout();
        pnlTeacherRoleCard.ResumeLayout(false);
        pnlTeacherRoleCard.PerformLayout();
        pnlAccessMatrixCard.ResumeLayout(false);
        tblAccessMatrixLayout.ResumeLayout(false);
        pnlAccessMatrixHeader.ResumeLayout(false);
        pnlAccessMatrixHeader.PerformLayout();
        flpAccessLegend.ResumeLayout(false);
        flpAccessLegend.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAccessMatrix).EndInit();
        pnlAccessMatrixFooter.ResumeLayout(false);
        ResumeLayout(false);
    }
}

