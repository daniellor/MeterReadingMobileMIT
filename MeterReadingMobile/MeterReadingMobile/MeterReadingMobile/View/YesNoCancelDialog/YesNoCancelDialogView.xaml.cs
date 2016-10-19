using MeterReadingMobile.ViewModel;
using System;
using Xamarin.Forms;

namespace MeterReadingMobile.View
{
    public partial class YesNoCancelDialogView : ContentPageBase
    {
        private YesNoCancelDialogViewModel _viewModel;

        public YesNoCancelDialogViewModel ViewModel
        {
            get { return _viewModel; }
            private set { _viewModel = value; }
        }


        public YesNoCancelDialogView(string message)
        {
            InitializeComponent();
            ViewModel = new YesNoCancelDialogViewModel(this.Navigation);
            ViewModel.Message = message;
            BindingContext = ViewModel;
        }
    }
}
