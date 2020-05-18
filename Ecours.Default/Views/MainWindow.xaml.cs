


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ecours.Default.ViewModel;


namespace AttemptWpfDef
{

#if DEBUG
    using System.Diagnostics;
#endif

    public partial class MainWindow : Window
    {

        public MainVM ViewModel
        {
            get { return this.DataContext as MainVM; }
            set { this.DataContext = value; }
        }
        public MainWindow()
        {
            InitializeComponent();

#if DEBUG
            Debug.WriteLine(SystemParameters.PrimaryScreenWidth);
            Debug.WriteLine(SystemParameters.PrimaryScreenHeight);
            Debug.WriteLine(SystemParameters.CaretWidth);
#endif
            ViewModel = new MainVM();
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.OnShowDialog("Tool");
            // ViewModel.OnRefresh("Stub");           
        
        }
    }
}
