using MeterReadingMobile.ViewModel;
using System;

using Xamarin.Forms;

namespace MeterReadingMobile.View
{
    public partial class AddEditCounterTypeView : ContentPageBase
    {
        private CounterTypeAddEditViewModel _viewModel;

        public CounterTypeAddEditViewModel ViewModel
        {
            get { return _viewModel; }
            private set { _viewModel = value; }
        }


        public AddEditCounterTypeView(CrudFlags crudFlag, Func<CounterTypeViewModel> bindData)
        {
            InitializeComponent();
            ViewModel = new CounterTypeAddEditViewModel(this.Navigation);
            ViewModel.CurrentCrudFlag = crudFlag;
            if (bindData != null)
                ViewModel.InitDataBind(bindData);

            BindingContext = ViewModel;

        }

    }
}
