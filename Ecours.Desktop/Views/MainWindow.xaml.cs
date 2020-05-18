
using Prism.Modularity;
using System.IO;
using System.Windows;
using System.Windows.Controls.Ribbon;
using Ecours.Utils.Logging;
using Ecours.Desktop.ViewModel;

namespace Ecours.Desktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        

        public MainWindow(IModuleManager moduleManager)
        {
            InitializeComponent();
            ViewModel = new MainWindowVM(new ApplicationCommands(), moduleManager);
            
        }

        public MainWindowVM ViewModel
        {
            get { return this.DataContext as MainWindowVM; }
            set { this.DataContext = value; }
        }

       
    }
}
