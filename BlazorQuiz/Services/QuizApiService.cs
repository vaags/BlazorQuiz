using BlazorQuiz.Entities;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace BlazorQuiz.Services
{
    public interface IQuizApiService
    {
        Task<CategoryApiResponse> GetCategories();
        Task<QuestionApiResponse> GetQuestions(int categoryId, int amount = 10);
    }

    public class QuizApiService : IQuizApiService
    {
        private const string URL = "https://opentdb.com";
        private readonly HttpClient http;

        public QuizApiService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public Task<CategoryApiResponse> GetCategories()
        {
            return http.GetJsonAsync<CategoryApiResponse>($"{URL}/api_category.php");
        }

        public Task<QuestionApiResponse> GetQuestions(int categoryId, int amount = 10)
        {
            return http.GetJsonAsync<QuestionApiResponse>($"{URL}/api.php?category={categoryId}&amount={amount}");
        }
    }
}
