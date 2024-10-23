using Application.Orders.ViewModels;
using Domain.Orders;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Persistance.Orders.Repositories
{
    internal class OrdersRepository : IOrdersRepository
    {
        private List<Order> _orders;
        private const string FILE_PATH = "OrdersStorage.json";
        public OrdersRepository()
        {
            CreateStorageIfNotExisit();
        }
        public async Task<Guid> AddOrderAsync(CreateOrdersViewModel model)
        {
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                DevileryAt = DateTime.Now.AddMinutes(30),
                Weight = model.Weight,
                Region = new Region 
                {
                    Id = Guid.NewGuid(),
                    NameOfStreet = model.NameOfStreet 
                },
            };

            _orders = await GetOrdersAsync();
            _orders.Add(order);

            var json = JsonConvert.SerializeObject(_orders, Formatting.Indented);
            File.WriteAllText(FILE_PATH, json);

            return order.Id;
        }
        private async Task<List<Order>> GetOrdersAsync()
        {
            string json = File.ReadAllText(FILE_PATH);
            if(string.IsNullOrEmpty(json))
                return new List<Order>();

            _orders = JsonConvert.DeserializeObject<List<Order>>(json);

            return _orders;
        }
        private void CreateStorageIfNotExisit()
        {
            if (File.Exists(FILE_PATH) == false)
            {
                var fs = File.Create(FILE_PATH);
                fs.Close();
            }             
        }
    }
}
