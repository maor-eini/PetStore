using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.ViewModels
{
    public class BaseFormViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Heading { get; set; }
    }
}
