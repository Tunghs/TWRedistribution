using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace TwRedistribution.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public TitleBarViewModel _TitleBarViewModel { get; set; }
        public RedistributionViewModel _RedistributionViewModel { get; set; }
        public ListViewModel _ListViewModel { get; set; }

        private Window _windowState;
        public Window WindowState
        {
            get { return _windowState; }
            set { _windowState = value; RaisePropertyChanged("WindowState"); }
        }

        public MainViewModel()
        {
            _TitleBarViewModel = new TitleBarViewModel();
            _RedistributionViewModel = new RedistributionViewModel();
            _ListViewModel = new ListViewModel();


        }
    }
}
