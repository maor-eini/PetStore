using System.Collections.Generic;

namespace PetStore.Models
{
    public class Provider
    {
        public Provider()
        {
            Products = new HashSet<ProviderItem>();
        }

        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProviderItem> Products { get; set; }

    }
}
