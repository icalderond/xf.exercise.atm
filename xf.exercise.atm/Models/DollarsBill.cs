namespace xf.exercise.atm.Models
{
    /// <summary>
    /// This class is representation of how much dollars bill there is in bank.
    /// </summary>
    public class DollarsBill
    {
        /// <summary>
        /// Values of dollar
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Quantity of bills with the same value
        /// </summary>
        public int Quantity { get; set; }
    }
}
