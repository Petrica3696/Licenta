using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Write
{
    public class UpdateBid
    {
        public string WinnerId { get; set; }
        
        public double FinalPrice { get; set; }
        
        public DateTime Deadline { get; set; }
    }
}
