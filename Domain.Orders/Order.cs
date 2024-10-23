namespace Domain.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public Region Region { get; set; }
        /// <summary>
        /// On kilograms
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// The order will be deliveried at this time
        /// </summary>
        public DateTime DevileryAt { get; set; }
    }
}
