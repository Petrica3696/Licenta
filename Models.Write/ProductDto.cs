using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Write
{
    public class ProductDto : BaseDto
    {
        public string CategoryId { get; set; }

        public Guid? WinnerId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double StartPrice { get; set; }

        public double? FinalPrice { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsSold { get; set; }

        public string ImageFile { get; set; }
    }
}
