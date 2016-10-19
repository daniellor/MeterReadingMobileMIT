namespace MeterReadingMobile
{
    public interface IJsonStream
    {
        bool FileExists(string filename);
        T Load<T>(string jsonFileName);
        void Save<T>(string jsonFileName, T collection);
    }
}
