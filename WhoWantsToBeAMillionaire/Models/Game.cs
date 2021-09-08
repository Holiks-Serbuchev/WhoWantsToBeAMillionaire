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
        public List<int> scoreNumber = new List<int>() { 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000, 500000, 1000000 };
        public string correctAnswer = String.Empty;
        public string question { get; set; }
        public double equal = 0;
    }
}
