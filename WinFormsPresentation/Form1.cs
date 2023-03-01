using DAL.Entities;
using Task = DAL.Entities.Task;
using BLL.Services;

namespace WinFormsPresentation
{
    public partial class Form1 : Form
    {
        private UserService _userService = new UserService();
        private TaskService _taskService = new TaskService();
        private TaskNoteService _taskNoteService = new TaskNoteService();
        public Form1()
        {
            InitializeComponent();
        }
        #region User
        private void button_User_GetAll_Click(object sender, EventArgs e)
        {
            var users = _userService.GetAll();
            InitUserDataGridView(users);
        }
        private void InitUserDataGridView(IEnumerable<User> users)
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
            int id = int.Parse(textBox_UserId.Text);
            var user = _userService.GetById(id);
            List<User> tmp = new List<User> { user };
            InitUserDataGridView(tmp);
        }

        private void button_User_Update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox_UserId.Text);
            string name = textBox_UserName.Text;
            _userService.Update(id, name);
        }

        private void button_User_Insert_Click(object sender, EventArgs e)
        {
            string name = textBox_UserName.Text;
            _userService.Add(name);
        }

        private void button_User_Delete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox_UserId.Text);
            _userService.Delete(id);
        }
        #endregion
        #region Task
        private void button_Task_GetAll_Click(object sender, EventArgs e)
        {
            var tasks = _taskService.GetAll();
            InitTaskDataGridView(tasks);
        }
        private void InitTaskDataGridView(IEnumerable<Task> tasks)
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
            var id = int.Parse(textBox_TaskId.Text);
            var task = _taskService.GetById(id);
            List<Task> tmp = new List<Task> { task };
            InitTaskDataGridView(tmp);
        }

        private void button_Task_Update_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox_TaskId.Text);
            var name = textBox_TaskName.Text;
            var description = textBox_TaskDescription.Text;
            _taskService.Update(id, name, description);
        }

        private void button_Task_Insert_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox_TaskId.Text);
            var name = textBox_TaskName.Text;
            var description = textBox_TaskDescription.Text;
            _taskService.Add(id, name, description);
        }

        private void button_Task_Delete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox_TaskId.Text);
            _taskService.Delete(id);
        }
        #endregion
        #region TaskNote
        private void button_TaskNote_GetAll_Click(object sender, EventArgs e)
        {
            var taskNotes = _taskNoteService.GetAll();
            InitTaskNoteDataGridView(taskNotes);
        }
        private void InitTaskNoteDataGridView(IEnumerable<TaskNote> taskNotes)
        {
            dataGridView_Task.ColumnCount = 4;
            dataGridView_Task.Columns[0].Name = "Id";
            dataGridView_Task.Columns[1].Name = "Task Id";
            dataGridView_Task.Columns[2].Name = "Appointer Id";
            dataGridView_Task.Columns[3].Name = "Executor Id";
            foreach (var taskNote in taskNotes)
            {
                string[] str = { taskNote.Id.ToString(),
                    taskNote.TaskId.ToString(),
                    taskNote.AppointerId.ToString(),
                    taskNote.ExecutorId.ToString() };
                dataGridView_Task.Rows.Add(str);
            }
        }

        private void button_TaskNote_GetId_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox_TNTaskId.Text);
            _taskNoteService.GetById(id);
        }

        private void button_TaskNote_Update_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox_TaskNoteId.Text);
            var taskId = int.Parse(textBox_TNTaskId.Text);
            var appointerId = int.Parse(textBox_TNAppenderId.Text);
            var executorId = int.Parse(textBox_TNExecutorId.Text);
            _taskNoteService.Update(id, taskId, appointerId, executorId);
        }

        private void button_TaskNote_Insert_Click(object sender, EventArgs e)
        {
            var taskId = int.Parse(textBox_TNTaskId.Text);
            var appointerId = int.Parse(textBox_TNAppenderId.Text);
            var executorId = int.Parse(textBox_TNExecutorId.Text);
            _taskNoteService.Add(taskId, appointerId, executorId);
        }

        private void button_TaskNote_Delete_Click(object sender, EventArgs e)
        {
            var id = 1;
            _taskNoteService.Delete(id);
        }
        #endregion
    }
}