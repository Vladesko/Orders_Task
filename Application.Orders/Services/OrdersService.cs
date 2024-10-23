using Application.Orders.Interfaces;
using Application.Orders.ViewModels;

namespace Application.Orders.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<Guid> CreateOrderAsync(CreateOrdersViewModel model)
        {
            var result = await _ordersRepository.AddOrderAsync(model);
            return result;
        }
    }
}
