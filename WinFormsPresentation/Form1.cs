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
        }

        private void button_User_GetId_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox_UserId.Text);
            var user = _userRepository.GetById(id);
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

        }

        private void button_Task_GetId_Click(object sender, EventArgs e)
        {

        }

        private void button_Task_Update_Click(object sender, EventArgs e)
        {

        }

        private void button_Task_Insert_Click(object sender, EventArgs e)
        {

        }

        private void button_Task_Delete_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region TaskNote
        private void button_TaskNote_GetAll_Click(object sender, EventArgs e)
        {

        }

        private void button_TaskNote_GetId_Click(object sender, EventArgs e)
        {

        }

        private void button_TaskNote_Update_Click(object sender, EventArgs e)
        {

        }

        private void button_TaskNote_Insert_Click(object sender, EventArgs e)
        {

        }

        private void button_TaskNote_Delete_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}