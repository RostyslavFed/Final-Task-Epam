using Hospital.DAL.Entity;
using System;

namespace Hospital.BLL.DTO
{
	public class UserDTO
	{
        public string Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
	}
}
