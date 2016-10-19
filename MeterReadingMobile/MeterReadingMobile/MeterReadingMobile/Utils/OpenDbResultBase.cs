using System;

namespace MeterReadingMobile.Utils
{
    public class OpenDbResultBase
    {
        protected Action<Exception> _onError;

        public Action<Exception> OnError
        {
            get { return _onError; }
            set { _onError = value; }
        }

        protected Action _onConcurrencyError;

        public Action OnConcurrencyError
        {
            get { return _onConcurrencyError; }
            set { _onConcurrencyError = value; }
        }
    }
}
