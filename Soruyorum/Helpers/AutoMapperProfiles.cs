using AutoMapper;
using Soruyorum.DataTransferObjects;
using Soruyorum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soruyorum.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<QuestionToAddDTO, Question>();
            CreateMap<CommentToAdd, Comments>();
        }
    }
}
