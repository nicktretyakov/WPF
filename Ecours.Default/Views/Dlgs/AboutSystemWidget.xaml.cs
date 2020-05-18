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
    /// Логика взаимодействия для AboutSystemWidget.xaml
    /// </summary>
    public partial class AboutSystemWidget : Window
    {
        public AboutSystemWidget(String caption = "Caption")
        {
            InitializeComponent();
            WidgetCaption.Text = caption;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

    }
}
