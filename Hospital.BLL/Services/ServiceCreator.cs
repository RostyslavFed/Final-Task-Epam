using Hospital.BLL.Interfaces;
using Hospital.DAL.Repositories;

namespace Hospital.BLL.Services
{
	public class ServiceCreator : IServiceCreator
	{
		public IUserService CreateUserService(string connection)
		{
			return new UserService(new UnitOfWork(connection));
		}
	}
}
