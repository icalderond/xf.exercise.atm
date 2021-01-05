using System;
using System.Collections.Generic;
using System.Linq;
using xf.exercise.atm.Models;

namespace xf.exercise.atm.BusinessLayout
{
    public class DashBL
    {
        public List<DollarsBill> GetDollarBill(int dollarBill, IList<DollarsBill> dollarsBillStorage)
        {
            var GetBills = new List<DollarsBill>();
            var quantityBillEdit = dollarBill;

            if (dollarsBillStorage.Sum(x => x.Value * x.Quantity) < quantityBillEdit)
                throw new Exception("No se tiene dinero suficiente");

            foreach (var currentBill in dollarsBillStorage.Where(x => x.Quantity > 0).OrderByDescending(x => x.Value))
            {
                var quantityBill = quantityBillEdit / currentBill.Value;

                var quantityToRemove = quantityBill <= currentBill.Quantity
                    ? quantityBill
                    : currentBill.Quantity;

                if (quantityToRemove > 0)
                {
                    GetBills.Add(new DollarsBill { Value = currentBill.Value, Quantity = quantityToRemove });
                    quantityBillEdit -= currentBill.Value * quantityToRemove;
                }
                if (quantityBillEdit == 0) break;
            }

            if (GetBills.Select(x => x.Value * x.Quantity).Sum() == dollarBill)
                return GetBills;
            else
                throw new Exception("No se puede entregar la cantidad");
        }
    }
}
