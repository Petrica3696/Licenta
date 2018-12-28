using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Write
{
    public class ProductDto : BaseDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float StartPrice { get; set; }

        public float LowLimitPrice { get; set; }

        public bool IsSold { get; set; }
    }
}
