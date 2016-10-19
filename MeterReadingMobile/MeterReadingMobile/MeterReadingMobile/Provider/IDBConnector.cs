using System.Collections.Generic;
using MeterReadingMobile.Model;
using SQLite;
using System.Linq;

namespace MeterReadingMobile.Provider
{
    public interface IDBConnector
    {
        void CreateTables();
        int DeleteItem<TEntity>(TEntity entity) where TEntity : IEntityBase, new();
        TEntity GetItem<TEntity>(TEntity entity) where TEntity : IEntityBase, new();
        IQueryable<TEntity> GetItems<TEntity>() where TEntity : IEntityBase, new();
        SQLiteConnection Open();
        void Disconnect();
        int SaveItem<TEntity>(TEntity entity) where TEntity : IEntityBase, new();
    }
}