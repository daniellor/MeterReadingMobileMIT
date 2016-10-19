using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.View;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class LocationCollectionViewModel : ViewModelCollection<db_Location, LocationViewModel>
    {
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public LocationCollectionViewModel(INavigation navigate) : base(navigate)
        {
            EditCommand = new Command<LocationViewModel>(EditItem);
            AddCommand = new Command(AddItem);
            DeleteCommand = new Command<LocationViewModel>(DeleteItem);
        }

        void EditItem(LocationViewModel mv)
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Edit, mv));
        }
        void AddItem()
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Add, null));
        }
        void DeleteItem(LocationViewModel mv)
        {
            var yesnodialog = new YesNoCancelDialogView("Delete item?");
            SelectedItem = mv;
            yesnodialog.ViewModel.YesSucceeded += YesNoDialog_YesSucceeded;
            NavigateTo.PushAsync(yesnodialog);

        }

        private void YesNoDialog_YesSucceeded(object sender, EventArgs e)
        {
            DataBaseUtl.OpenDb(db =>
            {
                db.DeleteItem<db_Location>(SelectedItem.DataDB);
                RefreshEntity(CrudFlags.Delete, null, SelectedItem);
            }).ExecuteQuery();
        }

        private AddEditLocationView AddEditPage(CrudFlags crudFlag, LocationViewModel mv)
        {
            Func<LocationViewModel> bindData = null;

            if (crudFlag == CrudFlags.Edit)
                bindData = () => new LocationViewModel(mv.DataDB);

            if (crudFlag == CrudFlags.Add)
                bindData = () => new LocationViewModel(new db_Location());

            var addEditPage = new AddEditLocationView(crudFlag, bindData);
            SelectedItem = mv;

            addEditPage.ViewModel.SaveSucceeded += AddEditPage_SaveSucceeded;

            return addEditPage;
        }
        private void AddEditPage_SaveSucceeded(object sender, System.EventArgs e)
        {
            var obj = sender as LocationAddEditViewModel;
            DataBaseUtl.OpenDb(db =>
            {
                db.SaveItem<db_Location>(obj.DataBind.DataDB);
                RefreshEntity(obj.CurrentCrudFlag, obj.DataBind, SelectedItem);
            }
            ).ExecuteQuery();


        }

    }
}
