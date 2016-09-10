using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data.Repositories
{
    public class PetRepository
    {
        private PetStoreContext _context;

        public PetRepository(PetStoreContext _context)
        {
            this._context = _context;
        }
    }
}
