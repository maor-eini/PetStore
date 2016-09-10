using PetStore.Data.Repositories;
using PetStore.Data.Repositories.Interfaces;

namespace PetStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetStoreContext _context;

        public UnitOfWork(PetStoreContext context)
        {
            _context = context;
            //Products = new ProductRepository(_context);
            //Pets = new PetRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public IPetRepository Pets { get; private set; }

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
