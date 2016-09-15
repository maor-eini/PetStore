using PetStore.Models;

namespace PetStore.Data.Repositories.Interfaces
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        ShoppingCart GetShoppingCartByUserId(int id);
    }
}
