namespace Trung_tam_quan_ly_ngoai_ngu;
public partial class FrmEnrollment : Form
{
    public FrmEnrollment(){ InitializeComponent(); FormHostHelpers.ConfigureModuleSurface(this, "Ghi danh / xếp lớp"); dgvEnrollmentStudentList.DataSource = DemoDataFactory.GetEnrollmentStudents(); dgvEnrollmentClassList.DataSource = DemoDataFactory.GetEnrollmentClasses(); }
}
