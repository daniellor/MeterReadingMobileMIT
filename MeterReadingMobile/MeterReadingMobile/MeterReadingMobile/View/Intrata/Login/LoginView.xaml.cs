using MeterReadingMobile.Utils;
using MeterReadingMobile.ViewModel.Intrata;
using Xamarin.Forms;

namespace MeterReadingMobile.View.Intrata
{
    public partial class LoginView : ContentPage
    {
        private LoginViewModel _viewModel;

        public LoginView()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel(this.Navigation);


            BindingContext = _viewModel;
            this.AddProgressDisplay();
            _viewModel.InitializeAsync().ContinueWith(_ =>
            {
                _viewModel.IsBusy = false;
            });


        }



    }
}
