using System;

namespace Hospital.DAL.Entity
{
	public class Log
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
