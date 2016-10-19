using MeterReadingMobile.Model;

namespace MeterReadingMobile.ViewModel
{
    public class LocationViewModel : ViewModelBase<db_Location>
    {


        public LocationViewModel()
        {

        }
        public static LocationViewModel Init(db_Location databind)
        {
            return new LocationViewModel(databind);
        }

        public LocationViewModel(db_Location dataBind)
        {
            DataDB = dataBind;

        }

        public override db_Location DataDB
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
