using System.Threading.Tasks;

namespace RabitMqProductAPI.EventBus.EventBus
{
    ///不是每一个事件源都需要详细的事件信息，所以一个强类型的参数约束就没有必要，通过dynamic可以简化事件源的构建，更趋于灵活。
    /// <summary>
    /// 动态集成事件处理程序
    /// 接口
    /// </summary>
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
