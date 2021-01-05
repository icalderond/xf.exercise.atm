using System.Collections.Generic;
using xf.exercise.atm.Models;

namespace xf.exercise.atm.Mocks
{
    public static class DollarsBillMock
    {
        public static List<DollarsBill> GetDollarsBills()
        {
            var listDollarBills = new List<DollarsBill>();

            listDollarBills.Add(new DollarsBill { Value = 100, Quantity = 10 });
            listDollarBills.Add(new DollarsBill { Value = 50, Quantity = 10 });
            listDollarBills.Add(new DollarsBill { Value = 20, Quantity = 10 });
            listDollarBills.Add(new DollarsBill { Value = 10, Quantity = 10 });
            listDollarBills.Add(new DollarsBill { Value = 5, Quantity = 10 });
            listDollarBills.Add(new DollarsBill { Value = 1, Quantity = 10 });

            return listDollarBills;
        }
    }
}
