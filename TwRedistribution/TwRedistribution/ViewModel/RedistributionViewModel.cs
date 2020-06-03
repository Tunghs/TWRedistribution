using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace TwRedistribution.ViewModel
{
    #region Character Information
    public class CharacterInformation
    {
        public readonly List<string> CharacterList;
        public readonly List<string> CharacterStyle;
        public readonly List<string> CharacterSkill;

        public CharacterInformation()
        {
            CharacterList = new List<string>(new string[]
            {
                "루시안 칼츠", "보리스 진네만", "막시민 리프크네", "시벨린 우", "조슈아 폰 아르님", "란지에 로젠 크란츠",
                "이자크 듀카스텔", "밀라 네브라스카", "티치엘 쥬스피앙", "이스핀 샤를", "나야트레이", "아나이스 델 카릴",
                "클로에 다 폰티나", "벤야", "이솔렛", "로아미니", "녹턴 드 뷔엥", "클라리체 데 아브릴"
            });
        }

        public CharacterInformation(string name)
        {
            CharacterStyle = GetCharacterStyle(name);
            CharacterSkill = GetCharacterSkill(name);
        }

        private List<string> GetCharacterStyle(string name)
        {
            List<string> Style = new List<string>();

            if (name != null)
            {
                switch (name)
                {
                    case "루시안 칼츠":
                        Style = new List<string>(new string[] { "물리복합", "베기형", "찌르기형" });
                        break;
                    case "보리스 진네만":
                        Style = new List<string>(new string[] { "물리복합", "베기형", "마검사형" });
                        break;
                    case "막시민 리프크네":
                        Style = new List<string>(new string[] { "물리복합", "베기형", "마검사형" });
                        break;
                    case "시벨린 우":
                        Style = new List<string>(new string[] { "찌르기형", "물리복합", "베기형" });
                        break;
                    case "조슈아 폰 아르님":
                        Style = new List<string>(new string[] { "강화계", "변화계", "방출계" });
                        break;
                    case "란지에 로젠 크란츠":
                        Style = new List<string>(new string[] { "물리계열", "마법계열", "보조계열" });
                        break;
                    case "이자크 듀카스텔":
                        Style = new List<string>(new string[] { "찌르기형", "베기형", "물리복합" });
                        break;
                    case "밀라 네브라스카":
                        Style = new List<string>(new string[] { "베기형", "물리복합", "찌르기형" });
                        break;
                    case "티치엘 쥬피스앙":
                        Style = new List<string>(new string[] { "공격형", "보조형", "전투형" });
                        break;
                    case "이스핀 샤를":
                        Style = new List<string>(new string[] { "찌르기형", "물리복합", "베기형" });
                        break;
                    case "나야트레이":
                        Style = new List<string>(new string[] { "찌르기형", "물리복합", "베기형" });
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
                        Style = new List<string>(new string[] { "마력활성" });
                        break;
                }
            }
            else
            {
                Style = null;
            }

            return Style;
        }

        private List<string> GetCharacterSkill(string name)
        {
            List<string> Skill = new List<string>();
            switch (name)
            {
                case "루시안 칼츠":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "화염계(INT, DEX)", "바람계(DEX, INT)", "전격계(INT, MR)", "검계열(STAB,DEX)", "도계열(HACK, DEF)" });
                    break;
                case "보리스 진네만":
                    Skill = new List<string>(new string[] { "공통계열(DEX,AGI)", "빙한계(INT,MR)", "대지계(DEF,INT)", "암흑계(INT,MR)", "검계열(STAB,DEX)", "도계열(HACK, DEF)" });
                    break;
                case "막시민 리프크네":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "바람계(DEX,INT)", "전격계(INT,MR)", "암흑계(INT,MR)", "검계열(STAB,DEX)", "도계열(HACK,DEF)" });
                    break;
                case "시벨린 우":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "창계열(STAB,DEX)", "봉계열(HACK,STAB)" });
                    break;
                case "조슈아 폰 아르님":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "강화계열(STAB,DEX)", "변화계(INT,MR)", "방출계(INT,DEX)" });
                    break;
                case "란지에 로젠 크란츠":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "물리계열(STAB,DEX)", "마법계열(INT,DEX)", "보조계열(INT,MR)" });
                    break;
                case "이자크 듀카스텔":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "근접계열(STAB,DEX)", "기공계열(HACK,DEF)", "스탠스(DEF,AGI)" });
                    break;
                case "밀라 네브라스카":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "해적(HACK,DEF)", "기예(STAB,DEX)" });
                    break;
                case "티치엘 쥬피스앙":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "무속성(MR,INT)", "화염계(INT,DEX)", "빙한계(INT,MR)", "전격계(INT,MR)", "신성계(MR,INT)", "연금계(INT,MR)", "메이스계열(HACK,DEF)" });
                    break;
                case "이스핀 샤를":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "오를란느(STAB,DEX)", "에투알(HACK,DEF)" });
                    break;
                case "나야트레이":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "체술(HACK,DEF)", "음인술(STAB,AGI)" });
                    break;
                case "아나이스 델 카릴":
                    Skill = new List<string>(new string[] { "공통계(DEX, AGI)", "무속성(MR,INT)", "마법 인형 소환 계열(INT,DEX)", "파괴 정령 소환 계열 (INT,DEX)", "비호 정령 소환 계열(MR,DEF)" });
                    break;
                case "클로에 다 폰티나":
                    Skill = new List<string>(new string[] { "공통계(DEX,AGI)", "무속성(MR,INT)", "바람계(DEX,INT)", "대지계(DEF,INT)", "화염계(INT,DEX)", "빙한계(INT,MR)", "전격계(INT,MR)" });
                    break;
                case "벤야":
                    Skill = new List<string>(new string[] { "공통계(DEX,AGI)", "데스사이드 계열(HACK,DEF)", "홀리 헤머 계열(MR,DEF)" });
                    break;
                case "이솔렛":
                    Skill = new List<string>(new string[] { "공통계(DEX,AGI)", "티엘라 계열(HACK,DEX)", "신성찬트계열(MR,INT)" });
                    break;
                case "로아미니":
                    Skill = new List<string>(new string[] { "공통계(DEX,AGI)", "주술계(INT,DEX)", "독계(INT,MR)" });
                    break;
                case "녹턴 드 뷔엥":
                    Skill = new List<string>(new string[] { "공통계(DEX,AGI)", "공학계열(STAB,DEX)" });
                    break;
                case "클라리체 데 아브릴":
                    Skill = new List<string>(new string[] { "공통계(DEX,AGI)", "몽플레이네 검술(HACK,DEX)", "악의 무구 마력 활용(HACK,DEX)", "마력 폭주(HACK,DEX)" });
                    break;
            }
            return Skill;
        }
    }
    #endregion

    public class RedistributionViewModel : ViewModelBase
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
        private ObservableCollection<string> _characterSkillList = new ObservableCollection<string>();
        public ObservableCollection<string> CharacterSkillList
        {
            get { return _characterSkillList; }
            set { _characterSkillList = value; RaisePropertyChanged("CharacterSkillList"); }
        }
        private string _selectedSkill;
        public string SelectedSkill
        {
            get { return _selectedSkill; }
            set { _selectedSkill = value; RaisePropertyChanged("SelectedSkill"); }
        }
        private ObservableCollection<int> _percentageList = new ObservableCollection<int>();
        public ObservableCollection<int> PercentageList
        {
            get { return new ObservableCollection<int>(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 }); }
        }
        private int _selectedPercentage;
        public int SelectedPercentage
        {
            get { return _selectedPercentage; }
            set { _selectedPercentage = value; RaisePropertyChanged("SelectedPercentage"); }
        }
        private int _level = 1;
        public int Level
        {
            get { return _level; }
            set { _level = value; RaisePropertyChanged("Level"); }
        }
        #endregion

        #region Command
        public RelayCommand<object> ButtonClickCommand { get; private set; }
        public RelayCommand<EventArgs> SelectedCharacterCommand { get; private set; }

        private void InitRelayCommand()
        {
            SelectedCharacterCommand = new RelayCommand<EventArgs>(OnSelectedCharacter);
            ButtonClickCommand = new RelayCommand<object>(OnButtonClick);
        }

        private void OnButtonClick(object param)
        {
            switch (param.ToString())
            {
                case "LevelUp":
                    LvUpClick();
                    break;
            }
        }

        public void LvUpClick()
        {
            if (Level < 300)
            {
                Level++;
            }
                

            // point 부여 추가
            // LevelUp 하면 포인트 오르게 변경
        }

        public void OnSelectedCharacter(EventArgs e)
        {
            if (SelectedCharacter != null)
            {
                CharacterStyleList.Clear();
                CharacterSkillList.Clear();
                CharacterInformation characterInformation = new CharacterInformation(SelectedCharacter);
                foreach (string style in characterInformation.CharacterStyle)
                    CharacterStyleList.Add(style);
                foreach (string skill in characterInformation.CharacterSkill)
                    CharacterSkillList.Add(skill);
            }
        }
        #endregion

        public RedistributionViewModel()
        {
            SetCharacterList();
            InitRelayCommand();
        }

        private void SetCharacterList()
        {
            CharacterInformation characterInformation = new CharacterInformation();
            foreach (string list in characterInformation.CharacterList)
                CharacterList.Add(list);
        }
    }
}
