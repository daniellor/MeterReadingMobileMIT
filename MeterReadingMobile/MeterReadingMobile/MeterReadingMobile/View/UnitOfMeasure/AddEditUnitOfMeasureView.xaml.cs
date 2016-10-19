using MeterReadingMobile.ViewModel;
using System;

using Xamarin.Forms;

namespace MeterReadingMobile.View
{
    public partial class AddEditUnitOfMeasureView : ContentPageBase
    {
        private UnitOfMeasureAddEditViewModel _viewModel;

        public UnitOfMeasureAddEditViewModel ViewModel
        {
            get { return _viewModel; }
            private set { _viewModel = value; }
        }


        public AddEditUnitOfMeasureView(CrudFlags crudFlag, Func<UnitOfMeasureViewModel> bindData)
        {
            InitializeComponent();
            ViewModel = new UnitOfMeasureAddEditViewModel(this.Navigation);
            ViewModel.CurrentCrudFlag = crudFlag;
            if (bindData != null)
                ViewModel.InitDataBind(bindData);

            BindingContext = ViewModel;

        }

    }
}
