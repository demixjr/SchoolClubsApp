using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;

namespace SchoolClubsApp
{
    public partial class StudentsForm : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=SchoolClubsDB;Integrated Security=True;";

        public StudentsForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentsTableAdapter.Update(this.schoolClubsDBDataSet.students);
                MessageBox.Show("Дані успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547) // Код помилки конфлікту зовнішнього ключа
                {
                    MessageBox.Show("Не можна видалити учня, оскільки він записаний у гуртки.\n\n" +
                                   "Спочатку видаліть всі записи цього учня з гуртків.",
                                   "Помилка видалення",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);

                    this.schoolClubsDBDataSet.students.RejectChanges();
                    this.studentsTableAdapter.Fill(this.schoolClubsDBDataSet.students);
                }
                else
                {
                    MessageBox.Show("Помилка бази даних: " + ex.Message, "Помилка",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Помилка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            this.studentsTableAdapter.Fill(this.schoolClubsDBDataSet.students);
            dataGridView1.DataSource = studentsBindingSource;

            // Заповнення комбобоксів
            cmbSortField.Items.AddRange(new string[] { "last_name", "first_name", "class", "parent_phone" });
            cmbGroupField.Items.AddRange(new string[] { "last_name", "first_name", "class" });

            cmbSortOrder.Items.AddRange(new string[] { "ASC", "DESC" });
         

            // Заповнення комбобоксу для фільтрації за класом
            cmbClassFilter.Items.Add("Всі класи");
            LoadClasses();

            // Встановлення значень за замовчуванням
            cmbSortField.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            cmbGroupField.SelectedIndex = 0;
            cmbClassFilter.SelectedIndex = 0;
        }

        private void LoadClasses()
        {
            string query = "SELECT DISTINCT class FROM students ORDER BY class";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbClassFilter.Items.Add(reader["class"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження класів: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Сортування
        private void btnSort_Click(object sender, EventArgs e)
        {
            string field = cmbSortField.Text;
            string order = cmbSortOrder.Text;

            if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(order))
            {
                string query = $"SELECT * FROM students ORDER BY {field} {order}";
                ExecuteQueryAndDisplay(query);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть поле та порядок сортування", "Попередження",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Пошук
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string groupField = cmbGroupField.Text;
            string conditionValue = txtConditionValue.Text;

            if (!string.IsNullOrEmpty(groupField) && !string.IsNullOrEmpty(conditionValue))
            {
                string query = $"SELECT * FROM students WHERE {groupField} LIKE '%{conditionValue}%'";
                ExecuteQueryAndDisplay(query);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть поле та введіть значення для пошуку", "Попередження",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Допоміжний метод для виконання запиту та відображення результатів
        private void ExecuteQueryAndDisplay(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    toolStripStatusLabel1.Text = $"Знайдено записів: {dataTable.Rows.Count}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка виконання запиту: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Скидання фільтрів
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtConditionValue.Text = "";
            cmbClassFilter.SelectedIndex = 0;

            this.studentsTableAdapter.Fill(this.schoolClubsDBDataSet.students);
            dataGridView1.DataSource = studentsBindingSource;

            toolStripStatusLabel1.Text = "Фільтри скинуто";
        }

        // Перегляд розкладу учня
        private void btnShowSchedule_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Будь ласка, виберіть учня зі списку", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            string studentName = $"{selectedRow.Cells["last_name"].Value} {selectedRow.Cells["first_name"].Value}";
            int studentId = Convert.ToInt32(selectedRow.Cells["student_id"].Value);

            ShowStudentSchedule(studentId, studentName);
        }

        private void ShowStudentSchedule(int studentId, string studentName)
        {
            string query = $@" 
                SELECT * FROM enrollments e INNER JOIN clubs c ON e.club_id = c.club_id INNER JOIN schedules sc ON c.club_id = sc.club_id  
                WHERE e.student_id = {studentId}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable scheduleTable = new DataTable();
                    adapter.Fill(scheduleTable);
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = scheduleTable;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні розкладу: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Статистика учнів з більш ніж одним гуртком
        private void btnMultipleClubs_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT COUNT(*) as student_count
                FROM (
                    SELECT student_id 
                    FROM enrollments
                    GROUP BY student_id 
                    HAVING COUNT(*) > 1
                ) as multiple_clubs";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    object result = command.ExecuteScalar();

                    MessageBox.Show($"Кількість учнів, які відвідують більше одного гуртка: {result}",
                                  "Статистика",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні статистики: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Фільтрація за класом
        private void cmbClassFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedClass = cmbClassFilter.Text;

            if (selectedClass == "Всі класи")
            {
                studentsBindingSource.RemoveFilter();
            }
            else
            {
                studentsBindingSource.Filter = $"class = '{selectedClass}'";
            }

            toolStripStatusLabel1.Text = $"Клас: {selectedClass}";
        }
        // Пошук в панелі інструментів
        private void btnToolStripSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtToolStripSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                studentsBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Пошук скинуто";
                return;
            }

            string filter = $"last_name LIKE '%{searchText}%' OR " +
                           $"first_name LIKE '%{searchText}%' OR " +
                           $"patronymic LIKE '%{searchText}%' OR " +
                           $"class LIKE '%{searchText}%' OR " +
                           $"parent_phone LIKE '%{searchText}%' OR " +
                           $"email LIKE '%{searchText}%'";

            studentsBindingSource.Filter = filter;
            toolStripStatusLabel1.Text = $"Знайдено за запитом: '{searchText}'";
        }

        // Очищення пошуку в панелі інструментів
        private void btnToolStripClearSearch_Click(object sender, EventArgs e)
        {
            txtToolStripSearch.Text = "";
            studentsBindingSource.RemoveFilter();
            toolStripStatusLabel1.Text = "Пошук скинуто";
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}