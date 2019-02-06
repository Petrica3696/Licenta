using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Wishlist : BaseEntity
    {
        public string UserId { get; set; }

        public string ProductId { get; set; }
    }
}
