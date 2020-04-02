using System;
using System.Web.Mvc;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;

namespace Hospital.WEB.Filters
{
	public class LogFilter : IActionFilter
    {
        private readonly ILogService _logService;
        public LogFilter(ILogService logService)
        {
            _logService = logService;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            LogDTO log = new LogDTO()
            {
                Login = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "anonym",
                Ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                Url = request.RawUrl,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                Date = DateTime.Now
            };

            _logService.CreateLog(log);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) { }
	}
}