using MeterReadingMobile.WebApi.Intrata.Model;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel.Intrata
{
    public class InstallationAddEditViewModel : ViewModelAddEdit<InstallationBase, InstallationViewModel>
    {
        public ICommand SaveCommand { get; private set; }

        public InstallationAddEditViewModel(INavigation navigate) : base(navigate)
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
                    ((InstallationViewModel)this.DataBind).Code = value;
                    OnPropertyChanged("Code");

                }
            }
        }

        public virtual string Name
        {
            get { return this.DataBind.Name; }
            set
            {
                if (this.Name != value)
                {
                    if (value == string.Empty)
                        value = null;
                    ((InstallationViewModel)this.DataBind).Name = value;
                    OnPropertyChanged("Name");

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
