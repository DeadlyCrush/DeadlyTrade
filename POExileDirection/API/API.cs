using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Ninja_Price.API.PoeNinja
{
    public class Api
    {
        public static string DownloadFromUrl(string url)
        {
            try
            {
                using (var web = new WebClient())
                {
                    var json = web.DownloadString(url);
                    return json;
                }
            }
            catch (CookieException e)
            {
                return "";
            }
        }

        public class JsonAPI
        {
            public static string ReadJson(string filePath)
            {
                return File.ReadAllText(filePath);
            }

            public static void SaveJson(string filePath, string data)
            {
                using (var file = File.CreateText(filePath))
                {
                    file.WriteLine(data);
                }
            }

            public static TSettingType LoadSettingFile<TSettingType>(string fileName)
            {
                return !File.Exists(fileName) ? default(TSettingType) : JsonConvert.DeserializeObject<TSettingType>(File.ReadAllText(fileName));
            }

            public static void SaveSettingFile<TSettingType>(string fileName, TSettingType setting)
            {
                try
                {
                    File.WriteAllText(fileName, JsonConvert.SerializeObject(setting, Formatting.Indented));
                }
                catch(CookieException e)
                {
                    File.WriteAllText(fileName, "");
                }
            }
        }
    }
}