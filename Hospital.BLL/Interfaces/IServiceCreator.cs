﻿namespace Hospital.BLL.Interfaces
{
	public interface IServiceCreator
	{
		IUserService CreateUserService(string connection);
	}
}
