using System;
using Hospital.DAL.Entity;

namespace Hospital.BLL.DTO
{
    public abstract class PersonDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}