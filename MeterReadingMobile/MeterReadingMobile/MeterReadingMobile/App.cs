using MeterReadingMobile.Model;
using MeterReadingMobile.View;
using MeterReadingMobile.WebApi.Intrata;
using Xamarin.Forms;

namespace MeterReadingMobile
{
    public class App : Application
    {
        public App()
        {
            var nav = new NavigationPage(new MainPageView());

            MainPage = nav;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private SettingApp _settingApp;

        public SettingApp SettingApp
        {
            get
            {
                if (_settingApp == null)
                {

                    _settingApp = SettingApp.Load(this.DefaultConfigFileName);
                }
                return _settingApp;
            }
        }
        public string DefaultConfigFileName
        {
            get
            {
                return "MeterReadingMobile.Config.json";
            }
        }

        public IntrataApiClient CurrentIntrataApiClient { get; set; }
    }
}
