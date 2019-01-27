using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Recommendations : BaseEntity
    {
        public string UserId { get; set; }

        public string CategoryId { get; set; }

        public int Bids { get; set; }
    }
}
