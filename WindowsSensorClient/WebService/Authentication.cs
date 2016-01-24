using Newtonsoft.Json;

namespace WindowsSensorClient.WebService
{
    public class Authentication
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
