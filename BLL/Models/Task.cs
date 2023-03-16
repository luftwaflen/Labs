using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Task
    {
        public int Id { get; set; }
        public User Executor { get; set; }
        public User Appender { get; set; }
    }
}
