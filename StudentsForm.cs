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

            // Заповнення комбобоксів
            cmbSortField.Items.AddRange(new string[] { "last_name", "first_name", "class", "parent_phone" });
            cmbFilterField.Items.AddRange(new string[] { "student_id", "last_name", "class" });
            cmbAggregateField.Items.AddRange(new string[] { "student_id" });
            cmbGroupField.Items.AddRange(new string[] { "last_name", "first_name", "class" });

            cmbSortOrder.Items.AddRange(new string[] { "ASC", "DESC" });
            cmbAggregateFunction.Items.AddRange(new string[] { "COUNT", "MAX", "MIN" });

            // Заповнення комбобоксу для фільтрації за класом
            cmbClassFilter.Items.Add("Всі класи");
            LoadClasses();

            // Встановлення значень за замовчуванням
            cmbSortField.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            cmbFilterField.SelectedIndex = 0;
            cmbAggregateField.SelectedIndex = 0;
            cmbAggregateFunction.SelectedIndex = 0;
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

        // Фільтрація
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string field = cmbFilterField.Text;
            string minValue = txtMinValue.Text;
            string maxValue = txtMaxValue.Text;

            if (string.IsNullOrEmpty(field))
            {
                MessageBox.Show("Будь ласка, виберіть поле для фільтрації", "Попередження",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;
            if (field == "student_id")
            {
                if (!string.IsNullOrEmpty(minValue) && !string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM students WHERE {field} BETWEEN {minValue} AND {maxValue}";
                }
                else if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM students WHERE {field} >= {minValue}";
                }
                else if (!string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM students WHERE {field} <= {maxValue}";
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть мінімальне або максимальне значення", "Попередження",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM students WHERE {field} LIKE '%{minValue}%'";
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть значення для пошуку", "Попередження",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            ExecuteQueryAndDisplay(query);
        }

        // Агрегатні функції
        private void btnAggregate_Click(object sender, EventArgs e)
        {
            string field = cmbAggregateField.Text;
            string function = cmbAggregateFunction.Text;

            if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(function))
            {
                string query = $"SELECT {function}({field}) as Result FROM students";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        object result = command.ExecuteScalar();

                        string functionName;
                        if (function == "COUNT")
                        {
                            functionName = "Кількість";
                        }
                        else if (function == "MAX")
                        {
                            functionName = "Максимальне значення";
                        }
                        else if (function == "MIN")
                        {
                            functionName = "Мінімальне значення";
                        }
                        else
                        {
                            functionName = function;
                        }

                        MessageBox.Show($"{functionName}: {result}", "Результат агрегатної функції",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка: " + ex.Message, "Помилка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть поле та агрегатну функцію", "Попередження",
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
            txtMinValue.Text = "";
            txtMaxValue.Text = "";
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
                SELECT c.club_name, c.description, c.schedule, t.last_name + ' ' + t.first_name as teacher_name
                FROM clubs c 
                INNER JOIN student_clubs sc ON c.club_id = sc.club_id 
                INNER JOIN teachers t ON c.teacher_id = t.teacher_id
                WHERE sc.student_id = {studentId}
                ORDER BY c.schedule";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable scheduleTable = new DataTable();
                    adapter.Fill(scheduleTable);

                    string message = $"Учень: {studentName}\n\n";

                    if (scheduleTable.Rows.Count > 0)
                    {
                        message += "Повний розклад занять:\n\n";
                        foreach (DataRow row in scheduleTable.Rows)
                        {
                            message += $"• {row["club_name"]}\n";
                            message += $"  Викладач: {row["teacher_name"]}\n";
                            message += $"  Опис: {row["description"]}\n";
                            message += $"  Розклад: {row["schedule"]}\n\n";
                        }
                    }
                    else
                    {
                        message += "Учень не записаний до жодного гуртка.";
                    }

                    MessageBox.Show(message, "Розклад учня",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні розкладу: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Пошук учнів без гуртків
        private void btnFindWithoutClubs_Click(object sender, EventArgs e)
        {
            string selectedClass = cmbClassFilter.Text;
            string query;

            if (selectedClass == "Всі класи")
            {
                query = @"
                    SELECT s.* 
                    FROM students s 
                    LEFT JOIN student_clubs sc ON s.student_id = sc.student_id 
                    WHERE sc.student_id IS NULL";
            }
            else
            {
                query = $@"
                    SELECT s.* 
                    FROM students s 
                    LEFT JOIN student_clubs sc ON s.student_id = sc.student_id 
                    WHERE sc.student_id IS NULL AND s.class = '{selectedClass}'";
            }

            ExecuteQueryAndDisplay(query);
            toolStripStatusLabel1.Text = $"Учні {selectedClass} без гуртків";
        }

        // Статистика учнів з більш ніж одним гуртком
        private void btnMultipleClubs_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT COUNT(*) as student_count
                FROM (
                    SELECT student_id 
                    FROM student_clubs 
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
    }
}