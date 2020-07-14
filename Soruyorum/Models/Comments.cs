using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soruyorum.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public String Username { get; set; }
        public String Text { get; set; }
    }
}
