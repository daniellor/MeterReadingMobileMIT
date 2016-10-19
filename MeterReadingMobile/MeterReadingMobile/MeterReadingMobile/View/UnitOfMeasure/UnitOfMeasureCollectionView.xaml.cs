using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.ViewModel;

namespace MeterReadingMobile.View
{
    public partial class UnitOfMeasureCollectionView : ContentPageBase
    {
        private UnitOfMeasureCollectionViewModel _viewModel;

        public UnitOfMeasureCollectionView()
        {
            InitializeComponent();
            _viewModel = new UnitOfMeasureCollectionViewModel(this.Navigation);
            BindingContext = _viewModel;
        }
        protected override void OnRefreshData()
        {
            base.OnRefreshData();
            DataBaseUtl.OpenDb(db =>
            {
                _viewModel.Initialize(db.GetItems<db_UnitOfMeasure>());
            }
                          ).ExecuteQuery();

        }

    }




}
