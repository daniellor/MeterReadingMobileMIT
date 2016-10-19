using System;

namespace MeterReadingMobile.WebApi.Intrata.Model
{
    public class ResponseModel
    {
        public ResponseModel() { }

        public string message { get; set; }
        public string errorDesc { get; set; }

        public bool isError { get { return !String.IsNullOrWhiteSpace(errorDesc); } }

    }
}
