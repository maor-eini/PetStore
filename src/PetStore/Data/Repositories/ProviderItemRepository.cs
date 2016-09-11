using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;

namespace PetStore.Data.Repositories
{

    public class ProviderItemRepository : Repository<ProviderItem>, IProviderItemRepository
    {
        public ProviderItemRepository(PetStoreContext context)
            : base(context)
        {
        }

        public PetStoreContext PetStoreContext
        {
            get { return Context as PetStoreContext; }
        }
    }
}
