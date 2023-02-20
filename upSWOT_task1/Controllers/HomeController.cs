using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using upSWOT_task1.Helpers;
using upSWOT_task1.Models;

namespace upSWOT_task1.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class HomeController : Controller
    {
        public static List<SavedRequest> SavedReq { get; set; } = new List<SavedRequest>();
        [HttpPost]
        [Route("check-person")]
        public async Task<bool?> CheckPerson([FromBody] CheckPersonDTO input)
        {
            var saved = SavedReq.FirstOrDefault(i => i.Type == RequestType.CheckPerson && i.Arguments == input.personName + "," + input.episodeName);
            if (saved != null)
            {
                if (saved.Response == "404")
                {
                    Response.StatusCode = 404;
                    return null;
                }
                return (bool)saved.Response;
            }
            try
            {
                bool result = await HomeHelper.CheckPerson(input.personName, input.episodeName);
                SavedReq.Add(new SavedRequest(RequestType.CheckPerson, input.personName + "," + input.episodeName, (object)result));
                return result;
            }
            catch (Exception e)
            {
                Response.StatusCode = 404;
                SavedReq.Add(new SavedRequest(RequestType.CheckPerson, input.personName + "," + input.episodeName, (object)"404"));
                return null;
            }
        }
        [HttpGet]
        [Route("person")]
        public async Task<CharacterDTO> GetPerson(string name)
        {
            var saved = SavedReq.FirstOrDefault(i => i.Type == RequestType.GetPerson && i.Arguments == name);
            if (saved != null)
            {
                if (saved.Response == (object)"404")
                {
                    Response.StatusCode = 404;
                    return null;
                }
                return (CharacterDTO)saved.Response;
            }
            try
            {
                CharacterDTO result = await RetriveDataFromAPI.GetCharacterByName(name);
                SavedReq.Add(new SavedRequest(RequestType.GetPerson, name, (object)result));
                return result;
            }
            catch (Exception e)
            {
                Response.StatusCode = 404;
                SavedReq.Add(new SavedRequest(RequestType.GetPerson, name, (object)"404"));
                return null;
            }
        }
    }
}
