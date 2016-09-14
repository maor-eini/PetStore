using System.Collections.Generic;

namespace PetStore.Models
{
    public class PetType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Pet Pet { get; set; }
    }
}