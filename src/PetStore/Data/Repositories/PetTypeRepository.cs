using System.Collections.Generic;
using PetStore.Data.Repositories.Interfaces;
using PetStore.Models;
using System.Linq;

namespace PetStore.Data.Repositories
{
    public class PetTypeRepository : Repository<PetType>, IPetTypeRepository
    {
        public PetTypeRepository(PetStoreContext context)
            : base(context)
        {
        }

        public PetStoreContext PetStoreContext
        {
            get { return Context as PetStoreContext; }
        }

        public IEnumerable<string> GetTypeNameList()
        {
            return PetStoreContext.PetTypes.OrderBy(t => t.Name).Select(t => t.Name);
        }
    }
}
