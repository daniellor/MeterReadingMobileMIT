using MeterReadingMobile.Model;

namespace MeterReadingMobile.ViewModel
{
    public class PropertyViewModel : ViewModelBase<db_Property>
    {


        public PropertyViewModel()
        {

        }
        public static PropertyViewModel Init(db_Property databind)
        {
            return new PropertyViewModel(databind);
        }

        public PropertyViewModel(db_Property dataBind)
        {
            DataDB = dataBind;

        }

        public override db_Property DataDB
        {
            get
            {
                return base.DataDB;
            }

            set
            {
                base.DataDB = value;
                OnPropertyChanged("Code");
                OnPropertyChanged("ShortName");
                OnPropertyChanged("Name1");
                OnPropertyChanged("Name2");
                OnPropertyChanged("Name3");
                OnPropertyChanged("Name4");
                OnPropertyChanged("Name5");
                OnPropertyChanged("Street");
                OnPropertyChanged("HouseNumber");
                OnPropertyChanged("ApartmentNumber");



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

        public string ShortName
        {
            get { return DataDB.shortname; }
            set
            {
                if (value != null || value != ShortName) DataDB.shortname = value;
                OnPropertyChanged("ShortName");
            }
        }

        public string Name1
        {
            get { return DataDB.name1; }
            set
            {
                if (value != null || value != Name1) DataDB.name1 = value;
                OnPropertyChanged("Name1");
            }
        }

        public string Name2
        {
            get { return DataDB.name2; }
            set
            {
                if (value != null || value != Name2) DataDB.name2 = value;
                OnPropertyChanged("Name2");
            }
        }

        public string Name3
        {
            get { return DataDB.name3; }
            set
            {
                if (value != null || value != Name3) DataDB.name3 = value;
                OnPropertyChanged("Name3");
            }
        }

        public string Name4
        {
            get { return DataDB.name4; }
            set
            {
                if (value != null || value != Name4) DataDB.name4 = value;
                OnPropertyChanged("Name4");
            }
        }

        public string Name5
        {
            get { return DataDB.name5; }
            set
            {
                if (value != null || value != Name5) DataDB.name5 = value;
                OnPropertyChanged("Name1");
            }
        }

        public string Street
        {
            get { return DataDB.street; }
            set
            {
                if (value != null || value != Street) DataDB.street = value;
                OnPropertyChanged("Street");
            }
        }
        public string HouseNumber
        {
            get { return DataDB.housenumber; }
            set
            {
                if (value != null || value != HouseNumber) DataDB.housenumber = value;
                OnPropertyChanged("HouseNumber");
            }
        }
        public string ApartmentNumber
        {
            get { return DataDB.apartmentnumber; }
            set
            {
                if (value != null || value != ApartmentNumber) DataDB.apartmentnumber = value;
                OnPropertyChanged("ApartmentNumber");
            }
        }


    }
}
