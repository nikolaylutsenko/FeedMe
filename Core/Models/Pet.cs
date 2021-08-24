using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Pet : BaseEntity
    {
        public Pet()
        {
            Portions = new List<Portion>();
        }

        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public Guid OwnerId { get; set; }

        //navigation prop
        public AppUser Owner { get; set; }
        public ICollection<Portion> Portions { get; set; }
    }
}