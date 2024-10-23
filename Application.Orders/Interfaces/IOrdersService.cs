using Application.Orders.ViewModels;

namespace Application.Orders.Interfaces
{
    public interface IOrdersService
    {
        /// <summary>
        /// Create new order and add this to storage
        /// </summary>
        /// <param name="model">Order model</param>
        /// <returns>Id of order</returns>
        Task<Guid> CreateOrderAsync(CreateOrdersViewModel model);
    }
}
