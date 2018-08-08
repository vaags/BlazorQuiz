
using BlazorQuiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorQuiz.Services
{
    public class DataStoreService
    {
        public List<Category> Categories { get; private set; }
        public List<Question> Questions { get; private set; }
        public List<Quiz> Quizzes { get; } = new List<Quiz>();
        public bool ApiError { get; private set; }

        private readonly IQuizApiService _quizService;

        public DataStoreService(IQuizApiService quizService)
        {
            _quizService = quizService;
        }

        public async Task GetCategories()
        {
            if (Categories != null)
            {
                return;
            }

            try
            {
                var result = await _quizService.GetCategories();

                Categories = result.Trivia_categories
                                    .OrderBy(c => c.Name)
                                    .ToList();
            }
            catch (Exception)
            {
                ApiError = true;
            }
        }

        public async Task GetQuestions(int categoryId)
        {
            try
            {
                var result = await _quizService.GetQuestions(categoryId);

                if (result?.Response_code == ResponseCode.Success)
                {
                    Questions = result.Results.ToList();
                }
                else
                {
                    ApiError = true;
                }
            }
            catch (Exception)
            {
                ApiError = true;
            }
        }

        public void AddQuiz(string categoryName)
        {
            Quizzes.Add(new Quiz
            {
                Id = Guid.NewGuid(),
                Category = categoryName,
                Timestamp = DateTime.Now
            });
        }

        public Quiz GetActiveQuiz()
        {
            return Quizzes.LastOrDefault();
        }

        public void AddQuizPoint(Guid quizId)
        {
            Quizzes.ForEach(q =>
            {
                if (q.Id == quizId)
                {
                    q.Points++;
                }
            });
        }

        public void CompleteQuiz(Guid quizId)
        {
            Quizzes.ForEach(q =>
            {
                if (q.Id == quizId)
                {
                    q.IsCompleted = true;
                }
            });
        }
    }
}
