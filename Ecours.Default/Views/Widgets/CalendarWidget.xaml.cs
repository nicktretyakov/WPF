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
    public partial class CalendarWidget : UserControl
    {
        public CalendarVM ViewModel
        {
            get { return this.DataContext as CalendarVM; }
            set { this.DataContext = value; }
        }

        public CalendarWidget()
        {
            InitializeComponent();
            ViewModel = new CalendarVM();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }
    }
}
