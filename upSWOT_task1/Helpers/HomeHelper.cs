using upSWOT_task1.Models;

namespace upSWOT_task1.Helpers
{
    public static class HomeHelper
    {
        public async static Task<bool> CheckPerson(string characterName, string episodeName)
        {
            try
            {
                CharacterDTO character = await RetriveDataFromAPI.GetCharacterByName(characterName);
                EpisodeDTO episode = await RetriveDataFromAPI.GetEpisodeByName(episodeName);
                return episode.characters.Contains(character.Url);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
