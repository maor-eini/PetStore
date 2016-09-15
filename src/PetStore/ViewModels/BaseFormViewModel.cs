using System.ComponentModel.DataAnnotations;

namespace PetStore.ViewModels
{
    public class BaseFormViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Heading { get; set; }
    }
}
