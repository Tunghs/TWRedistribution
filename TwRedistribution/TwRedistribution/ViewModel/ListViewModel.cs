using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace TwRedistribution.ViewModel
{
    public class ListViewModel : ViewModelBase
    {
        #region UI Variable
        private int _listViewIndex = 0;
        public int ListViewIndex
        {
            get { return _listViewIndex; }
            set { _listViewIndex = value; RaisePropertyChanged("ListViewIndex"); }
        }
        #endregion

        #region Command
        public RelayCommand<EventArgs> SelectedListViewItemCommand { get; private set; }

        private void InitRelayCommand()
        {
            SelectedListViewItemCommand = new RelayCommand<EventArgs>(OnSelectedListViewItemIndex);
        }

        private void OnSelectedListViewItemIndex(EventArgs e)
        {
            if (_ShowSelectedListViewItemGridEvent != null)
                _ShowSelectedListViewItemGridEvent(ListViewIndex);
        }
        #endregion

        #region Event
        public delegate void SelectedListViewItemHandler(int listViewIndex);
        public event SelectedListViewItemHandler _ShowSelectedListViewItemGridEvent;
        #endregion

        public ListViewModel()
        {
            InitRelayCommand();
        }
    }
}
