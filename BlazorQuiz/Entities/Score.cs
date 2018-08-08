
using System;

namespace BlazorQuiz.Entities
{
    public class Score
    {
        public int Points { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}
