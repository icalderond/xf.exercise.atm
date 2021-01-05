using xf.exercise.atm.ViewModels;

namespace xf.exercise.atm.Models
{
    /// <summary>
    /// This class is representation of how much dollars bill there is in bank.
    /// </summary>
    public class DollarsBill : NotificationEnabledObject
    {
        /// <summary>
        /// Values of dollar
        /// </summary>
        private int _Value;
        public int Value
        {
            get => _Value;
            set => Set(ref _Value, value);
        }

        /// <summary>
        /// Quantity of bills with the same value
        /// </summary>
        private int _Quantity;
        public int Quantity
        {
            get => _Quantity;
            set => Set(ref _Quantity, value);
        }
    }
}
