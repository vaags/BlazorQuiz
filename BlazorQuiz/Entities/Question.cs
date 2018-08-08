
using System;

namespace BlazorQuiz.Entities
{
    public class Question
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Difficulty { get; set; }
        public string question { get; set; }
        public string Correct_answer { get; set; }
        public string[] Incorrect_answers { get; set; }
        public Answer Answer { get; set; } = new Answer();
    }

    public class Answer
    {
        public string SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsAnswered { get; set; }
    }
}
