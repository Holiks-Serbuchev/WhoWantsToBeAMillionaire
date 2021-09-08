using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Service.IQuestionService _questionService;
        public static Game game = new Game();

        public HomeController(ILogger<HomeController> logger, Service.IQuestionService questionService)
        {
            _questionService = questionService;
            _logger = logger;
        }
        public IActionResult Index(string nameStandart, string start, int maxSteps)
        {
            game.question = "Who want to be a millionaire?";
            _questionService.HideAndShow(game, nameStandart, start);
            if (start == "Старт" || nameStandart != null)
            {
                if (start == "Старт" || nameStandart.Contains("Answer"))
                {
                    try
                    {
                        if (_questionService.LoseOrWin(game, nameStandart, maxSteps) != false)
                            ChangeValues();
                    }
                    catch (Exception) { game.score = 0; ChangeValues(); game.maxSteps = maxSteps - 1; }
                }
            }
            //else if (start == "Стоп")
            //    game.score = 0;
            return View(game);
        }
        void ChangeValues()
        {
            try
            {
                game.question = _questionService.GetQuestions().ElementAt(game.step).QuestionText;
                _questionService.SetRandomName(_questionService.GetRandomName().OrderBy(i => new Random().Next()).ToList());
                ViewData[_questionService.GetRandomName()[0]] = _questionService.GetQuestions().ElementAt(game.step).FirstAnswer;
                ViewData[_questionService.GetRandomName()[1]] = _questionService.GetQuestions().ElementAt(game.step).SecondAnswer;
                ViewData[_questionService.GetRandomName()[2]] = _questionService.GetQuestions().ElementAt(game.step).ThirdAnswer;
                ViewData[_questionService.GetRandomName()[3]] = _questionService.GetQuestions().ElementAt(game.step).FourthAnswer;
                List<string> questionsValue = new List<string> {
                _questionService.GetQuestions().ElementAt(game.step).FirstAnswer, _questionService.GetQuestions().ElementAt(game.step).SecondAnswer,
                _questionService.GetQuestions().ElementAt(game.step).ThirdAnswer, _questionService.GetQuestions().ElementAt(game.step).FourthAnswer
            };
                _questionService.SetQuestionValue(questionsValue);
                game.correctAnswer = _questionService.GetQuestions().ElementAt(game.step).CorrectAnswer;
            }
            catch (Exception){}
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
