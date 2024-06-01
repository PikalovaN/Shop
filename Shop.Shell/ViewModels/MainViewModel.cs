using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Shop.Shell.ViewModels
{
    public class MainViewModel: BindableBase
    {
        #region property DisplayName

        /// <summary>
        /// Represent DisplayName property
        /// </summary>
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        /// <summary>
        /// Backing field for property DisplayName
        /// </summary>
        private string _displayName = "Книжный Мир";

        #endregion
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManager;

        public MainViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
        }
    }
}
