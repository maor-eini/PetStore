using System.Collections.Generic;

namespace PetStore.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public ICollection<ProviderItem> Products { get; set; }

    }
}
