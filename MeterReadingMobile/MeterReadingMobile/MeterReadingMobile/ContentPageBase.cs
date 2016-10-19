using MeterReadingMobile.Utils;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeterReadingMobile
{
    public class ContentPageBase : ContentPage
    {
        private bool _startUp = true;

        public ContentPageBase()
        {
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_startUp)
            {
                this.AddProgressDisplay();
                OnRefreshDataAsync();
                OnRefreshData();
                _startUp = false;
            }
        }
        protected virtual async void OnRefreshDataAsync()
        {
            await Task.FromResult(default(object));
        }
        protected virtual void OnRefreshData()
        {

        }
    }
}
