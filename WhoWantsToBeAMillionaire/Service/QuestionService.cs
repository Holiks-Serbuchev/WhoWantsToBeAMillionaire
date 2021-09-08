using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Service
{
    public class QuestionService : IQuestionService
    {
        private IEnumerable<Models.Question> _collection;
        private Repositories.IQuestionRepo _questionRepo;
        public static List<Question> questions;
        public static List<string> randomName = new List<string>() { "FirstAnswer", "SecondAnswer", "ThirdAnswer", "FourthAnswer" };
        public static List<string> questionsValue = new List<string>();
        public QuestionService(Repositories.IQuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }
        public IEnumerable<Models.Question> Shuffle()
        {
            _collection = _questionRepo.GetQuestions();
            return _collection.OrderBy(i => new Random().Next()).ToList();
        }
        public void HideAndShow(Game game, string nameStandart, string start)
        {
            try
            {
                if (game.start == "true" && nameStandart == null)
                {
                    questions = Shuffle().ToList();
                    game.start = "false";
                }
                else
                {
                    game.start = "true";
                    game.correctAnswer = questions.ElementAt(game.step).CorrectAnswer;
                }
            }
            catch (Exception){}
        }
        public void Print(string value, Game game)
        {
            game.question = value;
            game.start = "false";
            game.step = 0;
            questions = Shuffle().ToList();
        }
        public bool LoseOrWin(Game game, string nameStandart, int maxSteps)
        {
            bool returnBool = false;
            bool block = false;
            if (questionsValue.ElementAt(Convert.ToInt32(randomName.IndexOf(nameStandart))) == questions.ElementAt(game.step).CorrectAnswer)
            {
                double equal = 1000000 / (game.maxSteps + 1);
                if (game.step == game.maxSteps)
                {
                    Print("You have won the game who wants to be a Millionaire!!!", game);
                    if (game.maxSteps + 1 == 15)
                        game.score = game.score + Convert.ToInt32(equal) + 10;
                    else
                        game.score = game.score + Convert.ToInt32(equal);
                    game.start = "false";
                    block = true;
                }
                if (block != true)
                {
                    game.score = game.score + Convert.ToInt32(equal);
                    game.step++;
                    returnBool = true;
                }
            }
            else if (questionsValue.ElementAt(Convert.ToInt32(randomName.IndexOf(nameStandart))) != questions.ElementAt(game.step).CorrectAnswer)
            {
                Print("You lost this game!!!", game);
                game.step = 0;
            }
            return returnBool;
        }
        public List<Question> GetQuestions() => questions;
        public List<string> GetRandomName() => randomName;
        public void SetQuestionValue(List<string> collection) => questionsValue = collection;
        public void SetRandomName(List<string> collection) => randomName = collection;
    }
}
