using System.Collections.Generic;

namespace PetStore.ViewModels
{
    public class RegisterViewModel
    {

        public AccountFormViewModel UserForm { get; set; }
        public PetFormViewModel PetForm { get; set; }
        public AddressFormViewModel AddressForm { get; set; }
      
    }
}
