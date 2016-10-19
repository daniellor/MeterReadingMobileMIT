using MeterReadingMobile.ViewModel.Intrata;
using MeterReadingMobile.WebApi.Intrata;
using MeterReadingMobile.WebApi.Intrata.Model;

namespace MeterReadingMobile.View.Intrata
{
    public partial class InstallationCollectionView : ContentPageBase
    {
        private InstallationCollectionViewModel _viewModel;

        public InstallationCollectionView()
        {
            InitializeComponent();
            _viewModel = new InstallationCollectionViewModel(this.Navigation);
            BindingContext = _viewModel;
        }

        protected override async void OnRefreshDataAsync()
        {
            await _viewModel.BusyAction(async () =>
            {
                await _viewModel.InitializeWebApiAsync(new InstallationBase(), ApiServices.Installation());
            });

        }

    }
}
