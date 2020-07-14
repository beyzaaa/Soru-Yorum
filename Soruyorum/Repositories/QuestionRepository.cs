using Microsoft.EntityFrameworkCore;
using Soruyorum.Models;
using Soruyorum.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soruyorum.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly Soruyorum1Context _context;

        public QuestionRepository(Soruyorum1Context context)
        {
            _context = context;
        }

        public void AddComment(Comments comment)
        {
            _context.Comments.Add(comment);
        }

        public void AddQuestion(Question question)
        {
            _context.Questions.Add(question);
        }

        public IEnumerable<Category> GetCategories()
        {
            var results = _context.Categories.ToList();
            return results;
        }

        public IEnumerable<Comments> GetComments(int questionId)
        {
            var results = _context.Comments.OrderByDescending(i => i.Id).Where(u => u.QuestionId == questionId).AsEnumerable();
            return results;
        }

        public IEnumerable<Question> GetQuestions()
        {
            var results = _context.Questions.OrderByDescending(i => i.Id).ToList();
            return  results;
            
        }

        public IEnumerable<Question> GetQuestionsByCategory(int id)
        {
            var results = _context.Questions.OrderByDescending(i => i.Id).Where(u => u.Category == id).ToList();
            return results;
        }

        public IEnumerable<Question> GetUserQuestions(string username)
        {
            var results = _context.Questions.OrderByDescending(i => i.Id).Where(u => u.Username == username).ToList();
            return results;
        }

        public Question GetUserQuestions(int id)
        {
            var result = _context.Questions.FirstOrDefault(i => i.Id == id);
            return result;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
