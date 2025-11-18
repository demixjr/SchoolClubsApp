using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;

namespace SchoolClubsApp
{
    public partial class ClubsForm : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=SchoolClubsDB;Integrated Security=True;";

        public ClubsForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.clubsTableAdapter.Update(this.schoolClubsDBDataSet.clubs);
                MessageBox.Show("Дані успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 547) // Код помилки конфлікту зовнішнього ключа
                {
                    MessageBox.Show("Не можна видалити гурток, оскільки в ньому є учні.\n\n" +
                                   "Спочатку видаліть всіх учнів з цього гуртка.",
                                   "Помилка видалення",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);

                    this.schoolClubsDBDataSet.clubs.RejectChanges();
                    this.clubsTableAdapter.Fill(this.schoolClubsDBDataSet.clubs);
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

        private void ClubsForm_Load(object sender, EventArgs e)
        {
            this.clubsTableAdapter.Fill(this.schoolClubsDBDataSet.clubs);

            // Заповнення комбобоксів
            cmbSortField.Items.AddRange(new string[] { "club_name", "age_restrictions", "max_students", "teacher_id" });
            cmbFilterField.Items.AddRange(new string[] { "club_id", "club_name", "age_restrictions", "teacher_id" });
            cmbAggregateField.Items.AddRange(new string[] { "club_id", "max_students" });
            cmbGroupField.Items.AddRange(new string[] { "club_name", "age_restrictions" });

            cmbSortOrder.Items.AddRange(new string[] { "ASC", "DESC" });
            cmbAggregateFunction.Items.AddRange(new string[] { "COUNT", "MAX", "MIN", "AVG" });

            // Заповнення комбобоксів для фільтрації
            LoadAgeRestrictions();
            LoadTeachers();

            // Встановлення значень за замовчуванням
            cmbSortField.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            cmbFilterField.SelectedIndex = 0;
            cmbAggregateField.SelectedIndex = 0;
            cmbAggregateFunction.SelectedIndex = 0;
            cmbGroupField.SelectedIndex = 0;
            cmbAgeFilter.SelectedIndex = 0;
            cmbTeacherFilter.SelectedIndex = 0;
        }

        private void LoadAgeRestrictions()
        {
            string query = "SELECT DISTINCT age_restrictions FROM clubs WHERE age_restrictions IS NOT NULL ORDER BY age_restrictions";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cmbAgeFilter.Items.Add("Всі вікові групи");
                    while (reader.Read())
                    {
                        cmbAgeFilter.Items.Add(reader["age_restrictions"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження вікових обмежень: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadTeachers()
        {
            string query = "SELECT teacher_id, last_name + ' ' + first_name as teacher_name FROM teachers ORDER BY last_name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cmbTeacherFilter.Items.Add("Всі викладачі");
                    while (reader.Read())
                    {
                        cmbTeacherFilter.Items.Add(new
                        {
                            Text = reader["teacher_name"].ToString(),
                            Value = reader["teacher_id"]
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження викладачів: " + ex.Message, "Помилка",
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
                string query = $"SELECT * FROM clubs ORDER BY {field} {order}";
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
            if (field == "club_id" || field == "teacher_id" || field == "max_students")
            {
                if (!string.IsNullOrEmpty(minValue) && !string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM clubs WHERE {field} BETWEEN {minValue} AND {maxValue}";
                }
                else if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM clubs WHERE {field} >= {minValue}";
                }
                else if (!string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM clubs WHERE {field} <= {maxValue}";
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
                    query = $"SELECT * FROM clubs WHERE {field} LIKE '%{minValue}%'";
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
                string query = $"SELECT {function}({field}) as Result FROM clubs";

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
                        else if (function == "AVG")
                        {
                            functionName = "Середнє значення";
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
                string query = $"SELECT * FROM clubs WHERE {groupField} LIKE '%{conditionValue}%'";
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
            cmbAgeFilter.SelectedIndex = 0;
            cmbTeacherFilter.SelectedIndex = 0;

            this.clubsTableAdapter.Fill(this.schoolClubsDBDataSet.clubs);
            dataGridView1.DataSource = clubsBindingSource;

            toolStripStatusLabel1.Text = "Фільтри скинуто";
        }

        // Експорт даних
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV файл (*.csv)|*.csv";
                saveFileDialog.Title = "Експорт даних гуртків";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder();

                    csv.AppendLine("ID,Назва,Опис,Вікові обмеження,Макс. студентів,ID викладача");

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            csv.AppendLine($"{row.Cells[0].Value}," +
                                         $"{row.Cells[1].Value}," +
                                         $"{row.Cells[2].Value}," +
                                         $"{row.Cells[3].Value}," +
                                         $"{row.Cells[4].Value}," +
                                         $"{row.Cells[5].Value}");
                        }
                    }

                    System.IO.File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);
                    MessageBox.Show("Дані успішно експортовано", "Успіх",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при експорті: " + ex.Message, "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Перегляд вільних місць
        private void btnShowFreeSlots_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Будь ласка, виберіть гурток зі списку", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            string clubName = selectedRow.Cells["club_name"].Value.ToString();
            int clubId = Convert.ToInt32(selectedRow.Cells["club_id"].Value);
            int maxStudents = Convert.ToInt32(selectedRow.Cells["max_students"].Value);

            ShowFreeSlots(clubId, clubName, maxStudents);
        }

        private void ShowFreeSlots(int clubId, string clubName, int maxStudents)
        {
            string query = $@"
                SELECT COUNT(*) as current_students
                FROM student_clubs 
                WHERE club_id = {clubId}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    int currentStudents = Convert.ToInt32(command.ExecuteScalar());
                    int freeSlots = maxStudents - currentStudents;

                    string message = $"Гурток: {clubName}\n\n";
                    message += $"Максимальна кількість студентів: {maxStudents}\n";
                    message += $"Поточна кількість студентів: {currentStudents}\n";
                    message += $"Вільних місць: {freeSlots}";

                    MessageBox.Show(message, "Вільні місця",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні даних: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Пошук популярних гуртків
        private void btnPopularClubs_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT c.club_id, c.club_name, c.description, c.age_restrictions, 
                       c.max_students, c.teacher_id, 
                       COUNT(sc.student_id) as student_count,
                       t.last_name + ' ' + t.first_name as teacher_name
                FROM clubs c
                LEFT JOIN student_clubs sc ON c.club_id = sc.club_id
                INNER JOIN teachers t ON c.teacher_id = t.teacher_id
                GROUP BY c.club_id, c.club_name, c.description, c.age_restrictions, 
                         c.max_students, c.teacher_id, t.last_name, t.first_name
                ORDER BY student_count DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable popularClubsTable = new DataTable();
                    adapter.Fill(popularClubsTable);

                    // Створюємо нову таблицю для відображення
                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("ID", typeof(int));
                    displayTable.Columns.Add("Назва", typeof(string));
                    displayTable.Columns.Add("Викладач", typeof(string));
                    displayTable.Columns.Add("Кількість студентів", typeof(int));
                    displayTable.Columns.Add("Макс. студентів", typeof(int));

                    foreach (DataRow row in popularClubsTable.Rows)
                    {
                        displayTable.Rows.Add(
                            row["club_id"],
                            row["club_name"],
                            row["teacher_name"],
                            row["student_count"],
                            row["max_students"]
                        );
                    }

                    dataGridView1.DataSource = displayTable;
                    toolStripStatusLabel1.Text = "Популярні гуртки (за кількістю студентів)";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні популярних гуртків: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Фільтрація за віковими обмеженнями
        private void cmbAgeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Фільтрація за викладачем
        private void cmbTeacherFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string ageFilter = "";
            string teacherFilter = "";

            // Фільтр за віковими обмеженнями
            if (cmbAgeFilter.SelectedIndex > 0)
            {
                string selectedAge = cmbAgeFilter.Text;
                ageFilter = $"age_restrictions = '{selectedAge}'";
            }

            // Фільтр за викладачем
            if (cmbTeacherFilter.SelectedIndex > 0)
            {
                string selectedTeacher = cmbTeacherFilter.Text;
                // Тут потрібно отримати ID викладача з об'єкта
                // Для спрощення використовуємо текстовий пошук
                teacherFilter = $"teacher_id IN (SELECT teacher_id FROM teachers WHERE last_name + ' ' + first_name LIKE '%{selectedTeacher.Split(' ')[0]}%')";
            }

            // Комбінуємо фільтри
            string finalFilter = "";
            if (!string.IsNullOrEmpty(ageFilter) && !string.IsNullOrEmpty(teacherFilter))
            {
                finalFilter = $"{ageFilter} AND {teacherFilter}";
            }
            else if (!string.IsNullOrEmpty(ageFilter))
            {
                finalFilter = ageFilter;
            }
            else if (!string.IsNullOrEmpty(teacherFilter))
            {
                finalFilter = teacherFilter;
            }

            if (!string.IsNullOrEmpty(finalFilter))
            {
                clubsBindingSource.Filter = finalFilter;
                toolStripStatusLabel1.Text = "Застосовано фільтри";
            }
            else
            {
                clubsBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Фільтри скинуто";
            }
        }

        // Пошук в панелі інструментів
        private void btnToolStripSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtToolStripSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                clubsBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Пошук скинуто";
                return;
            }

            string filter = $"club_name LIKE '%{searchText}%' OR " +
                           $"description LIKE '%{searchText}%' OR " +
                           $"age_restrictions LIKE '%{searchText}%'";

            // Додаємо пошук за іменем викладача
            filter += $" OR teacher_id IN (SELECT teacher_id FROM teachers WHERE last_name + ' ' + first_name LIKE '%{searchText}%')";

            clubsBindingSource.Filter = filter;
            toolStripStatusLabel1.Text = $"Знайдено за запитом: '{searchText}'";
        }

        // Очищення пошуку в панелі інструментів
        private void btnToolStripClearSearch_Click(object sender, EventArgs e)
        {
            txtToolStripSearch.Text = "";
            clubsBindingSource.RemoveFilter();
            toolStripStatusLabel1.Text = "Пошук скинуто";
        }
    }
}