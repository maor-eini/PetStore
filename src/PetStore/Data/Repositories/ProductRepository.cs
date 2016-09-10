using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Data.Repositories
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(PetStoreContext context)
            : base(context)
        {
        }

        public IEnumerable<Product> GetTopSellingProduct(int count)
        {
            return PetStoreContext.Products.OrderByDescending(c => c.Price).Take(count).ToList();
        }

        public PetStoreContext PetStoreContext
        {
            get { return Context as PetStoreContext; }
        }
    }
}
