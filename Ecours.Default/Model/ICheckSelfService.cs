using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Default.Model
{
    public interface ICheckSelfService
    {
        Question GetQuestion(int number);
       
        List<String> GetPossibleAnswers(Question question);

        List<String> GetCorrectAnswers(Question question);

        int GetQuestionCount();
    }
}
