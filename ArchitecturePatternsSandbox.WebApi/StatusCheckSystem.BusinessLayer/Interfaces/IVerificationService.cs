using StatusCheckSystem.Data.Entities;

namespace StatusCheckSystem.BusinessLayer.Interfaces
{
    public interface IVerificationService
    {
        Task<IList<VerificationLog>> CheckStatus();
    }
}
