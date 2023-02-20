using Newtonsoft.Json.Linq;

namespace upSWOT_task1.Models
{
    public class EpisodeDTO
    {
        public string Name { get; set; }
        public IEnumerable<string> characters { get; set; }
        public EpisodeDTO(JObject json)
        {
            Name = json["results"][0]["name"].ToString();
            characters = json["results"][0]["characters"].ToList().Select(i => i.ToString());
        }
    }
}
