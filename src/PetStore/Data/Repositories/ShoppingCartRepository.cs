using System;
using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;
using System.Linq;

namespace PetStore.Data.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(PetStoreContext context)
            : base(context)
        {
        }

        public PetStoreContext PetStoreContext
        {
            get { return Context as PetStoreContext; }
        }

        public ShoppingCart GetShoppingCartByUserId(int userId)
        {
            return PetStoreContext.ShoppingCarts
                .Where(sc => sc.UserAccountId == userId)
                .OrderByDescending(sc => sc.DateCreated)
                .FirstOrDefault();
        }
    }
}
