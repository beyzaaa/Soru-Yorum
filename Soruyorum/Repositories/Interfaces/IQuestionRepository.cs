using Soruyorum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soruyorum.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        void AddQuestion(Question question);
        void AddComment(Comments comment);

        IEnumerable<Question> GetQuestions();
        IEnumerable<Question> GetQuestionsByCategory(int id);
        IEnumerable<Question> GetUserQuestions(string username);
        IEnumerable<Category> GetCategories();
        Question GetUserQuestions(int id);
        IEnumerable<Comments> GetComments(int questionId);
        bool SaveAll();
    }
}
