using Newtonsoft.Json.Linq;
using upSWOT_task1.Models;
namespace upSWOT_task1.Helpers
{
    public static class RetriveDataFromAPI
    {
        public static async Task<CharacterDTO> GetCharacterByName(string name)
        {
            CharacterDTO result;
            using (var httpClient = new HttpClient())
            {
                using (var characterResponse = await httpClient.GetAsync($"https://rickandmortyapi.com/api/character/?name={name}"))
                {
                    JObject json = JObject.Parse(await characterResponse.Content.ReadAsStringAsync());
                    if (json.HasValues)
                    {
                        if (json.ContainsKey("error"))
                        {
                            throw new Exception(json["error"]?.ToString());
                        }

                        using (var locationResponse = await httpClient.GetAsync(json["results"][0]["origin"]["url"].ToString()))
                        {
                            result = new CharacterDTO(json, JObject.Parse(await locationResponse.Content.ReadAsStringAsync()));
                        }
                    }
                    else { throw new Exception("Unknonw Error"); }
                }
            }

            return result;
        }
        public static async Task<EpisodeDTO> GetEpisodeByName(string name)
        {
            EpisodeDTO result;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://rickandmortyapi.com/api/episode/?name={name}"))
                {
                    JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());
                    if (json.HasValues)
                    {
                        if (json.ContainsKey("error"))
                        {
                            throw new Exception(json["error"]?.ToString());
                        }
                        result = new EpisodeDTO(json);

                    }
                    else { throw new Exception("Unknonw Error"); }
                }
            }

            return result;
        }
    }
}
