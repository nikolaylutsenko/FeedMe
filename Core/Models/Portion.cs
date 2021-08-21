using System;

namespace Core.Models
{
    public class Portion : BaseEntity
    {
        public float Weight { get; set; }
        public DateTime Date { get; set; }

        //public Guid? UserId { get; set; }

        // navigation prop
        //public AppUser User { get; set; }
    }
}