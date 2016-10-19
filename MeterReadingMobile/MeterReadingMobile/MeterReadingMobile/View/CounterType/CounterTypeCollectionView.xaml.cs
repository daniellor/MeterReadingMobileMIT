using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.ViewModel;

namespace MeterReadingMobile.View
{
    public partial class CounterTypeCollectionView : ContentPageBase
    {
        private CounterTypeCollectionViewModel _viewModel;

        public CounterTypeCollectionView()
        {
            InitializeComponent();
            _viewModel = new CounterTypeCollectionViewModel(this.Navigation);

            BindingContext = _viewModel;
        }

        protected override void OnRefreshData()
        {
            base.OnRefreshData();
            DataBaseUtl.OpenDb(db =>
            {
                _viewModel.Initialize(db.GetItems<db_CounterType>());
            }).ExecuteQuery();

        }
    }




}
