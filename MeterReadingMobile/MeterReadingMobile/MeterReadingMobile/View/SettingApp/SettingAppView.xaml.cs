using MeterReadingMobile.Model;
using System;

using Xamarin.Forms;

namespace MeterReadingMobile.View
{
    public partial class SettingAppView : ContentPage
    {
        public SettingAppView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = ((App)App.Current).SettingApp;
        }
        void saveClicked(object sender, EventArgs e)
        {
            var settingApp = (SettingApp)BindingContext;
            SettingApp.Save(((App)App.Current).DefaultConfigFileName, settingApp);
            this.Navigation.PopAsync();
        }



        void cancelClicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

    }
}
