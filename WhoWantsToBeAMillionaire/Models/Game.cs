using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire.Models
{
    public class Game
    {
        public int score = 0;
        public string start = "true";
        public int step = 0;
        public int maxSteps { get; set; }
        public string correctAnswer = String.Empty;
        public string question { get; set; }
        public double equal = 0;
    }
}
