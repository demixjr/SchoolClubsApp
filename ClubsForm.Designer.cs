namespace SchoolClubsApp
{
    partial class ClubsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClubsForm));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.clubsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schoolClubsDBDataSet = new SchoolClubsApp.SchoolClubsDBDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtToolStripSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnToolStripSearch = new System.Windows.Forms.ToolStripButton();
            this.btnToolStripClearSearch = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clubidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agerestrictionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxstudentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacheridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubsTableAdapter = new SchoolClubsApp.SchoolClubsDBDataSetTableAdapters.clubsTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPopularClubs = new System.Windows.Forms.Button();
            this.btnShowFreeSlots = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbTeacherFilter = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbAgeFilter = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtConditionValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGroupField = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAggregateFunction = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAggregateField = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAggregate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaxValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilterField = new System.Windows.Forms.ComboBox();
            this.lblFilterField = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbSortOrder = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSortField = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clubsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolClubsDBDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.clubsBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtToolStripSearch,
            this.btnToolStripSearch,
            this.btnToolStripClearSearch});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1200, 27);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Додати";
            // 
            // clubsBindingSource
            // 
            this.clubsBindingSource.DataMember = "clubs";
            this.clubsBindingSource.DataSource = this.schoolClubsDBDataSet;
            // 
            // schoolClubsDBDataSet
            // 
            this.schoolClubsDBDataSet.DataSetName = "SchoolClubsDBDataSet";
            this.schoolClubsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Загальна кількість елементів";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Видалити";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Перемістити на початок";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Перемістити назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Позиція";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Поточна позиція";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Перемістити вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Перемістити в кінець";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "Зберегти";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 24);
            this.toolStripLabel1.Text = "Пошук:";
            // 
            // txtToolStripSearch
            // 
            this.txtToolStripSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtToolStripSearch.Name = "txtToolStripSearch";
            this.txtToolStripSearch.Size = new System.Drawing.Size(150, 27);
            this.txtToolStripSearch.ToolTipText = "Пошук за назвою, категорією або викладачем";
            // 
            // btnToolStripSearch
            // 
            this.btnToolStripSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolStripSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToolStripSearch.Name = "btnToolStripSearch";
            this.btnToolStripSearch.Size = new System.Drawing.Size(29, 24);
            this.btnToolStripSearch.Text = "Шукати";
            this.btnToolStripSearch.Click += new System.EventHandler(this.btnToolStripSearch_Click);
            // 
            // btnToolStripClearSearch
            // 
            this.btnToolStripClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolStripClearSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToolStripClearSearch.Name = "btnToolStripClearSearch";
            this.btnToolStripClearSearch.Size = new System.Drawing.Size(29, 24);
            this.btnToolStripClearSearch.Text = "Очистити пошук";
            this.btnToolStripClearSearch.Click += new System.EventHandler(this.btnToolStripClearSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(300, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 610);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clubidDataGridViewTextBoxColumn,
            this.clubnameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.agerestrictionsDataGridViewTextBoxColumn,
            this.maxstudentsDataGridViewTextBoxColumn,
            this.teacheridDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.clubsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(900, 610);
            this.dataGridView1.TabIndex = 0;
            // 
            // clubidDataGridViewTextBoxColumn
            // 
            this.clubidDataGridViewTextBoxColumn.DataPropertyName = "club_id";
            this.clubidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.clubidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.clubidDataGridViewTextBoxColumn.Name = "clubidDataGridViewTextBoxColumn";
            this.clubidDataGridViewTextBoxColumn.ReadOnly = true;
            this.clubidDataGridViewTextBoxColumn.Width = 50;
            // 
            // clubnameDataGridViewTextBoxColumn
            // 
            this.clubnameDataGridViewTextBoxColumn.DataPropertyName = "club_name";
            this.clubnameDataGridViewTextBoxColumn.HeaderText = "Назва";
            this.clubnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.clubnameDataGridViewTextBoxColumn.Name = "clubnameDataGridViewTextBoxColumn";
            this.clubnameDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Опис";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // agerestrictionsDataGridViewTextBoxColumn
            // 
            this.agerestrictionsDataGridViewTextBoxColumn.DataPropertyName = "age_restrictions";
            this.agerestrictionsDataGridViewTextBoxColumn.HeaderText = "Вікові обмеження";
            this.agerestrictionsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.agerestrictionsDataGridViewTextBoxColumn.Name = "agerestrictionsDataGridViewTextBoxColumn";
            this.agerestrictionsDataGridViewTextBoxColumn.Width = 120;
            // 
            // maxstudentsDataGridViewTextBoxColumn
            // 
            this.maxstudentsDataGridViewTextBoxColumn.DataPropertyName = "max_students";
            this.maxstudentsDataGridViewTextBoxColumn.HeaderText = "Макс. студентів";
            this.maxstudentsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.maxstudentsDataGridViewTextBoxColumn.Name = "maxstudentsDataGridViewTextBoxColumn";
            this.maxstudentsDataGridViewTextBoxColumn.Width = 80;
            // 
            // teacheridDataGridViewTextBoxColumn
            // 
            this.teacheridDataGridViewTextBoxColumn.DataPropertyName = "teacher_id";
            this.teacheridDataGridViewTextBoxColumn.HeaderText = "ID викладача";
            this.teacheridDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.teacheridDataGridViewTextBoxColumn.Name = "teacheridDataGridViewTextBoxColumn";
            this.teacheridDataGridViewTextBoxColumn.Width = 80;
            // 
            // clubsTableAdapter
            // 
            this.clubsTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPopularClubs);
            this.panel2.Controls.Add(this.btnShowFreeSlots);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 637);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 50);
            this.panel2.TabIndex = 2;
            // 
            // btnPopularClubs
            // 
            this.btnPopularClubs.Location = new System.Drawing.Point(240, 10);
            this.btnPopularClubs.Name = "btnPopularClubs";
            this.btnPopularClubs.Size = new System.Drawing.Size(200, 30);
            this.btnPopularClubs.TabIndex = 2;
            this.btnPopularClubs.Text = "Популярні гуртки";
            this.btnPopularClubs.UseVisualStyleBackColor = true;
            this.btnPopularClubs.Click += new System.EventHandler(this.btnPopularClubs_Click);
            // 
            // btnShowFreeSlots
            // 
            this.btnShowFreeSlots.Location = new System.Drawing.Point(20, 10);
            this.btnShowFreeSlots.Name = "btnShowFreeSlots";
            this.btnShowFreeSlots.Size = new System.Drawing.Size(200, 30);
            this.btnShowFreeSlots.TabIndex = 0;
            this.btnShowFreeSlots.Text = "Вільні місця";
            this.btnShowFreeSlots.UseVisualStyleBackColor = true;
            this.btnShowFreeSlots.Click += new System.EventHandler(this.btnShowFreeSlots_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Controls.Add(this.btnFilter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 610);
            this.panel3.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbTeacherFilter);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.cmbAgeFilter);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(12, 460);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(276, 90);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Фільтрація";
            // 
            // cmbTeacherFilter
            // 
            this.cmbTeacherFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacherFilter.FormattingEnabled = true;
            this.cmbTeacherFilter.Location = new System.Drawing.Point(90, 55);
            this.cmbTeacherFilter.Name = "cmbTeacherFilter";
            this.cmbTeacherFilter.Size = new System.Drawing.Size(170, 24);
            this.cmbTeacherFilter.TabIndex = 3;
            this.cmbTeacherFilter.SelectedIndexChanged += new System.EventHandler(this.cmbTeacherFilter_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Викладач:";
            // 
            // cmbAgeFilter
            // 
            this.cmbAgeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeFilter.FormattingEnabled = true;
            this.cmbAgeFilter.Location = new System.Drawing.Point(90, 25);
            this.cmbAgeFilter.Name = "cmbAgeFilter";
            this.cmbAgeFilter.Size = new System.Drawing.Size(170, 24);
            this.cmbAgeFilter.TabIndex = 1;
            this.cmbAgeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbAgeFilter_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Вік група:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtConditionValue);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmbGroupField);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Location = new System.Drawing.Point(12, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 120);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Пошук";
            // 
            // txtConditionValue
            // 
            this.txtConditionValue.Location = new System.Drawing.Point(90, 55);
            this.txtConditionValue.Name = "txtConditionValue";
            this.txtConditionValue.Size = new System.Drawing.Size(170, 22);
            this.txtConditionValue.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Значення:";
            // 
            // cmbGroupField
            // 
            this.cmbGroupField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupField.FormattingEnabled = true;
            this.cmbGroupField.Location = new System.Drawing.Point(90, 25);
            this.cmbGroupField.Name = "cmbGroupField";
            this.cmbGroupField.Size = new System.Drawing.Size(170, 24);
            this.cmbGroupField.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Поле:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(90, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(170, 25);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbAggregateFunction);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbAggregateField);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnAggregate);
            this.groupBox2.Location = new System.Drawing.Point(12, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 90);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Агрегатні функції";
            // 
            // cmbAggregateFunction
            // 
            this.cmbAggregateFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAggregateFunction.FormattingEnabled = true;
            this.cmbAggregateFunction.Location = new System.Drawing.Point(90, 55);
            this.cmbAggregateFunction.Name = "cmbAggregateFunction";
            this.cmbAggregateFunction.Size = new System.Drawing.Size(170, 24);
            this.cmbAggregateFunction.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Функція:";
            // 
            // cmbAggregateField
            // 
            this.cmbAggregateField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAggregateField.FormattingEnabled = true;
            this.cmbAggregateField.Location = new System.Drawing.Point(90, 25);
            this.cmbAggregateField.Name = "cmbAggregateField";
            this.cmbAggregateField.Size = new System.Drawing.Size(170, 24);
            this.cmbAggregateField.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Поле:";
            // 
            // btnAggregate
            // 
            this.btnAggregate.Location = new System.Drawing.Point(90, 55);
            this.btnAggregate.Name = "btnAggregate";
            this.btnAggregate.Size = new System.Drawing.Size(170, 25);
            this.btnAggregate.TabIndex = 0;
            this.btnAggregate.Text = "Обчислити";
            this.btnAggregate.UseVisualStyleBackColor = true;
            this.btnAggregate.Click += new System.EventHandler(this.btnAggregate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaxValue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMinValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbFilterField);
            this.groupBox1.Controls.Add(this.lblFilterField);
            this.groupBox1.Location = new System.Drawing.Point(12, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фільтрація";
            // 
            // txtMaxValue
            // 
            this.txtMaxValue.Location = new System.Drawing.Point(200, 55);
            this.txtMaxValue.Name = "txtMaxValue";
            this.txtMaxValue.Size = new System.Drawing.Size(60, 22);
            this.txtMaxValue.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "до:";
            // 
            // txtMinValue
            // 
            this.txtMinValue.Location = new System.Drawing.Point(90, 55);
            this.txtMinValue.Name = "txtMinValue";
            this.txtMinValue.Size = new System.Drawing.Size(60, 22);
            this.txtMinValue.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Діапазон:";
            // 
            // cmbFilterField
            // 
            this.cmbFilterField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterField.FormattingEnabled = true;
            this.cmbFilterField.Location = new System.Drawing.Point(90, 25);
            this.cmbFilterField.Name = "cmbFilterField";
            this.cmbFilterField.Size = new System.Drawing.Size(170, 24);
            this.cmbFilterField.TabIndex = 2;
            // 
            // lblFilterField
            // 
            this.lblFilterField.AutoSize = true;
            this.lblFilterField.Location = new System.Drawing.Point(10, 28);
            this.lblFilterField.Name = "lblFilterField";
            this.lblFilterField.Size = new System.Drawing.Size(44, 16);
            this.lblFilterField.TabIndex = 1;
            this.lblFilterField.Text = "Поле:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbSortOrder);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.cmbSortField);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnSort);
            this.groupBox4.Location = new System.Drawing.Point(12, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(276, 90);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Сортування";
            // 
            // cmbSortOrder
            // 
            this.cmbSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortOrder.FormattingEnabled = true;
            this.cmbSortOrder.Location = new System.Drawing.Point(90, 55);
            this.cmbSortOrder.Name = "cmbSortOrder";
            this.cmbSortOrder.Size = new System.Drawing.Size(170, 24);
            this.cmbSortOrder.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Порядок:";
            // 
            // cmbSortField
            // 
            this.cmbSortField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortField.FormattingEnabled = true;
            this.cmbSortField.Location = new System.Drawing.Point(90, 25);
            this.cmbSortField.Name = "cmbSortField";
            this.cmbSortField.Size = new System.Drawing.Size(170, 24);
            this.cmbSortField.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Поле:";
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(90, 55);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(170, 25);
            this.btnSort.TabIndex = 0;
            this.btnSort.Text = "Сортувати";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 560);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(276, 35);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Скинути фільтри";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(102, 203);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(170, 25);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Text = "Фільтрувати";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1185, 20);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Готово";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClubsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 713);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ClubsForm";
            this.Text = "Управління гуртками";
            this.Load += new System.EventHandler(this.ClubsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clubsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolClubsDBDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SchoolClubsDBDataSet schoolClubsDBDataSet;
        private System.Windows.Forms.BindingSource clubsBindingSource;
        private SchoolClubsDBDataSetTableAdapters.clubsTableAdapter clubsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agerestrictionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxstudentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacheridDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtToolStripSearch;
        private System.Windows.Forms.ToolStripButton btnToolStripSearch;
        private System.Windows.Forms.ToolStripButton btnToolStripClearSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShowFreeSlots;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAggregate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSortField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSortOrder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbFilterField;
        private System.Windows.Forms.Label lblFilterField;
        private System.Windows.Forms.TextBox txtMaxValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMinValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAggregateFunction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAggregateField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConditionValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGroupField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbAgeFilter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTeacherFilter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPopularClubs;
    }
}