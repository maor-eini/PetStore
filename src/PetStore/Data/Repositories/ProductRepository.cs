using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data.Repositories
{
    public class ProductRepository
    {
        private PetStoreContext _context;

        public ProductRepository(PetStoreContext _context)
        {
            this._context = _context;
        }
    }
}
