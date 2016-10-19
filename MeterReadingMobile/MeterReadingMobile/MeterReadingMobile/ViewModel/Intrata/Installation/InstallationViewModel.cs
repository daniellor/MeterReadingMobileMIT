using MeterReadingMobile.WebApi.Intrata.Model;
using System;

namespace MeterReadingMobile.ViewModel.Intrata
{
    public class InstallationViewModel : ViewModelBase<InstallationBase>
    {


        public InstallationViewModel()
        {

        }
        public static InstallationViewModel Init(InstallationBase databind)
        {
            return new InstallationViewModel(databind);
        }

        public InstallationViewModel(InstallationBase dataBind)
        {
            DataDB = dataBind;

        }

        public override InstallationBase DataDB
        {
            get
            {
                return base.DataDB;
            }

            set
            {
                base.DataDB = value;
                OnPropertyChanged("Code");
                OnPropertyChanged("Name");


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

        public string Name
        {
            get { return DataDB.nazwa; }
            set
            {
                if (value != null || value != Name) DataDB.nazwa = value;
                OnPropertyChanged("Name");
            }
        }

        public string CodeAndName
        {
            get { return Code + " " + Name; }
        }




    }
}
