using MeterReadingMobile.WebApi.Intrata.Model;
using System;

namespace MeterReadingMobile.ViewModel.Intrata
{
    public class YearViewModel : ViewModelBase<YearBase>
    {


        public static YearViewModel Init(YearBase databind)
        {
            return new YearViewModel(databind);
        }

        public YearViewModel(YearBase dataBind)
        {
            DataDB = dataBind;

        }

        public override YearBase DataDB
        {
            get
            {
                return base.DataDB;
            }

            set
            {
                base.DataDB = value;
                OnPropertyChanged("Code");
                OnPropertyChanged("FromDate");
                OnPropertyChanged("ToDate");


            }
        }

        public string Code
        {
            get { return DataDB.kod; }
            set
            {
                if (value != null || value != Code) DataDB.kod = value;
                OnPropertyChanged("Code");
            }
        }

        public DateTime FromDate
        {
            get { return DataDB.oddaty; }
            set
            {
                if (value != null || value != FromDate) DataDB.oddaty = value;
                OnPropertyChanged("FromDate");
            }
        }

        public DateTime ToDate
        {
            get { return DataDB.dodaty; }
            set
            {
                if (value != null || value != ToDate) DataDB.dodaty = value;
                OnPropertyChanged("ToDate");
            }
        }




    }
}
