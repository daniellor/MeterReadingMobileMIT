using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.ViewModel;

namespace MeterReadingMobile.View
{
    public partial class LocationCollectionView : ContentPageBase
    {
        private LocationCollectionViewModel _viewModel;

        public LocationCollectionView()
        {
            InitializeComponent();
            _viewModel = new LocationCollectionViewModel(this.Navigation);
            BindingContext = _viewModel;
        }
        protected override void OnRefreshData()
        {
            base.OnRefreshData();
            DataBaseUtl.OpenDb(db =>
            {
                _viewModel.Initialize(db.GetItems<db_Location>());
            }
                          ).ExecuteQuery();

        }

    }




}
