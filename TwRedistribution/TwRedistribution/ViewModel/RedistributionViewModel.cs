using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace TwRedistribution.ViewModel
{
    #region Character Style
    public class CharacterStyle
    {
    }
    #endregion

    class RedistributionViewModel : ViewModelBase
    {
        #region UI Variable
        private ObservableCollection<string> _characterList = new ObservableCollection<string>();
        public ObservableCollection<string> CharacterList
        {
            get { return _characterList; }
            set { _characterList = value; RaisePropertyChanged("CharacterList"); }
        }
        private string _selectedCharacter;
        public string SelectedCharacter
        {
            get { return _selectedCharacter; }
            set { _selectedCharacter = value; RaisePropertyChanged("SelectedCharacter"); }
        }
        private ObservableCollection<string> _characterStyleList = new ObservableCollection<string>();
        public ObservableCollection<string> CharacterStyleList
        {
            get { return _characterStyleList; }
            set { _characterStyleList = value; RaisePropertyChanged("CharacterStyleList"); }
        }
        #endregion

        #region Command
        public RelayCommand<EventArgs> SelectedCharacterCommand { get; private set; }

        private void InitRelayCommand()
        {
            SelectedCharacterCommand = new RelayCommand<EventArgs>((e) => OnSelectedCharacter(e));
        }

        public void OnSelectedCharacter(EventArgs e)
        {
            if (SelectedCharacter != null)
            {
                GetCharacterStyle(SelectedCharacter);
            }
        }
        
        public void GetCharacterStyle(string character)
        {

        }

        #endregion
    }
}
