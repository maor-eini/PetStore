using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;

namespace PetStore.Data.Repositories
{

    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(PetStoreContext context)
            : base(context)
        {
        }

        public PetStoreContext PetStoreContext
        {
            get { return Context as PetStoreContext; }
        }
    }
}
