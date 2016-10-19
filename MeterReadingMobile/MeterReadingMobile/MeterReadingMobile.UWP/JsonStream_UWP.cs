using MeterReadingMobile.UWP;
using Newtonsoft.Json;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(JsonStream_UWP))]

namespace MeterReadingMobile.UWP
{
    public class JsonStream_UWP : IJsonStream
    {
        public JsonStream_UWP()
        {
        }

        #region ISettingApp implementation
        public T Load<T>(string jsonFileName)
        {

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(FilePath(jsonFileName)));
        }
        public void Save<T>(string jsonFileName, T settings)
        {
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(FilePath(jsonFileName), json);

        }

        private string FilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
        public bool FileExists(string filename)
        {
            return File.Exists(FilePath(filename));
        }

        #endregion
    }
}
