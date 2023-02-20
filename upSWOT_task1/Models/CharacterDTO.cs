using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace upSWOT_task1.Models
{
    public class CharacterDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("species")]
        public string Species { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("origin")]
        public Dictionary<string, string> Origin { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string Url { get; set; }
        public CharacterDTO(JObject characterInJson, JObject originLocationInJson)
        {
            Name = characterInJson["results"][0]["name"].ToString();
            Status = characterInJson["results"][0]["status"].ToString();
            Species = characterInJson["results"][0]["species"].ToString();
            Type = characterInJson["results"][0]["type"].ToString();
            Gender = characterInJson["results"][0]["gender"].ToString();
            Origin = new Dictionary<string, string>() { { "name", originLocationInJson["name"].ToString() }, { "type", originLocationInJson["type"].ToString() }, { "dimension", originLocationInJson["dimension"].ToString() } };
            Url = characterInJson["results"][0]["url"].ToString();

        }
    }
}
