using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Services;

[assembly: OwinStartup(typeof(Hospital.WEB.App_Start.Startup))]

namespace Hospital.WEB.App_Start
{
	public class Startup
	{
        private IServiceCreator _serviceCreator;

        public void Configuration(IAppBuilder app)
        {
            _serviceCreator = new ServiceCreator();

            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return _serviceCreator.CreateUserService("HospitalContext");
        }
    }
}