using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace TwRedistribution.ViewModel
{
    #region Character List
    public class SetCharacterList
    {
        public readonly List<string> Character;
        public SetCharacterList()
        {
            Character = new List<string>(new string[]
            {
                "루시안 칼츠", "보리스 진네만", "막시민 리프크네", "시벨린 우", "조슈아 폰 아르님", "란지에 로젠 크란츠",
                "이자크 듀카스텔", "밀라 네브라스카", "티치엘 쥬스피앙", "이스핀 샤를", "나야트레이", "아나이스 델 카릴",
                "클로에 다 폰티나", "벤야", "이솔렛", "로아미니", "녹턴 드 뷔엥", "클라리체 데 아브릴"
            });
        }
    }
    #endregion

    #region Character Style
    public class SetCharacterStyle
    {
        public readonly List<string> Style;
        public SetCharacterStyle(string character)
        {
            switch (character)
            {
                case "루시안 칼츠":
                    Style = new List<string>(new string[] { "물리복합형", "베기형", "찌르기형" });
                    break;
                case "보리스 진네만":
                    Style = new List<string>(new string[] { "물리복합형", "베기형", "마검사형" });
                    break;
                case "막시민 리프크네":
                    Style = new List<string>(new string[] { "물리복합형", "베기형", "마검사형" });
                    break;
                case "시벨린 우":
                    Style = new List<string>(new string[] { "찌르기형", "물리복합형" });
                    break;
                case "조슈아 폰 아르님":
                    Style = new List<string>(new string[] { "강화계", "변화계", "방출계" });
                    break;
                case "란지에 로젠 크란츠":
                    Style = new List<string>(new string[] { "물리형", "마법형", "보조형" });
                    break;
                case "이자크 듀카스텔":
                    Style = new List<string>(new string[] { "찌르기형", "베기형", "물리복합형" });
                    break;
                case "밀라 네브라스카":
                    Style = new List<string>(new string[] { "베기형", "물리복합형" });
                    break;
                case "티치엘 쥬피스앙":
                    Style = new List<string>(new string[] { "공격형", "보조형", "전투형" });
                    break;
                case "이스핀 샤를":
                    Style = new List<string>(new string[] { "물리복합형", "베기형", "찌르기형" });
                    break;
                case "나야트레이":
                    Style = new List<string>(new string[] { "물리복합형", "베기형", "찌르기형" });
                    break;
                case "아나이스 델 카릴":
                    Style = new List<string>(new string[] { "마법인형", "파괴정령", "비호정령" });
                    break;
                case "클로에 다 폰티나":
                    Style = new List<string>(new string[] { "화염계", "빙한계", "전격계" });
                    break;
                case "벤야":
                    Style = new List<string>(new string[] { "영령계" });
                    break;
                case "이솔렛":
                    Style = new List<string>(new string[] { "티엘라", "신성차트" });
                    break;
                case "로아미니":
                    Style = new List<string>(new string[] { "주술계" });
                    break;
                case "녹턴 드 뷔엥":
                    Style = new List<string>(new string[] { "공학계" });
                    break;
                case "클라리체 데 아브릴":
                    Style = new List<string>(new string[] { "아밍소드" });
                    break;
            }
        }
    }
    #endregion

    #region Character Skill
    #endregion

    class RedistributionViewModel : ViewModelBase
    {
        #region UI Variable
        private ObservableCollection<string> _characterList = new ObservableCollection<string>();
        public ObservableCollection<string> CharacterList
        {
            get { return _characterList; }
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
        private string _selectedStyle;
        public string SelectedStyle
        {
            get { return _selectedStyle; }
            set { _selectedStyle = value; RaisePropertyChanged("SelectedStyle"); }
        }
        #endregion

        #region Command
        public RelayCommand<EventArgs> SelectedCharacterCommand { get; private set; }
        public RelayCommand<EventArgs> SelectedListCommand { get; private set; }

        private void InitRelayCommand()
        {
            SelectedCharacterCommand = new RelayCommand<EventArgs>((e) => OnSelectedCharacter(e));
            SelectedListCommand = new RelayCommand<EventArgs>((e) => OnSelectedStyle(e));
        }

        public void OnSelectedCharacter(EventArgs e)
        {
            if (SelectedCharacter != null)
            {
                CharacterStyleList.Clear();

                SetCharacterStyle characterStyle = new SetCharacterStyle(SelectedCharacter);
                foreach(string style in characterStyle.Style)
                {
                    CharacterStyleList.Add(style);
                }
            }
        }

        public void OnSelectedStyle(EventArgs e)
        {
            if (SelectedStyle != null)
            {

            }
        }
        #endregion

        public RedistributionViewModel()
        {
            SetCharacterList setCharacterList = new SetCharacterList();
            foreach(string character in setCharacterList.Character)
            {
                CharacterList.Add(character);
            }
            InitRelayCommand();
        }
    }
}
