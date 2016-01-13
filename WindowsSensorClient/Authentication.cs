using Newtonsoft.Json;

namespace WindowsSensorClient
{
    public class Authentication
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
