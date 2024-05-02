using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using Shop.Modules.ClientsTabRegion;
using Shop.Modules.OrdersTabRegion;
using Shop.Modules.ProductsTabRegion;
using Shop.Shell.ViewModels;
using Shop.Shell.Views;
using System.Windows;

namespace Shop.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<MainView, MainViewModel>();
        }
        protected override Window CreateShell() => Container.Resolve<MainView>();
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ProductsTabRegionModule>();
            moduleCatalog.AddModule<OrdersTabRegionModule>();
            moduleCatalog.AddModule<ClientsTabRegionModule>();
        }
    }
}
