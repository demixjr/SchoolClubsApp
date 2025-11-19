using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolClubsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void учніToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsForm studentsForm = new StudentsForm();
            studentsForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolClubsDBDataSet.attendance". При необходимости она может быть перемещена или удалена.
            this.attendanceTableAdapter.Fill(this.schoolClubsDBDataSet.attendance);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolClubsDBDataSet.enrollments". При необходимости она может быть перемещена или удалена.
            this.enrollmentsTableAdapter.Fill(this.schoolClubsDBDataSet.enrollments);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolClubsDBDataSet.schedules". При необходимости она может быть перемещена или удалена.
            this.schedulesTableAdapter.Fill(this.schoolClubsDBDataSet.schedules);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolClubsDBDataSet.clubs". При необходимости она может быть перемещена или удалена.
            this.clubsTableAdapter.Fill(this.schoolClubsDBDataSet.clubs);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolClubsDBDataSet.teachers". При необходимости она может быть перемещена или удалена.
            this.teachersTableAdapter.Fill(this.schoolClubsDBDataSet.teachers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolClubsDBDataSet.students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.schoolClubsDBDataSet.students);

        }

        private void викладачіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeachersForm teachersForm = new TeachersForm(); 
            teachersForm.Show();
        }

        private void гурткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClubsForm clubsForm = new ClubsForm();
            clubsForm.Show();
        }

        private void розкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SchedulesForm form   = new SchedulesForm();
            form.Show();
        }

        private void записToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnrollmentsForm enrollmentsForm = new EnrollmentsForm();
            enrollmentsForm.Show();
        }

        private void відвідуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceForm attendanceForm = new AttendanceForm();
            attendanceForm.Show();
        }
    }
}
