using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class QuestionRepo : IQuestionRepo
    {
        private List<Models.Question> questions = new List<Models.Question>();
        public QuestionRepo()
        {
            try
            {
                ConnectionClass.connection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("GetQuestions", ConnectionClass.connection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                        questions.Add(new Models.Question() { ID = Convert.ToInt32(dataReader[0]),
                        QuestionText = dataReader[1].ToString(),
                        FirstAnswer = dataReader[2].ToString(),
                        SecondAnswer = dataReader[3].ToString(),
                        ThirdAnswer = dataReader[4].ToString(),
                        FourthAnswer = dataReader[5].ToString(),
                        CorrectAnswer = dataReader[6].ToString()
                        } );
                }
                ConnectionClass.connection.Close();
            }
            catch (Exception) { ConnectionClass.connection.Close(); }
        }
        public List<Models.Question> GetQuestions() => questions;
    }
}
