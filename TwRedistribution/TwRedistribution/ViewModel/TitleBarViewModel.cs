using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TwRedistribution.ViewModel
{
    public class TitleBarViewModel : ViewModelBase
    {
        #region UIVariable

        #endregion

        #region Command
        public RelayCommand<object> ButtonClickCommand { get; private set; }

        private void InitRelayCommand()
        {
            ButtonClickCommand = new RelayCommand<object>((param) => OnButtonClick(param));
        }

        private void OnButtonClick(object param)
        {
            switch (param.ToString())
            {
                case "Exit":
                    ExitProgramClick();
                    break;
                case "WindowMinimize":
                    WindowMinimizeClick();
                    break;
            }
        }

        private void ExitProgramClick()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void WindowMinimizeClick()
        {
            _WindowStateEvent?.Invoke(WindowState.Minimized);
        }
        #endregion

        #region Event
        public delegate void WindowStateHandler(WindowState state);
        public event WindowStateHandler _WindowStateEvent;
        #endregion

        public TitleBarViewModel()
        {
            InitRelayCommand();
        }
    }
}
