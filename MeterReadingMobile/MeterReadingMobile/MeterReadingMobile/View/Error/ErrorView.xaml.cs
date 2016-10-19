using MeterReadingMobile.ViewModel;

namespace MeterReadingMobile.View
{
    public partial class ErrorView : ContentPageBase
    {
        private ErrorViewModel _viewModel;

        public ErrorView(string errorDesc)
        {
            InitializeComponent();
            _viewModel = new ErrorViewModel(this.Navigation);
            _viewModel.ErrorDesc = errorDesc;
            BindingContext = _viewModel;
        }
    }
}
