﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.ViewModels.Product
{
    public class ProductFormViewModel : BaseFormViewModel
    { 
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }

    }
}
