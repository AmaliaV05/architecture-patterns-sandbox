using ECommerceLite.Data.Entities;

namespace ECommerceLite.BusinessLogic.Interfaces
{
    public interface IFileOrderRepository : IDisposable
    {
        void WriteLog(Order order);
    }
}
