using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string FourthAnswer { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
