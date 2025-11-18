using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolClubsApp
{
    public partial class StudentsForm : Form
    {
        private SqlConnection connection;
        private string connectionString = @"Data Source=.;Initial Catalog=SchoolClubsDB;Integrated Security=True";

        public StudentsForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            connection = new SqlConnection(connectionString);
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentsTableAdapter.Update(this.schoolClubsDBDataSet.students);
                MessageBox.Show("Дані успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Помилка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void StudentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStudents();
                LoadClassFilter();
                LoadClassesForQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження даних: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudents()
        {
            try
            {
                string query = "SELECT * FROM students ORDER BY last_name, first_name";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження студентів: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClassFilter()
        {
            try
            {
                comboBoxClassFilter.Items.Clear();
                comboBoxClassFilter.Items.Add("Всі класи");

                string query = "SELECT DISTINCT class FROM students ORDER BY class";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxClassFilter.Items.Add(reader["class"].ToString());
                }
                reader.Close();
                connection.Close();

                comboBoxClassFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження фільтрів: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadClassesForQuery()
        {
            try
            {
                comboBoxClassQuery.Items.Clear();

                string query = "SELECT DISTINCT class FROM students ORDER BY class";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxClassQuery.Items.Add(reader["class"].ToString());
                }
                reader.Close();
                connection.Close();

                if (comboBoxClassQuery.Items.Count > 0)
                    comboBoxClassQuery.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження класів: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        // 1. Пошук учня за прізвищем, ім'ям або класом
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadStudents();
                return;
            }

            try
            {
                string query = @"
                    SELECT * FROM students 
                    WHERE last_name LIKE @search 
                       OR first_name LIKE @search 
                       OR class LIKE @search 
                    ORDER BY last_name, first_name";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@search", "%" + searchText + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка пошуку: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Фільтрація учнів за класом
        private void btnFilterByClass_Click(object sender, EventArgs e)
        {
            if (comboBoxClassFilter.SelectedItem?.ToString() == "Всі класи")
            {
                LoadStudents();
                return;
            }

            string selectedClass = comboBoxClassFilter.SelectedItem.ToString();

            try
            {
                string query = "SELECT * FROM students WHERE class = @class ORDER BY last_name, first_name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@class", selectedClass);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка фільтрації: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Сортування списку учнів за прізвищем
        private void btnSortByLastName_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM students ORDER BY last_name, first_name, patronymic";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка сортування: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Сортування списку учнів за класом
        private void btnSortByClass_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM students ORDER BY class, last_name, first_name";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка сортування: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Хто з учнів {клас} класу не записаний жоден гурток?
        private void btnStudentsWithoutClubs_Click(object sender, EventArgs e)
        {
            if (comboBoxClassQuery.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть клас", "Попередження",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedClass = comboBoxClassQuery.SelectedItem.ToString();

            try
            {
                string query = @"
                    SELECT s.student_id, s.last_name, s.first_name, s.patronymic, s.class
                    FROM students s
                    WHERE s.class = @class 
                    AND s.student_id NOT IN (
                        SELECT student_id FROM student_clubs
                    )";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@class", selectedClass);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable resultTable = new DataTable();
                adapter.Fill(resultTable);

                dataGridViewQueryResults.DataSource = resultTable;
                dataGridViewQueryResults.Visible = true;

                MessageBox.Show($"Знайдено {resultTable.Rows.Count} учнів без гуртків у {selectedClass} класі",
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка виконання запиту: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 6. Скільки учнів відвідують більше одного гуртка?
        private void btnMultipleClubs_Click(object sender, EventArgs e)
        {
            try
            {
                // Запит для підрахунку кількості
                string countQuery = @"
                    SELECT COUNT(*) as student_count
                    FROM (
                        SELECT student_id 
                        FROM student_clubs 
                        GROUP BY student_id 
                        HAVING COUNT(*) > 1
                    ) as multiple_club_students";

                SqlCommand countCommand = new SqlCommand(countQuery, connection);
                connection.Open();
                int count = Convert.ToInt32(countCommand.ExecuteScalar());
                connection.Close();

                // Детальний запит для відображення
                string detailedQuery = @"
                    SELECT s.student_id, s.last_name, s.first_name, s.patronymic, s.class,
                           COUNT(sc.club_id) as club_count
                    FROM students s
                    JOIN student_clubs sc ON s.student_id = sc.student_id
                    GROUP BY s.student_id, s.last_name, s.first_name, s.patronymic, s.class
                    HAVING COUNT(sc.club_id) > 1
                    ORDER BY club_count DESC, s.last_name, s.first_name";

                SqlCommand detailedCommand = new SqlCommand(detailedQuery, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(detailedCommand);
                DataTable resultTable = new DataTable();
                adapter.Fill(resultTable);

                dataGridViewQueryResults.DataSource = resultTable;
                dataGridViewQueryResults.Visible = true;

                MessageBox.Show($"{count} учнів відвідують більше одного гуртка",
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка виконання запиту: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        // Скидання пошуку
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadStudents();
        }

 
    }
}