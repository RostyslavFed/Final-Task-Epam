using Hospital.BLL.Interfaces;
using Hospital.WEB.Filters;
using System.Web.Mvc;

namespace Hospital.WEB
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters, ILogService logService)
		{
			//filters.Add(new HandleErrorAttribute());
			filters.Add(new LogFilter(logService));
		}
	}
}
