using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using log4net;

namespace POExileDirection
{
    public enum LEAGUE_STRING
    {
        [Description("Standard")]
        LEAGUE_STANDARD,

        [Description("Hardcore")]
        LEAGUE_HDCORE_STANDARD,

        [Description("Delirium")]
        LEAGUE_CURRENT,

        [Description("Hardcore Delirium")]
        LEAGUE_HDCORE_CURRENT,       
    };

    public static class LEAGUE_STRINGExtensions
    {
        public static string ToDescriptionString(this LEAGUE_STRING val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public enum HOTKEYNAME_STRING
    {
        [Description("JUN")]
        HOTKEYNAME_JUN,

        [Description("REMAINS")]
        HOTKEYNAME_REMAINS,

        [Description("ALVA")]
        HOTKEYNAME_ALVA,

        [Description("ZANA")]
        HOTKEYNAME_ZANA,

        [Description("HIDEOUT")]
        HOTKEYNAME_HIDEOUT,

        [Description("SEARCH")]
        HOTKEYNAME_SEARCH,

        [Description("EXIT")]
        HOTKEYNAME_EXIT,

        [Description("INVITE")]
        HOTKEYNAME_INVITE,

        [Description("TRADE")]
        HOTKEYNAME_TRADE,

        [Description("KICK")]
        HOTKEYNAME_KICK,

        [Description("MINIMIZE")]
        HOTKEYNAME_MINIMIZE,

        [Description("CLOSE")]
        HOTKEYNAME_CLOSE,

        [Description("SOLD")]
        HOTKEYNAME_SOLD,

        [Description("WAIT")]
        HOTKEYNAME_WAIT,

        [Description("THX")]
        HOTKEYNAME_THX,
    };

    public static class HOTKEYNAME_STRINGExtensions
    {
        public static string ToDescriptionString(this HOTKEYNAME_STRING val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public static class DeadlyLog4Net
    {
        public static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }

    public static class DeadlyDBHelper
    {
        public static string IsLoggedInCurrent(SqlConnection _sqlcon, string strIP, string strMac)
        {
            string strisLogin = "N";
            string strSQL = String.Format("SELECT isLogin, IPAddress, MacAddress FROM DeadlyCurrent Where IPAddress = '{0}' and MacAddress = '{1}' ", strIP, strMac);

            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlAdapt = new SqlDataAdapter(strSQL, _sqlcon);
            DataTable dt = new DataTable();
            try
            {
                if (_sqlcon.State != ConnectionState.Open) _sqlcon.Open();
                sqlAdapt.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    strisLogin = "X";
                }
                else
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["isLogin"].ToString() == "Y" &&
                        (dr["IPAddress"].ToString() == strIP || dr["MacAddress"].ToString() == strMac))
                    {
                        strisLogin = "Y";
                    }
                    else
                        strisLogin = "N";
                }

                dt.Dispose();
                sqlCmd.Dispose();
                sqlAdapt.Dispose();

                return strisLogin;
            }
            catch (Exception ex)
            {
                dt.Dispose();
                sqlCmd.Dispose();
                sqlAdapt.Dispose();

                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return strisLogin;
            }
        }

        public static void UpdateLoginCurrent(SqlConnection _sqlcon, string strisLogin, string strIP, string strMac, DateTime dtActionDate)
        {
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                if (_sqlcon.State != ConnectionState.Open) _sqlcon.Open();

                sqlCmd.Connection = _sqlcon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"UPDATE DeadlyCurrent SET isLogin=@isLogin, ActionDate=@ActionDate where IPAddress=@IPAddress and MacAddress=@MacAddress";

                sqlCmd.Parameters.AddWithValue("@isLogin", strisLogin);
                sqlCmd.Parameters.AddWithValue("@ActionDate", dtActionDate);
                sqlCmd.Parameters.AddWithValue("@IPAddress", strIP);
                sqlCmd.Parameters.AddWithValue("@MacAddress", strMac);

                sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                if (_sqlcon.State == ConnectionState.Open) _sqlcon.Close();
            }
            catch (Exception ex)
            {
                sqlCmd.Dispose();
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        public static string IsLoggedIn(SqlConnection _sqlcon, string strIP, string strMac)
        {
            string strisLogin = "N";
            string strSQL = String.Format("SELECT isLogin, IPAddress, MacAddress FROM DeadlyLOG Where IPAddress = '{0}' and MacAddress = '{1}' "
                                + "Order by ActionDate DESC", strIP, strMac);

            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlAdapt = new SqlDataAdapter(strSQL, _sqlcon);
            DataTable dt = new DataTable();
            try
            {
                if (_sqlcon.State != ConnectionState.Open) _sqlcon.Open();
                sqlAdapt.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    strisLogin = "N";
                }
                else
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["isLogin"].ToString() == "Y" &&
                        (dr["IPAddress"].ToString() == strIP || dr["MacAddress"].ToString() == strMac))
                    {
                        strisLogin = "Y";
                    }
                    else
                        strisLogin = "N";
                }

                dt.Dispose();
                sqlCmd.Dispose();
                sqlAdapt.Dispose();

                return strisLogin;
            }
            catch (Exception ex)
            {
                dt.Dispose();
                sqlCmd.Dispose();
                sqlAdapt.Dispose();

                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return strisLogin;
            }
        }

        public static void InsertLoginCurrent(SqlConnection _sqlcon, string strisLogin, string strIP, string strMac, string strNick,
            string strID, DateTime dtActionDate)
        {
            if (strNick == "" || String.IsNullOrEmpty(strNick))
                strNick = ".";

            if (strID == "" || String.IsNullOrEmpty(strID))
                strID = ".";

            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                if (_sqlcon.State != ConnectionState.Open) _sqlcon.Open();


                sqlCmd.Connection = _sqlcon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"INSERT INTO DeadlyCurrent(IPAddress,MacAddress,UserID,CharacterName,isLogin, ActionDate) 
                            VALUES(@IPAddress,@MacAddress,@UserID,@CharacterName,@isLogin,@ActionDate)";

                sqlCmd.Parameters.AddWithValue("@IPAddress", strIP);
                sqlCmd.Parameters.AddWithValue("@MacAddress", strMac);
                sqlCmd.Parameters.AddWithValue("@CharacterName", strNick);
                sqlCmd.Parameters.AddWithValue("@UserID", dtActionDate);
                sqlCmd.Parameters.AddWithValue("@isLogin", strisLogin);
                sqlCmd.Parameters.AddWithValue("@ActionDate", dtActionDate);

                sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                if (_sqlcon.State == ConnectionState.Open) _sqlcon.Close();
            }
            catch (Exception ex)
            {
                sqlCmd.Dispose();
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        public static void InsertLoginStatus(SqlConnection _sqlcon, string strisLogin, string strIP, string strMac, string strNick,
            string strAction, string strCountryEN, DateTime dtActionDate, int nElapsedTime)
        {
            if (strNick == "" || String.IsNullOrEmpty(strNick))
                strNick = ".";

            SqlCommand sqlCmd = new SqlCommand();
            try
            {         
                if (_sqlcon.State != ConnectionState.Open) _sqlcon.Open();


                sqlCmd.Connection = _sqlcon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"INSERT INTO DeadlyLOG(IPAddress,MacAddress,NickName,ActionType,CountryEN,isLogin,ActionDate,ElapsedTime) 
                            VALUES(@IPAddress,@MacAddress,@NickName,@ActionType,@CountryEN,@isLogin,@ActionDate,@ElapsedTime)";

                sqlCmd.Parameters.AddWithValue("@IPAddress", strIP);
                sqlCmd.Parameters.AddWithValue("@MacAddress", strMac);
                sqlCmd.Parameters.AddWithValue("@NickName", strNick);
                sqlCmd.Parameters.AddWithValue("@ActionType", strAction);
                sqlCmd.Parameters.AddWithValue("@CountryEN", strCountryEN);
                sqlCmd.Parameters.AddWithValue("@isLogin", strisLogin);
                sqlCmd.Parameters.AddWithValue("@ActionDate", dtActionDate);
                sqlCmd.Parameters.AddWithValue("@ElapsedTime", nElapsedTime);

                sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                if (_sqlcon.State == ConnectionState.Open) _sqlcon.Close();
            }
            catch (Exception ex)
            {
                sqlCmd.Dispose();
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }
    }

    public static class EncryptionHelper
    {
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "DeadlyCrushEOCSDEV2Rino";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "DeadlyCrushEOCSDEV2Rino";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }

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

        // Joined the area.
        public Regex RegExJoinedAreENG { get; set; } // : Ian_Curtis has joined the area.
        public Regex RegExJoinedAreKOR { get; set; } // Ian_Curtis has joined the area.

        // Chat Scan : Trade Channel
        public Regex RegExChatTradeChannel { get; set; }

        // Trade Message - English
        public Regex RegExENGPriceWithTabName { get; set; }
        public Regex RegExENGPriceNoTabName { get; set; }
        public Regex RegExENGPoeAppCom { get; set; }
            // BUYING
            public Regex RegExENGPoeAppComTabNameKAKAO { get; set; }
        public Regex RegExENGPricePoeApp { get; set; }
        public Regex RegExENGBulkCurrencies { get; set; }
        public Regex RegExENGCurrency { get; set; }
        public Regex RegExENGMapLiveSite { get; set; }
            // BUYING
            public Regex RegExENGPriceWithTabNameKAKAO { get; set; } // ^@(.*\s)?(.+) Hi, I (.+ to buy your\s+?(.+?)(\s+?listed for\s+?([\d\.]+?)\s+?(.+))?\s+?in\s+?(.+?)\s+?\(stash tab \"(.*)\"; position: left (\d+), top (\d+)\)\s*?(.*))$
            public Regex RegExENGPriceNoTabNameKAKAO { get; set; }
            public Regex RegExENGCurrencyKAKAO { get; set; }   
            public Regex RegExENGMapLiveSiteKAKAO { get; set; }

        // Trade Message - Korean
        public Regex RegExKORPriceWithTabName { get; set; }
        public Regex RegExKORPriceNoTabName { get; set; }
        public Regex RegExKORUnPrice { get; set; }
        public Regex RegExKORBulkCurrencies { get; set; }
        public Regex RegExKORCurrency { get; set; }
        public Regex RegExKORMapLiveSite { get; set; }
            // BUYING
            public Regex RegExKORPriceWithTabNameKAKAO { get; set; }
            public Regex RegExKORUnPriceKAKAO { get; set; }
        

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

    public class DeadlyAtlas
    {
        public class FossilInformation
        {
            public string Zone { get; set; }
            public string ZoneKR { get; set; }
            public List<string> FossilNameKR { get; set; }
            public List<string> FossilDescription { get; set; }
        }

        public class RootObjectFossilInformation
        {
            public List<FossilInformation> FossilInformation { get; set; }
        }

        public class OilsMapAnoint
        {
            public string Oils { get; set; }
            public string Effect { get; set; }
            public string EffectKR { get; set; }
        }

        public class RootObjectOilsMapAnoint
        {
            public List<OilsMapAnoint> OilsMapAnoint { get; set; }
        }

        public class OilsRingAnoint
        {
            public List<string> Oils { get; set; }
            public string Effect { get; set; }
            public string EffectKR { get; set; }
        }

        public class RootObjectOilsRingAnoint
        {
            public List<OilsRingAnoint> OilsRingAnoint { get; set; }
        }

        public class OilsPassive
        {
            public string OilA { get; set; }
            public string OilB { get; set; }
            public string OilC { get; set; }
            public string PassiveName { get; set; }
            public string KORName { get; set; }
            public string Effect { get; set; }
        }

        public class RootObjectOilsPassive
        {
            public List<OilsPassive> OilsPassive { get; set; }
        }

        public class AtlasDataCollections
        {
            public string en { get; set; }
            public string kr { get; set; }
            public List<string> drop { get; set; }
        }

        public class RootObject
        {
            public List<AtlasDataCollections> AtlasData { get; set; }
        }

        public class MapCollection
        {
            public string Id { get; set; }
            public string Text_en { get; set; }
            public string Text_ko { get; set; }
            public string DDSFile { get; set; }
        }

        public class RootObjectMap
        {
            public List<MapCollection> Maps { get; set; }
        }

        public class CurrencyCollection
        {
            public string Id { get; set; }
            public string Name_en { get; set; }
            public string Name_ko { get; set; }
            public string DDSFile { get; set; }
        }

        public class RootObjectCurruncy
        {
            public List<CurrencyCollection> Currency { get; set; }
        }

        public class DivinationCardCollection
        {
            public string Id { get; set; }
            public string Name_en { get; set; }
            public string Name_ko { get; set; }
            public string DDSFile { get; set; }
        }

        public class RootObjectDivinationCard
        {
            public List<DivinationCardCollection> DivinationCards { get; set; }
        }

        public class DelveCollection
        {
            public string Id { get; set; }
            public string Name_en { get; set; }
            public string Name_ko { get; set; }
            public string DDSFile { get; set; }
        }

        public class RootObjectDelve
        {
            public List<DelveCollection> Delve { get; set; }
        }

        public class ScarabCollection
        {
            public string Id { get; set; }
            public string Name_en { get; set; }
            public string Name_ko { get; set; }
            public string DDSFile { get; set; }
        }

        public class RootObjectScarab
        {
            public List<ScarabCollection> Scarabs { get; set; }
        }

        public class MapFragmentCollection
        {
            public string Id { get; set; }
            public string Name_en { get; set; }
            public string Name_ko { get; set; }
            public string DDSFile { get; set; }
        }

        public class RootObjectMapFragment
        {
            public List<MapFragmentCollection> MapFragments { get; set; }
        }

        public class ProphecyCollection
        {
            public string Id { get; set; }
            public string Name_en { get; set; }
            public string Name_ko { get; set; }
            public string DDSFile { get; set; }
        }

        public class RootObjectProphecy
        {
            public List<ProphecyCollection> Prophecies { get; set; }
        }

        public class UniqueMapCollection
        {
            public string Id { get; set; }
            public string Text_en { get; set; }
            public string Text_ko { get; set; }
            public string DDSFile { get; set; }
        }

        public class RootObjectUniqueMap
        {
            public List<UniqueMapCollection> UniqueMaps { get; set; }
        }

        public class UniqueCollection
        {
            public string Id { get; set; }
            public string Text_en { get; set; }
            public string Text_ko { get; set; }
            public string DDSFile { get; set; }
        }

        public class RootObjectUnique
        {
            public List<UniqueCollection> Uniques { get; set; }
        }

        public class NotifyMSGCollection
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Msg { get; set; }
        }

        public class RootObjectNotifyMSG
        {
            public List<NotifyMSGCollection> NotifyMSG { get; set; }
        }

        public class MapAlertMSGCollection
        {
            public string Id { get; set; }
            public List<string> Msg { get; set; }
        }

        public class RootObjectMapAlertMSG
        {
            public List<MapAlertMSGCollection> MapAlertMSG { get; set; }
        }
    }

    /*public class DeadlyHotkeys
    {
        public string fsModString { get; set; }
        public string hotKeyNumber { get; set; }
    }*/
    public static class DeadlyFlaskImage
    {
        private static Dictionary<int, int> g_nFlaskImageTimer = new Dictionary<int, int>();

        public static void FlaskImageTimerFromINI()
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            string strImageNumber = String.Empty;
            // 1
            strImageNumber = parser.GetSetting("MISC", "FLASKIMAGE1");
            if (String.IsNullOrEmpty(strImageNumber))
                g_nFlaskImageTimer.Add(0, 0);
            else
                g_nFlaskImageTimer.Add(0, Convert.ToInt32(strImageNumber));
            // 2
            strImageNumber = parser.GetSetting("MISC", "FLASKIMAGE2");
            if (String.IsNullOrEmpty(strImageNumber))
                g_nFlaskImageTimer.Add(1, 1);
            else
                g_nFlaskImageTimer.Add(1, Convert.ToInt32(strImageNumber));
            // 3
            strImageNumber = parser.GetSetting("MISC", "FLASKIMAGE3");
            if (String.IsNullOrEmpty(strImageNumber))
                g_nFlaskImageTimer.Add(2, 2);
            else
                g_nFlaskImageTimer.Add(2, Convert.ToInt32(strImageNumber));
            // 4
            strImageNumber = parser.GetSetting("MISC", "FLASKIMAGE4");
            if (String.IsNullOrEmpty(strImageNumber))
                g_nFlaskImageTimer.Add(3, 3);
            else
                g_nFlaskImageTimer.Add(3, Convert.ToInt32(strImageNumber));
            // 5
            strImageNumber = parser.GetSetting("MISC", "FLASKIMAGE5");
            if (String.IsNullOrEmpty(strImageNumber))
                g_nFlaskImageTimer.Add(4, 4);
            else
                g_nFlaskImageTimer.Add(4, Convert.ToInt32(strImageNumber));

            parser = null;
        }

        public static void FlaskImageTimerSavetoINI()
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            parser.AddSetting("MISC", "FLASKIMAGE1", g_nFlaskImageTimer[0].ToString());
            parser.AddSetting("MISC", "FLASKIMAGE2", g_nFlaskImageTimer[1].ToString());
            parser.AddSetting("MISC", "FLASKIMAGE3", g_nFlaskImageTimer[2].ToString());
            parser.AddSetting("MISC", "FLASKIMAGE4", g_nFlaskImageTimer[3].ToString());
            parser.AddSetting("MISC", "FLASKIMAGE5", g_nFlaskImageTimer[4].ToString());

            parser.SaveSettings();
            parser = null;
        }

        public static void FlaskImageTimerSavetoINI_FlaskImageKeyValue(int nFlaskImagePanelFlaskNumber, int nValue)
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            switch (nFlaskImagePanelFlaskNumber)
            {
                case 1:
                    g_nFlaskImageTimer[0] = nValue;
                    parser.AddSetting("MISC", "FLASKIMAGE1", g_nFlaskImageTimer[0].ToString());
                    break;
                case 2:
                    g_nFlaskImageTimer[1] = nValue;
                    parser.AddSetting("MISC", "FLASKIMAGE2", g_nFlaskImageTimer[1].ToString());
                    break;
                case 3:
                    g_nFlaskImageTimer[2] = nValue;
                    parser.AddSetting("MISC", "FLASKIMAGE3", g_nFlaskImageTimer[2].ToString());
                    break;
                case 4:
                    g_nFlaskImageTimer[3] = nValue;
                    parser.AddSetting("MISC", "FLASKIMAGE4", g_nFlaskImageTimer[3].ToString());
                    break;
                case 5:
                    g_nFlaskImageTimer[4] = nValue;
                    parser.AddSetting("MISC", "FLASKIMAGE5", g_nFlaskImageTimer[4].ToString());
                    break;
                default:
                    break;
            }

            parser.SaveSettings();
            parser = null;
        }

        public static int FlaskImageTimerGetValuebyKey(int key)
        {
            return g_nFlaskImageTimer[key];
        }
    }

    public static class DeadlyZoneInform
    {
        static Dictionary<string, string> ActZoneNamePart1 = new Dictionary<string, string>();
        static Dictionary<string, string> ActZoneNamePart2 = new Dictionary<string, string>();
        static Dictionary<string, string> ActZoneNamePart1ENG = new Dictionary<string, string>();
        static Dictionary<string, string> ActZoneNamePart2ENG = new Dictionary<string, string>();

        public static void InitActZoneDictionary()
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


        public static string GetActROMAbyZoneName(string strZoneName, bool bIsPartTwo)
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

    public class DeadlyHotkeys
    {
        public WindowsHook.Keys fsMod { get; set; }
        public WindowsHook.Keys hotKeys { get; set; }
    }

    public static class DeadlyImageCommon
    {
        public static Bitmap resizeImage(Bitmap imgToResize, float zoomScale)
        {
            return new Bitmap(imgToResize, new Size(Convert.ToInt32(imgToResize.Width * zoomScale), Convert.ToInt32(imgToResize.Height * zoomScale)));
            //(int)(imgToResize.Width * zoomScale), (int)(imgToResize.Height * zoomScale));
        }

        public static Bitmap cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Bitmap ScaleImage(Bitmap bmp, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / bmp.Width;
            var ratioY = (double)maxHeight / bmp.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(bmp.Width * ratio);
            var newHeight = (int)(bmp.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(bmp))
                graphics.DrawImage(newImage, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }

    public static class CommonDeadly
    {
        public static int GetFileCountFromFolder(string strPath, bool bSearchSubDir)
        {
            int nCnt = 0;

            try
            {
                if (bSearchSubDir)
                    nCnt = Directory.GetFiles(strPath, "*", SearchOption.AllDirectories).Length;    // searches the current directory and sub directory
                else
                    nCnt = Directory.GetFiles(strPath, "*", SearchOption.TopDirectoryOnly).Length;  // searches the current directory
            }
            catch
            {

            }

            return nCnt;
        }

        public static void DeleteAllFilesInFoder(string strPath)
        {
            // Delete all files in a directory  
            try
            {
                string[] files = Directory.GetFiles(strPath);
                foreach (string file in files)
                    File.Delete(file);
            }
            catch
            {

            }
        }
    }
}
