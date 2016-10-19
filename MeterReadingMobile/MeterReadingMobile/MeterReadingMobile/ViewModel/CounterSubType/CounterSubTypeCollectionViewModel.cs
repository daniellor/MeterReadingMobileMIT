using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.View;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class CounterSubTypeCollectionViewModel : ViewModelCollection<db_CounterSubType, CounterSubTypeViewModel>
    {
        public CounterTypeViewModel CounterType { get; private set; }

        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }


        public CounterSubTypeCollectionViewModel(INavigation navigate, CounterTypeViewModel dataMaster) : base(navigate)
        {
            EditCommand = new Command<CounterSubTypeViewModel>(EditItem);
            AddCommand = new Command(AddItem);
            DeleteCommand = new Command<CounterSubTypeViewModel>(DeleteItem);

            CounterType = dataMaster;
        }

        void EditItem(CounterSubTypeViewModel mv)
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Edit, mv));
        }
        void AddItem()
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Add, null));
        }
        void DeleteItem(CounterSubTypeViewModel mv)
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
                db.DeleteItem<db_CounterSubType>(SelectedItem.DataDB);
                RefreshEntity(CrudFlags.Delete, null, SelectedItem);
            })
            .ExecuteQuery();
        }

        private AddEditCounterSubTypeView AddEditPage(CrudFlags crudFlag, CounterSubTypeViewModel mv)
        {
            Func<CounterSubTypeViewModel> bindData = null;

            if (crudFlag == CrudFlags.Edit)
                bindData = () => new CounterSubTypeViewModel(mv.DataDB);

            if (crudFlag == CrudFlags.Add)
                bindData = () => new CounterSubTypeViewModel(new db_CounterSubType());

            var addEditPage = new AddEditCounterSubTypeView(crudFlag, bindData, CounterType);
            SelectedItem = mv;

            addEditPage.ViewModel.SaveSucceeded += AddEditPage_SaveSucceeded;

            return addEditPage;
        }
        private void AddEditPage_SaveSucceeded(object sender, System.EventArgs e)
        {
            var obj = sender as CounterSubTypeAddEditViewModel;
            obj.DataBind.DataDB.countertypeid = CounterType.DataDB.id;
            DataBaseUtl.OpenDb(db =>
            {
                db.SaveItem<db_CounterSubType>(obj.DataBind.DataDB);
                RefreshEntity(obj.CurrentCrudFlag, obj.DataBind, SelectedItem);
            }
            ).ExecuteQuery();

        }

    }
}
