using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Default.Model
{
    public class Question
    {
        public int Number;

        public String BodyQuestion; 

        public IEnumerable<Tuple<String, bool> > possibleAnswers;  // Возможные ответы с флагом правильности

    }

    class CheckSelfService : ICheckSelfService
    {

        List<Question> questions_m; 

        public CheckSelfService() {
            questions_m = new List<Question>();

            Question q1 = new Question()
            {
                Number = 1,
                BodyQuestion = "Что является основным признаком отходов производства и потребления ?",
                possibleAnswers = new List<Tuple<String, bool>>() {
                    Tuple.Create<String, bool>("Класс опасности", false),
                    Tuple.Create<String, bool>("Удаляемость", true),
                    Tuple.Create<String, bool>("Объем", false)
                }                                        
                
            };

            questions_m.Add(q1);

            Question q2 = new Question()
            {
                Number = 2,
                BodyQuestion = "Твердые коммунальные отходы - это:",
                possibleAnswers = new List<Tuple<String, bool>>() {
                    Tuple.Create<String, bool>("А. Отходы, образующиеся в жилых помещениях в процессе потребления физическими лицам", false),
                    Tuple.Create<String, bool>("Б. Отходы, образующиеся в процессе деятельности юридических лиц, индивидуальных предпринимателей и подобные по составу отходам, образующимся в жилых помещениях в процессе потребления физическими лицами", false),
                    Tuple.Create<String, bool>("В. Отходы, указанные в п. А и Б", true)
                }

            };

            questions_m.Add(q2);

        }

        public List<string> GetCorrectAnswers(Question question)
        {

            IEnumerable<Tuple<String, bool>> possibleAnswers = questions_m.Where(q => q.Number == question.Number).First().possibleAnswers;
            return possibleAnswers.Where(a => a.Item2 == true).Select(a => a.Item1).ToList();
        }

        public List<string> GetPossibleAnswers(Question question)
        {
            IEnumerable<Tuple<String, bool>> possibleAnswers = questions_m.Where(q => q.Number == question.Number).First().possibleAnswers;
            return possibleAnswers.Select(a => a.Item1).ToList();
        }

        public Question GetQuestion(int number)
        {
            Question res = questions_m.Where(q => q.Number == number).FirstOrDefault();
            return res;

        }

        public int GetQuestionCount()
        {
            return questions_m.Count();
        }
    }
}
