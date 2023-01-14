using Microsoft.AspNetCore.Mvc;
using RabitMqProductAPI.EventBus.EventBus;
using RabitMqProductAPI.EventHandling;

namespace RabitMqProductAPI.Controllers
{
    /// <summary>
    /// Values控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 测试RabbitMQ事件总线
        /// </summary>
        /// <param name="_eventBus"></param>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet]
        public void EventBusTry([FromServices] IEventBus _eventBus, int blogId = 1)
        {
            var blogDeletedEvent = new ProductQueryIntegrationEvent(blogId);

            _eventBus.Publish(blogDeletedEvent);
        }

    }
}
