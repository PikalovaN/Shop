using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Shop.Core;
using Shop.Modules.OrdersTabRegion.ViewModels;
using Shop.Modules.OrdersTabRegion.Views;

namespace Shop.Modules.OrdersTabRegion
{
    public class OrdersTabRegionModule : IModule
    {
        IRegionManager _regionManager;
        public OrdersTabRegionModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(Regions.OrdersTabRegion, typeof(UserControlOrdersTabRegion));
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<UserControlOrdersTabRegion, OrdersTabRegionViewModel>();
        }
    }
}
