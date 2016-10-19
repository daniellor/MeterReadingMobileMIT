using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.ViewModel;
using System.Linq;

namespace MeterReadingMobile.View
{
    public partial class CounterSubTypeCollectionView : ContentPageBase
    {
        private CounterSubTypeCollectionViewModel _viewModel;

        public CounterSubTypeCollectionViewModel ViewModel
        {
            get { return _viewModel; }
            private set { _viewModel = value; }
        }


        public CounterSubTypeCollectionView(CounterTypeViewModel dataMaster)
        {
            InitializeComponent();
            ViewModel = new CounterSubTypeCollectionViewModel(this.Navigation, dataMaster);
            BindingContext = ViewModel;
        }

        protected override void OnRefreshData()
        {
            base.OnRefreshData();
            DataBaseUtl.OpenDb(db =>
            {
                ViewModel.Initialize(db.GetItems<db_CounterSubType>().Where(o => o.countertypeid == ViewModel.CounterType.DataDB.id));
            }).ExecuteQuery();


        }

    }




}
