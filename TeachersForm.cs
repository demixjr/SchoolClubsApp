using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;

namespace SchoolClubsApp
{
    public partial class TeachersForm : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=SchoolClubsDB;Integrated Security=True;";

        public TeachersForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.teachersTableAdapter.Update(this.schoolClubsDBDataSet.teachers);
                MessageBox.Show("Дані успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Помилка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TeachersForm_Load(object sender, EventArgs e)
        {
            this.teachersTableAdapter.Fill(this.schoolClubsDBDataSet.teachers);

            // Заповнення комбобоксів для сортування та фільтрації
            cmbSortField.Items.AddRange(new string[] { "last_name", "first_name", "specialization", "phone" });
            cmbFilterField.Items.AddRange(new string[] { "teacher_id" });
            cmbAggregateField.Items.AddRange(new string[] { "teacher_id" });
            cmbGroupField.Items.AddRange(new string[] { "last_name", "first_name", "specialization" });

            cmbSortOrder.Items.AddRange(new string[] { "ASC", "DESC" });
            cmbAggregateFunction.Items.AddRange(new string[] { "COUNT", "MAX", "MIN" });

            // Встановлення значень за замовчуванням
            cmbSortField.SelectedIndex = 0;
            cmbSortOrder.SelectedIndex = 0;
            cmbFilterField.SelectedIndex = 0;
            cmbAggregateField.SelectedIndex = 0;
            cmbAggregateFunction.SelectedIndex = 0;
            cmbGroupField.SelectedIndex = 0;
        }

        // Сортування
        private void btnSort_Click(object sender, EventArgs e)
        {
            string field = cmbSortField.Text;
            string order = cmbSortOrder.Text;

            if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(order))
            {
                string query = $"SELECT * FROM teachers ORDER BY {field} {order}";
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
            if (field == "teacher_id")
            {
                // Фільтрація за діапазоном для числового поля
                if (!string.IsNullOrEmpty(minValue) && !string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM teachers WHERE {field} BETWEEN {minValue} AND {maxValue}";
                }
                else if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM teachers WHERE {field} >= {minValue}";
                }
                else if (!string.IsNullOrEmpty(maxValue))
                {
                    query = $"SELECT * FROM teachers WHERE {field} <= {maxValue}";
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
                // Фільтрація за текстовим полем
                if (!string.IsNullOrEmpty(minValue))
                {
                    query = $"SELECT * FROM teachers WHERE {field} LIKE '%{minValue}%'";
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
                string query = $"SELECT {function}({field}) as Result FROM teachers";

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

        // Пошук (групування за умовою)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string groupField = cmbGroupField.Text;
            string conditionValue = txtConditionValue.Text;

            if (!string.IsNullOrEmpty(groupField) && !string.IsNullOrEmpty(conditionValue))
            {
                string query = $"SELECT * FROM teachers WHERE {groupField} LIKE '%{conditionValue}%'";
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

                    // Оновлення статусу
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
            // Очищення полів
            txtMinValue.Text = "";
            txtMaxValue.Text = "";
            txtConditionValue.Text = "";

            // Повернення до оригінальних даних
            this.teachersTableAdapter.Fill(this.schoolClubsDBDataSet.teachers);
            dataGridView1.DataSource = teachersBindingSource;

            toolStripStatusLabel1.Text = "Фільтри скинуто";
        }


        // Перегляд гуртків викладача
        private void btnShowClubs_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Будь ласка, виберіть викладача зі списку", "Інформація",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            string teacherName = $"{selectedRow.Cells["last_name"].Value} {selectedRow.Cells["first_name"].Value} {selectedRow.Cells["patronymic"].Value}";
            int teacherId = Convert.ToInt32(selectedRow.Cells["teacher_id"].Value);

            ShowTeacherClubs(teacherId, teacherName);
        }

        private void ShowTeacherClubs(int teacherId, string teacherName)
        {
            string query = $@"
        SELECT 
            c.club_id,
            c.club_name,
            c.description,
            c.age_restrictions,
            c.max_students
        FROM clubs c
        WHERE c.teacher_id = {teacherId}";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable clubsTable = new DataTable();
                    adapter.Fill(clubsTable);
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = clubsTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при отриманні даних гуртків: " + ex.Message, "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Пошук в панелі інструментів
        private void btnToolStripSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtToolStripSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                teachersBindingSource.RemoveFilter();
                toolStripStatusLabel1.Text = "Пошук скинуто";
                return;
            }

            string filter = $"last_name LIKE '%{searchText}%' OR " +
                           $"first_name LIKE '%{searchText}%' OR " +
                           $"patronymic LIKE '%{searchText}%' OR " +
                           $"specialization LIKE '%{searchText}%' OR " +
                           $"phone LIKE '%{searchText}%' OR " +
                           $"email LIKE '%{searchText}%'";

            teachersBindingSource.Filter = filter;
            toolStripStatusLabel1.Text = $"Знайдено за запитом: '{searchText}'";
        }

        // Очищення пошуку в панелі інструментів
        private void btnToolStripClearSearch_Click(object sender, EventArgs e)
        {
            txtToolStripSearch.Text = "";
            teachersBindingSource.RemoveFilter();
            toolStripStatusLabel1.Text = "Пошук скинуто";
        }

        // Звіт про завантаженість викладачів
        private void button1_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            t.last_name + ' ' + t.first_name AS Викладач,
            COUNT(c.club_id) AS [Кількість гуртків]
        FROM teachers t
        LEFT JOIN clubs c ON t.teacher_id = c.teacher_id
        GROUP BY t.teacher_id, t.last_name, t.first_name
        ORDER BY [Кількість гуртків] DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("Немає даних для відображення", "Інформація");
                        return;
                    }

                    // Просте вікно з результатами
                    using (var reportForm = new Form())
                    {
                        reportForm.Text = "Кількість гуртків по викладачах";
                        reportForm.Size = new Size(400, 300);
                        reportForm.StartPosition = FormStartPosition.CenterParent;

                        var dataGridView = new DataGridView()
                        {
                            Dock = DockStyle.Fill,
                            ReadOnly = true,
                            AllowUserToAddRows = false,
                            DataSource = table
                        };

                        var btnClose = new Button()
                        {
                            Text = "Закрити",
                            Size = new Size(80, 30),
                            Location = new Point(160, 230)
                        };
                        btnClose.Click += (s, ev) => reportForm.Close();

                        reportForm.Controls.Add(dataGridView);
                        reportForm.Controls.Add(btnClose);
                        reportForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message, "Помилка");
                }
            }
        }

        private void cmbAggregateFunction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}