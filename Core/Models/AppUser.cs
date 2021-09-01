using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Pets = new List<Pet>();
        }

        // navigation prop
        public ICollection<Pet> Pets { get; set; }
    }
}