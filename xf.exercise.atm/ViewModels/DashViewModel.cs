using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms.Internals;
using xf.exercise.atm.BusinessLayout;
using xf.exercise.atm.Mocks;
using xf.exercise.atm.Models;

namespace xf.exercise.atm.ViewModels
{
    public class DashViewModel : NotificationEnabledObject
    {
        #region Constructor
        public DashViewModel()
        {
            ResetDollarBills();
        }
        #endregion Constructor

        #region Properties
        private ObservableCollection<DollarsBill> _DollarsBillStorage;
        public ObservableCollection<DollarsBill> DollarsBillStorage
        {
            get => _DollarsBillStorage;
            set => Set(ref _DollarsBillStorage, value);
        }
        private DashBL _DashBL;
        public DashBL DashBL
        {
            get => _DashBL = _DashBL ?? new DashBL();
        }
        #endregion Properties

        #region Commands
        private ActionCommand<int> _GetDollarBillCommand;
        public ActionCommand<int> GetDollarBillCommand
        {
            get => _GetDollarBillCommand = _GetDollarBillCommand
                ?? new ActionCommand<int>((dollarBill) => GetDollarBill(dollarBill));
        }

        private ActionCommand _ResetDollarBillCommand;
        public ActionCommand ResetDollarBillCommand
        {
            get => _ResetDollarBillCommand = _ResetDollarBillCommand ?? new ActionCommand(ResetDollarBills);
        }
        #endregion Commands

        #region Methods

        private void ResetDollarBills()
        {
            DollarsBillStorage = new ObservableCollection<DollarsBill>(DollarsBillMock.GetDollarsBills());
        }

        private async void GetDollarBill(int dollarBill)
        {
            try
            {
                var GetBills = DashBL.GetDollarBill(dollarBill, DollarsBillStorage);
                DollarsBillStorage.ForEach((bill) =>
                {
                    var billToRemove = GetBills.FirstOrDefault(x => x.Value == bill.Value);
                    if (billToRemove != null)
                        bill.Quantity -= billToRemove.Quantity;
                });
                await App.Current.MainPage.DisplayAlert("Operación correcta", $"El dinero ha sido entregado ({dollarBill} dollar)", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Operación incorrecta", ex.Message, "Enterado");
            }
        }
        #endregion Methods
    }
}
