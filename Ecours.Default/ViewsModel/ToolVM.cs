
using Ecours.Default.Model;
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
    public class ToolVM: BindableBase
    {

        public ObservableCollection<Widget> LineItems { get; private set; }

        public ToolVM(IWidgetService ws) {

            this.LineItems = new ObservableCollection<Widget>(ws.GetWidgetList());
        }
    }
}
