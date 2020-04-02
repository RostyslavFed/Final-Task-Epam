using Hospital.BLL.Infrastructure;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Services;
using Ninject;
using Ninject.Modules;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hospital.WEB.Util
{
	public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public NinjectControllerFactory()
        {
            // внедрение зависимостей
            INinjectModule[] ninjectModules = new NinjectModule[]
            {
                new ServiceModule("HospitalContext"),
                new ServicesModule(),
                new FactoryModule(),
                new AutoMapperModule()
            };

            kernel = new StandardKernel(ninjectModules);
        }

        public ILogService GetLogService()
        {
            return kernel.Get<LogService>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }
            else
            {
                return (IController)kernel.Get(controllerType);
            }
        }
    }
}