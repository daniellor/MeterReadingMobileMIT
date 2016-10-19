using MeterReadingMobile.ViewModel;
using System;

using Xamarin.Forms;

namespace MeterReadingMobile.View
{
    public partial class AddEditPropertyView : ContentPageBase
    {
        private PropertyAddEditViewModel _viewModel;

        public PropertyAddEditViewModel ViewModel
        {
            get { return _viewModel; }
            private set { _viewModel = value; }
        }


        public AddEditPropertyView(CrudFlags crudFlag, Func<PropertyViewModel> bindData)
        {
            InitializeComponent();
            ViewModel = new PropertyAddEditViewModel(this.Navigation);
            ViewModel.CurrentCrudFlag = crudFlag;
            if (bindData != null)
                ViewModel.InitDataBind(bindData);

            BindingContext = ViewModel;

        }

    }
}
