using MeterReadingMobile.Model;

namespace MeterReadingMobile.ViewModel
{
    public class CounterTypeViewModel : ViewModelBase<db_CounterType>
    {


        public CounterTypeViewModel()
        {

        }
        public static CounterTypeViewModel Init(db_CounterType databind)
        {
            return new CounterTypeViewModel(databind);
        }

        public CounterTypeViewModel(db_CounterType dataBind)
        {
            DataDB = dataBind;

        }

        public override db_CounterType DataDB
        {
            get
            {
                return base.DataDB;
            }

            set
            {
                base.DataDB = value;
                OnPropertyChanged("Code");
                OnPropertyChanged("Description");


            }
        }

        public string Code
        {
            get { return DataDB.code; }
            set
            {
                if (value != null || value != Code) DataDB.code = value;
                OnPropertyChanged("Code");
            }
        }

        public string Description
        {
            get { return DataDB.description; }
            set
            {
                if (value != null || value != Description) DataDB.description = value;
                OnPropertyChanged("Description");
            }
        }





    }
}
