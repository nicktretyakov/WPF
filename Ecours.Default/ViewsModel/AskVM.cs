
using Ecours.Default.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecours.Default.ViewModel
{
    public class AskVM: BindableBase
    {
        String orgName = String.Empty;

        public String OrgName {
            get { return orgName; }
            set {

                SetProperty(ref orgName, value);
                RaisePropertyChanged(nameof(OrgName));

                RaisePropertyChanged(nameof(IsEnabled));
            }
        }

        public bool IsEnabled {
            get {
                return (orgName != String.Empty);
            }
        }

        private readonly IAskService askService_m;

        private readonly Ask ask_m;

        #region Commands Properties 
        private readonly ICommand toSend_m;

        public ICommand ToSend
        {
            get
            {
                return toSend_m;
            }
        }
        #endregion

        public AskVM(IAskService askService)
        {
            askService_m = askService;

            toSend_m = new DelegateCommand(async () => await OnToSend());
            
        }

        async Task OnToSend()
        {
            await askService_m.ToSend(ask_m);
        }
       
    }
}
