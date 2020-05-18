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
    public partial class ToolFastLinkWidget : Window
    {

        public FastLinksVM ViewModel
        {
            get { return this.DataContext as FastLinksVM; }
            set { this.DataContext = value; }
        }

        public ToolFastLinkWidget(String caption = "Caption")
        {

            InitializeComponent();         

            WidgetCaption.Text = caption;

 //           ViewModel = new FastLinksVM();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           DialogResult = false;
        }
        public bool? ShowDialog(FastLinksVM fastLinksVM) {

            ViewModel = fastLinksVM;


            bool? res = base.ShowDialog();           

            if (res.HasValue && res.Value)
            {


              //  fastLinksVM.OnSelect("Dictionary");
                fastLinksVM.UpdateFastLinks();
            }

            return res;
        }
        private void BtOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CreateFastLink(object sender, RoutedEventArgs e)
        {
            foreach (object o in ecoursModules.SelectedItems)
                ViewModel.OnSelect(o);
        }

        private void RemoveFastLink(object sender, RoutedEventArgs e)
        {
            object o = ecoursSelectedModules.SelectedItems[0] as object;
            ViewModel.OnUnSelect(o);
        }
    }
}
