using MeterReadingMobile.Model;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class PropertyAddEditViewModel : ViewModelAddEdit<db_Property, PropertyViewModel>
    {
        public ICommand SaveCommand { get; private set; }

        public PropertyAddEditViewModel(INavigation navigate) : base(navigate)
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
                    ((PropertyViewModel)this.DataBind).Code = value;
                    OnPropertyChanged("Code");

                }
            }
        }

        public virtual string ShortName
        {
            get { return this.DataBind.ShortName; }
            set
            {
                if (this.ShortName != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((PropertyViewModel)this.DataBind).ShortName = value;
                    OnPropertyChanged("ShortName");

                }
            }
        }
        public virtual string Name1
        {
            get { return this.DataBind.Name1; }
            set
            {
                if (this.Name1 != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((PropertyViewModel)this.DataBind).Name1 = value;
                    OnPropertyChanged("Name1");

                }
            }
        }

        public virtual string Name2
        {
            get { return this.DataBind.Name2; }
            set
            {
                if (this.Name2 != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((PropertyViewModel)this.DataBind).Name2 = value;
                    OnPropertyChanged("Name2");

                }
            }
        }

        public virtual string Name3
        {
            get { return this.DataBind.Name3; }
            set
            {
                if (this.Name3 != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((PropertyViewModel)this.DataBind).Name3 = value;
                    OnPropertyChanged("Name3");

                }
            }
        }

        public virtual string Name4
        {
            get { return this.DataBind.Name4; }
            set
            {
                if (this.Name4 != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((PropertyViewModel)this.DataBind).Name4 = value;
                    OnPropertyChanged("Name4");

                }
            }
        }

        public virtual string Name5
        {
            get { return this.DataBind.Name5; }
            set
            {
                if (this.Name5 != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((PropertyViewModel)this.DataBind).Name5 = value;
                    OnPropertyChanged("Name5");

                }
            }
        }

        public virtual string Street
        {
            get { return this.DataBind.Street; }
            set
            {
                if (this.Street != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((PropertyViewModel)this.DataBind).Street = value;
                    OnPropertyChanged("Street");

                }
            }
        }

        public virtual string HouseNumber
        {
            get { return this.DataBind.HouseNumber; }
            set
            {
                if (this.HouseNumber != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((PropertyViewModel)this.DataBind).HouseNumber = value;
                    OnPropertyChanged("HouseNumber");

                }
            }
        }

        public virtual string ApartmentNumber
        {
            get { return this.DataBind.ApartmentNumber; }
            set
            {
                if (this.ApartmentNumber != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((PropertyViewModel)this.DataBind).ApartmentNumber = value;
                    OnPropertyChanged("ApartmentNumber");

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
