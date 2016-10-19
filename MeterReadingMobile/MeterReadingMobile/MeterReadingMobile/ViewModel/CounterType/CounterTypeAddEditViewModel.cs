﻿using MeterReadingMobile.Model;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class CounterTypeAddEditViewModel : ViewModelAddEdit<db_CounterType, CounterTypeViewModel>
    {
        public ICommand SaveCommand { get; private set; }

        public CounterTypeAddEditViewModel(INavigation navigate) : base(navigate)
        {
            SaveCommand = new Command(OnSave);
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
                    ((CounterTypeViewModel)this.DataBind).Code = value;
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
                    ((CounterTypeViewModel)this.DataBind).Description = value;
                    OnPropertyChanged("Description");

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
