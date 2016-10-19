using System;
using Xamarin.Forms;

namespace MeterReadingMobile.ViewModel
{
    public class ViewModelAddEdit<TEntityBase, TEntityView> : ViewModelBase<TEntityBase> where TEntityBase : new() where TEntityView : ViewModelBase<TEntityBase>, new()

    {
        public ViewModelAddEdit()
        {
        }
        public ViewModelAddEdit(INavigation navigate) : base(navigate)
        {
        }

        private TEntityView _dataBind;

        public TEntityView DataBind
        {
            get { return _dataBind; }
            set { _dataBind = value; }
        }


        bool _isDirty = true;

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                OnPropertyChanged("IsDirty");
            }
        }


        CrudFlags _currentCrudFlag = CrudFlags.Unspecified;

        public CrudFlags CurrentCrudFlag
        {
            get { return _currentCrudFlag; }
            set
            {
                _currentCrudFlag = value;
                OnPropertyChanged("CurrentCrudFlag");
            }
        }

        public void InitDataBind(Func<TEntityView> delegateCrud)
        {
            DataBind = delegateCrud();
        }


    }
}

