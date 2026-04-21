namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmStaffDashboard
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSidebarStaff; private Panel pnlTopbarStaff; private Panel pnlContentHostStaff; private Panel pnlDashboardHome; private Label lblCurrentRoleStaff; private Label lblCurrentUserStaff; private Button btnLogoutStaff;
    private Button btnMenuStaffDashboard; private Button btnMenuStudentManagement; private Button btnMenuTeacherManagement; private Button btnMenuCourseManagement; private Button btnMenuClassManagement; private Button btnMenuEnrollment; private Button btnMenuTuitionReceipt; private Button btnMenuDebtTracking;
    private Label lblStaffDashboardTitle; private Panel pnlNewStudentsToday; private Panel pnlAvailableClasses; private Panel pnlTodayReceipts; private Panel pnlDebtStudents; private Label lblNewStudentsTodayValue; private Label lblAvailableClassesValue; private Label lblTodayReceiptsValue; private Label lblDebtStudentsValue; private DataGridView dgvRecentReceipts;
    protected override void Dispose(bool disposing){ if(disposing && components!=null) components.Dispose(); base.Dispose(disposing);} 
    private void InitializeComponent()
    {
        pnlSidebarStaff=new Panel(); pnlTopbarStaff=new Panel(); pnlContentHostStaff=new Panel(); pnlDashboardHome=new Panel(); lblCurrentRoleStaff=new Label(); lblCurrentUserStaff=new Label(); btnLogoutStaff=new Button();
        btnMenuStaffDashboard=new Button(); btnMenuStudentManagement=new Button(); btnMenuTeacherManagement=new Button(); btnMenuCourseManagement=new Button(); btnMenuClassManagement=new Button(); btnMenuEnrollment=new Button(); btnMenuTuitionReceipt=new Button(); btnMenuDebtTracking=new Button();
        lblStaffDashboardTitle=new Label(); pnlNewStudentsToday=new Panel(); pnlAvailableClasses=new Panel(); pnlTodayReceipts=new Panel(); pnlDebtStudents=new Panel(); lblNewStudentsTodayValue=new Label(); lblAvailableClassesValue=new Label(); lblTodayReceiptsValue=new Label(); lblDebtStudentsValue=new Label(); dgvRecentReceipts=new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvRecentReceipts).BeginInit(); SuspendLayout();
        pnlSidebarStaff.BackColor=Color.FromArgb(230,246,255); pnlSidebarStaff.Dock=DockStyle.Left; pnlSidebarStaff.Width=256;
        var buttons=new[]{btnMenuStaffDashboard,btnMenuStudentManagement,btnMenuTeacherManagement,btnMenuCourseManagement,btnMenuClassManagement,btnMenuEnrollment,btnMenuTuitionReceipt,btnMenuDebtTracking};
        string[] texts={"Dashboard v?n hành","Qu?n lý h?c viên","Qu?n lý giáo viên","Qu?n lý khóa h?c","Qu?n lý l?p h?c","Ghi danh / x?p l?p","Thu h?c phí","Công n? h?c viên"};
        for(int i=0;i<buttons.Length;i++){buttons[i].Location=new Point(24,120+(i*44)); buttons[i].Size=new Size(208,40); buttons[i].Text=texts[i]; pnlSidebarStaff.Controls.Add(buttons[i]);}
        pnlTopbarStaff.BackColor=Color.White; pnlTopbarStaff.Dock=DockStyle.Top; pnlTopbarStaff.Height=68; lblCurrentRoleStaff.Location=new Point(24,24); lblCurrentRoleStaff.AutoSize=true; lblCurrentUserStaff.Location=new Point(860,24); lblCurrentUserStaff.AutoSize=true; btnLogoutStaff.Location=new Point(1040,18); btnLogoutStaff.Size=new Size(110,32); btnLogoutStaff.Text="Ðang xu?t"; pnlTopbarStaff.Controls.AddRange(new Control[]{lblCurrentRoleStaff,lblCurrentUserStaff,btnLogoutStaff});
        pnlContentHostStaff.Dock=DockStyle.Fill; pnlContentHostStaff.Padding=new Padding(18); pnlContentHostStaff.Controls.Add(pnlDashboardHome);
        pnlDashboardHome.Dock=DockStyle.Fill; pnlDashboardHome.Controls.AddRange(new Control[]{dgvRecentReceipts,pnlDebtStudents,pnlTodayReceipts,pnlAvailableClasses,pnlNewStudentsToday,lblStaffDashboardTitle});
        lblStaffDashboardTitle.AutoSize=true; lblStaffDashboardTitle.Font=AppTheme.FontTitle; lblStaffDashboardTitle.Location=new Point(12,12); lblStaffDashboardTitle.Text="Dashboard v?n hành";
        pnlNewStudentsToday.BorderStyle=BorderStyle.FixedSingle; pnlNewStudentsToday.Location=new Point(16,64); pnlNewStudentsToday.Size=new Size(240,96); pnlNewStudentsToday.Controls.Add(lblNewStudentsTodayValue);
        pnlAvailableClasses.BorderStyle=BorderStyle.FixedSingle; pnlAvailableClasses.Location=new Point(272,64); pnlAvailableClasses.Size=new Size(240,96); pnlAvailableClasses.Controls.Add(lblAvailableClassesValue);
        pnlTodayReceipts.BorderStyle=BorderStyle.FixedSingle; pnlTodayReceipts.Location=new Point(528,64); pnlTodayReceipts.Size=new Size(240,96); pnlTodayReceipts.Controls.Add(lblTodayReceiptsValue);
        pnlDebtStudents.BorderStyle=BorderStyle.FixedSingle; pnlDebtStudents.Location=new Point(784,64); pnlDebtStudents.Size=new Size(240,96); pnlDebtStudents.Controls.Add(lblDebtStudentsValue);
        foreach(var lbl in new[]{lblNewStudentsTodayValue,lblAvailableClassesValue,lblTodayReceiptsValue,lblDebtStudentsValue}){ lbl.Dock=DockStyle.Fill; lbl.TextAlign=ContentAlignment.MiddleCenter; lbl.Font=AppTheme.FontKpi; }
        dgvRecentReceipts.Location=new Point(16,184); dgvRecentReceipts.Size=new Size(1008,420); dgvRecentReceipts.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill; dgvRecentReceipts.RowHeadersVisible=false; dgvRecentReceipts.Name="dgvRecentReceipts";
        AutoScaleMode=AutoScaleMode.None; ClientSize=new Size(920,580); Controls.AddRange(new Control[]{pnlContentHostStaff,pnlTopbarStaff,pnlSidebarStaff}); Name="FrmStaffDashboard"; ((System.ComponentModel.ISupportInitialize)dgvRecentReceipts).EndInit(); ResumeLayout(false);
    }
}

