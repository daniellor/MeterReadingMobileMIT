using MeterReadingMobile.View;
using MeterReadingMobile.View.Intrata;
using MeterReadingMobile.WebApi.Intrata.Model;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel.Intrata
{
    public class InstallationCollectionViewModel : ViewModelCollection<InstallationBase, InstallationViewModel>
    {
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public InstallationCollectionViewModel(INavigation navigate) : base(navigate)
        {
            EditCommand = new Command<InstallationViewModel>(EditItem);
            AddCommand = new Command(AddItem);
            DeleteCommand = new Command<InstallationViewModel>(DeleteItem);

        }

        void EditItem(InstallationViewModel mv)
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Edit, mv));
        }
        void AddItem()
        {
            NavigateTo.PushAsync(AddEditPage(CrudFlags.Add, null));
        }
        void DeleteItem(InstallationViewModel mv)
        {
            var yesnodialog = new YesNoCancelDialogView("Delete item?");
            SelectedItem = mv;
            yesnodialog.ViewModel.YesSucceeded += YesNoDialog_YesSucceeded;
            NavigateTo.PushAsync(yesnodialog);

        }

        private void YesNoDialog_YesSucceeded(object sender, EventArgs e)
        {
            RefreshEntity(CrudFlags.Delete, null, SelectedItem);
        }

        private AddEditInstallationView AddEditPage(CrudFlags crudFlag, InstallationViewModel mv)
        {
            Func<InstallationViewModel> bindData = null;

            if (crudFlag == CrudFlags.Edit)
                bindData = () => new InstallationViewModel((InstallationBase)mv.DataDB.Clone());

            if (crudFlag == CrudFlags.Add)
                bindData = () => new InstallationViewModel(InstallationBase.NewRecord());

            var addEditPage = new AddEditInstallationView(crudFlag, bindData);
            SelectedItem = mv;

            addEditPage.ViewModel.SaveSucceeded += AddEditPage_SaveSucceeded;

            return addEditPage;
        }
        private void AddEditPage_SaveSucceeded(object sender, System.EventArgs e)
        {
            var obj = sender as InstallationAddEditViewModel;
            RefreshEntity(obj.CurrentCrudFlag, obj.DataBind, SelectedItem);
        }
    }
}
