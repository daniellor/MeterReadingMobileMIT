using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.View;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class PropertyCollectionViewModel : ViewModelCollection<db_Property, PropertyViewModel>
    {
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public ICommand CounterCommand { get; private set; }
        public ICommand MeterReadingCommand { get; private set; }

        public PropertyCollectionViewModel(INavigation navigate) : base(navigate)
        {
            EditCommand = new Command<PropertyViewModel>(EditItem);
            AddCommand = new Command(AddItem);
            DeleteCommand = new Command<PropertyViewModel>(DeleteItem);


        }

        void EditItem(PropertyViewModel mv)
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Edit, mv));
        }
        void AddItem()
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Add, null));
        }
        void DeleteItem(PropertyViewModel mv)
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
                db.DeleteItem<db_Property>(SelectedItem.DataDB);
                RefreshEntity(CrudFlags.Delete, null, SelectedItem);
            }).ExecuteQuery();


        }

        private AddEditPropertyView AddEditPage(CrudFlags crudFlag, PropertyViewModel mv)
        {
            Func<PropertyViewModel> bindData = null;

            if (crudFlag == CrudFlags.Edit)
                bindData = () => new PropertyViewModel(mv.DataDB);

            if (crudFlag == CrudFlags.Add)
                bindData = () => new PropertyViewModel(new db_Property());

            var addEditPage = new AddEditPropertyView(crudFlag, bindData);
            SelectedItem = mv;

            addEditPage.ViewModel.SaveSucceeded += AddEditPage_SaveSucceeded;

            return addEditPage;
        }
        private void AddEditPage_SaveSucceeded(object sender, System.EventArgs e)
        {
            var obj = sender as PropertyAddEditViewModel;
            DataBaseUtl.OpenDb(db =>
            {
                db.SaveItem<db_Property>(obj.DataBind.DataDB);
                RefreshEntity(obj.CurrentCrudFlag, obj.DataBind, SelectedItem);
            }
            ).ExecuteQuery();


        }

    }
}
