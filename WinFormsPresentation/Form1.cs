using DAL.Entities;
using TaskEntity = DAL.Entities.TaskEntity;
using BLL.Services;
using Microsoft.Extensions.Configuration;

namespace WinFormsPresentation
{
    public partial class Form1 : Form
    {
        private UserService _userService;
        private TaskService _taskService;
        private TaskNoteService _taskNoteService;
        public Form1()
        {
            InitializeComponent();

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("C:\\PROGA\\IGI\\Labs\\WinFormsPresentation\\configuration.json")
                .AddEnvironmentVariables()
                .Build();

            Configuration projectConfig = config.GetRequiredSection("ConnectionStrings").Get<Configuration>();
            var connectionString = projectConfig.DbString;

            _userService = new UserService(connectionString, 1);
            _taskService = new TaskService(connectionString, 1);
            _taskNoteService = new TaskNoteService(connectionString, 1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var users = _userService.GetAll();
            InitUserDataGridView(users);
            var tasks = _taskService.GetAll();
            InitTaskDataGridView(tasks);
            var taskNotes = _taskNoteService.GetAll();
            InitTaskNoteDataGridView(taskNotes);
        }
        #region User
        private void button_User_GetAll_Click(object sender, EventArgs e)
        {
            try
            {
                var users = _userService.GetAll();
                dataGridView_User.Rows.Clear();
                InitUserDataGridView(users);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitUserDataGridView(IEnumerable<UserEntity> users)
        {
            dataGridView_User.ColumnCount = 2;
            dataGridView_User.Columns[0].Name = "Id";
            dataGridView_User.Columns[1].Name = "Name";
            foreach (var user in users)
            {
                string[] str = { user.Id.ToString(), user.Name };
                dataGridView_User.Rows.Add(str);
            }
        }

        private void button_User_GetId_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox_UserId.Text);
                var user = _userService.GetById(id);
                var tmp = new List<UserEntity> { user };
                dataGridView_User.Rows.Clear();
                InitUserDataGridView(tmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_User_Update_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox_UserId.Text);
                var name = textBox_UserName.Text;
                _userService.Update(id, name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_User_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                var name = textBox_UserName.Text;
                if (name == "")
                    throw new Exception("Empty name");
                _userService.Add(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_User_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox_UserId.Text);
                _userService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Task
        private void button_Task_GetAll_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = _taskService.GetAll();
                dataGridView_Task.Rows.Clear();
                InitTaskDataGridView(tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitTaskDataGridView(IEnumerable<TaskEntity> tasks)
        {
            dataGridView_Task.ColumnCount = 3;
            dataGridView_Task.Columns[0].Name = "Id";
            dataGridView_Task.Columns[1].Name = "Name";
            dataGridView_Task.Columns[2].Name = "Description";
            foreach (var task in tasks)
            {
                string[] str = { task.Id.ToString(), task.Name, task.Description };
                dataGridView_Task.Rows.Add(str);
            }
        }

        private void button_Task_GetId_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox_TaskId.Text);
                var task = _taskService.GetById(id);
                var tmp = new List<TaskEntity> { task };
                dataGridView_Task.Rows.Clear();
                InitTaskDataGridView(tmp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Task_Update_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox_TaskId.Text);
                var name = textBox_TaskName.Text;
                var description = textBox_TaskDescription.Text;
                if (name == "" || description == "")
                    throw new Exception("No data");
                _taskService.Update(id, name, description);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Task_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                var name = textBox_TaskName.Text;
                var description = textBox_TaskDescription.Text;
                if (name == "" || description == "")
                    throw new Exception("No data");
                _taskService.Add(0, name, description);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Task_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox_TaskId.Text);
                _taskService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region TaskNote
        private void button_TaskNote_GetAll_Click(object sender, EventArgs e)
        {
            try
            {
                var taskNotes = _taskNoteService.GetAll();
                dataGridView_TaskNote.Rows.Clear();
                InitTaskNoteDataGridView(taskNotes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitTaskNoteDataGridView(IEnumerable<TaskNoteEntity> taskNotes)
        {
            dataGridView_TaskNote.ColumnCount = 4;
            dataGridView_TaskNote.Columns[0].Name = "Id";
            dataGridView_TaskNote.Columns[1].Name = "Task Id";
            dataGridView_TaskNote.Columns[2].Name = "Appointer Id";
            dataGridView_TaskNote.Columns[3].Name = "Executor Id";
            foreach (var taskNote in taskNotes)
            {
                string[] str = { taskNote.Id.ToString(),
                    taskNote.TaskId.ToString(),
                    taskNote.AppointerId.ToString(),
                    taskNote.ExecutorId.ToString() };
                dataGridView_TaskNote.Rows.Add(str);
            }
        }

        private void button_TaskNote_GetId_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox_TaskNoteId.Text);
                dataGridView_TaskNote.Rows.Clear();
                List<TaskNoteEntity> notes = new List<TaskNoteEntity>();
                notes.Add(_taskNoteService.GetById(id));
                InitTaskNoteDataGridView(notes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void button_TaskNote_Update_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox_TaskNoteId.Text);
                var taskId = int.Parse(textBox_TNTaskId.Text);
                var appointerId = int.Parse(textBox_TNAppenderId.Text);
                var executorId = int.Parse(textBox_TNExecutorId.Text);
                _taskNoteService.Update(id, taskId, appointerId, executorId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_TaskNote_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                var taskId = int.Parse(textBox_TNTaskId.Text);
                var appointerId = int.Parse(textBox_TNAppenderId.Text);
                var executorId = int.Parse(textBox_TNExecutorId.Text);
                _taskNoteService.Add(taskId, appointerId, executorId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_TaskNote_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox_TaskNoteId.Text);
                _taskNoteService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}