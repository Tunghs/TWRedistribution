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
            switch (ListViewIndex)
            {
                case 0:
                    MessageBox.Show("0번");
                    if (_SelectedListViewItemEvent != null)
                        _SelectedListViewItemEvent();
                    break;
                case 1:
                    MessageBox.Show("1번");
                    break;
            }
        }
        #endregion

        #region Event
        public delegate void SelectedListViewItemHandler();
        public event SelectedListViewItemHandler _SelectedListViewItemEvent;
        #endregion

        public ListViewModel()
        {
            InitRelayCommand();
        }
    }
}
