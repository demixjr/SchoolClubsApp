using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;

namespace SchoolClubsApp
{
    public partial class SchedulesForm : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=SchoolClubsDB;Integrated Security=True;";

        public SchedulesForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.schedulesTableAdapter.Update(this.schoolClubsDBDataSet.schedules);
                MessageBox.Show("Дані успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 2627) // Код помилки унікального обмеження
                {
                    MessageBox.Show("Не можна додати розклад з однаковим гуртком, днем тижня та часом початку.\n\n" +
                                   "Цей гурток вже має заняття у вказаний час.",
                                   "Помилка додавання",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);

                    this.schoolClubsDBDataSet.schedules.RejectChanges();
                    this.schedulesTableAdapter.Fill(this.schoolClubsDBDataSet.schedules);
                }
                else if (ex.Number == 547) // Код помилки зовнішнього ключа
                {
                    MessageBox.Show("Помилка зовнішнього ключа: перевірте правильність ID гуртка.",
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

        private void SchedulesForm_Load(object sender, EventArgs e)
        {
            this.schedulesTableAdapter.Fill(this.schoolClubsDBDataSet.schedules);

            // Заповнення комбобоксів
            cmbSortField.Items.AddRange(new string[] { "day_of_week", "start_time", "end_time", "room", "club_id" });
            cmbFilterField.Items.AddRange(new string[] { "schedule_id", "club_id", "day_of_week", "room" });
            cmbAggregateField.Items.AddRange(new string[] { "schedule_id" });
            cmbGroupField.Items.AddRange(new string[] { "day_of_week", "room", "club_id" });

            cmbSortOrder.Items.AddRange(new string[] { "ASC", "DESC" });
            cmbAggregateFunction.Items.AddRange(new string[] { "COUNT", "MAX", "MIN" });

            // Заповнення комбобоксів для фільтрації
            LoadDaysOfWeek();
            LoadClubs();
            LoadRooms();

            // Встановлення значень за замовчуванням
            cmbSortField.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            cmbFilterField.SelectedIndex = 0;
            cmbAggregateField.SelectedIndex = 0;
            cmbAggregateFunction.SelectedIndex = 0;
            cmbGroupField.SelectedIndex = 0;
            cmbDayFilter.SelectedIndex = 0;
            cmbClubFilter.SelectedIndex = 0;
            cmbRoomFilter.SelectedIndex = 0;
        }

        private void LoadDaysOfWeek()
        {
            string[] days = { "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота" };
            cmbDayFilter.Items.Add("Всі дні");
            cmbDayFilter.Items.AddRange(days);
        }

        private void LoadClubs()
        {
            string query = "SELECT club_id, club_name FROM clubs ORDER BY club_name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cmbClubFilter.Items.Add("Всі гуртки");
                    while (reader.Read())
                    {
                        cmbClubFilter.Items.Add(new
                        {
                            Text = reader["club_name"].ToString(),
                            Value = reader["club_id"]
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження гуртків: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRooms()
        {
            string query = "SELECT DISTINCT room FROM schedules ORDER BY room";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cmbRoomFilter.Items.Add("Всі приміщення");
                    while (reader.Read())
                    {
                        cmbRoomFilter.Items.Add(reader["room"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження приміщень: " + ex.Message, "Помилка",
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
                // Спеціальна логіка сортування для днів тижня
                if (field == "day_of_week")
                {
                    string query = $@"
                        SELECT * FROM schedules 
                        ORDER BY CASE day_of_week
                            WHEN 'Понеділок' THEN 1
                            WHEN 'Вівторок' THEN 2
                            WHEN 'Середа' THEN 3
                            WHEN 'Четвер' THEN 4
                            WHEN 'П''ятниця' THEN 5
                            WHEN 'Субота' THEN 6
                        END {order}, start_time {order}";
                    ExecuteQueryAndDisplay(query);
                }
                else
                {
                    string query = $"SELECT * FROM schedules ORDER BY {field} {order}";
                    ExecuteQueryAndDisplay(query);
                }
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
            if (field == "schedule_id" || field == "club_id")
            {
                if (!string.IsNullOrEmpty(minValue) && !string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM schedules WHERE {field} BETWEEN {minValue} AND {maxValue}";
                }
                else if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM schedules WHERE {field} >= {minValue}";
                }
                else if (!string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM schedules WHERE {field} <= {maxValue}";
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
                    query = $"SELECT * FROM schedules WHERE {field} LIKE '%{minValue}%'";
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
                string query = $"SELECT {function}({field}) as Result FROM schedules";

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
                string query = $"SELECT * FROM schedules WHERE {groupField} LIKE '%{conditionValue}%'";
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
            cmbDayFilter.SelectedIndex = 0;
            cmbClubFilter.SelectedIndex = 0;
            cmbRoomFilter.SelectedIndex = 0;

            this.schedulesTableAdapter.Fill(this.schoolClubsDBDataSet.schedules);
            dataGridView1.DataSource = schedulesBindingSource;

            toolStripStatusLabel1.Text = "Фільтри скинуто";
        }

        // Експорт даних
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV файл (*.csv)|*.csv";
                saveFileDialog.Title = "Експорт даних розкладу";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder();

                    csv.AppendLine("ID,ID гуртка,День тижня,Час початку,Час завершення,Приміщення");

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

        // Перегляд розкладу для учня
        private void btnShowStudentSchedule_Click(object sender, EventArgs e)
        {
            using (StudentSelectionForm studentForm = new StudentSelectionForm())
            {
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    int studentId = studentForm.SelectedStudentId;
                    string studentName = studentForm.SelectedStudentName;
                    ShowStudentFullSchedule(studentId, studentName);
                }
            }
        }

        private void ShowStudentFullSchedule(int studentId, string studentName)
        {
            string query = $@"
                SELECT 
                    s.day_of_week,
                    s.start_time,
                    s.end_time,
                    s.room,
                    c.club_name,
                    t.last_name + ' ' + t.first_name as teacher_name
                FROM schedules s
                INNER JOIN clubs c ON s.club_id = c.club_id
                INNER JOIN teachers t ON c.teacher_id = t.teacher_id
                INNER JOIN student_clubs sc ON c.club_id = sc.club_id
                WHERE sc.student_id = {studentId}
                ORDER BY 
                    CASE s.day_of_week
                        WHEN 'Понеділок' THEN 1
                        WHEN 'Вівторок' THEN 2
                        WHEN 'Середа' THEN 3
                        WHEN 'Четвер' THEN 4
                        WHEN 'П''ятниця' THEN 5
                        WHEN 'Субота' THEN 6
                    END,
                    s.start_time";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable scheduleTable = new DataTable();
                    adapter.Fill(scheduleTable);

                    string message = $"Повний розклад занять для учня: {studentName}\n\n";

                    if (scheduleTable.Rows.Count > 0)
                    {
                        string currentDay = "";
                        foreach (DataRow row in scheduleTable.Rows)
                        {
                            string day = row["day_of_week"].ToString();
                            if (day != currentDay)
                            {
                                message += $"\n{day}:\n";
                                currentDay = day;
                            }

                            TimeSpan startTime = (TimeSpan)row["start_time"];
                            TimeSpan endTime = (TimeSpan)row["end_time"];

                            message += $"  {startTime:hh\\:mm} - {endTime:hh\\:mm}";
                            message += $" | {row["club_name"]}";
                            message += $" | {row["teacher_name"]}";
                            message += $" | {row["room"]}\n";
                        }
                    }
                    else
                    {
                        message += "Учень не має жодних занять у гуртках.";
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

        // Фільтрація за днем тижня
        private void cmbDayFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Фільтрація за гуртком
        private void cmbClubFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Фільтрація за приміщенням
        private void cmbRoomFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string dayFilter = "";
            string clubFilter = "";
            string roomFilter = "";

            // Фільтр за днем тижня
            if (cmbDayFilter.SelectedIndex > 0)
            {
                string selectedDay = cmbDayFilter.Text;
                dayFilter = $"day_of_week = '{selectedDay}'";
            }

            // Фільтр за гуртком
            if (cmbClubFilter.SelectedIndex > 0)
            {
                string selectedClub = cmbClubFilter.Text;
                clubFilter = $"club_id IN (SELECT club_id FROM clubs WHERE club_name LIKE '%{selectedClub.Split(' ')[0]}%')";
            }

            // Фільтр за приміщенням
            if (cmbRoomFilter.SelectedIndex > 0)
            {
                string selectedRoom = cmbRoomFilter.Text;
                roomFilter = $"room = '{selectedRoom}'";
            }

            // Комбінуємо фільтри
            string finalFilter = "";
            if (!string.IsNullOrEmpty(dayFilter))
            {
                finalFilter = dayFilter;
            }
            if (!string.IsNullOrEmpty(clubFilter))
            {
                finalFilter += (string.IsNullOrEmpty(finalFilter) ? "" : " AND ") + clubFilter;
            }
            if (!string.IsNullOrEmpty(roomFilter))
            {
                finalFilter += (string.IsNullOrEmpty(finalFilter) ? "" : " AND ") + roomFilter;
            }

            if (!string.IsNullOrEmpty(finalFilter))
            {
                schedulesBindingSource.Filter = finalFilter;
                toolStripStatusLabel1.Text = "Застосовано фільтри";
            }
            else
            {
                schedulesBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Фільтри скинуто";
            }
        }

        // Пошук в панелі інструментів
        private void btnToolStripSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtToolStripSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                schedulesBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Пошук скинуто";
                return;
            }

            string filter = $"day_of_week LIKE '%{searchText}%' OR " +
                           $"room LIKE '%{searchText}%' OR " +
                           $"start_time LIKE '%{searchText}%' OR " +
                           $"end_time LIKE '%{searchText}%'";

            // Додаємо пошук за назвою гуртка
            filter += $" OR club_id IN (SELECT club_id FROM clubs WHERE club_name LIKE '%{searchText}%')";

            schedulesBindingSource.Filter = filter;
            toolStripStatusLabel1.Text = $"Знайдено за запитом: '{searchText}'";
        }

        // Очищення пошуку в панелі інструментів
        private void btnToolStripClearSearch_Click(object sender, EventArgs e)
        {
            txtToolStripSearch.Text = "";
            schedulesBindingSource.RemoveFilter();
            toolStripStatusLabel1.Text = "Пошук скинуто";
        }

        // Перегляд тижневого розкладу
        private void btnWeeklySchedule_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    s.day_of_week,
                    s.start_time,
                    s.end_time,
                    s.room,
                    c.club_name,
                    t.last_name + ' ' + t.first_name as teacher_name
                FROM schedules s
                INNER JOIN clubs c ON s.club_id = c.club_id
                INNER JOIN teachers t ON c.teacher_id = t.teacher_id
                ORDER BY 
                    CASE s.day_of_week
                        WHEN 'Понеділок' THEN 1
                        WHEN 'Вівторок' THEN 2
                        WHEN 'Середа' THEN 3
                        WHEN 'Четвер' THEN 4
                        WHEN 'П''ятниця' THEN 5
                        WHEN 'Субота' THEN 6
                    END,
                    s.start_time";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable weeklyScheduleTable = new DataTable();
                    adapter.Fill(weeklyScheduleTable);

                    // Створюємо нову таблицю для відображення
                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("День", typeof(string));
                    displayTable.Columns.Add("Час", typeof(string));
                    displayTable.Columns.Add("Гурток", typeof(string));
                    displayTable.Columns.Add("Викладач", typeof(string));
                    displayTable.Columns.Add("Приміщення", typeof(string));

                    foreach (DataRow row in weeklyScheduleTable.Rows)
                    {
                        TimeSpan startTime = (TimeSpan)row["start_time"];
                        TimeSpan endTime = (TimeSpan)row["end_time"];

                        displayTable.Rows.Add(
                            row["day_of_week"],
                            $"{startTime:hh\\:mm} - {endTime:hh\\:mm}",
                            row["club_name"],
                            row["teacher_name"],
                            row["room"]
                        );
                    }

                    dataGridView1.DataSource = displayTable;
                    toolStripStatusLabel1.Text = "Тижневий розклад занять";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні тижневого розкладу: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }
    }

    // Допоміжна форма для вибору учня
    public class StudentSelectionForm : Form
    {
        private ComboBox cmbStudents;
        private Button btnOK;
        private Button btnCancel;

        public int SelectedStudentId { get; private set; }
        public string SelectedStudentName { get; private set; }

        public StudentSelectionForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void InitializeComponent()
        {
            this.cmbStudents = new ComboBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // ComboBox
            this.cmbStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Location = new System.Drawing.Point(20, 20);
            this.cmbStudents.Size = new System.Drawing.Size(300, 24);
            this.cmbStudents.TabIndex = 0;

            // OK Button
            this.btnOK.Location = new System.Drawing.Point(20, 60);
            this.btnOK.Size = new System.Drawing.Size(140, 30);
            this.btnOK.Text = "OK";
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Click += new EventHandler(btnOK_Click);

            // Cancel Button
            this.btnCancel.Location = new System.Drawing.Point(180, 60);
            this.btnCancel.Size = new System.Drawing.Size(140, 30);
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.DialogResult = DialogResult.Cancel;

            // Form
            this.ClientSize = new System.Drawing.Size(340, 110);
            this.Controls.AddRange(new Control[] { this.cmbStudents, this.btnOK, this.btnCancel });
            this.Text = "Виберіть учня";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            this.ResumeLayout(false);
        }

        private void LoadStudents()
        {
            string connectionString = @"Data Source=.;Initial Catalog=SchoolClubsDB;Integrated Security=True;";
            string query = "SELECT student_id, last_name + ' ' + first_name as student_name FROM students ORDER BY last_name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbStudents.Items.Add(new
                        {
                            Text = reader["student_name"].ToString(),
                            Value = reader["student_id"]
                        });
                    }
                    reader.Close();

                    if (cmbStudents.Items.Count > 0)
                        cmbStudents.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження учнів: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedItem != null)
            {
                dynamic selectedItem = cmbStudents.SelectedItem;
                SelectedStudentId = selectedItem.Value;
                SelectedStudentName = selectedItem.Text;
            }
        }
    }
}