using MeterReadingMobile;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(JsonStream_Droid))]
public class JsonStream_Droid : IJsonStream
{
    public JsonStream_Droid()
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
        return Path.Combine(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename));
    }
    public bool FileExists(string filename)
    {
        return File.Exists(FilePath(filename));
    }

    #endregion
}