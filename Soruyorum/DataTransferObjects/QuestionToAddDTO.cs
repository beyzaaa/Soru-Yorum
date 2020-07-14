using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soruyorum.DataTransferObjects
{
    public class QuestionToAddDTO
    {
        public String Username { get; set; }
        public int Category { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
    }
}
