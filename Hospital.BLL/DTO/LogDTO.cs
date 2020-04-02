using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
	public class LogDTO
	{
        public int Id { get; set; }
        public string Login { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public DateTime Date { get; set; }
    }
}
