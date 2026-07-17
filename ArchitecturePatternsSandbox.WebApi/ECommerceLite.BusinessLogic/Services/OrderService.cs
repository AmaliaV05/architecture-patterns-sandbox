using ECommerceLite.BusinessLogic.Interfaces;
using ECommerceLite.Data.Entities;

namespace ECommerceLite.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IFileOrderRepository _orderRepository;
        private readonly IValidator<Order> _orderValidator;
        private readonly Dictionary<string, IDiscountStrategy> _strategies;

        public OrderService(IFileOrderRepository orderRepository, IValidator<Order> orderValidator)
        {
            _orderRepository = orderRepository;
            _orderValidator = orderValidator;
            _strategies = new Dictionary<string, IDiscountStrategy>
            {
                { "BF2026", new BlackFridayStrategy() },
                { "NONE", new NoDiscountStrategy() }
            };
        }

        public bool PlaceOrder(Order order, string promoCode)
        {
            if (_orderValidator.Validate(order))
            {
                var strategy = _strategies.ContainsKey(promoCode) ? _strategies[promoCode] : _strategies["NONE"];

                order.TotalAmount = strategy.ApplyDiscount(order.TotalAmount);

                _orderRepository.WriteLog(order);

                return true;
            }

            return false;
        }
    }
}
