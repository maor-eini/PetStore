using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace PetStore.Models
{
    public class UserRole : IdentityRole<int>
    {
        public UserRole() : base() { }
    }
}
