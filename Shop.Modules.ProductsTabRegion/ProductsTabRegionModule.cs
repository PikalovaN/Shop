using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Shop.Core;
using Shop.Core.Services;
using Shop.Modules.ProductsTabRegion.ViewModels;
using Shop.Modules.ProductsTabRegion.Views;

namespace Shop.Modules.ProductsTabRegion
{
    public class ProductsTabRegionModule : IModule
    {
        IRegionManager _regionManager;
        public ProductsTabRegionModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(Regions.ProductsTabRegion, typeof(UserControlProductsTabRegion));
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<UserControlProductsTabRegion, ProductsTabRegionViewModel>();
        }
    }
}
