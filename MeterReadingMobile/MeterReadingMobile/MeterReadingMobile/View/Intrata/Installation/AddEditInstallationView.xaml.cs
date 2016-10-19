using MeterReadingMobile.ViewModel.Intrata;
using System;
using Xamarin.Forms;

namespace MeterReadingMobile.View.Intrata
{
    public partial class AddEditInstallationView : ContentPageBase
    {
        private InstallationAddEditViewModel _viewModel;

        public InstallationAddEditViewModel ViewModel
        {
            get { return _viewModel; }
            private set { _viewModel = value; }
        }


        public AddEditInstallationView(CrudFlags crudFlag, Func<InstallationViewModel> bindData)
        {
            InitializeComponent();
            ViewModel = new InstallationAddEditViewModel(this.Navigation);
            ViewModel.CurrentCrudFlag = crudFlag;
            if (bindData != null)
                ViewModel.InitDataBind(bindData);

            BindingContext = ViewModel;

        }






    }
}
