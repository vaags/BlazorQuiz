using System;

namespace BlazorQuiz.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public DateTime Timestamp { get; set; }
        public int QuestionCount { get; set; } = 10;
        public int Points { get; set; }
        public int Score => Points * 100 / QuestionCount;
        public bool IsCompleted { get; set; }
    }
}
