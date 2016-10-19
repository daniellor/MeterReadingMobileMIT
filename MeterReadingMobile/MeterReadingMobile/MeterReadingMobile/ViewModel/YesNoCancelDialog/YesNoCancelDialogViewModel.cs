using MeterReadingMobile.WebApi.Intrata.Model;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class YesNoCancelDialogViewModel : ViewModelBase<ModelBase>
    {


        public YesNoCancelDialogViewModel(INavigation navigate) : base(navigate)
        {
            CancelCommand = new Command(OnCancel);
            YesCommand = new Command(OnYes);
            NoCommand = new Command(OnNo);


        }
        #region properties

        // ICommand implementations
        public ICommand CancelCommand { protected set; get; }

        public ICommand YesCommand { protected set; get; }

        public ICommand NoCommand { protected set; get; }



        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (value != null || value != _message) _message = value;
                OnPropertyChanged("Message");
            }
        }


        #endregion

        #region events
        private void OnYes()
        {
            if (YesSucceeded != null)
            {
                YesSucceeded(this, EventArgs.Empty);
            }
            NavigateTo.PopAsync();

        }

        public event EventHandler YesSucceeded;


        private void OnNo()
        {
            if (NoSucceeded != null)
            {
                NoSucceeded(this, EventArgs.Empty);
            }
            NavigateTo.PopAsync();
        }

        public event EventHandler NoSucceeded;


        private void OnCancel()
        {
            if (CancelSucceeded != null)
            {
                CancelSucceeded(this, EventArgs.Empty);
            }
            NavigateTo.PopAsync();
        }

        public event EventHandler CancelSucceeded;

        #endregion


    }
}
