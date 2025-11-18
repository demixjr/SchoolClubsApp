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
    public partial class EnrollmentsForm : Form
    {
        public EnrollmentsForm()
        {
            InitializeComponent();
        }

        private void EnrollmentsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "schoolClubsDBDataSet.enrollments". При необходимости она может быть перемещена или удалена.
            this.enrollmentsTableAdapter.Fill(this.schoolClubsDBDataSet.enrollments);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.enrollmentsTableAdapter.Update(this.schoolClubsDBDataSet.enrollments);
                MessageBox.Show("Дані успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Помилка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
