using MeterReadingMobile.ViewModel;
using System;

using Xamarin.Forms;

namespace MeterReadingMobile.View
{
    public partial class AddEditCounterSubTypeView : ContentPageBase
    {
        private CounterSubTypeAddEditViewModel _viewModel;

        public CounterSubTypeAddEditViewModel ViewModel
        {
            get { return _viewModel; }
            private set { _viewModel = value; }
        }


        public AddEditCounterSubTypeView(CrudFlags crudFlag, Func<CounterSubTypeViewModel> bindData, CounterTypeViewModel dataMaster)
        {
            InitializeComponent();
            ViewModel = new CounterSubTypeAddEditViewModel(this.Navigation, dataMaster);
            ViewModel.CurrentCrudFlag = crudFlag;
            if (bindData != null)
                ViewModel.InitDataBind(bindData);

            BindingContext = ViewModel;

        }

    }
}
