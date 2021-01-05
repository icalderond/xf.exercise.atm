using System;
using NUnit.Framework;
using xf.exercise.atm.BusinessLayout;

namespace xf.exercise.atm.NUnit
{
    [TestFixture()]
    public class Test
    {
        DashBL DashBL;
        public Test()
        {
            DashBL = new DashBL();
        }

        [Test()]
        public void Get_100Dollar_IsSuccesfull()
        {
            var mockList = Mocks.DollarsBillMock.GetDollarsBills();
            var billsToRemove = DashBL.GetDollarBill(100, mockList);

            Assert.IsTrue(billsToRemove.Count == 1);
        }

        [Test()]
        public void Get_1860Dollar_IsSuccesfull()
        {
            var mockList = Mocks.DollarsBillMock.GetDollarsBills();
            var billsToRemove = DashBL.GetDollarBill(1860, mockList);

            Assert.IsTrue(billsToRemove.Count == 6);
        }

        [Test()]
        public void Get_1861Dollar_Exception_NoSeTieneDineroSuficiente()
        {
            var mockList = Mocks.DollarsBillMock.GetDollarsBills();
            var ex = Assert.Throws<Exception>(() => DashBL.GetDollarBill(1861, mockList));
            Assert.AreEqual("No se tiene dinero suficiente", ex.Message);
        }
    }
}
