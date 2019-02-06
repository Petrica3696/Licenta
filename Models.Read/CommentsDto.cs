using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Read
{
    public class CommentsDto : BaseModel
    {
        public string ProductId { get; set; }

        public string UserId { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }
    }
}
