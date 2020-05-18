using Ecours.Default.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ecours.Default.ViewModel
{
    class DlgCreator
    {
        public static Window Create(String dlgName) {

            Window dlg = null; 

            switch (dlgName) {

                case "AboutSystem":
                    dlg = new AboutSystemWidget(); 
                    break;

                case "Product":
                    dlg = new ProductWidget();
                    break;

                case "Tool":
                    dlg = new ToolWidget();
                    break;

                case "ToolFastLink":
                    dlg = new ToolFastLinkWidget();
                    break;

                case "Help":
                    throw  new NotImplementedException();                    
            }

            return dlg;
        }
    }
}
