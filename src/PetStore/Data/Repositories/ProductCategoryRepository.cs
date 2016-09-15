using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PetStore.Data.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(PetStoreContext context)
            : base(context)
        {
        }

        public PetStoreContext PetStoreContext
        {
            get { return Context as PetStoreContext; }
        }
    }
}
