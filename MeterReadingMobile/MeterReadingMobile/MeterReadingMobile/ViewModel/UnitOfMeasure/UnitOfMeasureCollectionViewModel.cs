using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.View;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class UnitOfMeasureCollectionViewModel : ViewModelCollection<db_UnitOfMeasure, UnitOfMeasureViewModel>
    {
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public UnitOfMeasureCollectionViewModel(INavigation navigate) : base(navigate)
        {
            EditCommand = new Command<UnitOfMeasureViewModel>(EditItem);
            AddCommand = new Command(AddItem);
            DeleteCommand = new Command<UnitOfMeasureViewModel>(DeleteItem);
        }

        void EditItem(UnitOfMeasureViewModel mv)
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Edit, mv));
        }
        void AddItem()
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Add, null));
        }
        void DeleteItem(UnitOfMeasureViewModel mv)
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
                db.DeleteItem<db_UnitOfMeasure>(SelectedItem.DataDB);
                RefreshEntity(CrudFlags.Delete, null, SelectedItem);
            }).ExecuteQuery();


        }

        private AddEditUnitOfMeasureView AddEditPage(CrudFlags crudFlag, UnitOfMeasureViewModel mv)
        {
            Func<UnitOfMeasureViewModel> bindData = null;

            if (crudFlag == CrudFlags.Edit)
                bindData = () => new UnitOfMeasureViewModel(mv.DataDB);

            if (crudFlag == CrudFlags.Add)
                bindData = () => new UnitOfMeasureViewModel(new db_UnitOfMeasure());

            var addEditPage = new AddEditUnitOfMeasureView(crudFlag, bindData);
            SelectedItem = mv;

            addEditPage.ViewModel.SaveSucceeded += AddEditPage_SaveSucceeded;

            return addEditPage;
        }
        private void AddEditPage_SaveSucceeded(object sender, System.EventArgs e)
        {
            var obj = sender as UnitOfMeasureAddEditViewModel;
            DataBaseUtl.OpenDb(db =>
            {
                db.SaveItem<db_UnitOfMeasure>(obj.DataBind.DataDB);
                RefreshEntity(obj.CurrentCrudFlag, obj.DataBind, SelectedItem);
            }).ExecuteQuery();


        }

    }
}
