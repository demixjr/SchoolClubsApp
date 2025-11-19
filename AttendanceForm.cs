using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace SchoolClubsApp
{
    public partial class AttendanceForm : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=SchoolClubsDB;Integrated Security=True;";

        public AttendanceForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.attendanceTableAdapter.Update(this.schoolClubsDBDataSet.attendance);
                MessageBox.Show("Дані успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 2627) // Код помилки унікального обмеження
                {
                    MessageBox.Show("Не можна додати запис: відвідування для цього учня в цей день вже існує.\n\n" +
                                   "Кожен учень може мати лише один запис відвідування на день.",
                                   "Помилка додавання",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);

                    this.schoolClubsDBDataSet.attendance.RejectChanges();
                    this.attendanceTableAdapter.Fill(this.schoolClubsDBDataSet.attendance);
                }
                else if (ex.Number == 547) // Код помилки зовнішнього ключа
                {
                    MessageBox.Show("Помилка зовнішнього ключа: перевірте правильність ID запису.",
                                   "Помилка",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
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

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            this.attendanceTableAdapter.Fill(this.schoolClubsDBDataSet.attendance);

            // Заповнення комбобоксів
            cmbSortField.Items.AddRange(new string[] { "lesson_date", "status", "enrollment_id" });
            cmbFilterField.Items.AddRange(new string[] { "attendance_id", "enrollment_id" });
            cmbAggregateField.Items.AddRange(new string[] { "attendance_id" });
            cmbGroupField.Items.AddRange(new string[] { "enrollment_id" });

            cmbSortOrder.Items.AddRange(new string[] { "ASC", "DESC" });
            cmbAggregateFunction.Items.AddRange(new string[] { "COUNT", "MAX", "MIN" });

            // Заповнення комбобоксів для фільтрації
            LoadStatusFilter();
            LoadDateFilters();

            // Встановлення значень за замовчуванням
            cmbSortField.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            cmbFilterField.SelectedIndex = 0;
            cmbAggregateField.SelectedIndex = 0;
            cmbAggregateFunction.SelectedIndex = 0;
            cmbGroupField.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;
            cmbMonthFilter.SelectedIndex = 0;
        }

        private void LoadStatusFilter()
        {
            cmbStatusFilter.Items.Add("Всі статуси");
            cmbStatusFilter.Items.Add("відвідав");
            cmbStatusFilter.Items.Add("пропустив");
        }


        private void LoadDateFilters()
        {
            cmbMonthFilter.Items.Add("Весь період");
            cmbMonthFilter.Items.Add("Поточний місяць");
            cmbMonthFilter.Items.Add("Минулий місяць");
            cmbMonthFilter.Items.Add("Останні 3 місяці");
            cmbMonthFilter.Items.Add("Останні 6 місяців");
        }

        // Сортування
        private void btnSort_Click(object sender, EventArgs e)
        {
            string field = cmbSortField.Text;
            string order = cmbSortOrder.Text;

            if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(order))
            {
                string query = $"SELECT * FROM attendance ORDER BY {field} {order}";
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
            if (field == "attendance_id" || field == "enrollment_id")
            {
                if (!string.IsNullOrEmpty(minValue) && !string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM attendance WHERE {field} BETWEEN {minValue} AND {maxValue}";
                }
                else if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM attendance WHERE {field} >= {minValue}";
                }
                else if (!string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM attendance WHERE {field} <= {maxValue}";
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть мінімальне або максимальне значення", "Попередження",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (field == "lesson_date")
            {
                if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM attendance WHERE {field} >= '{minValue}'";
                    if (!string.IsNullOrEmpty(maxValue))
                    {
                        query += $" AND {field} <= '{maxValue}'";
                    }
                }
                else if (!string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM attendance WHERE {field} <= '{maxValue}'";
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть дату для фільтрації", "Попередження",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM attendance WHERE {field} LIKE '%{minValue}%'";
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
                string query = $"SELECT {function}({field}) as Result FROM attendance";

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
                string query = $"SELECT * FROM attendance WHERE {groupField} LIKE '%{conditionValue}%'";
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
            cmbStatusFilter.SelectedIndex = 0;
            cmbMonthFilter.SelectedIndex = 0;

            this.attendanceTableAdapter.Fill(this.schoolClubsDBDataSet.attendance);
            dataGridView1.DataSource = attendanceBindingSource;

            toolStripStatusLabel1.Text = "Фільтри скинуто";
        }


        // Статистика відвідуваності за гуртком
        private void btnClubAttendance_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            ShowClubAttendanceStats(id);
        }

        private void ShowClubAttendanceStats(int id)
        {
            string query = $@"
        SELECT 
            c.club_name,
            COUNT(*) as total_lessons,
            SUM(CASE WHEN a.status = 'відвідав' THEN 1 ELSE 0 END) as attended_lessons,
            SUM(CASE WHEN a.status = 'пропустив' THEN 1 ELSE 0 END) as missed_lessons,
            CAST(SUM(CASE WHEN a.status = 'відвідав' THEN 1 ELSE 0 END) * 100.0 / COUNT(*) as DECIMAL(5,2)) as attendance_percentage
        FROM attendance a
        INNER JOIN enrollments e ON a.enrollment_id = e.enrollment_id
        INNER JOIN clubs c ON e.club_id = c.club_id
        WHERE c.club_id = {id}
        GROUP BY c.club_id, c.club_name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string clubName = reader.IsDBNull(0) ? "Невідомий гурток" : reader.GetString(0);
                        int totalLessons = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        int attendedLessons = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        int missedLessons = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        decimal attendancePercentage = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);

                        string message = $"Статистика відвідуваності для гуртка: {clubName}\n\n";
                        message += $"Період: {cmbMonthFilter.Text}\n";
                        message += $"Загальна кількість занять: {totalLessons}\n";
                        message += $"Відвідано занять: {attendedLessons}\n";
                        message += $"Пропущено занять: {missedLessons}\n";
                        message += $"Відсоток відвідуваності: {attendancePercentage}%";

                        MessageBox.Show(message, "Статистика відвідуваності",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні статистики: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetPeriodFilter()
        {
            string periodFilter = "";
            DateTime now = DateTime.Now;

            switch (cmbMonthFilter.SelectedIndex)
            {
                case 1: // Поточний місяць
                    periodFilter = $"AND a.lesson_date >= '{new DateTime(now.Year, now.Month, 1):yyyy-MM-dd}'";
                    break;
                case 2: // Минулий місяць
                    DateTime firstDayLastMonth = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
                    DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1).AddDays(-1);
                    periodFilter = $"AND a.lesson_date BETWEEN '{firstDayLastMonth:yyyy-MM-dd}' AND '{lastDayLastMonth:yyyy-MM-dd}'";
                    break;
                case 3: // Останні 3 місяці
                    periodFilter = $"AND a.lesson_date >= '{now.AddMonths(-3):yyyy-MM-dd}'";
                    break;
                case 4: // Останні 6 місяців
                    periodFilter = $"AND a.lesson_date >= '{now.AddMonths(-6):yyyy-MM-dd}'";
                    break;
            }

            return periodFilter;
        }


        // Фільтрація за статусом
        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Фільтрація за гуртком
        private void cmbClubFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Фільтрація за періодом
        private void cmbMonthFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string statusFilter = "";
            string clubFilter = "";
            string periodFilter = "";

            // Фільтр за статусом
            if (cmbStatusFilter.SelectedIndex > 0)
            {
                string selectedStatus = cmbStatusFilter.Text;
                statusFilter = $"status = '{selectedStatus}'";
            }


            // Фільтр за періодом
            if (cmbMonthFilter.SelectedIndex > 0)
            {
                periodFilter = GetPeriodFilter().Replace("a.", "");
            }

            // Комбінуємо фільтри
            string finalFilter = "";
            if (!string.IsNullOrEmpty(statusFilter))
            {
                finalFilter = statusFilter;
            }
            if (!string.IsNullOrEmpty(clubFilter))
            {
                finalFilter += (string.IsNullOrEmpty(finalFilter) ? "" : " AND ") + clubFilter;
            }
            if (!string.IsNullOrEmpty(periodFilter))
            {
                finalFilter += (string.IsNullOrEmpty(finalFilter) ? "" : " AND ") + periodFilter;
            }

            if (!string.IsNullOrEmpty(finalFilter))
            {
                attendanceBindingSource.Filter = finalFilter;
                toolStripStatusLabel1.Text = "Застосовано фільтри";
            }
            else
            {
                attendanceBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Фільтри скинуто";
            }
        }

        // Пошук в панелі інструментів
        private void btnToolStripSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtToolStripSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                attendanceBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Пошук скинуто";
                return;
            }

            string filter = $"status LIKE '%{searchText}%' OR " +
                           $"lesson_date LIKE '%{searchText}%'";

            // Додаємо пошук за іменем учня та назвою гуртка
            filter += $" OR enrollment_id IN (SELECT e.enrollment_id FROM enrollments e INNER JOIN students s ON e.student_id = s.student_id WHERE s.last_name + ' ' + s.first_name LIKE '%{searchText}%')";
            filter += $" OR enrollment_id IN (SELECT e.enrollment_id FROM enrollments e INNER JOIN clubs c ON e.club_id = c.club_id WHERE c.club_name LIKE '%{searchText}%')";

            attendanceBindingSource.Filter = filter;
            toolStripStatusLabel1.Text = $"Знайдено за запитом: '{searchText}'";
        }

        // Очищення пошуку в панелі інструментів
        private void btnToolStripClearSearch_Click(object sender, EventArgs e)
        {
            txtToolStripSearch.Text = "";
            attendanceBindingSource.RemoveFilter();
            toolStripStatusLabel1.Text = "Пошук скинуто";
        }

        // Масове оновлення статусу
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            using (StatusUpdateForm statusForm = new StatusUpdateForm())
            {
                if (statusForm.ShowDialog() == DialogResult.OK)
                {
                    string newStatus = statusForm.SelectedStatus;
                    UpdateAttendanceStatus(newStatus);
                }
            }
        }

        private void UpdateAttendanceStatus(string newStatus)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть записи для оновлення статусу", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            int attendanceId = Convert.ToInt32(row.Cells["attendance_id"].Value);
                            string query = $"UPDATE attendance SET status = '{newStatus}' WHERE attendance_id = {attendanceId}";

                            SqlCommand command = new SqlCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Оновлюємо дані
                    this.attendanceTableAdapter.Fill(this.schoolClubsDBDataSet.attendance);
                    MessageBox.Show("Статус відвідуваності успішно оновлено", "Успіх",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при оновленні статусу: " + ex.Message, "Помилка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}