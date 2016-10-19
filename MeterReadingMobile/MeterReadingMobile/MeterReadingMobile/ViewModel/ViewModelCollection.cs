using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class ViewModelCollection<TEntityBase, TEntityView> : ViewModelBase<TEntityBase> where TEntityBase : new() where TEntityView : ViewModelBase<TEntityBase>, new()
    {
        public ViewModelCollection(INavigation navigate) : base(navigate)
        {
            Items = new ObservableCollection<TEntityView>();

        }
        #region properties

        private ObservableCollection<TEntityView> _items = new ObservableCollection<TEntityView>();
        public virtual ObservableCollection<TEntityView> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }


        private TEntityView _selectedItem;
        public virtual TEntityView SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }


        private string _busyMessage;

        public string BusyMessage
        {
            get { return _busyMessage; }
            set
            {
                _busyMessage = value;
                OnPropertyChanged("BusyMessage");
            }
        }
        #endregion

        public virtual async Task InitializeWebApiAsync(TEntityBase filter, string apiservice)
        {
            var api = ((App)App.Current).CurrentIntrataApiClient;
            List<TEntityBase> es = await api.GetCollectionsAsync<TEntityBase>(filter, apiservice);
            Items = new ObservableCollection<TEntityView>(es.Select(e => new TEntityView() { DataDB = e }));
        }
        public virtual void Initialize(IEnumerable<TEntityBase> data)
        {
            Items = new ObservableCollection<TEntityView>(data.Select(e => new TEntityView() { DataDB = e }));

        }
        public async Task<bool> BusyAction(Func<Task> act, string message = "Ładuję ...")
        {
            bool result = false;
            try
            {
                IsBusy = true;
                BusyMessage = message;
                await act();
                result = true;
            }
            catch (Exception e)
            {
                //LogHelper.Error(e.ToString());
            }
            finally
            {
                IsBusy = false;
            }
            return result;
        }
        public virtual void RefreshEntity(CrudFlags crud, TEntityView val, TEntityView item2refresh)
        {
            switch (crud)
            {
                case CrudFlags.Add:
                    {
                        Items.Add(val);
                        break;
                    }
                case CrudFlags.Edit:
                    {
                        Items.Remove(item2refresh);
                        Items.Add(val);
                        break;
                    }
                case CrudFlags.Delete:
                    {
                        Items.Remove(item2refresh);
                        break;
                    }
            }

        }




    }
}

