using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Shop.Core;
using Shop.Modules.EditTabRegion.Views;
using Shop.Modules.EditTabRegion.ViewModels;

namespace Shop.Modules.EditTabRegion
{
    public class EditTabRegionModule : IModule
    {
        IRegionManager _regionManager;
        public EditTabRegionModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(Regions.EditTabRegion, typeof(UserControlEditTabRegion));
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<UserControlEditTabRegion, EditTabRegionViewModel>();
        }
    }
}
