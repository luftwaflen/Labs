using DAL.Repository.Interfaces;
using DAL.Repository.BDRepository;
using DAL.Repository.XMLRepository;
using DAL.Entities;
using Task = DAL.Entities.Task;

namespace WinFormsPresentation
{
    public partial class Form1 : Form
    {
        private IRepository<User> _userRepository = new UserRepository();
        private IRepository<Task> _taskRepository = new TaskRepository();
        private IRepository<TaskNote> _taskNoteRepository = new TaskNoteRepository();

        /*
        private IRepository<User> _userRepository = new UserXMLRepository();
        private IRepository<Task> _taskRepository = new TaskXMLRepository();
        private IRepository<TaskNote> _taskNoteRepository = new TaskNoteXMLRepository();
         */
        public Form1()
        {
            InitializeComponent();
        }
        #region User
        private void button_User_GetAll_Click(object sender, EventArgs e)
        {
            var users = _userRepository.GetAll();
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
            var user = _userRepository.GetById(id);
            List<User> tmp = new List<User> { user };
            InitUserDataGridView(tmp);
        }

        private void button_User_Update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox_UserId.Text);
            string name = textBox_UserName.Text;
            _userRepository.Update(new User { Id = id, Name = name });
        }

        private void button_User_Insert_Click(object sender, EventArgs e)
        {
            string name = textBox_UserName.Text;
            _userRepository.Add(new User { Name = name });
        }

        private void button_User_Delete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox_UserId.Text);
            _userRepository.Delete(id);
        }
        #endregion
        #region Task
        private void button_Task_GetAll_Click(object sender, EventArgs e)
        {
            var tasks = _taskRepository.GetAll();
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
            var task = _taskRepository.GetById(id);
            List<Task> tmp = new List<Task> { task };
            InitTaskDataGridView(tmp);
        }

        private void button_Task_Update_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox_TaskId.Text);
            var name = textBox_TaskName.Text;
            var description = textBox_TaskDescription.Text;
            _taskRepository.Update(new Task { Id = id, Name = name, Description = description });
        }

        private void button_Task_Insert_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox_TaskId.Text);
            var name = textBox_TaskName.Text;
            var description = textBox_TaskDescription.Text;
            _taskRepository.Add(new Task { Id = id, Name = name, Description = description });
        }

        private void button_Task_Delete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox_TaskId.Text);
            _taskRepository.Delete(id);
        }
        #endregion
        #region TaskNote
        private void button_TaskNote_GetAll_Click(object sender, EventArgs e)
        {
            var taskNotes = _taskNoteRepository.GetAll();
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
            _taskNoteRepository.GetById(id);
        }

        private void button_TaskNote_Update_Click(object sender, EventArgs e)
        {
            //var id
            var taskId = int.Parse(textBox_TNTaskId.Text);
            var appointerId = int.Parse(textBox_TNAppenderId.Text);
            var executorId = int.Parse(textBox_TNExecutorId.Text);
            _taskNoteRepository.Update(new TaskNote
            {
                Id = 1,
                TaskId = taskId,
                AppointerId = appointerId,
                ExecutorId = executorId
            });
        }

        private void button_TaskNote_Insert_Click(object sender, EventArgs e)
        {
            var taskId = int.Parse(textBox_TNTaskId.Text);
            var appointerId = int.Parse(textBox_TNAppenderId.Text);
            var executorId = int.Parse(textBox_TNExecutorId.Text);
            _taskNoteRepository.Add(new TaskNote
            {
                TaskId = taskId,
                AppointerId = appointerId,
                ExecutorId = executorId
            });
        }

        private void button_TaskNote_Delete_Click(object sender, EventArgs e)
        {
            var id = 1;
            _taskNoteRepository.Delete(id);
        }
        #endregion
    }
}