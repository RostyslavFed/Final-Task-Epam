using Hospital.BLL.DTO;
using System;
using System.Security.Claims;

namespace Hospital.BLL.Interfaces
{
	public interface IUserService : IDisposable
	{
		void Create(UserDTO userDto);
		ClaimsIdentity Authenticate(UserDTO userDto);
	}
}
