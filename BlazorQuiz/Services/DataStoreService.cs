
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
    }
}
