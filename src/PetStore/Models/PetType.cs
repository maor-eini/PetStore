using System.Collections.Generic;

namespace PetStore.Models
{
    public class PetType
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }
    }
}