
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
using System.Windows.Shapes;

namespace Ecours.Default.Views
{
    /// <summary>
    /// Логика взаимодействия для ToolWidget.xaml
    /// </summary>
    public partial class ToolWidget : Window
    {
        public MainVM ViewModel
        {
            get { return this.DataContext as MainVM; }
            set { this.DataContext = value; }
        }
        public ToolWidget(String caption = "Настройка виджетов стартового окна")
        {            
            InitializeComponent();
            WidgetCaption.Text = caption;
            
        }        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        public bool? ShowDialog(MainVM mainVM)
        {

            ViewModel = mainVM;

            bool? res = base.ShowDialog();

            if (res.HasValue && res.Value)
            {
                mainVM.OnRefresh("FastLink");
            }

            return res;
        }
    }
}
