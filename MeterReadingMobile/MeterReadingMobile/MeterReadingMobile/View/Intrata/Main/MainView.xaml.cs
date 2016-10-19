using System;
using Xamarin.Forms;

namespace MeterReadingMobile.View.Intrata
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            Command<Type> navigateCommand =
               new Command<Type>(async (Type pageType) =>
               {
                   Page page = (Page)Activator.CreateInstance(pageType);
                   await this.Navigation.PushAsync(page);
               });


            this.Content = new TableView
            {
                Intent = TableIntent.Menu,
                Root = new TableRoot
                    {
                        new TableSection("Main")
                        {

                            new TextCell
                            {
                                Text = "Login",
                                Command = navigateCommand,
                                CommandParameter = typeof(LoginView)
                            },
                             new TextCell
                            {
                                Text = "Installations",
                                Command = navigateCommand,
                                CommandParameter = typeof(InstallationCollectionView)
                            },
                        }

                    }
            };

        }


    }
}
