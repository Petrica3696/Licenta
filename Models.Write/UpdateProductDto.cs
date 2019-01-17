using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Write
{
    public class UpdateProductDto
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double StartPrice { get; set; }

        public DateTime Deadline { get; set; }
    }
}
