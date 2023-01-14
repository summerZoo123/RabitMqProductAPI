using RabitMqProductAPI.Common;
using RabitMqProductAPI.EventBus.EventBus;
using RabitMqProductAPI.Services;

namespace RabitMqProductAPI.EventHandling
{
    public class ProductQueryIntegrationEventHandler : IIntegrationEventHandler<ProductQueryIntegrationEvent>
    {
        private readonly IProductService _productServices;
        private readonly ILogger<ProductQueryIntegrationEventHandler> _logger;

        public ProductQueryIntegrationEventHandler(
            IProductService blogArticleServices,
            ILogger<ProductQueryIntegrationEventHandler> logger)
        {
            _productServices = blogArticleServices;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(ProductQueryIntegrationEvent @event)
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, "Blog.Core", @event);

            ConsoleHelper.WriteSuccessLine($"----- Handling integration event: {@event.Id} at Blog.Core - ({@event})");

            await _productServices.GetProductByIdAsync(@event.ProductId);
        }

    }
}
