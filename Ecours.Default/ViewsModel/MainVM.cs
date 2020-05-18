

using Ecours.Default.Model;
using Ecours.Default.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ecours.Default.ViewModel
{
    public class MainVM : BindableBase
    {

        private readonly IWidgetService widgetService_m;


        private readonly ICommand showDlg_m;

        public ICommand ShowDlg { get { return showDlg_m; } }

        private readonly ICommand refresh_m;

        public ICommand Refresh { get { return refresh_m; } }

        public ObservableCollection<Widget> Widgets { get; private set; }

        public ObservableCollection<UserControl> SelectedWidgets { get; set; }

        public MainVM()
        {

            widgetService_m = new WidgetService();

            this.showDlg_m = new DelegateCommand<String>(this.OnShowDialog, this.CanShowDialog);

            this.refresh_m = new DelegateCommand<String>(this.OnRefresh);

            Widgets = new ObservableCollection<Widget>(widgetService_m.GetWidgetList());

            SelectedWidgets = new ObservableCollection<UserControl>(widgetService_m.GetUserControlList());

        }

        public void OnShowDialog(String dlgName)
        {
            Window dlg = DlgCreator.Create(dlgName);

            if (dlg is ToolWidget)
            {

                (dlg as ToolWidget).ShowDialog(this);

                SelectedWidgets = new ObservableCollection<UserControl>(widgetService_m.GetUserControlList());

            } else

            dlg.ShowDialog();

        }

        
        public bool CanShowDialog(String dlgName)
        {
            return true;
        }

        public void OnRefresh(String close) {

       //     widgetService_m.Select((WidgetTag)Enum.Parse(typeof(WidgetTag), widget));
            SelectedWidgets = new ObservableCollection<UserControl>(widgetService_m.GetUserControlList());

        }

    }
}
