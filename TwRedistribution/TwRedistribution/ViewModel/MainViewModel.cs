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

        private WindowState _mainWindowState;
        public WindowState MainWindowState
        {
            get { return _mainWindowState; }
            set { _mainWindowState = value; RaisePropertyChanged("MainWindowState"); }
        }

        public MainViewModel()
        {
            _TitleBarViewModel = new TitleBarViewModel();
            _RedistributionViewModel = new RedistributionViewModel();
            _ListViewModel = new ListViewModel();

            _TitleBarViewModel._WindowStateEvent += new TitleBarViewModel.WindowStateHandler(this.ReceiveWindowState);
        }

        public void ReceiveWindowState(WindowState state)
        {
            MainWindowState = state;
        }
    }
}
