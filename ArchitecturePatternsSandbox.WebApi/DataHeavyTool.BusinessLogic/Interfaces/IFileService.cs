using Microsoft.AspNetCore.Http;

namespace DataHeavyTool.BusinessLogic.Interfaces
{
    public interface IFileService
    {
        Task ProcessLargeCsvAsync(IFormFile file);
    }
}
