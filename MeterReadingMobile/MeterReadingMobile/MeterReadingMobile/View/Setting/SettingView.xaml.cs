using System;
using Xamarin.Forms;

namespace MeterReadingMobile.View
{
    public partial class SettingView : ContentPage
    {
        public SettingView()
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
                        new TableSection("Configuration")
                        {
                            new TextCell
                            {
                                Text = "Property",
                                Command = navigateCommand,
                                CommandParameter = typeof(PropertyCollectionView)
                            },
                           new TextCell
                            {
                                Text = "Unit of measure",
                                Command = navigateCommand,
                                CommandParameter = typeof(UnitOfMeasureCollectionView)
                            },
                            new TextCell
                            {
                                Text = "Location",
                                Command = navigateCommand,
                                CommandParameter = typeof(LocationCollectionView)
                            },
                            new TextCell
                            {
                                Text = "Counter type",
                                Command = navigateCommand,
                                CommandParameter = typeof(CounterTypeCollectionView)
                            },


                            new TextCell
                            {
                                Text = "Settings Application",
                                Command = navigateCommand,
                                CommandParameter = typeof(SettingAppView)
                            },

                        }

                    }
            };

        }


    }
}
