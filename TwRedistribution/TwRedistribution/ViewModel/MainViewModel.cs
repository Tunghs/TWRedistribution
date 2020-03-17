using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace TwRedistribution.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region UIVariable
        private bool _showGridView = true;
        public bool ShowGridView
        {
            get { return _showGridView; }
            set { _showGridView = value; RaisePropertyChanged("ShowGridView"); }
        }
        private bool _hideGridView = false;
        public bool HideGridView
        {
            get { return _hideGridView; }
            set { _hideGridView = value; RaisePropertyChanged("HideGridView"); }
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

        

        public MainViewModel()
        {
            _TitleBarViewModel = new TitleBarViewModel();
            _RedistributionViewModel = new RedistributionViewModel();
            _ListViewModel = new ListViewModel();

            _TitleBarViewModel._WindowStateEvent += new TitleBarViewModel.WindowStateHandler(this.ReceiveWindowState);
            _ListViewModel._SelectedListViewItemEvent += new ListViewModel.SelectedListViewItemHandler(this.ReceiveSelectedListViewItemGrid);
        }

        public void ReceiveWindowState(WindowState state)
        {
            MainWindowState = state;
        }

        public void ReceiveSelectedListViewItemGrid()
        {
            if (ShowGridView)
            {
                ShowGridView = false;
                HideGridView = true;
            }
            else
            {
                ShowGridView = true;
                HideGridView = false;
            }
        }
    }
}
