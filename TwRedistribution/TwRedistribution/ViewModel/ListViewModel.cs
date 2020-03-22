﻿using GalaSoft.MvvmLight;
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

        private bool _redistributionBarVisibility = true;
        public bool RedistributionBarVisibility
        {
            get { return _redistributionBarVisibility; }
            set { _redistributionBarVisibility = value; RaisePropertyChanged("RedistributionBarVisibility"); }
        }
        private bool _logBarVisibility = false;
        public bool LogBarVisibility
        {
            get { return _logBarVisibility; }
            set { _logBarVisibility = value; RaisePropertyChanged("LogBarVisibility"); }
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
                    RedistributionBarVisibility = true;
                    LogBarVisibility = false;
                    break;
                case 1:
                    RedistributionBarVisibility = false;
                    LogBarVisibility = true;
                    break;
            }

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
