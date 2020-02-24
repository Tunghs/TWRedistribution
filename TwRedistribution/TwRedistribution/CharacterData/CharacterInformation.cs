using System.Collections.Generic;

namespace TwRedistribution.CharacterData
{
    static class CharacterInformation
    {
        #region Character List
        public static List<string> GetCharacterList()
        {
            return new List<string>(new string[]
            {
                "루시안 칼츠", "보리스 진네만", "막시민 리프크네", "시벨린 우", "조슈아 폰 아르님", "란지에 로젠 크란츠",
                "이자크 듀카스텔", "밀라 네브라스카", "티치엘 쥬스피앙", "이스핀 샤를", "나야트레이", "아나이스 델 카릴",
                "클로에 다 폰티나", "벤야", "이솔렛", "로아미니", "녹턴 드 뷔엥", "클라리체 데 아브릴"
            });
        }
        #endregion
    }
}
