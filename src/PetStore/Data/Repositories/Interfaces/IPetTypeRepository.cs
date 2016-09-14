using PetStore.Models;
using System.Collections.Generic;

namespace PetStore.Data.Repositories.Interfaces
{
    public interface IPetTypeRepository : IRepository<PetType>
    {
        IEnumerable<string> GetTypeNameList();
    }
}
