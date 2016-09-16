using PetStore.Data.Repositories.Interfaces;
using System;

namespace PetStore.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserAddressRepository UserAddress { get; }

        IProductRepository Products { get; }

        IOrderRepository Orders { get;  }
        IOrderItemRepository OrderItems { get; }

        IPetRepository Pets { get; }
        IPetTypeRepository PetTypes { get; }

        IShoppingCartRepository ShoppingCarts { get; }
        IShoppingCartItemRepository ShoppingCartItems { get;  }
        int Complete();
    }
}
