using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ninja_Price.API.PoeNinja.Classes
{
    public partial class Leagues
    {
        [JsonProperty("endAt")] public string EndAt { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("startAt")] public string StartAt { get; set; }

        [JsonProperty("url")] public string Url { get; set; }
    }

    public partial class Leagues
    {
        public static List<Leagues> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<Leagues>>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this List<Leagues> self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling        = DateParseHandling.None
        };
    }
}