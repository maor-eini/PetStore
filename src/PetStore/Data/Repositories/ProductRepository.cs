using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
            return PetStoreContext.Products.OrderByDescending(c => c.Orders.Count).Take(count).ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsOrderedByName(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public PetStoreContext PetStoreContext
        {
            get { return Context as PetStoreContext; }
        }
    }
}
