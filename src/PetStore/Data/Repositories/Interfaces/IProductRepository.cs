using PetStore.Models;
using System.Collections.Generic;

namespace PetStore.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetTopSellingProduct(int count);
        IEnumerable<Product> GetProductsByCategory(int count);
        IEnumerable<Product> GetProductsOrderedByName(int count);
        IEnumerable<Product> GetProductById(int id);
    }
}
