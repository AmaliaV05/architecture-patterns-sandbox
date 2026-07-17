using ECommerceLite.BusinessLogic.Interfaces;
using ECommerceLite.Data.Entities;

namespace ECommerceLite.BusinessLogic.Services
{
    public class FileOrderRepository : IFileOrderRepository
    {
        private readonly StreamWriter _streamWriter;
        private bool _disposed;

        public FileOrderRepository(string filePath)
        {
            _streamWriter = new StreamWriter(filePath, append: true);
        }

        public void WriteLog(Order order)
        {
            _streamWriter.WriteLine(order.ToString());
            _streamWriter.Flush();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool dispose)
        {
            if (!_disposed)
            {
                if (dispose)
                {
                    _streamWriter?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
