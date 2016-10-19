using MeterReadingMobile.ViewModel;
using System;

using Xamarin.Forms;

namespace MeterReadingMobile.View
{
    public partial class AddEditLocationView : ContentPageBase
    {
        private LocationAddEditViewModel _viewModel;

        public LocationAddEditViewModel ViewModel
        {
            get { return _viewModel; }
            private set { _viewModel = value; }
        }


        public AddEditLocationView(CrudFlags crudFlag, Func<LocationViewModel> bindData)
        {
            InitializeComponent();
            ViewModel = new LocationAddEditViewModel(this.Navigation);
            ViewModel.CurrentCrudFlag = crudFlag;
            if (bindData != null)
                ViewModel.InitDataBind(bindData);

            BindingContext = ViewModel;

        }

    }
}
