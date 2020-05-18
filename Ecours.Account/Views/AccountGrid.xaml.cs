using Ecours.Account.ViewsModel;
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

namespace Ecours.Account.Views
{
    public partial class AccountGrid : UserControl
    {

        private readonly AccountVM accountVM = new AccountVM(25, 0); 
        public AccountGrid()
        {
            InitializeComponent();
        }

        private void AccountDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            AccountDataGrid.ItemsSource = accountVM.ListAccount;
        }


    }
}
