using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStore.ViewModels
{
    public class UserFormViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Heading { get; set; }

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
        public string DateOfBirth { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<AccountController, Task<IActionResult>>> update = (c => c.Update(this));
                Expression<Func<AccountController, Task<IActionResult>>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public DateTime GetDateTimeOfBirth()
        {
            return DateTime.ParseExact(DateOfBirth, "dd/mm/yyyy", new CultureInfo("it-IT"));
        }
    }
}
