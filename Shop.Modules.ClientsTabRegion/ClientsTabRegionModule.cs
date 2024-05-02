using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Shop.Core;
using Shop.Modules.ClientsTabRegion.ViewModels;
using Shop.Modules.ClientsTabRegion.Views;

namespace Shop.Modules.ClientsTabRegion
{
    public class ClientsTabRegionModule : IModule
    {
        IRegionManager _regionManager;
        public ClientsTabRegionModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(Regions.ClientsTabRegion, typeof(UserControlClientsTabRegion));
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<UserControlClientsTabRegion, ClientsTabRegionViewModel>();
        }
    }
}
