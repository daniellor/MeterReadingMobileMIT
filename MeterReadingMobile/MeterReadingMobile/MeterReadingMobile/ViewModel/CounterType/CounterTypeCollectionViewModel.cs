using MeterReadingMobile.Model;
using MeterReadingMobile.Utils;
using MeterReadingMobile.View;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class CounterTypeCollectionViewModel : ViewModelCollection<db_CounterType, CounterTypeViewModel>
    {
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public ICommand SubTypeCommand { get; private set; }

        public CounterTypeCollectionViewModel(INavigation navigate) : base(navigate)
        {
            EditCommand = new Command<CounterTypeViewModel>(EditItem);
            AddCommand = new Command(AddItem);
            DeleteCommand = new Command<CounterTypeViewModel>(DeleteItem);

            SubTypeCommand = new Command<CounterTypeViewModel>(SubTypeItem);

        }

        void EditItem(CounterTypeViewModel mv)
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Edit, mv));
        }
        void AddItem()
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Add, null));
        }
        void DeleteItem(CounterTypeViewModel mv)
        {
            var yesnodialog = new YesNoCancelDialogView("Delete item?");
            SelectedItem = mv;
            yesnodialog.ViewModel.YesSucceeded += YesNoDialog_YesSucceeded;
            NavigateTo.PushAsync(yesnodialog);

        }
        void SubTypeItem(CounterTypeViewModel mv)
        {
            NavigateTo.PushAsync(new CounterSubTypeCollectionView(mv));
        }

        private void YesNoDialog_YesSucceeded(object sender, EventArgs e)
        {
            DataBaseUtl.OpenDb(db =>
            {
                db.DeleteItem<db_CounterType>(SelectedItem.DataDB);
                RefreshEntity(CrudFlags.Delete, null, SelectedItem);
            }).ExecuteQuery();


        }

        private AddEditCounterTypeView AddEditPage(CrudFlags crudFlag, CounterTypeViewModel mv)
        {
            Func<CounterTypeViewModel> bindData = null;

            if (crudFlag == CrudFlags.Edit)
                bindData = () => new CounterTypeViewModel(mv.DataDB);

            if (crudFlag == CrudFlags.Add)
                bindData = () => new CounterTypeViewModel(new db_CounterType());

            var addEditPage = new AddEditCounterTypeView(crudFlag, bindData);
            SelectedItem = mv;

            addEditPage.ViewModel.SaveSucceeded += AddEditPage_SaveSucceeded;

            return addEditPage;
        }
        private void AddEditPage_SaveSucceeded(object sender, System.EventArgs e)
        {
            var obj = sender as CounterTypeAddEditViewModel;
            DataBaseUtl.OpenDb(db =>
            {
                db.SaveItem<db_CounterType>(obj.DataBind.DataDB);
                RefreshEntity(obj.CurrentCrudFlag, obj.DataBind, SelectedItem);
            }
            ).ExecuteQuery();


        }

    }
}
