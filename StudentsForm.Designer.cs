namespace SchoolClubsApp
{
    partial class StudentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentsForm));
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
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
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
            this.studentsTableAdapter = new SchoolClubsApp.SchoolClubsDBDataSetTableAdapters.studentsTableAdapter();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.comboBoxClassFilter = new System.Windows.Forms.ComboBox();
            this.btnFilterByClass = new System.Windows.Forms.Button();
            this.groupBoxSorting = new System.Windows.Forms.GroupBox();
            this.btnSortByLastName = new System.Windows.Forms.Button();
            this.btnSortByClass = new System.Windows.Forms.Button();
            this.groupBoxQueries = new System.Windows.Forms.GroupBox();
            this.comboBoxClassQuery = new System.Windows.Forms.ComboBox();
            this.btnStudentsWithoutClubs = new System.Windows.Forms.Button();
            this.btnMultipleClubs = new System.Windows.Forms.Button();
            this.dataGridViewQueryResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolClubsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxFilter.SuspendLayout();
            this.groupBoxSorting.SuspendLayout();
            this.groupBoxQueries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueryResults)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 140);
            this.dataGridView1.TabIndex = 0;
            // 
            // studentidDataGridViewTextBoxColumn
            // 
            this.studentidDataGridViewTextBoxColumn.DataPropertyName = "student_id";
            this.studentidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.studentidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.studentidDataGridViewTextBoxColumn.Name = "studentidDataGridViewTextBoxColumn";
            this.studentidDataGridViewTextBoxColumn.ReadOnly = true;
            this.studentidDataGridViewTextBoxColumn.Width = 50;
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "Прізвище";
            this.lastnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            this.lastnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "Ім\'я";
            this.firstnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // patronymicDataGridViewTextBoxColumn
            // 
            this.patronymicDataGridViewTextBoxColumn.DataPropertyName = "patronymic";
            this.patronymicDataGridViewTextBoxColumn.HeaderText = "По батькові";
            this.patronymicDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.patronymicDataGridViewTextBoxColumn.Name = "patronymicDataGridViewTextBoxColumn";
            this.patronymicDataGridViewTextBoxColumn.Width = 125;
            // 
            // classDataGridViewTextBoxColumn
            // 
            this.classDataGridViewTextBoxColumn.DataPropertyName = "class";
            this.classDataGridViewTextBoxColumn.HeaderText = "Клас";
            this.classDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.classDataGridViewTextBoxColumn.Name = "classDataGridViewTextBoxColumn";
            this.classDataGridViewTextBoxColumn.Width = 80;
            // 
            // parentphoneDataGridViewTextBoxColumn
            // 
            this.parentphoneDataGridViewTextBoxColumn.DataPropertyName = "parent_phone";
            this.parentphoneDataGridViewTextBoxColumn.HeaderText = "Телефон батьків";
            this.parentphoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.parentphoneDataGridViewTextBoxColumn.Name = "parentphoneDataGridViewTextBoxColumn";
            this.parentphoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 150;
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
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.studentsBindingSource;
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
            this.toolStripButton1});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1000, 27);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
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
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
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
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // studentsTableAdapter
            // 
            this.studentsTableAdapter.ClearBeforeFill = true;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.txtSearch);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.btnClearSearch);
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 40);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(400, 50);
            this.groupBoxSearch.TabIndex = 2;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Пошук учнів";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(10, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Прізвище, ім\'я або клас";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(220, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 25);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(310, 18);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(80, 25);
            this.btnClearSearch.TabIndex = 2;
            this.btnClearSearch.Text = "Очистити";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.comboBoxClassFilter);
            this.groupBoxFilter.Controls.Add(this.btnFilterByClass);
            this.groupBoxFilter.Location = new System.Drawing.Point(420, 40);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(300, 50);
            this.groupBoxFilter.TabIndex = 3;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Фільтрація за класом";
            // 
            // comboBoxClassFilter
            // 
            this.comboBoxClassFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClassFilter.FormattingEnabled = true;
            this.comboBoxClassFilter.Location = new System.Drawing.Point(10, 20);
            this.comboBoxClassFilter.Name = "comboBoxClassFilter";
            this.comboBoxClassFilter.Size = new System.Drawing.Size(150, 24);
            this.comboBoxClassFilter.TabIndex = 0;
            this.comboBoxClassFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxClassFilter_SelectedIndexChanged);
            // 
            // btnFilterByClass
            // 
            this.btnFilterByClass.Location = new System.Drawing.Point(170, 18);
            this.btnFilterByClass.Name = "btnFilterByClass";
            this.btnFilterByClass.Size = new System.Drawing.Size(120, 25);
            this.btnFilterByClass.TabIndex = 1;
            this.btnFilterByClass.Text = "Застосувати";
            this.btnFilterByClass.UseVisualStyleBackColor = true;
            this.btnFilterByClass.Click += new System.EventHandler(this.btnFilterByClass_Click);
            // 
            // groupBoxSorting
            // 
            this.groupBoxSorting.Controls.Add(this.btnSortByLastName);
            this.groupBoxSorting.Controls.Add(this.btnSortByClass);
            this.groupBoxSorting.Location = new System.Drawing.Point(12, 250);
            this.groupBoxSorting.Name = "groupBoxSorting";
            this.groupBoxSorting.Size = new System.Drawing.Size(250, 60);
            this.groupBoxSorting.TabIndex = 4;
            this.groupBoxSorting.TabStop = false;
            this.groupBoxSorting.Text = "Сортування";
            // 
            // btnSortByLastName
            // 
            this.btnSortByLastName.Location = new System.Drawing.Point(10, 25);
            this.btnSortByLastName.Name = "btnSortByLastName";
            this.btnSortByLastName.Size = new System.Drawing.Size(110, 25);
            this.btnSortByLastName.TabIndex = 0;
            this.btnSortByLastName.Text = "За прізвищем";
            this.btnSortByLastName.UseVisualStyleBackColor = true;
            this.btnSortByLastName.Click += new System.EventHandler(this.btnSortByLastName_Click);
            // 
            // btnSortByClass
            // 
            this.btnSortByClass.Location = new System.Drawing.Point(130, 25);
            this.btnSortByClass.Name = "btnSortByClass";
            this.btnSortByClass.Size = new System.Drawing.Size(110, 25);
            this.btnSortByClass.TabIndex = 1;
            this.btnSortByClass.Text = "За класом";
            this.btnSortByClass.UseVisualStyleBackColor = true;
            this.btnSortByClass.Click += new System.EventHandler(this.btnSortByClass_Click);
            // 
            // groupBoxQueries
            // 
            this.groupBoxQueries.Controls.Add(this.comboBoxClassQuery);
            this.groupBoxQueries.Controls.Add(this.btnStudentsWithoutClubs);
            this.groupBoxQueries.Controls.Add(this.btnMultipleClubs);
            this.groupBoxQueries.Location = new System.Drawing.Point(280, 250);
            this.groupBoxQueries.Name = "groupBoxQueries";
            this.groupBoxQueries.Size = new System.Drawing.Size(500, 60);
            this.groupBoxQueries.TabIndex = 5;
            this.groupBoxQueries.TabStop = false;
            this.groupBoxQueries.Text = "Спеціальні запити";
            // 
            // comboBoxClassQuery
            // 
            this.comboBoxClassQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClassQuery.FormattingEnabled = true;
            this.comboBoxClassQuery.Location = new System.Drawing.Point(10, 25);
            this.comboBoxClassQuery.Name = "comboBoxClassQuery";
            this.comboBoxClassQuery.Size = new System.Drawing.Size(120, 24);
            this.comboBoxClassQuery.TabIndex = 0;
            // 
            // btnStudentsWithoutClubs
            // 
            this.btnStudentsWithoutClubs.Location = new System.Drawing.Point(140, 23);
            this.btnStudentsWithoutClubs.Name = "btnStudentsWithoutClubs";
            this.btnStudentsWithoutClubs.Size = new System.Drawing.Size(170, 25);
            this.btnStudentsWithoutClubs.TabIndex = 1;
            this.btnStudentsWithoutClubs.Text = "Учні без гуртків";
            this.btnStudentsWithoutClubs.UseVisualStyleBackColor = true;
            this.btnStudentsWithoutClubs.Click += new System.EventHandler(this.btnStudentsWithoutClubs_Click);
            // 
            // btnMultipleClubs
            // 
            this.btnMultipleClubs.Location = new System.Drawing.Point(320, 23);
            this.btnMultipleClubs.Name = "btnMultipleClubs";
            this.btnMultipleClubs.Size = new System.Drawing.Size(170, 25);
            this.btnMultipleClubs.TabIndex = 2;
            this.btnMultipleClubs.Text = "Учні з >1 гуртком";
            this.btnMultipleClubs.UseVisualStyleBackColor = true;
            this.btnMultipleClubs.Click += new System.EventHandler(this.btnMultipleClubs_Click);
            // 
            // dataGridViewQueryResults
            // 
            this.dataGridViewQueryResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQueryResults.Location = new System.Drawing.Point(12, 320);
            this.dataGridViewQueryResults.Name = "dataGridViewQueryResults";
            this.dataGridViewQueryResults.RowHeadersWidth = 51;
            this.dataGridViewQueryResults.RowTemplate.Height = 24;
            this.dataGridViewQueryResults.Size = new System.Drawing.Size(976, 200);
            this.dataGridViewQueryResults.TabIndex = 6;
            this.dataGridViewQueryResults.Visible = false;
            // 
            // StudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.dataGridViewQueryResults);
            this.Controls.Add(this.groupBoxQueries);
            this.Controls.Add(this.groupBoxSorting);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StudentsForm";
            this.Text = "Учні";
            this.Load += new System.EventHandler(this.StudentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolClubsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxSorting.ResumeLayout(false);
            this.groupBoxQueries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueryResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.ComboBox comboBoxClassFilter;
        private System.Windows.Forms.Button btnFilterByClass;
        private System.Windows.Forms.GroupBox groupBoxSorting;
        private System.Windows.Forms.Button btnSortByLastName;
        private System.Windows.Forms.Button btnSortByClass;
        private System.Windows.Forms.GroupBox groupBoxQueries;
        private System.Windows.Forms.ComboBox comboBoxClassQuery;
        private System.Windows.Forms.Button btnStudentsWithoutClubs;
        private System.Windows.Forms.Button btnMultipleClubs;
        private System.Windows.Forms.DataGridView dataGridViewQueryResults;
    }
}