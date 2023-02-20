namespace upSWOT_task1.Models
{
    public enum RequestType
    {
        CheckPerson,
        GetPerson
    }
    public class SavedRequest
    {
        public RequestType Type { get; set; }
        public string Arguments { get; set; }
        public object Response { get; set; }

        public SavedRequest(RequestType type, string args, object resp)
        {
            Type = type; 
            Arguments = args; 
            Response = resp;
        }
    }
}
