using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(PetStoreContext context)
            : base(context)
        {
        }

        public PetStoreContext PetStoreContext
        {
            get { return Context as PetStoreContext; }
        }
    }
}
