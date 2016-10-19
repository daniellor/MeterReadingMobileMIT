using MeterReadingMobile.Model;

namespace MeterReadingMobile.ViewModel
{
    public class CounterSubTypeViewModel : ViewModelBase<db_CounterSubType>
    {


        public CounterSubTypeViewModel()
        {

        }
        public static CounterSubTypeViewModel Init(db_CounterSubType databind)
        {
            return new CounterSubTypeViewModel(databind);
        }

        public CounterSubTypeViewModel(db_CounterSubType dataBind)
        {
            DataDB = dataBind;

        }

        public override db_CounterSubType DataDB
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
