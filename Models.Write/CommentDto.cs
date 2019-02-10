using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Write
{
    public class CommentDto : BaseDto
    {
        public string ProductId { get; set; }

        public string UserId { get; set; }

        public string Text { get; set; }
    }
}
