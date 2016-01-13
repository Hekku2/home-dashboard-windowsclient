using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace WindowsSensorClient
{
    public sealed class WebServiceClient : IDisposable
    {
        private readonly string _serviceUrl;
        private readonly string _username;
        private readonly string _password;
        private readonly int _sensorId;
        private readonly WebClient _client = new WebClient();

        private string _token;

        public WebServiceClient(string serviceUrl, string username, string password, int sensorId)
        {
            _serviceUrl = serviceUrl;
            _username = username;
            _password = password;
            _sensorId = sensorId;
        }

        public void Authenticate()
        {
            var response = _client.UploadValues(string.Format("{0}/login", _serviceUrl), AuthenticationValues());
            var converted = JsonConvert.DeserializeObject<Authentication>(Encoding.Default.GetString(response));
            _token = converted.Token;
        }

        public void SendTemperature(float value)
        {
            _client.UploadValues(string.Format("{0}/measurement",_serviceUrl), MeasurementValues(value));
        }

        public void Dispose()
        {
            if (_client != null)
            {
                var values = new NameValueCollection();
                values["token"] = _token;
                _client.UploadValues(string.Format("{0}/logout",_serviceUrl), values);
                _client.Dispose();
            }
            
        }

        private NameValueCollection MeasurementValues(double value)
        {
            var values = new NameValueCollection();
            values["token"] = _token;
            values["timestamp"] = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            values["sensor"] = _sensorId.ToString();
            values["value"] = value.ToString(CultureInfo.InvariantCulture);
            return values;
        }

        private NameValueCollection AuthenticationValues()
        {
            var values = new NameValueCollection();
            values["identifier"] = _username;
            values["password"] = _password;
            return values;
        }
    }
}
