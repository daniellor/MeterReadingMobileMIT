using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.ViewModel;

namespace MeterReadingMobile.View
{
    public partial class PropertyCollectionView : ContentPageBase
    {
        private PropertyCollectionViewModel _viewModel;

        public PropertyCollectionView()
        {
            InitializeComponent();
            _viewModel = new PropertyCollectionViewModel(this.Navigation);

            BindingContext = _viewModel;
        }

        protected override void OnRefreshData()
        {
            base.OnRefreshData();
            DataBaseUtl.OpenDb(db =>
            {
                _viewModel.Initialize(db.GetItems<db_Property>());
            }).ExecuteQuery();

        }
    }




}
