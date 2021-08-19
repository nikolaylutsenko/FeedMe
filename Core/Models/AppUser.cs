using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Portions = new List<Portion>();
        }

        // navigation prop
        public ICollection<Portion> Portions { get; set; }
    }

    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }

    public class AppUserRole : IdentityUserRole<Guid>
    {
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}