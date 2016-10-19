using MeterReadingMobile.UWP;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace MeterReadingMobile.UWP
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP()
        {
        }
        #region ISQLite implementation
        public SQLite.SQLiteConnection GetConnection(string sqliteFilename)
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            return new SQLite.SQLiteConnection(path);
        }
        public bool DatabaseExists(string filenamedb)
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, filenamedb);

            return File.Exists(path);
        }
        #endregion
    }
}
