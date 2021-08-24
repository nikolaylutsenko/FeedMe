using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Portion : BaseEntity
    {
        public float Weight { get; set; }
        public DateTime Date { get; set; }

        // navigation prop
        public ICollection<Pet> Pets { get; set; }
    }
}