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
    public partial class FastLinkWidget : UserControl
    {

        public FastLinksVM ViewModel
        {
            get { return this.DataContext as FastLinksVM; }
            set { this.DataContext = value; }
        }

        public FastLinkWidget()
        {
            InitializeComponent();
            ViewModel = new FastLinksVM();

         /*
            btnContainer.Children.Clear();

            foreach (Button button in ViewModel.FastLinks)
                btnContainer.Children.Add(button);

        */
        }
    }
}
