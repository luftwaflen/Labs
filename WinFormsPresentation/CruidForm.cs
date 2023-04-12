using BLL.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsPresentation
{
    public partial class CruidForm : Form
    {
        private TaskService _taskService;
        private TaskNoteService _taskNoteService;
        private UserService _userService;
        public CruidForm(int dataSource)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("C:\\PROGA\\IGI\\Labs\\WinFormsPresentation\\configuration.json")
                .AddEnvironmentVariables()
                .Build();

            var projectConfig = config.GetRequiredSection("ConnectionStrings").Get<Configuration>();
            
            var dictionary = new Dictionary<int, string>();
            var dictionary1 = new Dictionary<int, (TaskService, TaskNoteService, UserService)>();
            //dictionary1.Add(1, (new TaskService(), new TaskNoteService(), new UserService()));
            var b = dictionary1[1].Item1;
            dictionary.Add(0, "database");
            dictionary.Add(1, "csv");
            //Вызываем метод соответствующий этой говне
            var a = dictionary[dataSource];

            switch (dataSource)
            {
                case 1:
                    {
                        var userCsv = projectConfig.UserCsv;
                        var taskCsv = projectConfig.TaskCsv;
                        var taskNoteCsv = projectConfig.TaskNoteCsv;
                        _userService = new UserService(userCsv, dataSource);
                        _taskService = new TaskService(taskCsv, dataSource);
                        _taskNoteService = new TaskNoteService(taskNoteCsv, dataSource);
                    }
                    break;

                default:
                    {
                        var connectionString = projectConfig.DbString;
                        _taskService = new TaskService(connectionString, dataSource);
                        _userService = new UserService(connectionString, dataSource);
                        _taskNoteService = new TaskNoteService(connectionString, dataSource);
                    }
                    break;
            }

            InitializeComponent();
        }
    }
}
