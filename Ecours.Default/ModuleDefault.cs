using Ecours.Default.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.ServiceModel;
using System.Windows;
using Ecours.Utils.Logging;
using System.Configuration;
using System.Collections;

namespace Ecours.Default
{
    public class ModuleDefault : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
                IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();

                 IRegion region = regionManager.Regions["WorkspaceRegion"];
                 region.RemoveAll();

                //We get from the container an instance of AccountGrid.
          //      AccountGrid view = containerProvider.Resolve<AccountGrid>();

                //We get from the region manager our target region.
           //     IRegion region = regionManager.Regions["WorkspaceRegion"];

                //We inject the view into the region.
           //     region.Add(view);
                
                
                regionManager.RegisterViewWithRegion("WorkspaceRegion", typeof(DefaultView));

                Logger.Log.Info("DefaultModule is loaded");
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        

    }
}