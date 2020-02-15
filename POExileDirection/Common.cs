using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public class DeadlyRegEx
    {
        // ZONE
        public Regex RegExZoneEnteredENG { get; set; } // new Regex(@"You have entered (.*)\.", RegexOptions.IgnoreCase);
        public Regex RegExZoneEnteredKOR { get; set; } // new Regex(@": (.*)에 진입했습니다.", RegexOptions.IgnoreCase);

        // MONSTER
        public Regex RegExMonsterRemainsENG { get; set; } // new Regex(@": (.*) monsters remain."); // : 3 monsters remain.
        public Regex RegExMonsterRemainsKOR { get; set; } // new Regex(@": 몬스터 (.*)개체가 남아있습니다."); // : 몬스터 0개체가 남아있습니다.
        public Regex RegExMonsterRemainsKORMore { get; set; } // : 몬스터가 (.*)개체 이상 남아있습니다.
        public Regex RegExMonsterRemainsENGMore { get; set; } // : More than 50 monsters remain.

        // Trade Message - English
        public Regex RegExENGPriceWithTabName { get; set; }
        public Regex RegExENGPriceNoTabName { get; set; }
        public Regex RegExENGUnPrice { get; set; }
        public Regex RegExENGBulkCurrencies { get; set; }
        public Regex RegExENGCurrency { get; set; }
        public Regex RegExENGMapLiveSite { get; set; }

        // Trade Message - Korean
        public Regex RegExKORPriceWithTabName { get; set; }
        public Regex RegExKORPriceNoTabName { get; set; }
        public Regex RegExKORUnPrice { get; set; }
        public Regex RegExKORBulkCurrencies { get; set; }
        public Regex RegExKORCurrency { get; set; }
        public Regex RegExKORMapLiveSite { get; set; }
    }

    public class DeadlyTRADE
    {
        public class TradeMSG
        {
            // 알림 패널 정보
            public string id { get; set; }
            public bool expanded { get; set; }

            // 구매, 판매 정보
            public string tradePurpose { get; set; } // 거래 목적 : 구매? 판매?

            // 기본 정보
            public string fullMSG { get; set; } // 전체 메시지
            public string league { get; set; } // 전체 메시지
            public string nickName { get; set; } // 누가
            public string tabName { get; set; } // 어떤 보관함의
            public string xPos { get; set; } // 가로 좌표
            public string yPos { get; set; } // 세로 좌표
            public string itemName { get; set; } // 어떤 아이템을

            // 메시지 보낸 사람이 내는 가격
            public string priceCall { get; set; } // 얼마의 (요청자) :: 나의 170
            public string whichCurrency { get; set; } // 어떤 커런시로 (요청자) :: 나의 Chaos Orb 로

            // 추가 메시지
            public string offerMSG { get; set; } // 추가로 할말과 함께

            // 메시지 받는 사람에게 원하는 커런시
            public string priceYour { get; set; } // 대상자의 얼마를 :: 너의 1
            public string yourCurrency { get; set; } // 대상자의 어떤 커런시를 :: 너의 Exalted Orb 를

        }
    }

    public enum UI_LANG
    {
        UI_KOREAN,
        UI_ENGLISH,
        UI_UNKOWN,
        UI_ERROR,
    };

    public enum OVERLAY_WHAT
    {
        OVER_JUN,
        OVER_ALVA,
        OVER_MAP,
    }

    public struct RECT
    {
        public int left, top, right, bottom;
    }

    public enum fsModifiers
    {
        None = 0x0000,
        Alt = 0x0001,
        Control = 0x0002,
        Shift = 0x0004,
        Window = 0x0008,
    }

    public class ConvertKOR
    {
        public class RootObject
        {
            public List<EnkrDataCollections> EnkrData { get; set; }
        }

        public class EnkrDataCollections
        {
            public string id { get; set; }
            public string kr { get; set; }
            public string en { get; set; }
        }
    }

    public class OverlayHotkeys
    {
        public fsModifiers fsMod { get; set; }
        public Keys hotKeys { get; set; }
    }

    public class Common
    {
        Dictionary<string, string> ActZoneNamePart1 = new Dictionary<string, string>();
        Dictionary<string, string> ActZoneNamePart2 = new Dictionary<string, string>();
        Dictionary<string, string> ActZoneNamePart1ENG = new Dictionary<string, string>();
        Dictionary<string, string> ActZoneNamePart2ENG = new Dictionary<string, string>();

        public void InitActZoneDictionary()
        {
            // KOR Part One
            ActZoneNamePart1.Add("I", "라이온아이 초소");
            ActZoneNamePart1.Add("II", "숲 야영지");
            ActZoneNamePart1.Add("III", "사안 야영지");
            ActZoneNamePart1.Add("IV", "하이게이트");
            ActZoneNamePart1.Add("V", "감시탑");
            // KOR Part Two
            ActZoneNamePart2.Add("VI", "라이온아이 초소");
            ActZoneNamePart2.Add("VII", "다리 야영지");
            ActZoneNamePart2.Add("VIII", "사안 야영지");
            ActZoneNamePart2.Add("IX", "하이게이트");
            ActZoneNamePart2.Add("X", "오리아스 부두");

            // ENG Part One
            ActZoneNamePart1ENG.Add("I", "Lioneye's Watch");
            ActZoneNamePart1ENG.Add("II", "The Forest Encampment");
            ActZoneNamePart1ENG.Add("III", "The Sarn Encampment");
            ActZoneNamePart1ENG.Add("IV", "Highgate");
            ActZoneNamePart1ENG.Add("V", "Overseer's Tower");
            // ENG Part Two
            ActZoneNamePart2ENG.Add("VI", "Lioneye's Watch");
            ActZoneNamePart2ENG.Add("VII", "The Bridge Encampment");
            ActZoneNamePart2ENG.Add("VIII", "The Sarn Encampment");
            ActZoneNamePart2ENG.Add("IX", "Highgate");
            ActZoneNamePart2ENG.Add("X", "Oriath  Docks");
        }
     

        public string GetActROMAbyZoneName(string strZoneName, bool bIsPartTwo)
        {
            bool bFound = false;
            string strRet = "";

            // Check Part One - KOR
            if (bIsPartTwo == false)
            {
                strRet = ActZoneNamePart1.FirstOrDefault(x => x.Value == strZoneName && (bFound = true)).Key;
                if (bFound)
                    return strRet;
            }
            else // Check Part Two - KOR
            {
                strRet = ActZoneNamePart2.FirstOrDefault(x => x.Value == strZoneName && (bFound = true)).Key;
                if (bFound)
                    return strRet;
            }

            // Check Part One - ENG
            if (bIsPartTwo == false)
            {
                strRet = ActZoneNamePart1ENG.FirstOrDefault(x => x.Value == strZoneName && (bFound = true)).Key;
                if (bFound)
                    return strRet;
            }
            else // Check Part Two- ENG
            {
                strRet = ActZoneNamePart2ENG.FirstOrDefault(x => x.Value == strZoneName && (bFound = true)).Key;
                if (bFound)
                    return strRet;
            }

            // Last Check
            if (strZoneName == "오리아스" || strZoneName == "Oriath")
                return "O";
            else if (strZoneName == "템플러의 실험실" || strZoneName == "The Templar Laboratory")
                return "Z";
            else if (strZoneName.Contains(" 은신처") || strZoneName.Contains(" Hideout"))
                return "H";
            else
                return "?";
        }
    }
}
