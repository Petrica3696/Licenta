using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Read
{
    public class ProductDto : BaseModel
    {
        public string CategoryId { get; set; }

        public string WinnerId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float StartPrice { get; set; }

        public float FinalPrice { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsSold { get; set; }
    }
}
