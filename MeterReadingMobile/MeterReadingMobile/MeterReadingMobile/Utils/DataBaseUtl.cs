using MeterReadingMobile.Provider;
using System;

namespace MeterReadingMobile.Utils
{
    public static class DataBaseUtl
    {

        public static OpenDbResult OpenDb(Action<IDBConnector> actionDB)
        {
            return new OpenDbResult(actionDB);
        }
        public static OpenDbResult WhenConcurrencyError(this OpenDbResult result, Action errorEvent)
        {
            result.OnConcurrencyError = errorEvent;
            return result;
        }
        public static OpenDbResult WhenError(this OpenDbResult result, Action<Exception> errorEvent)
        {
            result.OnError = errorEvent;
            return result;
        }
        public static OpenDbResult ExecuteQuery(this OpenDbResult result)
        {
            result.Execute();
            return result;
        }



    }
}
