using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace PetStore.Models
{
    public class User : IdentityUser
    {
        public string PasswordOld { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Activated { get; set; }
    }
}
