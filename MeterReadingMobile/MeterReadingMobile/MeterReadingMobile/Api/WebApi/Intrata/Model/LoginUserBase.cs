using System;

namespace MeterReadingMobile.WebApi.Intrata.Model
{
    public class LoginUserBase : ModelBase
    {

        public LoginUserBase() { }
        public LoginUserBase(string urlstring)
        {
            url = new Uri(urlstring);
        }
        public Uri url { get; set; }
        public string loginname { get; set; }
        public string password { get; set; }

        public string token { get; set; }

        public int year { get; set; }
        public int install { get; set; }
    }
}
