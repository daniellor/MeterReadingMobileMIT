using MeterReadingMobile.Provider;
using System;

namespace MeterReadingMobile.Utils
{
    public class OpenDbResult : OpenDbResultBase
    {
        private Action<IDBConnector> _actionDB;

        public OpenDbResult(Action<IDBConnector> actionDB)
        {
            this._actionDB = actionDB;
        }
        public void Execute()
        {
            IDBConnector db = null;
            try
            {
                db = DBConnector.Initialize();
                db.Open();
                _actionDB(db);
            }
            catch (Exception ex)
            {
                if (OnError != null)
                    OnError(ex);
            }
            finally
            {
                if (db != null)
                    db.Disconnect();
            };
        }
    }
}
