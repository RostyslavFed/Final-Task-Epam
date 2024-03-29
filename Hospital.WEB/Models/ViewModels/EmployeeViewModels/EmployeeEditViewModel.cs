﻿using Hospital.DAL.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hospital.WEB.Models.ViewModels.EmployeeViewModels
{
	public class EmployeeEditViewModel
	{
        private const int DaysInYear = 365;

        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Required field User Name")]
        [StringLength(20, ErrorMessage = "User Name must be between 3 and 20 characters", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required field Birthday")]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Required field Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Required field Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        //[StringLength(13, ErrorMessage = "Length must be 13 characters", MinimumLength = 13)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Confirm Phone Number?")]
        public bool PhoneNumberConfirmed { get; set; }

        [Required(ErrorMessage = "Required field Email")]
        [StringLength(30, ErrorMessage = "Email must be between 8 and 20 characters", MinimumLength = 8)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Confirm Email?")]
        public bool EmailConfirmed { get; set; }

        [Required(ErrorMessage = "Required field Address")]
        [StringLength(20, ErrorMessage = "Address must be between 6 and 20 characters", MinimumLength = 6)]
        public string Address { get; set; }

        //[Required(ErrorMessage = "Required field Password")]
        //[Display(Name = "Password")]
        //[DataType(DataType.Password)]
        //[StringLength(20, ErrorMessage = "Password must be between 6 and 20 characters", MinimumLength = 6)]
        //public string PasswordHash { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Required field Category")]
        public int? CategoryId { get; set; }

        public SelectList CategoriesDTO { get; set; }

        public DateTime MinDate
        {
            get
            {
                const int maxAge = 120;
                return DateTime.Now.AddDays(-(maxAge * DaysInYear));
            }
        }

        public DateTime MaxDate
        {
            get
            {
                const int minAge = 20;
                return DateTime.Now.AddDays(-(minAge * DaysInYear));
            }
        }
    }
}