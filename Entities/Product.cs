using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Product : BaseEntity
    {
        public Guid CategoryId { get; set; }

        public Guid? WinnerId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float StartPrice { get; set; }

        public float? FinalPrice { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsSold { get; set; }
    }
}
