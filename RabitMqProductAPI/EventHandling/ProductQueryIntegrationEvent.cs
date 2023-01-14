using RabitMqProductAPI.EventBus.EventBus;

namespace RabitMqProductAPI.EventHandling
{
    public class ProductQueryIntegrationEvent : IntegrationEvent
    {
        public int ProductId { get; private set; }

        public ProductQueryIntegrationEvent(int blogid)
            => ProductId = blogid;
    }
}
