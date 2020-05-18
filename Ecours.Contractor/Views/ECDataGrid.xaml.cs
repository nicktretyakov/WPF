using Ecours.Contractor.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Ecours.Contractor.Views
{
    /// <summary>
    /// Interaction logic for ECDataGrid.xaml
    /// </summary>
    public partial class ECDataGrid : UserControl
    {

        private readonly ContractRegistryVM contractorVM = new ContractRegistryVM(0, 10); 
        public ECDataGrid()
        {
            InitializeComponent();
        }

        private void ContractorDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            ContractorDataGrid.ItemsSource = contractorVM.ListContractRegistry;
        }


    }
}
