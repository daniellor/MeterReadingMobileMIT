using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class ViewModelBase<T> : INotifyPropertyChanged

    {
        public virtual T DataDB { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
		/// Event for when IsBusy changes
		/// </summary>
		public event EventHandler IsBusyChanged;

        public ViewModelBase()
        {

        }

        public ViewModelBase(INavigation navigateTo)
        {
            NavigateTo = navigateTo;
        }


        public INavigation NavigateTo { protected set; get; }


        bool _isBusy = false;

        /// <summary>
		/// Value indicating if a spinner should be shown
		/// </summary>
		public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;

                    OnPropertyChanged("IsBusy");
                    OnIsBusyChanged();
                }
            }
        }

        /// <summary>
        /// Other viewmodels can override this if something should be done when busy
        /// </summary>
        protected virtual void OnIsBusyChanged()
        {
            var ev = IsBusyChanged;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            var ev = PropertyChanged;
            if (ev != null)
            {
                ev(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
