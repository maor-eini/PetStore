using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;

namespace PetStore.Data.Repositories
{

    public class UserAddressRepository : Repository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(PetStoreContext context)
            : base(context)
        {
        }

        public PetStoreContext PetStoreContext
        {
            get { return Context as PetStoreContext; }
        }
    }
}
