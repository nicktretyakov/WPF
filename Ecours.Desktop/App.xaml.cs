using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Ecours.Desktop.Views;
using System;
using System.Text;
using Ecours.Desktop.ViewModel;

namespace Ecours.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
         //   var mainWindowVM = Container.Resolve<MainWindowVM>();

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }


        
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\DefModules" };
        }

        private String GetModulePath(String FileNameModule)
        {
            StringBuilder FullName = new StringBuilder(@"file://"+AppDomain.CurrentDomain.BaseDirectory + "Modules/" + FileNameModule);
            return FullName.ToString();
        }


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            /*
            List<Assembly> assemblies = new List<Assembly>(AppDomain.CurrentDomain.GetAssemblies());

            Assembly moduleAssembly = assemblies.Find(asm => asm.FullName == typeof(IModule).Assembly.FullName);

            Type IModuleType = moduleAssembly.GetType(typeof(IModule).FullName);
           


            var moduleAType = typeof(ModuleContractor);

             */
            
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = "ModuleContractor", //   moduleAType.Name
                ModuleType = "Ecours.Contractor.ModuleContractor, Ecours.Contractor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", // moduleAType.AssemblyQualifiedName
                InitializationMode = InitializationMode.OnDemand,
                Ref = GetModulePath("Ecours.Contractor.dll")
            });
            
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = "ModuleAccount", //   moduleAType.Name
                ModuleType = "Ecours.Account.ModuleAccount, Ecours.Account, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", // moduleAType.AssemblyQualifiedName
                InitializationMode = InitializationMode.OnDemand,
                Ref = GetModulePath("Ecours.Account.dll")
            });

        }
    }
}
