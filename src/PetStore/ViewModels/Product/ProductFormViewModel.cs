using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.ViewModels.Product
{
    public class ProductFormViewModel : BaseFormViewModel
    { 
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string SubCategory { get; set; }

    }
}
