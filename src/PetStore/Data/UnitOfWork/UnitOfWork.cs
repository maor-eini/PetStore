﻿using PetStore.Data.Repositories;
using PetStore.Data.Repositories.Interfaces;

namespace PetStore.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetStoreContext _context;

        public UnitOfWork(PetStoreContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Pets = new PetRepository(_context);
            Orders = new OrderRepository(_context);
            ShoppingCarts = new ShoppingCartRepository(_context);
            Providers = new ProviderRepository(_context);
            Pets = new PetRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public IPetRepository Pets { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IShoppingCartRepository ShoppingCarts { get; private set; }
        public IProviderRepository Providers { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}