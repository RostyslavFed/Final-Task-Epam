using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.WEB.Models.ViewModels.CategoryViewModels;
using Hospital.WEB.Models.ViewModels.PatientViewModels;
using Hospital.WEB.Models.ViewModels.EmployeeViewModels;
using Ninject;
using Ninject.Modules;

namespace Hospital.WEB.Util
{
	public class AutoMapperModule : NinjectModule
	{
		public override void Load()
		{
			var mapperConfiguration = CreateConfiguration();
			Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
			Bind<IMapper>().ToMethod(ctx =>
				new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
		}

		private MapperConfiguration CreateConfiguration()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<Hospital.BLL.Infrastructure.AutoMapper>();
				cfg.AddProfile(new Hospital.BLL.Infrastructure.AutoMapper());

				cfg.CreateMap<CategoryDTO, CategoryViewModel>().ReverseMap();

				cfg.CreateMap<EmployeeDTO, EmployeeCreateViewModel>().ReverseMap();
				cfg.CreateMap<EmployeeDTO, EmployeeEditViewModel>().ReverseMap();
				cfg.CreateMap<EmployeeDTO, EmployeeViewModel>().ReverseMap();

				cfg.CreateMap<PatientDTO, PatientViewModel>().ReverseMap();

			});
			
            return config;
        }
	}
}