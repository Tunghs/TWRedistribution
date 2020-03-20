using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace TwRedistribution.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region UIVariable
        private bool _redistributionViewVisibility = true;
        public bool RedistributionViewVisibility
        {
            get { return _redistributionViewVisibility; }
            set { _redistributionViewVisibility = value; RaisePropertyChanged("RedistributionViewVisibility"); }
        }
        private bool _logViewVisibility = false;
        public bool LogViewVisibility
        {
            get { return _logViewVisibility; }
            set { _logViewVisibility = value; RaisePropertyChanged("HideGridView"); }
        }

        private WindowState _mainWindowState;
        public WindowState MainWindowState
        {
            get { return _mainWindowState; }
            set { _mainWindowState = value; RaisePropertyChanged("MainWindowState"); }
        }
        #endregion

        public TitleBarViewModel _TitleBarViewModel { get; set; }
        public RedistributionViewModel _RedistributionViewModel { get; set; }
        public ListViewModel _ListViewModel { get; set; }
        public LogViewModel _LogViewModel { get; set; }

        public MainViewModel()
        {
            _TitleBarViewModel = new TitleBarViewModel();
            _RedistributionViewModel = new RedistributionViewModel();
            _ListViewModel = new ListViewModel();
            _LogViewModel = new LogViewModel();

            _TitleBarViewModel._WindowStateEvent += new TitleBarViewModel.WindowStateHandler(this.ReceiveWindowState);
            _ListViewModel._ShowSelectedListViewItemGridEvent += new ListViewModel.SelectedListViewItemHandler(this.ShowSelectedListViewItem);
        }

        public void ReceiveWindowState(WindowState state)
        {
            MainWindowState = state;
        }

        public void ShowSelectedListViewItem(int listViewIndex)
        {
            switch (listViewIndex)
            {
                case 0:
                    RedistributionViewVisibility = true;
                    LogViewVisibility = false;
                    break;
                case 1:
                    RedistributionViewVisibility = false;
                    LogViewVisibility = true;
                    break;
            }
        }
    }
}
