using MeterReadingMobile.Utils;
using MeterReadingMobile.WebApi.Intrata;
using MeterReadingMobile.WebApi.Intrata.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class ErrorViewModel : ViewModelBase<ModelBase>
    {


        public ErrorViewModel(INavigation navigate) : base(navigate)
        {
            BackToCommand = new Command(async () =>
            {
                await NavigateTo.PopAsync();
            });

        }
        #region properties

        // ICommand implementations
        public ICommand BackToCommand { protected set; get; }



        private string _ErrorDesc;
        public string ErrorDesc
        {
            get { return _ErrorDesc; }
            set
            {
                if (value != null || value != _ErrorDesc) _ErrorDesc = value;
                OnPropertyChanged("ErrorDesc");
            }
        }


        #endregion


    }
}
