using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhoWantsToBeAMillionaire.Repositories;
using MySql.Data.MySqlClient;
using WhoWantsToBeAMillionaire;
using WhoWantsToBeAMillionaire.Models;
using System.Collections.Generic;
using WhoWantsToBeAMillionaire.Service;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConnectionToDataBase()
        {
            try
            {
                ConnectionClass.connection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `questions`", ConnectionClass.connection);
                mySqlCommand.ExecuteNonQuery();
                ConnectionClass.connection.Close();
                Assert.AreEqual(true, true);
            }
            catch (System.Exception){ Assert.AreEqual(false, true); }
        }
        [TestMethod]
        public void GetQuestions()
        {
            QuestionRepo questionRepo = new QuestionRepo();
            List<Question> questions = questionRepo.GetQuestions();
            CollectionAssert.AreNotEqual(questions, new List<Question>());
        }
        [TestMethod]
        public void ShuffleCollection()
        {
            QuestionRepo questionRepo = new QuestionRepo();
            QuestionService questionService = new QuestionService(questionRepo);
            CollectionAssert.AreNotEqual(questionRepo.GetQuestions(), (System.Collections.ICollection)questionService.Shuffle());
        }
    }
}
