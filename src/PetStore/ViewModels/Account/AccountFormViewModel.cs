using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PetStore.ViewModels
{
    public class AccountFormViewModel : BaseFormViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<SelectListItem> GenderOptions {
            get
            {
                if (_genderOptions == null)
                {
                    _genderOptions = new List<SelectListItem>
                    {
                        new SelectListItem { Value = "M", Text = "Male"},
                        new SelectListItem { Value = "F", Text = "Female" }
                    };
                }
                 
                return _genderOptions;
            }
        }

        private IEnumerable<SelectListItem> _genderOptions;
    }
}
