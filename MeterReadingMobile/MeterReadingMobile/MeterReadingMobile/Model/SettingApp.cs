using System;
using Xamarin.Forms;

namespace MeterReadingMobile.Model
{
    public class SettingApp
    {
        public string DatabaseName { get; set; }
        public string IntrataApiServer { get; set; }

        public static SettingApp Load(string filename)
        {
            if (!DependencyService.Get<IJsonStream>().FileExists(filename))
            {
                DependencyService.Get<IJsonStream>().Save(filename, DefaultSettings());
            }
            return DependencyService.Get<IJsonStream>().Load<SettingApp>(filename);
        }
        public static void Save(string filename, SettingApp settings)
        {
            DependencyService.Get<IJsonStream>().Save(filename, settings);
        }
        private static SettingApp DefaultSettings()
        {
            return new SettingApp()
            {
                DatabaseName = string.Format("MeterReading{0}.db3", DateTime.Now.ToString("yyyyMMddHHmmss")),
                IntrataApiServer = "http://127.0.0.1:8080",
            };

        }
    }
}

