using Hospital.WEB.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web;

namespace Hospital.WEB
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			var ninjectControllerFactory = new NinjectControllerFactory();
			ControllerBuilder.Current.SetControllerFactory(ninjectControllerFactory);
			
			AreaRegistration.RegisterAllAreas();

			var logService = ninjectControllerFactory.GetLogService();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, logService);

			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);	
		}
	}
}
