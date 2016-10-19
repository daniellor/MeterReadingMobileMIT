using MeterReadingMobile.Model;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class CounterSubTypeAddEditViewModel : ViewModelAddEdit<db_CounterSubType, CounterSubTypeViewModel>
    {
        public ICommand SaveCommand { get; private set; }


        public CounterSubTypeAddEditViewModel(INavigation navigate, CounterTypeViewModel counterType) : base(navigate)
        {
            SaveCommand = new Command(OnSave);
            CounterType = counterType;
        }
        public virtual string Code
        {
            get { return this.DataBind.Code; }
            set
            {
                if (this.Code != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((CounterSubTypeViewModel)this.DataBind).Code = value;
                    OnPropertyChanged("Code");

                }
            }
        }

        public virtual string Description
        {
            get { return this.DataBind.Description; }
            set
            {
                if (this.Description != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((CounterSubTypeViewModel)this.DataBind).Description = value;
                    OnPropertyChanged("Description");

                }
            }
        }

        private CounterTypeViewModel _counterType;
        public virtual CounterTypeViewModel CounterType
        {
            get { return _counterType; }
            set
            {
                if (this.CounterType != value)
                {
                    _counterType = value;
                    OnPropertyChanged("CounterType");

                }
            }
        }

        #region events
        private void OnSave()
        {
            if (SaveSucceeded != null)
            {
                SaveSucceeded(this, EventArgs.Empty);
                NavigateTo.PopAsync();
            }
        }

        public event EventHandler SaveSucceeded;
        #endregion

    }
}
