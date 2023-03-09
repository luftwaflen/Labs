namespace WinFormsPresentation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUser = new System.Windows.Forms.TabPage();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_UserId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_User = new System.Windows.Forms.DataGridView();
            this.button_User_Delete = new System.Windows.Forms.Button();
            this.button_User_Update = new System.Windows.Forms.Button();
            this.button_User_Insert = new System.Windows.Forms.Button();
            this.button_User_GetId = new System.Windows.Forms.Button();
            this.button_User_GetAll = new System.Windows.Forms.Button();
            this.tabPageTask = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_TaskDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TaskName = new System.Windows.Forms.TextBox();
            this.textBox_TaskId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_Task = new System.Windows.Forms.DataGridView();
            this.button_Task_Delete = new System.Windows.Forms.Button();
            this.button_Task_Update = new System.Windows.Forms.Button();
            this.button_Task_Insert = new System.Windows.Forms.Button();
            this.button_Task_GetId = new System.Windows.Forms.Button();
            this.button_Task_GetAll = new System.Windows.Forms.Button();
            this.tabPageTaskNote = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_TNTaskId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_TNExecutorId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_TNAppenderId = new System.Windows.Forms.TextBox();
            this.textBox_TaskNoteId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView_TaskNote = new System.Windows.Forms.DataGridView();
            this.button_TaskNote_Delete = new System.Windows.Forms.Button();
            this.button_TaskNote_Update = new System.Windows.Forms.Button();
            this.button_TaskNote_Insert = new System.Windows.Forms.Button();
            this.button_TaskNote_GetId = new System.Windows.Forms.Button();
            this.button_TaskNote_GetAll = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_User)).BeginInit();
            this.tabPageTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Task)).BeginInit();
            this.tabPageTaskNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TaskNote)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUser);
            this.tabControl1.Controls.Add(this.tabPageTask);
            this.tabControl1.Controls.Add(this.tabPageTaskNote);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageUser
            // 
            this.tabPageUser.Controls.Add(this.textBox_UserName);
            this.tabPageUser.Controls.Add(this.textBox_UserId);
            this.tabPageUser.Controls.Add(this.label2);
            this.tabPageUser.Controls.Add(this.label1);
            this.tabPageUser.Controls.Add(this.dataGridView_User);
            this.tabPageUser.Controls.Add(this.button_User_Delete);
            this.tabPageUser.Controls.Add(this.button_User_Update);
            this.tabPageUser.Controls.Add(this.button_User_Insert);
            this.tabPageUser.Controls.Add(this.button_User_GetId);
            this.tabPageUser.Controls.Add(this.button_User_GetAll);
            this.tabPageUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageUser.Location = new System.Drawing.Point(4, 24);
            this.tabPageUser.Name = "tabPageUser";
            this.tabPageUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUser.Size = new System.Drawing.Size(792, 422);
            this.tabPageUser.TabIndex = 0;
            this.tabPageUser.Text = "User";
            this.tabPageUser.UseVisualStyleBackColor = true;
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_UserName.Location = new System.Drawing.Point(253, 317);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(100, 29);
            this.textBox_UserName.TabIndex = 9;
            // 
            // textBox_UserId
            // 
            this.textBox_UserId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_UserId.Location = new System.Drawing.Point(68, 317);
            this.textBox_UserId.Name = "textBox_UserId";
            this.textBox_UserId.Size = new System.Drawing.Size(100, 29);
            this.textBox_UserId.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(192, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Id:";
            // 
            // dataGridView_User
            // 
            this.dataGridView_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_User.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_User.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_User.Name = "dataGridView_User";
            this.dataGridView_User.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_User.RowTemplate.Height = 25;
            this.dataGridView_User.Size = new System.Drawing.Size(786, 284);
            this.dataGridView_User.TabIndex = 5;
            // 
            // button_User_Delete
            // 
            this.button_User_Delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_User_Delete.Location = new System.Drawing.Point(408, 375);
            this.button_User_Delete.Name = "button_User_Delete";
            this.button_User_Delete.Size = new System.Drawing.Size(75, 30);
            this.button_User_Delete.TabIndex = 4;
            this.button_User_Delete.Text = "Delete";
            this.button_User_Delete.UseVisualStyleBackColor = true;
            this.button_User_Delete.Click += new System.EventHandler(this.button_User_Delete_Click);
            // 
            // button_User_Update
            // 
            this.button_User_Update.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_User_Update.Location = new System.Drawing.Point(216, 375);
            this.button_User_Update.Name = "button_User_Update";
            this.button_User_Update.Size = new System.Drawing.Size(75, 30);
            this.button_User_Update.TabIndex = 3;
            this.button_User_Update.Text = "Update";
            this.button_User_Update.UseVisualStyleBackColor = true;
            this.button_User_Update.Click += new System.EventHandler(this.button_User_Update_Click);
            // 
            // button_User_Insert
            // 
            this.button_User_Insert.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_User_Insert.Location = new System.Drawing.Point(312, 375);
            this.button_User_Insert.Name = "button_User_Insert";
            this.button_User_Insert.Size = new System.Drawing.Size(75, 30);
            this.button_User_Insert.TabIndex = 2;
            this.button_User_Insert.Text = "Insert";
            this.button_User_Insert.UseVisualStyleBackColor = true;
            this.button_User_Insert.Click += new System.EventHandler(this.button_User_Insert_Click);
            // 
            // button_User_GetId
            // 
            this.button_User_GetId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_User_GetId.Location = new System.Drawing.Point(120, 375);
            this.button_User_GetId.Name = "button_User_GetId";
            this.button_User_GetId.Size = new System.Drawing.Size(75, 30);
            this.button_User_GetId.TabIndex = 1;
            this.button_User_GetId.Text = "GetById";
            this.button_User_GetId.UseVisualStyleBackColor = true;
            this.button_User_GetId.Click += new System.EventHandler(this.button_User_GetId_Click);
            // 
            // button_User_GetAll
            // 
            this.button_User_GetAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_User_GetAll.Location = new System.Drawing.Point(24, 375);
            this.button_User_GetAll.Name = "button_User_GetAll";
            this.button_User_GetAll.Size = new System.Drawing.Size(75, 30);
            this.button_User_GetAll.TabIndex = 0;
            this.button_User_GetAll.Text = "GetAll";
            this.button_User_GetAll.UseVisualStyleBackColor = true;
            this.button_User_GetAll.Click += new System.EventHandler(this.button_User_GetAll_Click);
            // 
            // tabPageTask
            // 
            this.tabPageTask.Controls.Add(this.label5);
            this.tabPageTask.Controls.Add(this.textBox_TaskDescription);
            this.tabPageTask.Controls.Add(this.label4);
            this.tabPageTask.Controls.Add(this.textBox_TaskName);
            this.tabPageTask.Controls.Add(this.textBox_TaskId);
            this.tabPageTask.Controls.Add(this.label3);
            this.tabPageTask.Controls.Add(this.dataGridView_Task);
            this.tabPageTask.Controls.Add(this.button_Task_Delete);
            this.tabPageTask.Controls.Add(this.button_Task_Update);
            this.tabPageTask.Controls.Add(this.button_Task_Insert);
            this.tabPageTask.Controls.Add(this.button_Task_GetId);
            this.tabPageTask.Controls.Add(this.button_Task_GetAll);
            this.tabPageTask.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageTask.Location = new System.Drawing.Point(4, 24);
            this.tabPageTask.Name = "tabPageTask";
            this.tabPageTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTask.Size = new System.Drawing.Size(792, 422);
            this.tabPageTask.TabIndex = 1;
            this.tabPageTask.Text = "Task";
            this.tabPageTask.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(376, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "Description:";
            // 
            // textBox_TaskDescription
            // 
            this.textBox_TaskDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TaskDescription.Location = new System.Drawing.Point(474, 326);
            this.textBox_TaskDescription.Name = "textBox_TaskDescription";
            this.textBox_TaskDescription.Size = new System.Drawing.Size(100, 29);
            this.textBox_TaskDescription.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(36, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "Id:";
            // 
            // textBox_TaskName
            // 
            this.textBox_TaskName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TaskName.Location = new System.Drawing.Point(253, 326);
            this.textBox_TaskName.Name = "textBox_TaskName";
            this.textBox_TaskName.Size = new System.Drawing.Size(100, 29);
            this.textBox_TaskName.TabIndex = 18;
            // 
            // textBox_TaskId
            // 
            this.textBox_TaskId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TaskId.Location = new System.Drawing.Point(68, 326);
            this.textBox_TaskId.Name = "textBox_TaskId";
            this.textBox_TaskId.Size = new System.Drawing.Size(100, 29);
            this.textBox_TaskId.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(192, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "Name:";
            // 
            // dataGridView_Task
            // 
            this.dataGridView_Task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Task.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_Task.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Task.Name = "dataGridView_Task";
            this.dataGridView_Task.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_Task.RowTemplate.Height = 25;
            this.dataGridView_Task.Size = new System.Drawing.Size(786, 284);
            this.dataGridView_Task.TabIndex = 15;
            // 
            // button_Task_Delete
            // 
            this.button_Task_Delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Task_Delete.Location = new System.Drawing.Point(408, 382);
            this.button_Task_Delete.Name = "button_Task_Delete";
            this.button_Task_Delete.Size = new System.Drawing.Size(75, 30);
            this.button_Task_Delete.TabIndex = 14;
            this.button_Task_Delete.Text = "Delete";
            this.button_Task_Delete.UseVisualStyleBackColor = true;
            this.button_Task_Delete.Click += new System.EventHandler(this.button_Task_Delete_Click);
            // 
            // button_Task_Update
            // 
            this.button_Task_Update.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Task_Update.Location = new System.Drawing.Point(216, 382);
            this.button_Task_Update.Name = "button_Task_Update";
            this.button_Task_Update.Size = new System.Drawing.Size(75, 30);
            this.button_Task_Update.TabIndex = 13;
            this.button_Task_Update.Text = "Update";
            this.button_Task_Update.UseVisualStyleBackColor = true;
            this.button_Task_Update.Click += new System.EventHandler(this.button_Task_Update_Click);
            // 
            // button_Task_Insert
            // 
            this.button_Task_Insert.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Task_Insert.Location = new System.Drawing.Point(312, 382);
            this.button_Task_Insert.Name = "button_Task_Insert";
            this.button_Task_Insert.Size = new System.Drawing.Size(75, 30);
            this.button_Task_Insert.TabIndex = 12;
            this.button_Task_Insert.Text = "Insert";
            this.button_Task_Insert.UseVisualStyleBackColor = true;
            this.button_Task_Insert.Click += new System.EventHandler(this.button_Task_Insert_Click);
            // 
            // button_Task_GetId
            // 
            this.button_Task_GetId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Task_GetId.Location = new System.Drawing.Point(120, 382);
            this.button_Task_GetId.Name = "button_Task_GetId";
            this.button_Task_GetId.Size = new System.Drawing.Size(75, 30);
            this.button_Task_GetId.TabIndex = 11;
            this.button_Task_GetId.Text = "GetById";
            this.button_Task_GetId.UseVisualStyleBackColor = true;
            this.button_Task_GetId.Click += new System.EventHandler(this.button_Task_GetId_Click);
            // 
            // button_Task_GetAll
            // 
            this.button_Task_GetAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Task_GetAll.Location = new System.Drawing.Point(24, 382);
            this.button_Task_GetAll.Name = "button_Task_GetAll";
            this.button_Task_GetAll.Size = new System.Drawing.Size(75, 30);
            this.button_Task_GetAll.TabIndex = 10;
            this.button_Task_GetAll.Text = "GetAll";
            this.button_Task_GetAll.UseVisualStyleBackColor = true;
            this.button_Task_GetAll.Click += new System.EventHandler(this.button_Task_GetAll_Click);
            // 
            // tabPageTaskNote
            // 
            this.tabPageTaskNote.Controls.Add(this.label9);
            this.tabPageTaskNote.Controls.Add(this.textBox_TNTaskId);
            this.tabPageTaskNote.Controls.Add(this.label6);
            this.tabPageTaskNote.Controls.Add(this.textBox_TNExecutorId);
            this.tabPageTaskNote.Controls.Add(this.label7);
            this.tabPageTaskNote.Controls.Add(this.textBox_TNAppenderId);
            this.tabPageTaskNote.Controls.Add(this.textBox_TaskNoteId);
            this.tabPageTaskNote.Controls.Add(this.label8);
            this.tabPageTaskNote.Controls.Add(this.dataGridView_TaskNote);
            this.tabPageTaskNote.Controls.Add(this.button_TaskNote_Delete);
            this.tabPageTaskNote.Controls.Add(this.button_TaskNote_Update);
            this.tabPageTaskNote.Controls.Add(this.button_TaskNote_Insert);
            this.tabPageTaskNote.Controls.Add(this.button_TaskNote_GetId);
            this.tabPageTaskNote.Controls.Add(this.button_TaskNote_GetAll);
            this.tabPageTaskNote.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageTaskNote.Location = new System.Drawing.Point(4, 24);
            this.tabPageTaskNote.Name = "tabPageTaskNote";
            this.tabPageTaskNote.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTaskNote.Size = new System.Drawing.Size(792, 422);
            this.tabPageTaskNote.TabIndex = 2;
            this.tabPageTaskNote.Text = "TaskNote";
            this.tabPageTaskNote.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(518, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 21);
            this.label9.TabIndex = 35;
            this.label9.Text = "TaskId:";
            // 
            // textBox_TNTaskId
            // 
            this.textBox_TNTaskId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TNTaskId.Location = new System.Drawing.Point(580, 328);
            this.textBox_TNTaskId.Name = "textBox_TNTaskId";
            this.textBox_TNTaskId.Size = new System.Drawing.Size(55, 29);
            this.textBox_TNTaskId.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(333, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 21);
            this.label6.TabIndex = 33;
            this.label6.Text = "ExecutorId:";
            // 
            // textBox_TNExecutorId
            // 
            this.textBox_TNExecutorId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TNExecutorId.Location = new System.Drawing.Point(425, 328);
            this.textBox_TNExecutorId.Name = "textBox_TNExecutorId";
            this.textBox_TNExecutorId.Size = new System.Drawing.Size(55, 29);
            this.textBox_TNExecutorId.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(13, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 21);
            this.label7.TabIndex = 31;
            this.label7.Text = "Id:";
            // 
            // textBox_TNAppenderId
            // 
            this.textBox_TNAppenderId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TNAppenderId.Location = new System.Drawing.Point(239, 328);
            this.textBox_TNAppenderId.Name = "textBox_TNAppenderId";
            this.textBox_TNAppenderId.Size = new System.Drawing.Size(55, 29);
            this.textBox_TNAppenderId.TabIndex = 30;
            // 
            // textBox_TaskNoteId
            // 
            this.textBox_TaskNoteId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TaskNoteId.Location = new System.Drawing.Point(46, 328);
            this.textBox_TaskNoteId.Name = "textBox_TaskNoteId";
            this.textBox_TaskNoteId.Size = new System.Drawing.Size(55, 29);
            this.textBox_TaskNoteId.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(138, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 21);
            this.label8.TabIndex = 28;
            this.label8.Text = "AppenderId:";
            // 
            // dataGridView_TaskNote
            // 
            this.dataGridView_TaskNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TaskNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_TaskNote.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_TaskNote.Name = "dataGridView_TaskNote";
            this.dataGridView_TaskNote.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_TaskNote.RowTemplate.Height = 25;
            this.dataGridView_TaskNote.Size = new System.Drawing.Size(786, 284);
            this.dataGridView_TaskNote.TabIndex = 27;
            // 
            // button_TaskNote_Delete
            // 
            this.button_TaskNote_Delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_TaskNote_Delete.Location = new System.Drawing.Point(408, 386);
            this.button_TaskNote_Delete.Name = "button_TaskNote_Delete";
            this.button_TaskNote_Delete.Size = new System.Drawing.Size(75, 30);
            this.button_TaskNote_Delete.TabIndex = 26;
            this.button_TaskNote_Delete.Text = "Delete";
            this.button_TaskNote_Delete.UseVisualStyleBackColor = true;
            this.button_TaskNote_Delete.Click += new System.EventHandler(this.button_TaskNote_Delete_Click);
            // 
            // button_TaskNote_Update
            // 
            this.button_TaskNote_Update.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_TaskNote_Update.Location = new System.Drawing.Point(216, 386);
            this.button_TaskNote_Update.Name = "button_TaskNote_Update";
            this.button_TaskNote_Update.Size = new System.Drawing.Size(75, 30);
            this.button_TaskNote_Update.TabIndex = 25;
            this.button_TaskNote_Update.Text = "Update";
            this.button_TaskNote_Update.UseVisualStyleBackColor = true;
            this.button_TaskNote_Update.Click += new System.EventHandler(this.button_TaskNote_Update_Click);
            // 
            // button_TaskNote_Insert
            // 
            this.button_TaskNote_Insert.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_TaskNote_Insert.Location = new System.Drawing.Point(312, 386);
            this.button_TaskNote_Insert.Name = "button_TaskNote_Insert";
            this.button_TaskNote_Insert.Size = new System.Drawing.Size(75, 30);
            this.button_TaskNote_Insert.TabIndex = 24;
            this.button_TaskNote_Insert.Text = "Insert";
            this.button_TaskNote_Insert.UseVisualStyleBackColor = true;
            this.button_TaskNote_Insert.Click += new System.EventHandler(this.button_TaskNote_Insert_Click);
            // 
            // button_TaskNote_GetId
            // 
            this.button_TaskNote_GetId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_TaskNote_GetId.Location = new System.Drawing.Point(120, 386);
            this.button_TaskNote_GetId.Name = "button_TaskNote_GetId";
            this.button_TaskNote_GetId.Size = new System.Drawing.Size(75, 30);
            this.button_TaskNote_GetId.TabIndex = 23;
            this.button_TaskNote_GetId.Text = "GetById";
            this.button_TaskNote_GetId.UseVisualStyleBackColor = true;
            this.button_TaskNote_GetId.Click += new System.EventHandler(this.button_TaskNote_GetId_Click);
            // 
            // button_TaskNote_GetAll
            // 
            this.button_TaskNote_GetAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_TaskNote_GetAll.Location = new System.Drawing.Point(24, 386);
            this.button_TaskNote_GetAll.Name = "button_TaskNote_GetAll";
            this.button_TaskNote_GetAll.Size = new System.Drawing.Size(75, 30);
            this.button_TaskNote_GetAll.TabIndex = 22;
            this.button_TaskNote_GetAll.Text = "GetAll";
            this.button_TaskNote_GetAll.UseVisualStyleBackColor = true;
            this.button_TaskNote_GetAll.Click += new System.EventHandler(this.button_TaskNote_GetAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "WA$ERSTDYFUGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageUser.ResumeLayout(false);
            this.tabPageUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_User)).EndInit();
            this.tabPageTask.ResumeLayout(false);
            this.tabPageTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Task)).EndInit();
            this.tabPageTaskNote.ResumeLayout(false);
            this.tabPageTaskNote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TaskNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageUser;
        private Button button_User_Delete;
        private Button button_User_Update;
        private Button button_User_Insert;
        private Button button_User_GetId;
        private Button button_User_GetAll;
        private TabPage tabPageTask;
        private TabPage tabPageTaskNote;
        private Label label1;
        private DataGridView dataGridView_User;
        private Label label2;
        private TextBox textBox_UserName;
        private TextBox textBox_UserId;
        private TextBox textBox_TaskName;
        private TextBox textBox_TaskId;
        private Label label3;
        private DataGridView dataGridView_Task;
        private Button button_Task_Delete;
        private Button button_Task_Update;
        private Button button_Task_Insert;
        private Button button_Task_GetId;
        private Button button_Task_GetAll;
        private Label label5;
        private TextBox textBox_TaskDescription;
        private Label label4;
        private Label label6;
        private TextBox textBox_TNExecutorId;
        private Label label7;
        private TextBox textBox_TNAppenderId;
        private TextBox textBox_TaskNoteId;
        private Label label8;
        private DataGridView dataGridView_TaskNote;
        private Button button_TaskNote_Delete;
        private Button button_TaskNote_Update;
        private Button button_TaskNote_Insert;
        private Button button_TaskNote_GetId;
        private Button button_TaskNote_GetAll;
        private Label label9;
        private TextBox textBox_TNTaskId;
    }
}