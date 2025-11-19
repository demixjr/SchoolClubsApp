using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;

namespace SchoolClubsApp
{
    public partial class EnrollmentsForm : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=SchoolClubsDB;Integrated Security=True;";

        public EnrollmentsForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.enrollmentsTableAdapter.Update(this.schoolClubsDBDataSet.enrollments);
                MessageBox.Show("Дані успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 2627) // Код помилки унікального обмеження
                {
                    MessageBox.Show("Не можна додати запис: учень вже записаний до цього гуртка.\n\n" +
                                   "Кожен учень може бути записаний до гуртка лише один раз.",
                                   "Помилка додавання",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);

                    this.schoolClubsDBDataSet.enrollments.RejectChanges();
                    this.enrollmentsTableAdapter.Fill(this.schoolClubsDBDataSet.enrollments);
                }
                else if (ex.Number == 547) // Код помилки зовнішнього ключа
                {
                    MessageBox.Show("Помилка зовнішнього ключа: перевірте правильність ID учня або гуртка.",
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

        private void EnrollmentsForm_Load(object sender, EventArgs e)
        {
            this.enrollmentsTableAdapter.Fill(this.schoolClubsDBDataSet.enrollments);

            // Заповнення комбобоксів
            cmbSortField.Items.AddRange(new string[] { "enrollment_date", "status", "student_id", "club_id" });
            cmbFilterField.Items.AddRange(new string[] { "enrollment_id", "student_id", "club_id", "status" });
            cmbAggregateField.Items.AddRange(new string[] { "enrollment_id" });
            cmbGroupField.Items.AddRange(new string[] { "status", "student_id", "club_id" });

            cmbSortOrder.Items.AddRange(new string[] { "ASC", "DESC" });
            cmbAggregateFunction.Items.AddRange(new string[] { "COUNT", "MAX", "MIN" });

            // Заповнення комбобоксів для фільтрації
            LoadStatusFilter();
            LoadStudents();
            LoadClubs();

            // Встановлення значень за замовчуванням
            cmbSortField.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            cmbFilterField.SelectedIndex = 0;
            cmbAggregateField.SelectedIndex = 0;
            cmbAggregateFunction.SelectedIndex = 0;
            cmbGroupField.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;
            cmbStudentFilter.SelectedIndex = 0;
            cmbClubFilter.SelectedIndex = 0;
        }

        private void LoadStatusFilter()
        {
            cmbStatusFilter.Items.Add("Всі статуси");
            cmbStatusFilter.Items.Add("активний");
            cmbStatusFilter.Items.Add("завершений");
        }

        private void LoadStudents()
        {
            string query = "SELECT student_id, last_name + ' ' + first_name as student_name FROM students ORDER BY last_name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cmbStudentFilter.Items.Add("Всі учні");
                    while (reader.Read())
                    {
                        cmbStudentFilter.Items.Add(new
                        {
                            Text = reader["student_name"].ToString(),
                            Value = reader["student_id"]
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження учнів: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        // Сортування
        private void btnSort_Click(object sender, EventArgs e)
        {
            string field = cmbSortField.Text;
            string order = cmbSortOrder.Text;

            if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(order))
            {
                string query = $"SELECT * FROM enrollments ORDER BY {field} {order}";
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
            if (field == "enrollment_id" || field == "student_id" || field == "club_id")
            {
                if (!string.IsNullOrEmpty(minValue) && !string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM enrollments WHERE {field} BETWEEN {minValue} AND {maxValue}";
                }
                else if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM enrollments WHERE {field} >= {minValue}";
                }
                else if (!string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM enrollments WHERE {field} <= {maxValue}";
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
                    query = $"SELECT * FROM enrollments WHERE {field} LIKE '%{minValue}%'";
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
                string query = $"SELECT {function}({field}) as Result FROM enrollments";

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
                string query = $"SELECT * FROM enrollments WHERE {groupField} LIKE '%{conditionValue}%'";
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
            cmbStudentFilter.SelectedIndex = 0;
            cmbClubFilter.SelectedIndex = 0;

            this.enrollmentsTableAdapter.Fill(this.schoolClubsDBDataSet.enrollments);
            dataGridView1.DataSource = enrollmentsBindingSource;

            toolStripStatusLabel1.Text = "Фільтри скинуто";
        }


        // Статистика активних записів
        private void btnActiveEnrollments_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    c.club_name,
                    COUNT(e.enrollment_id) as active_enrollments,
                    c.max_students,
                    (c.max_students - COUNT(e.enrollment_id)) as free_slots
                FROM clubs c
                LEFT JOIN enrollments e ON c.club_id = e.club_id AND e.status = 'активний'
                GROUP BY c.club_id, c.club_name, c.max_students
                ORDER BY active_enrollments DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable statsTable = new DataTable();
                    adapter.Fill(statsTable);

                    // Створюємо нову таблицю для відображення
                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("Гурток", typeof(string));
                    displayTable.Columns.Add("Активні записи", typeof(int));
                    displayTable.Columns.Add("Макс. студентів", typeof(int));
                    displayTable.Columns.Add("Вільні місця", typeof(int));

                    foreach (DataRow row in statsTable.Rows)
                    {
                        displayTable.Rows.Add(
                            row["club_name"],
                            row["active_enrollments"],
                            row["max_students"],
                            row["free_slots"]
                        );
                    }

                    dataGridView1.DataSource = displayTable;
                    toolStripStatusLabel1.Text = "Статистика активних записів по гуртках";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні статистики: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Фільтрація за статусом
        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Фільтрація за учнем
        private void cmbStudentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Фільтрація за гуртком
        private void cmbClubFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string statusFilter = "";
            string studentFilter = "";
            string clubFilter = "";

            // Фільтр за статусом
            if (cmbStatusFilter.SelectedIndex > 0)
            {
                string selectedStatus = cmbStatusFilter.Text;
                statusFilter = $"status = '{selectedStatus}'";
            }

            // Фільтр за учнем
            if (cmbStudentFilter.SelectedIndex > 0)
            {
                string selectedStudent = cmbStudentFilter.Text;
                studentFilter = $"student_id IN (SELECT student_id FROM students WHERE last_name + ' ' + first_name LIKE '%{selectedStudent.Split(' ')[0]}%')";
            }

            // Фільтр за гуртком
            if (cmbClubFilter.SelectedIndex > 0)
            {
                string selectedClub = cmbClubFilter.Text;
                clubFilter = $"club_id IN (SELECT club_id FROM clubs WHERE club_name LIKE '%{selectedClub.Split(' ')[0]}%')";
            }

            // Комбінуємо фільтри
            string finalFilter = "";
            if (!string.IsNullOrEmpty(statusFilter))
            {
                finalFilter = statusFilter;
            }
            if (!string.IsNullOrEmpty(studentFilter))
            {
                finalFilter += (string.IsNullOrEmpty(finalFilter) ? "" : " AND ") + studentFilter;
            }
            if (!string.IsNullOrEmpty(clubFilter))
            {
                finalFilter += (string.IsNullOrEmpty(finalFilter) ? "" : " AND ") + clubFilter;
            }

            if (!string.IsNullOrEmpty(finalFilter))
            {
                enrollmentsBindingSource.Filter = finalFilter;
                toolStripStatusLabel1.Text = "Застосовано фільтри";
            }
            else
            {
                enrollmentsBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Фільтри скинуто";
            }
        }

        // Пошук в панелі інструментів
        private void btnToolStripSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtToolStripSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                enrollmentsBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Пошук скинуто";
                return;
            }

            string filter = $"status LIKE '%{searchText}%' OR " +
                           $"enrollment_date LIKE '%{searchText}%'";

            // Додаємо пошук за іменем учня та назвою гуртка
            filter += $" OR student_id IN (SELECT student_id FROM students WHERE last_name + ' ' + first_name LIKE '%{searchText}%')";
            filter += $" OR club_id IN (SELECT club_id FROM clubs WHERE club_name LIKE '%{searchText}%')";

            enrollmentsBindingSource.Filter = filter;
            toolStripStatusLabel1.Text = $"Знайдено за запитом: '{searchText}'";
        }

        // Очищення пошуку в панелі інструментів
        private void btnToolStripClearSearch_Click(object sender, EventArgs e)
        {
            txtToolStripSearch.Text = "";
            enrollmentsBindingSource.RemoveFilter();
            toolStripStatusLabel1.Text = "Пошук скинуто";
        }

        // Перегляд записів учня
        private void btnStudentEnrollments_Click(object sender, EventArgs e)
        {
            using (StudentSelectionForm studentForm = new StudentSelectionForm())
            {
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    int studentId = studentForm.SelectedStudentId;
                    string studentName = studentForm.SelectedStudentName;
                    ShowStudentEnrollments(studentId, studentName);
                }
            }
        }

        private void ShowStudentEnrollments(int studentId, string studentName)
        {
            string query = $@"
                SELECT 
                    e.enrollment_id,
                    e.enrollment_date,
                    e.status,
                    c.club_name,
                    t.last_name + ' ' + t.first_name as teacher_name
                FROM enrollments e
                INNER JOIN clubs c ON e.club_id = c.club_id
                INNER JOIN teachers t ON c.teacher_id = t.teacher_id
                WHERE e.student_id = {studentId}
                ORDER BY e.enrollment_date DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable enrollmentsTable = new DataTable();
                    adapter.Fill(enrollmentsTable);

                    // Створюємо нову таблицю для відображення
                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("ID", typeof(int));
                    displayTable.Columns.Add("Дата запису", typeof(DateTime));
                    displayTable.Columns.Add("Статус", typeof(string));
                    displayTable.Columns.Add("Гурток", typeof(string));
                    displayTable.Columns.Add("Викладач", typeof(string));

                    foreach (DataRow row in enrollmentsTable.Rows)
                    {
                        displayTable.Rows.Add(
                            row["enrollment_id"],
                            row["enrollment_date"],
                            row["status"],
                            row["club_name"],
                            row["teacher_name"]
                        );
                    }

                    dataGridView1.DataSource = displayTable;
                    toolStripStatusLabel1.Text = $"Записи учня: {studentName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні записів учня: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            // Просте діалогове вікно вибору типу звіту
            using (var choiceForm = new Form())
            {
                choiceForm.Text = "Оберіть тип звіту";
                choiceForm.Size = new Size(300, 200);
                choiceForm.StartPosition = FormStartPosition.CenterParent;
                choiceForm.FormBorderStyle = FormBorderStyle.FixedDialog;

                var lblTitle = new Label()
                {
                    Text = "Який звіт показати?",
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                var btnByClass = new Button()
                {
                    Text = "За класами",
                    Location = new Point(20, 60),
                    Size = new Size(100, 30)
                };

                var btnByClub = new Button()
                {
                    Text = "За гуртками",
                    Location = new Point(140, 60),
                    Size = new Size(100, 30)
                };

                var btnSchoolTotal = new Button()
                {
                    Text = "По школі",
                    Location = new Point(80, 100),
                    Size = new Size(100, 30)
                };

                var btnCancel = new Button()
                {
                    Text = "Скасувати",
                    Location = new Point(100, 140),
                    Size = new Size(100, 30),
                    DialogResult = DialogResult.Cancel
                };

                btnByClass.Click += (s, ev) => { choiceForm.DialogResult = DialogResult.Yes; ShowSimpleReport("by_class"); };
                btnByClub.Click += (s, ev) => { choiceForm.DialogResult = DialogResult.Yes; ShowSimpleReport("by_club"); };
                btnSchoolTotal.Click += (s, ev) => { choiceForm.DialogResult = DialogResult.Yes; ShowSimpleReport("school_total"); };

                choiceForm.Controls.AddRange(new Control[] { lblTitle, btnByClass, btnByClub, btnSchoolTotal, btnCancel });
                choiceForm.ShowDialog();
            }
        }

        // Показати простий звіт
        private void ShowSimpleReport(string reportType)
        {
            DataTable reportData = GenerateCoverageReport(reportType);

            if (reportData.Rows.Count == 0)
            {
                MessageBox.Show("Немає даних для відображення", "Інформація");
                return;
            }

            // Створюємо просте вікно звіту
            using (var reportForm = new Form())
            {
                reportForm.Text = GetReportTitle(reportType);
                reportForm.Size = new Size(700, 400);
                reportForm.StartPosition = FormStartPosition.CenterParent;

                var dataGridView = new DataGridView()
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    DataSource = reportData
                };

                var btnClose = new Button()
                {
                    Text = "Закрити",
                    Size = new Size(80, 30),
                    Location = new Point(300, 320)
                };
                btnClose.Click += (s, ev) => reportForm.Close();

                reportForm.Controls.Add(dataGridView);
                reportForm.Controls.Add(btnClose);
                reportForm.ShowDialog();
            }
        }

        // Метод для генерації звіту 
        private DataTable GenerateCoverageReport(string reportType)
        {
            string query = "";

            switch (reportType)
            {
                case "by_class":
                    query = @"
                SELECT 
                    s.class AS Клас,
                    COUNT(DISTINCT s.student_id) AS [Всього учнів],
                    COUNT(DISTINCT CASE WHEN e.status = 'активний' THEN s.student_id END) AS [Охоплено гуртками],
                    CASE 
                        WHEN COUNT(DISTINCT s.student_id) > 0 
                        THEN FORMAT(COUNT(DISTINCT CASE WHEN e.status = 'активний' THEN s.student_id END) * 100.0 / COUNT(DISTINCT s.student_id), 'N2') + '%'
                        ELSE '0%'
                    END AS [Відсоток охоплення]
                FROM students s
                LEFT JOIN enrollments e ON s.student_id = e.student_id AND e.status = 'активний'
                GROUP BY s.class
                ORDER BY s.class";
                    break;

                case "by_club":
                    query = @"
                SELECT 
                    c.club_name AS [Назва гуртка],
                    t.last_name + ' ' + t.first_name AS [Викладач],
                    COUNT(DISTINCT e.student_id) AS [Кількість учнів],
                    c.max_students AS [Максимальна кількість],
                    CASE 
                        WHEN c.max_students > 0 
                        THEN FORMAT(COUNT(DISTINCT e.student_id) * 100.0 / c.max_students, 'N2') + '%'
                        ELSE '0%'
                    END AS [Заповненість]
                FROM clubs c
                LEFT JOIN enrollments e ON c.club_id = e.club_id AND e.status = 'активний'
                LEFT JOIN teachers t ON c.teacher_id = t.teacher_id
                GROUP BY c.club_id, c.club_name, t.last_name, t.first_name, c.max_students
                ORDER BY [Кількість учнів] DESC";
                    break;

                case "school_total":
                    query = @"
                SELECT 
                    COUNT(DISTINCT s.student_id) AS [Всього учнів],
                    COUNT(DISTINCT CASE WHEN e.status = 'активний' THEN s.student_id END) AS [Охоплено гуртками],
                    CASE 
                        WHEN COUNT(DISTINCT s.student_id) > 0 
                        THEN FORMAT(COUNT(DISTINCT CASE WHEN e.status = 'активний' THEN s.student_id END) * 100.0 / COUNT(DISTINCT s.student_id), 'N2') + '%'
                        ELSE '0%'
                    END AS [Відсоток охоплення],
                    COUNT(DISTINCT c.club_id) AS [Кількість гуртків]
                FROM students s
                LEFT JOIN enrollments e ON s.student_id = e.student_id AND e.status = 'активний'
                LEFT JOIN clubs c ON e.club_id = c.club_id";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable reportTable = new DataTable();
                adapter.Fill(reportTable);
                return reportTable;
            }
        }

        // Отримати заголовок звіту
        private string GetReportTitle(string reportType)
        {
            if (reportType == "by_class")
                return "Охоплення за класами";
            else if (reportType == "by_club")
                return "Охоплення за гуртками";
            else if (reportType == "school_total")
                return "Загальне охоплення по школі";
            else
                return "Звіт";
        }
    }

    // Допоміжна форма для оновлення статусу
    public class StatusUpdateForm : Form
    {
        private ComboBox cmbStatus;
        private Button btnOK;
        private Button btnCancel;

        public string SelectedStatus { get; private set; }

        public StatusUpdateForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.cmbStatus = new ComboBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // ComboBox
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "активний", "завершений" });
            this.cmbStatus.Location = new System.Drawing.Point(20, 20);
            this.cmbStatus.Size = new System.Drawing.Size(200, 24);
            this.cmbStatus.SelectedIndex = 0;
            this.cmbStatus.TabIndex = 0;

            // OK Button
            this.btnOK.Location = new System.Drawing.Point(20, 60);
            this.btnOK.Size = new System.Drawing.Size(90, 30);
            this.btnOK.Text = "OK";
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Click += new EventHandler(btnOK_Click);

            // Cancel Button
            this.btnCancel.Location = new System.Drawing.Point(130, 60);
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.DialogResult = DialogResult.Cancel;

            // Form
            this.ClientSize = new System.Drawing.Size(240, 110);
            this.Controls.AddRange(new Control[] { this.cmbStatus, this.btnOK, this.btnCancel });
            this.Text = "Оновлення статусу";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            this.ResumeLayout(false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem != null)
            {
                SelectedStatus = cmbStatus.SelectedItem.ToString();
            }
        }
    }
}