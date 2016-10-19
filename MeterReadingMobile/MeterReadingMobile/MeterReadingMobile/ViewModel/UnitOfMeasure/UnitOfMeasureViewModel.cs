using MeterReadingMobile.Model;

namespace MeterReadingMobile.ViewModel
{
    public class UnitOfMeasureViewModel : ViewModelBase<db_UnitOfMeasure>
    {


        public UnitOfMeasureViewModel()
        {

        }
        public static UnitOfMeasureViewModel Init(db_UnitOfMeasure databind)
        {
            return new UnitOfMeasureViewModel(databind);
        }

        public UnitOfMeasureViewModel(db_UnitOfMeasure dataBind)
        {
            DataDB = dataBind;

        }

        public override db_UnitOfMeasure DataDB
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
