namespace SchoolClubsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблиціToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учніToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.викладачіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гурткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.розкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відвідуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.studentidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentphoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schoolClubsDBDataSet = new SchoolClubsApp.SchoolClubsDBDataSet();
            this.studentsTableAdapter = new SchoolClubsApp.SchoolClubsDBDataSetTableAdapters.studentsTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.teacheridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymicDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specializationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teachersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.teachersTableAdapter = new SchoolClubsApp.SchoolClubsDBDataSetTableAdapters.teachersTableAdapter();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.clubidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agerestrictionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxstudentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacheridDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clubsTableAdapter = new SchoolClubsApp.SchoolClubsDBDataSetTableAdapters.clubsTableAdapter();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.scheduleidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayofweekDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.starttimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schedulesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schedulesTableAdapter = new SchoolClubsApp.SchoolClubsDBDataSetTableAdapters.schedulesTableAdapter();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.enrollmentidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubidDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enrollmentdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enrollmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.enrollmentsTableAdapter = new SchoolClubsApp.SchoolClubsDBDataSetTableAdapters.enrollmentsTableAdapter();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.attendanceidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enrollmentidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lessondateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.attendanceTableAdapter = new SchoolClubsApp.SchoolClubsDBDataSetTableAdapters.attendanceTableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolClubsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teachersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clubsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enrollmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблиціToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблиціToolStripMenuItem
            // 
            this.таблиціToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учніToolStripMenuItem,
            this.викладачіToolStripMenuItem,
            this.гурткиToolStripMenuItem,
            this.розкладToolStripMenuItem,
            this.записToolStripMenuItem,
            this.відвідуванняToolStripMenuItem});
            this.таблиціToolStripMenuItem.Name = "таблиціToolStripMenuItem";
            this.таблиціToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.таблиціToolStripMenuItem.Text = "Таблиці";
            // 
            // учніToolStripMenuItem
            // 
            this.учніToolStripMenuItem.Name = "учніToolStripMenuItem";
            this.учніToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.учніToolStripMenuItem.Text = "Учні";
            this.учніToolStripMenuItem.Click += new System.EventHandler(this.учніToolStripMenuItem_Click);
            // 
            // викладачіToolStripMenuItem
            // 
            this.викладачіToolStripMenuItem.Name = "викладачіToolStripMenuItem";
            this.викладачіToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.викладачіToolStripMenuItem.Text = "Викладачі";
            this.викладачіToolStripMenuItem.Click += new System.EventHandler(this.викладачіToolStripMenuItem_Click);
            // 
            // гурткиToolStripMenuItem
            // 
            this.гурткиToolStripMenuItem.Name = "гурткиToolStripMenuItem";
            this.гурткиToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.гурткиToolStripMenuItem.Text = "Гуртки";
            this.гурткиToolStripMenuItem.Click += new System.EventHandler(this.гурткиToolStripMenuItem_Click);
            // 
            // розкладToolStripMenuItem
            // 
            this.розкладToolStripMenuItem.Name = "розкладToolStripMenuItem";
            this.розкладToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.розкладToolStripMenuItem.Text = "Розклад";
            this.розкладToolStripMenuItem.Click += new System.EventHandler(this.розкладToolStripMenuItem_Click);
            // 
            // записToolStripMenuItem
            // 
            this.записToolStripMenuItem.Name = "записToolStripMenuItem";
            this.записToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.записToolStripMenuItem.Text = "Запис";
            this.записToolStripMenuItem.Click += new System.EventHandler(this.записToolStripMenuItem_Click);
            // 
            // відвідуванняToolStripMenuItem
            // 
            this.відвідуванняToolStripMenuItem.Name = "відвідуванняToolStripMenuItem";
            this.відвідуванняToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.відвідуванняToolStripMenuItem.Text = "Відвідування";
            this.відвідуванняToolStripMenuItem.Click += new System.EventHandler(this.відвідуванняToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentidDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.patronymicDataGridViewTextBoxColumn,
            this.classDataGridViewTextBoxColumn,
            this.parentphoneDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.studentsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(932, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // studentidDataGridViewTextBoxColumn
            // 
            this.studentidDataGridViewTextBoxColumn.DataPropertyName = "student_id";
            this.studentidDataGridViewTextBoxColumn.HeaderText = "student_id";
            this.studentidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.studentidDataGridViewTextBoxColumn.Name = "studentidDataGridViewTextBoxColumn";
            this.studentidDataGridViewTextBoxColumn.ReadOnly = true;
            this.studentidDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "last_name";
            this.lastnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            this.lastnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "first_name";
            this.firstnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // patronymicDataGridViewTextBoxColumn
            // 
            this.patronymicDataGridViewTextBoxColumn.DataPropertyName = "patronymic";
            this.patronymicDataGridViewTextBoxColumn.HeaderText = "patronymic";
            this.patronymicDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.patronymicDataGridViewTextBoxColumn.Name = "patronymicDataGridViewTextBoxColumn";
            this.patronymicDataGridViewTextBoxColumn.Width = 125;
            // 
            // classDataGridViewTextBoxColumn
            // 
            this.classDataGridViewTextBoxColumn.DataPropertyName = "class";
            this.classDataGridViewTextBoxColumn.HeaderText = "class";
            this.classDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.classDataGridViewTextBoxColumn.Name = "classDataGridViewTextBoxColumn";
            this.classDataGridViewTextBoxColumn.Width = 125;
            // 
            // parentphoneDataGridViewTextBoxColumn
            // 
            this.parentphoneDataGridViewTextBoxColumn.DataPropertyName = "parent_phone";
            this.parentphoneDataGridViewTextBoxColumn.HeaderText = "parent_phone";
            this.parentphoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.parentphoneDataGridViewTextBoxColumn.Name = "parentphoneDataGridViewTextBoxColumn";
            this.parentphoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "students";
            this.studentsBindingSource.DataSource = this.schoolClubsDBDataSet;
            // 
            // schoolClubsDBDataSet
            // 
            this.schoolClubsDBDataSet.DataSetName = "SchoolClubsDBDataSet";
            this.schoolClubsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentsTableAdapter
            // 
            this.studentsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.teacheridDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn1,
            this.firstnameDataGridViewTextBoxColumn1,
            this.patronymicDataGridViewTextBoxColumn1,
            this.phoneDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn1,
            this.specializationDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.teachersBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(0, 205);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(932, 150);
            this.dataGridView2.TabIndex = 2;
            // 
            // teacheridDataGridViewTextBoxColumn
            // 
            this.teacheridDataGridViewTextBoxColumn.DataPropertyName = "teacher_id";
            this.teacheridDataGridViewTextBoxColumn.HeaderText = "teacher_id";
            this.teacheridDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.teacheridDataGridViewTextBoxColumn.Name = "teacheridDataGridViewTextBoxColumn";
            this.teacheridDataGridViewTextBoxColumn.ReadOnly = true;
            this.teacheridDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastnameDataGridViewTextBoxColumn1
            // 
            this.lastnameDataGridViewTextBoxColumn1.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn1.HeaderText = "last_name";
            this.lastnameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.lastnameDataGridViewTextBoxColumn1.Name = "lastnameDataGridViewTextBoxColumn1";
            this.lastnameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // firstnameDataGridViewTextBoxColumn1
            // 
            this.firstnameDataGridViewTextBoxColumn1.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn1.HeaderText = "first_name";
            this.firstnameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.firstnameDataGridViewTextBoxColumn1.Name = "firstnameDataGridViewTextBoxColumn1";
            this.firstnameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // patronymicDataGridViewTextBoxColumn1
            // 
            this.patronymicDataGridViewTextBoxColumn1.DataPropertyName = "patronymic";
            this.patronymicDataGridViewTextBoxColumn1.HeaderText = "patronymic";
            this.patronymicDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.patronymicDataGridViewTextBoxColumn1.Name = "patronymicDataGridViewTextBoxColumn1";
            this.patronymicDataGridViewTextBoxColumn1.Width = 125;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "phone";
            this.phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn1
            // 
            this.emailDataGridViewTextBoxColumn1.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn1.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn1.Name = "emailDataGridViewTextBoxColumn1";
            this.emailDataGridViewTextBoxColumn1.Width = 125;
            // 
            // specializationDataGridViewTextBoxColumn
            // 
            this.specializationDataGridViewTextBoxColumn.DataPropertyName = "specialization";
            this.specializationDataGridViewTextBoxColumn.HeaderText = "specialization";
            this.specializationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.specializationDataGridViewTextBoxColumn.Name = "specializationDataGridViewTextBoxColumn";
            this.specializationDataGridViewTextBoxColumn.Width = 125;
            // 
            // teachersBindingSource
            // 
            this.teachersBindingSource.DataMember = "teachers";
            this.teachersBindingSource.DataSource = this.schoolClubsDBDataSet;
            // 
            // teachersTableAdapter
            // 
            this.teachersTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clubidDataGridViewTextBoxColumn,
            this.clubnameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.agerestrictionsDataGridViewTextBoxColumn,
            this.maxstudentsDataGridViewTextBoxColumn,
            this.teacheridDataGridViewTextBoxColumn1});
            this.dataGridView3.DataSource = this.clubsBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(0, 373);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(812, 150);
            this.dataGridView3.TabIndex = 3;
            // 
            // clubidDataGridViewTextBoxColumn
            // 
            this.clubidDataGridViewTextBoxColumn.DataPropertyName = "club_id";
            this.clubidDataGridViewTextBoxColumn.HeaderText = "club_id";
            this.clubidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.clubidDataGridViewTextBoxColumn.Name = "clubidDataGridViewTextBoxColumn";
            this.clubidDataGridViewTextBoxColumn.ReadOnly = true;
            this.clubidDataGridViewTextBoxColumn.Width = 125;
            // 
            // clubnameDataGridViewTextBoxColumn
            // 
            this.clubnameDataGridViewTextBoxColumn.DataPropertyName = "club_name";
            this.clubnameDataGridViewTextBoxColumn.HeaderText = "club_name";
            this.clubnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.clubnameDataGridViewTextBoxColumn.Name = "clubnameDataGridViewTextBoxColumn";
            this.clubnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 125;
            // 
            // agerestrictionsDataGridViewTextBoxColumn
            // 
            this.agerestrictionsDataGridViewTextBoxColumn.DataPropertyName = "age_restrictions";
            this.agerestrictionsDataGridViewTextBoxColumn.HeaderText = "age_restrictions";
            this.agerestrictionsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.agerestrictionsDataGridViewTextBoxColumn.Name = "agerestrictionsDataGridViewTextBoxColumn";
            this.agerestrictionsDataGridViewTextBoxColumn.Width = 125;
            // 
            // maxstudentsDataGridViewTextBoxColumn
            // 
            this.maxstudentsDataGridViewTextBoxColumn.DataPropertyName = "max_students";
            this.maxstudentsDataGridViewTextBoxColumn.HeaderText = "max_students";
            this.maxstudentsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.maxstudentsDataGridViewTextBoxColumn.Name = "maxstudentsDataGridViewTextBoxColumn";
            this.maxstudentsDataGridViewTextBoxColumn.Width = 125;
            // 
            // teacheridDataGridViewTextBoxColumn1
            // 
            this.teacheridDataGridViewTextBoxColumn1.DataPropertyName = "teacher_id";
            this.teacheridDataGridViewTextBoxColumn1.HeaderText = "teacher_id";
            this.teacheridDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.teacheridDataGridViewTextBoxColumn1.Name = "teacheridDataGridViewTextBoxColumn1";
            this.teacheridDataGridViewTextBoxColumn1.Width = 125;
            // 
            // clubsBindingSource
            // 
            this.clubsBindingSource.DataMember = "clubs";
            this.clubsBindingSource.DataSource = this.schoolClubsDBDataSet;
            // 
            // clubsTableAdapter
            // 
            this.clubsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scheduleidDataGridViewTextBoxColumn,
            this.clubidDataGridViewTextBoxColumn1,
            this.dayofweekDataGridViewTextBoxColumn,
            this.starttimeDataGridViewTextBoxColumn,
            this.endtimeDataGridViewTextBoxColumn,
            this.roomDataGridViewTextBoxColumn});
            this.dataGridView4.DataSource = this.schedulesBindingSource;
            this.dataGridView4.Location = new System.Drawing.Point(0, 547);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersWidth = 51;
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.Size = new System.Drawing.Size(812, 150);
            this.dataGridView4.TabIndex = 4;
            // 
            // scheduleidDataGridViewTextBoxColumn
            // 
            this.scheduleidDataGridViewTextBoxColumn.DataPropertyName = "schedule_id";
            this.scheduleidDataGridViewTextBoxColumn.HeaderText = "schedule_id";
            this.scheduleidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.scheduleidDataGridViewTextBoxColumn.Name = "scheduleidDataGridViewTextBoxColumn";
            this.scheduleidDataGridViewTextBoxColumn.ReadOnly = true;
            this.scheduleidDataGridViewTextBoxColumn.Width = 125;
            // 
            // clubidDataGridViewTextBoxColumn1
            // 
            this.clubidDataGridViewTextBoxColumn1.DataPropertyName = "club_id";
            this.clubidDataGridViewTextBoxColumn1.HeaderText = "club_id";
            this.clubidDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.clubidDataGridViewTextBoxColumn1.Name = "clubidDataGridViewTextBoxColumn1";
            this.clubidDataGridViewTextBoxColumn1.Width = 125;
            // 
            // dayofweekDataGridViewTextBoxColumn
            // 
            this.dayofweekDataGridViewTextBoxColumn.DataPropertyName = "day_of_week";
            this.dayofweekDataGridViewTextBoxColumn.HeaderText = "day_of_week";
            this.dayofweekDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dayofweekDataGridViewTextBoxColumn.Name = "dayofweekDataGridViewTextBoxColumn";
            this.dayofweekDataGridViewTextBoxColumn.Width = 125;
            // 
            // starttimeDataGridViewTextBoxColumn
            // 
            this.starttimeDataGridViewTextBoxColumn.DataPropertyName = "start_time";
            this.starttimeDataGridViewTextBoxColumn.HeaderText = "start_time";
            this.starttimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.starttimeDataGridViewTextBoxColumn.Name = "starttimeDataGridViewTextBoxColumn";
            this.starttimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // endtimeDataGridViewTextBoxColumn
            // 
            this.endtimeDataGridViewTextBoxColumn.DataPropertyName = "end_time";
            this.endtimeDataGridViewTextBoxColumn.HeaderText = "end_time";
            this.endtimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.endtimeDataGridViewTextBoxColumn.Name = "endtimeDataGridViewTextBoxColumn";
            this.endtimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // roomDataGridViewTextBoxColumn
            // 
            this.roomDataGridViewTextBoxColumn.DataPropertyName = "room";
            this.roomDataGridViewTextBoxColumn.HeaderText = "room";
            this.roomDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.roomDataGridViewTextBoxColumn.Name = "roomDataGridViewTextBoxColumn";
            this.roomDataGridViewTextBoxColumn.Width = 125;
            // 
            // schedulesBindingSource
            // 
            this.schedulesBindingSource.DataMember = "schedules";
            this.schedulesBindingSource.DataSource = this.schoolClubsDBDataSet;
            // 
            // schedulesTableAdapter
            // 
            this.schedulesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AutoGenerateColumns = false;
            this.dataGridView5.ColumnHeadersHeight = 29;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enrollmentidDataGridViewTextBoxColumn,
            this.studentidDataGridViewTextBoxColumn1,
            this.clubidDataGridViewTextBoxColumn2,
            this.enrollmentdateDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dataGridView5.DataSource = this.enrollmentsBindingSource;
            this.dataGridView5.Location = new System.Drawing.Point(0, 721);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersWidth = 51;
            this.dataGridView5.Size = new System.Drawing.Size(683, 150);
            this.dataGridView5.TabIndex = 0;
            // 
            // enrollmentidDataGridViewTextBoxColumn
            // 
            this.enrollmentidDataGridViewTextBoxColumn.DataPropertyName = "enrollment_id";
            this.enrollmentidDataGridViewTextBoxColumn.HeaderText = "enrollment_id";
            this.enrollmentidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.enrollmentidDataGridViewTextBoxColumn.Name = "enrollmentidDataGridViewTextBoxColumn";
            this.enrollmentidDataGridViewTextBoxColumn.ReadOnly = true;
            this.enrollmentidDataGridViewTextBoxColumn.Width = 125;
            // 
            // studentidDataGridViewTextBoxColumn1
            // 
            this.studentidDataGridViewTextBoxColumn1.DataPropertyName = "student_id";
            this.studentidDataGridViewTextBoxColumn1.HeaderText = "student_id";
            this.studentidDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.studentidDataGridViewTextBoxColumn1.Name = "studentidDataGridViewTextBoxColumn1";
            this.studentidDataGridViewTextBoxColumn1.Width = 125;
            // 
            // clubidDataGridViewTextBoxColumn2
            // 
            this.clubidDataGridViewTextBoxColumn2.DataPropertyName = "club_id";
            this.clubidDataGridViewTextBoxColumn2.HeaderText = "club_id";
            this.clubidDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.clubidDataGridViewTextBoxColumn2.Name = "clubidDataGridViewTextBoxColumn2";
            this.clubidDataGridViewTextBoxColumn2.Width = 125;
            // 
            // enrollmentdateDataGridViewTextBoxColumn
            // 
            this.enrollmentdateDataGridViewTextBoxColumn.DataPropertyName = "enrollment_date";
            this.enrollmentdateDataGridViewTextBoxColumn.HeaderText = "enrollment_date";
            this.enrollmentdateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.enrollmentdateDataGridViewTextBoxColumn.Name = "enrollmentdateDataGridViewTextBoxColumn";
            this.enrollmentdateDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // enrollmentsBindingSource
            // 
            this.enrollmentsBindingSource.DataMember = "enrollments";
            this.enrollmentsBindingSource.DataSource = this.schoolClubsDBDataSet;
            // 
            // enrollmentsTableAdapter
            // 
            this.enrollmentsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView6
            // 
            this.dataGridView6.AutoGenerateColumns = false;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attendanceidDataGridViewTextBoxColumn,
            this.enrollmentidDataGridViewTextBoxColumn1,
            this.lessondateDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn1});
            this.dataGridView6.DataSource = this.attendanceBindingSource;
            this.dataGridView6.Location = new System.Drawing.Point(0, 893);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.RowHeadersWidth = 51;
            this.dataGridView6.RowTemplate.Height = 24;
            this.dataGridView6.Size = new System.Drawing.Size(559, 150);
            this.dataGridView6.TabIndex = 5;
            // 
            // attendanceidDataGridViewTextBoxColumn
            // 
            this.attendanceidDataGridViewTextBoxColumn.DataPropertyName = "attendance_id";
            this.attendanceidDataGridViewTextBoxColumn.HeaderText = "attendance_id";
            this.attendanceidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.attendanceidDataGridViewTextBoxColumn.Name = "attendanceidDataGridViewTextBoxColumn";
            this.attendanceidDataGridViewTextBoxColumn.ReadOnly = true;
            this.attendanceidDataGridViewTextBoxColumn.Width = 125;
            // 
            // enrollmentidDataGridViewTextBoxColumn1
            // 
            this.enrollmentidDataGridViewTextBoxColumn1.DataPropertyName = "enrollment_id";
            this.enrollmentidDataGridViewTextBoxColumn1.HeaderText = "enrollment_id";
            this.enrollmentidDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.enrollmentidDataGridViewTextBoxColumn1.Name = "enrollmentidDataGridViewTextBoxColumn1";
            this.enrollmentidDataGridViewTextBoxColumn1.Width = 125;
            // 
            // lessondateDataGridViewTextBoxColumn
            // 
            this.lessondateDataGridViewTextBoxColumn.DataPropertyName = "lesson_date";
            this.lessondateDataGridViewTextBoxColumn.HeaderText = "lesson_date";
            this.lessondateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lessondateDataGridViewTextBoxColumn.Name = "lessondateDataGridViewTextBoxColumn";
            this.lessondateDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn1
            // 
            this.statusDataGridViewTextBoxColumn1.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn1.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn1.Name = "statusDataGridViewTextBoxColumn1";
            this.statusDataGridViewTextBoxColumn1.Width = 125;
            // 
            // attendanceBindingSource
            // 
            this.attendanceBindingSource.DataMember = "attendance";
            this.attendanceBindingSource.DataSource = this.schoolClubsDBDataSet;
            // 
            // attendanceTableAdapter
            // 
            this.attendanceTableAdapter.ClearBeforeFill = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 1055);
            this.Controls.Add(this.dataGridView6);
            this.Controls.Add(this.dataGridView5);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Система керування гуртками";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolClubsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teachersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clubsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enrollmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблиціToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учніToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem викладачіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гурткиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відвідуванняToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SchoolClubsDBDataSet schoolClubsDBDataSet;
        private System.Windows.Forms.BindingSource studentsBindingSource;
        private SchoolClubsDBDataSetTableAdapters.studentsTableAdapter studentsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentphoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource teachersBindingSource;
        private SchoolClubsDBDataSetTableAdapters.teachersTableAdapter teachersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacheridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymicDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn specializationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.BindingSource clubsBindingSource;
        private SchoolClubsDBDataSetTableAdapters.clubsTableAdapter clubsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agerestrictionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxstudentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacheridDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.BindingSource schedulesBindingSource;
        private SchoolClubsDBDataSetTableAdapters.schedulesTableAdapter schedulesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubidDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayofweekDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn starttimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn enrollmentidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentidDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubidDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn enrollmentdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource enrollmentsBindingSource;
        private SchoolClubsDBDataSetTableAdapters.enrollmentsTableAdapter enrollmentsTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.BindingSource attendanceBindingSource;
        private SchoolClubsDBDataSetTableAdapters.attendanceTableAdapter attendanceTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendanceidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enrollmentidDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lessondateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn1;
    }
}

