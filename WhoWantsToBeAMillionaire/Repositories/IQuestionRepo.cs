using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public interface IQuestionRepo
    {
        public List<Models.Question> GetQuestions();
    }
}
