using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Comments : BaseEntity
    {
        public string ProductId { get; set; }

        public string UserId { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }
    }
}
