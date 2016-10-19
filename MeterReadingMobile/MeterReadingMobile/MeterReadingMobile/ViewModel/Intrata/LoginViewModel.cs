using MeterReadingMobile.Utils;
using MeterReadingMobile.WebApi.Intrata;
using MeterReadingMobile.WebApi.Intrata.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MeterReadingMobile.View;

namespace MeterReadingMobile.ViewModel.Intrata
{
    public class LoginViewModel : ViewModelBase<LoginUserBase>
    {


        public LoginViewModel(INavigation navigate) : base(navigate)
        {
            LogInCommand = new Command(async () =>
            {
                bool loginStatus = await LoginAsync();
                if (!loginStatus)
                {

                    await NavigateTo.PushAsync(new ErrorView("Access danied"));
                }
                else
                    await NavigateTo.PopAsync();
            });

        }
        #region properties

        public ICommand LogInCommand { protected set; get; }

        private ObservableCollection<InstallationViewModel> _Installations;
        public ObservableCollection<InstallationViewModel> Installations
        {
            get { return _Installations; }
            set
            {
                if (value != null || value != _Installations) _Installations = value;
                OnPropertyChanged("Installations");
                OnPropertyChanged("CanLogin");
            }
        }


        private InstallationViewModel _SelectedInstallation;
        public InstallationViewModel SelectedInstallation
        {
            get { return _SelectedInstallation; }
            set
            {
                if (value != null || value != _SelectedInstallation) _SelectedInstallation = value;
                OnPropertyChanged("SelectedInstallation");
                OnPropertyChanged("CanLogin");
                IsBusy = true;
                YearsChangeAsync().ContinueWith(r => { IsBusy = false; });
            }
        }

        private ObservableCollection<YearViewModel> _Years;
        public ObservableCollection<YearViewModel> Years
        {
            get { return _Years; }
            set
            {
                if (value != null || value != _Years) _Years = value;
                OnPropertyChanged("Years");
                OnPropertyChanged("CanLogin");
            }
        }


        private YearViewModel _SelectedYear;
        public YearViewModel SelectedYear
        {
            get { return _SelectedYear; }
            set
            {
                if (value != null || value != _SelectedYear) _SelectedYear = value;
                OnPropertyChanged("SelectedYear");
                OnPropertyChanged("CanLogin");
            }
        }

        private string _User;
        public string User
        {
            get { return _User; }
            set
            {
                if (value != null || value != _User) _User = value;
                OnPropertyChanged("User");
                OnPropertyChanged("CanLogin");
            }
        }


        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if (value != null || value != _Password) _Password = value;
                OnPropertyChanged("Password");
                OnPropertyChanged("CanLogin");
            }
        }
        public bool CanLogin { get { return !string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Password) && SelectedInstallation != null && SelectedYear != null; } }

        #endregion

        #region methods
        public async Task InitializeAsync()
        {
            if (((App)App.Current).CurrentIntrataApiClient == null && ((App)App.Current).SettingApp.IntrataApiServer != null)
            {
                ((App)App.Current).CurrentIntrataApiClient = new IntrataApiClient(((App)App.Current).SettingApp.IntrataApiServer);
            }

            var api = ((App)App.Current).CurrentIntrataApiClient;
            List<InstallationBase> linstalls = await api.GetCollectionsAsync<InstallationBase>(null, ApiServices.ApiInstallation(), false, "", RestSharp.Portable.Method.GET);
            Installations = new ObservableCollection<InstallationViewModel>(linstalls.Select(e => new InstallationViewModel(e)));

        }

        public async Task YearsChangeAsync()
        {

            var api = ((App)App.Current).CurrentIntrataApiClient;
            YearBase filter = new YearBase() { instalacjaid = SelectedInstallation.DataDB.id };
            List<YearBase> years = await api.GetCollectionsAsync<YearBase>(filter, ApiServices.ApiInstallationYears(), false, "");
            Years = new ObservableCollection<YearViewModel>(years.Select(e => new YearViewModel(e)));
        }



        public async Task<bool> LoginAsync()
        {
            IsBusy = true;

            LoginUserBase login = new LoginUserBase(((App)App.Current).SettingApp.IntrataApiServer);

            login.loginname = User;
            login.password = CryptoUtil.Sha1Hash(Password);
            login.install = SelectedInstallation.DataDB.id;
            login.year = SelectedYear.DataDB.id;

            ((App)App.Current).CurrentIntrataApiClient = new IntrataApiClient(login);

            var status = await ((App)App.Current).CurrentIntrataApiClient.AreCredentialsValidAsync();
            IsBusy = false;
            return status;

        }
        #endregion

    }
}
