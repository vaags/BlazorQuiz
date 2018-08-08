
namespace BlazorQuiz.Entities
{
    public class QuestionApiResponse
    {
        public ResponseCode Response_code { get; set; }
        public Question[] Results { get; set; }
    }
}
