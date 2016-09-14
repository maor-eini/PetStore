using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PetStore.ViewModels
{
    public class PetFormViewModel : BaseFormViewModel
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Size { get; set; }


        public IEnumerable<SelectListItem> TypeOptions { get; set; }

        private IEnumerable<SelectListItem> _sizeOptions;
        public IEnumerable<SelectListItem> SizeOptions {
            get
            {
                if (_sizeOptions == null)
                {
                    _sizeOptions = new List<SelectListItem>
                    {
                        new SelectListItem { Value = "XS", Text = "Tiny" },
                        new SelectListItem { Value = "S", Text = "Small" },
                        new SelectListItem { Value = "M", Text = "Medium" },
                        new SelectListItem { Value = "L", Text = "Large" },
                        new SelectListItem { Value = "XL", Text = "Xtra Large" }
                    };
                }

                return _sizeOptions;
            }
        }
    }
}
