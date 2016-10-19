using System.IO;
using Xamarin.Forms;
using MeterReadingMobile.Droid;

[assembly: Dependency(typeof(SQLite_Droid))]

namespace MeterReadingMobile.Droid
{
    public class SQLite_Droid : ISQLite
    {
        public SQLite_Droid()
        {
        }

        #region ISQLite implementation

        public SQLite.SQLiteConnection GetConnection(string sqliteFilename)
        {
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), sqliteFilename);
            return new SQLite.SQLiteConnection(path);
        }
        public bool DatabaseExists(string filenamedb)
        {
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filenamedb);

            return File.Exists(path);
        }

        #endregion


    }
}