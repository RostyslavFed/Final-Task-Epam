using Hospital.BLL.Interfaces;
using System.Web.Mvc;
using Hospital.WEB.Models.ViewModels.LogViewModels;
using Hospital.WEB.Models;
using System.Linq;

namespace Hospital.WEB.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public ActionResult List(int page = 1)
        {
            int pageSize = 10;
            var logs = _logService.GetAllLogs();
            int totalItem = logs.ToList().Count;

            var pageInfo = new PageInfo(page, pageSize, totalItem);
            var logsPerPage = logs.Skip((pageInfo.PageNumber - 1) * pageSize).Take(pageSize);
            var logListViewModel = new LogListViewModel
            {
                PageInfo = pageInfo,
                Logs = logsPerPage
            };

            return View(logListViewModel);
        }

        [HttpPost]
        public ActionResult Clear()
        {
            _logService.ClearAllLogs();
            return RedirectToAction("List");
        }
    }
}