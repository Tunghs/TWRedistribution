using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace TwRedistribution.ViewModel
{
    class TitleBarViewModel : ViewModelBase
    {
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
            }
        }

        public void ExitProgramClick()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        #endregion

        public TitleBarViewModel()
        {
            InitRelayCommand();
        }
    }
}
