using Ecours.Contractor.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.ServiceModel;
using System.Windows;
using Ecours.Utils.Logging;
using System.Configuration;
using System.Collections;
using Ecours.Contractor.ViewsModel;

namespace Ecours.Contractor
{
    public class ModuleContractor : IModule
    {


        public void OnInitialized(IContainerProvider containerProvider)
        {
            if (ContractRegistryVM.TestService())
            {
                var regionManager = containerProvider.Resolve<IRegionManager>();                
                regionManager.RegisterViewWithRegion("WorkspaceRegion", typeof(ECDataGrid));

                
            }
            else throw new ModularityException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        

    }
}