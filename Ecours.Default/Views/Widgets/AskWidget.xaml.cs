
using Ecours.Default.Model;
using Ecours.Default.ViewModel;
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

namespace Ecours.Default.Views
{
    /// <summary>
    /// Логика взаимодействия для FastLinkWidget.xaml
    /// </summary>
    public partial class AskWidget : UserControl
    {

        public AskVM ViewModel
        {
            get { return this.DataContext as AskVM; }
            set { this.DataContext = value; }
        }

        public AskWidget()
        {
            InitializeComponent();

            ViewModel = new AskVM(new AskService());

        }
    }
}
