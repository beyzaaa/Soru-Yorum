using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soruyorum.DataTransferObjects
{
    public class CommentToAdd
    {
        public int QuestionId { get; set; }
        public String Username { get; set; }
        public String Text { get; set; }
    }
}
