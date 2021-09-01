using System;

namespace Core.Models
{
    public class Portion : BaseEntity
    {
        public float Weight { get; set; }
        public DateTime Date { get; set; }
        public Guid PetId { get; set; }

        // navigation prop
        public Pet Pet { get; set; }
    }
}