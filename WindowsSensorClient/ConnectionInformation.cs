using System;

namespace WindowsSensorClient
{
    public sealed class ConnectionInformation
    {
        public string Url { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public ConnectionInformation(string url, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException(string.Format("Url can't be null or white space. Given url was: {0}", url), "url");
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException(string.Format("Username can't be null or white space. Given username was: {0}", username), "username");

            Url = url;
            Username = username;
            Password = password;
        }
    }
}
