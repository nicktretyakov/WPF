using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Desktop.ViewModel
{

    public interface ITab {
        String Name { get; set; }
        DelegateCommand CloseTabCommand { get; }

        event EventHandler CloseRequested;

    }
    public abstract class TabVM : ITab
    {

        public TabVM() {

            CloseTabCommand = new DelegateCommand(CloseTab);
        }

        public String Name { get; set; }

        public DelegateCommand CloseTabCommand { get; private set; }

        public event EventHandler CloseRequested;

        private void CloseTab()
        {

        }
    }
}
