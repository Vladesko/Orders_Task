namespace Application.Orders.ViewModels
{
    public interface IOrdersRepository
    {
        /// <summary>
        /// Add new order to file
        /// </summary>
        /// <param name="model">Order</param>
        /// <returns>Id of orders</returns>
        Task<Guid> AddOrderAsync(CreateOrdersViewModel model);
    }
}
