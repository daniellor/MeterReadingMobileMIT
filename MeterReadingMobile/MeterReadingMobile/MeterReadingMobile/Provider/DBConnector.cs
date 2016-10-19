using MeterReadingMobile.Model;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MeterReadingMobile.Provider
{
    public partial class DBConnector : IDBConnector
    {
        static object _locker = new object();

        SQLiteConnection _database;
        string _databasePath;

        public DBConnector(string databasePath)
        {
            _databasePath = databasePath;
        }

        public static DBConnector Initialize()
        {
            return Initialize(((App)App.Current).SettingApp.DatabaseName);
        }
        public static DBConnector Initialize(string databasename)
        {
            return new DBConnector(databasename);
        }
        public SQLiteConnection Open()
        {

            lock (_locker)
            {
                if (!DependencyService.Get<ISQLite>().DatabaseExists(_databasePath))
                {
                    _database = DependencyService.Get<ISQLite>().GetConnection(_databasePath);
                    CreateTables();
                    return _database;
                }
                return _database = DependencyService.Get<ISQLite>().GetConnection(_databasePath);
            }
        }

        public void Disconnect()
        {
            _database.Close();
        }

        public TEntity GetItem<TEntity>(TEntity entity) where TEntity : IEntityBase, new()
        {
            lock (_locker)
            {
                return _database.Table<TEntity>().FirstOrDefault(x => x.id == entity.id);
            }
        }

        public int SaveItem<TEntity>(TEntity entity) where TEntity : IEntityBase, new()
        {
            lock (_locker)
            {
                if (entity.id != 0)
                {
                    entity.rowversion = entity.rowversion + 1;
                    return _database.Update(entity);
                }
                else
                {
                    return _database.Insert(entity);
                }
            }
        }

        public int DeleteItem<TEntity>(TEntity entity) where TEntity : IEntityBase, new()
        {
            lock (_locker)
            {
                return _database.Delete<TEntity>(entity.id);
            }
        }
        public IQueryable<TEntity> GetItems<TEntity>() where TEntity : IEntityBase, new()
        {
            lock (_locker)
            {
                return (from i in _database.Table<TEntity>() select i).AsQueryable<TEntity>();
            }
        }


    }
}
