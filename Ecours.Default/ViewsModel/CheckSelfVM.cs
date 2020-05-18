
using Ecours.Default.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecours.Default.ViewModel
{
    public class CheckSelfVM : BindableBase
    {

        private readonly ICheckSelfService checkSelfService_m = new CheckSelfService();

        #region Commans
        private readonly ICommand answer_m;

        private readonly ICommand goOver_m;

        public ICommand Answer { get { return answer_m; } }

        public ICommand GoOver { get { return goOver_m; } }
        #endregion
        private String question_m;

        private List<Tuple<String, bool> > answers_m;

        public List<Tuple<String, bool> > Answers
        {
            get { return answers_m; }

        }

        public String Question {
            get { return question_m; }         
            
        }

        private int currentNumber_m;
        private int countNumber_m;

        public CheckSelfVM() {

            this.answer_m = new DelegateCommand(this.OnAnswer);
            this.goOver_m = new DelegateCommand<String>(this.OnGoOver);

            currentNumber_m = 1;

            question_m = checkSelfService_m.GetQuestion(currentNumber_m).BodyQuestion;
            countNumber_m = checkSelfService_m.GetQuestionCount();

            answers_m = checkSelfService_m.GetQuestion(currentNumber_m).possibleAnswers.ToList();
        }

        public void OnAnswer()
        {

        }

        public void OnGoOver(String whither)
        {
            switch (whither)
            {
                case "backward":
                    currentNumber_m = (currentNumber_m > 1) ? currentNumber_m - 1 : 1;
                    break;

                case "forward":
                    currentNumber_m = (currentNumber_m < countNumber_m) ? currentNumber_m + 1 : countNumber_m;
                    break;
            }

            question_m = checkSelfService_m.GetQuestion(currentNumber_m).BodyQuestion;

            answers_m = checkSelfService_m.GetQuestion(currentNumber_m).possibleAnswers.ToList();

            RaisePropertyChanged(nameof(Question));

            RaisePropertyChanged(nameof(Answers));

            RaisePropertyChanged(nameof(Page));

        }
        public String Page
        {
            get
            {
                return String.Format("{0}/{1}", currentNumber_m, countNumber_m);
            }
        }


    }
}
