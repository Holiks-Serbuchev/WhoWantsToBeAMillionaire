using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Service
{
    public interface IQuestionService
    {
        public IEnumerable<Question> Shuffle();
        public void HideAndShow(Game game, string nameStandart, string start);
        public void Print(string value, Game game);
        public bool LoseOrWin(Game game, string nameStandart, int maxSteps);
        public List<Question> GetQuestions();
        public List<string> GetRandomName();
        public void SetQuestionValue(List<string> collection);
        public void SetRandomName(List<string> collection);
    }
}
