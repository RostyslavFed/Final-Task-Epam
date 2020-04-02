using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System;

namespace Hospital.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ClaimsIdentity Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            User user = _unitOfWork.UserManager.FindByEmail(userDto.Email);
            if (user != null)
            {
                user = _unitOfWork.UserManager.Find(user.UserName, userDto.Password);

                // авторизуем его и возвращаем объект ClaimsIdentity
                if (user != null)
                {
                    claim = _unitOfWork.UserManager
                        .CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                }
            }

            return claim;
        }

        public void Create(UserDTO userDto)
        {
            User user = _unitOfWork.UserManager.FindByEmail(userDto.Email);
            if (user == null)
            {
                user = new User
                {
                    Email = userDto.Email,
                    UserName = userDto.UserName,
                    PhoneNumber = userDto.PhoneNumber,
                    Address = userDto.Address,
                    Birthday = userDto.Birthday,
                    Gender = userDto.Gender, 
                    Id = Guid.NewGuid().ToString()
                };
                var result = _unitOfWork.UserManager.Create(user, userDto.Password);
                if (result.Succeeded)
                {
                    if (!_unitOfWork.RoleManager.RoleExists(userDto.Role))
                    {
                        _unitOfWork.RoleManager.Create(new Role(userDto.Role));
                    }
                    // добавляем роль
                    _unitOfWork.UserManager.AddToRole(user.Id, userDto.Role);
                    _unitOfWork.Save();
                }
            }
        }

        public void Dispose()
        {

        }
    }
}
