
using Ecours.Desktop.Views;
using Ecours.Utils.Logging;
using Prism;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ecours.Desktop.ViewModel
{
    public class MainWindowVM: BindableBase, IActiveAware
    {
        private IApplicationCommands applicationCommands_m;

        readonly IModuleManager moduleManager_m;

        public event EventHandler IsActiveChanged;

        public IApplicationCommands ApplicationCommands
        {
            get { return applicationCommands_m; }
            set { SetProperty(ref applicationCommands_m, value); }
        }

        public DelegateCommand ExitCommand { get; private set; }

        public DelegateCommand LoadCommand { get; private set; }

        public DelegateCommand LoadAccount { get; private set; }

        public bool IsActive {
            get { return ExitCommand.IsActive; }
            set { ExitCommand.IsActive = value; }
        }

        private readonly ObservableCollection<ITab> tabs_m;
        public MainWindowVM(IApplicationCommands applicationCommands, IModuleManager moduleManager)
        {
            moduleManager_m = moduleManager;

            ApplicationCommands = applicationCommands;

            ExitCommand = new DelegateCommand(Exit);
            applicationCommands.ExitCommand.RegisterCommand(ExitCommand);

            LoadCommand = new DelegateCommand(LoadModule);
            applicationCommands.LoadCommand.RegisterCommand(LoadCommand);

            LoadAccount = new DelegateCommand(LoadAccountModule);
            applicationCommands.LoadAccountModule.RegisterCommand(LoadAccount);

            tabs_m = new ObservableCollection<ITab>();
            tabs_m.CollectionChanged += TabsCollectionChanged;
          //  tabs_m.Add()
            Tabs = tabs_m;
        }

        private void TabsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ITab tab;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (ITab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (ITab)e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }

        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            Tabs.Remove((ITab)sender);
        }

        private void Exit()
        {      
            if (EcoursMessageWindow.Show("Ecours", "Вы уверены, что хотите закончить работу с Системой ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Environment.Exit(1);
            }
                
        }

        private void LoadModule()
        {
            try
            {
                moduleManager_m.LoadModule("ModuleContractor");

            }
           
            catch (ModularityException ex)
            {
                EcoursMessageWindow.Show("Ошибка", "Ошибка загрузки модуля!", MessageBoxButton.OK);
                Logger.Log.Warn(ex.Message);
            }
        }

        private void LoadAccountModule()
        {
            try
            {
                moduleManager_m.LoadModule("ModuleAccount");

            }
            catch (ModuleNotFoundException ex) {
                EcoursMessageWindow.Show("Ошибка", "Модуль не найден!", MessageBoxButton.OK);
                Logger.Log.Warn(ex.Message);
            }
            catch (ModularityException ex)
            {
                EcoursMessageWindow.Show("Ошибка", "Ошибка загрузки модуля.", MessageBoxButton.OK);
                Logger.Log.Warn(ex.Message);
            }
        }

        private void OnIsActiveChanged()
        {
            ExitCommand.IsActive = IsActive;
            IsActiveChanged?.Invoke(this, new EventArgs()); 
        }


        public ICollection<ITab> Tabs { get;  }

        private void AddTab()
        {

           
        }

        public void Destroy()
        {
         //   applicationCommands_m.UnregisterCommand(UpdateCommand);
        }
    }
}
