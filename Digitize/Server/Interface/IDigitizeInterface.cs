using Digitize.Shared.Data;

namespace Digitize.Server.Interface
{
    public interface IDigitizeInterface
    {
        Task<IEnumerable<Aadhaar>> GetAllAdhaar();
        Task<Aadhaar> GetAdhaar(int Uid);
        Task<Birth> GetBirth(int id);
        Task<Voter> GetVoter(int id);
        Task<int> RemoveAdhaar(int Uid);
        Task<int> RemoveBirth(int id);
        Task<int> RemoveVoter(int id);
        Task<Aadhaar> CreateAdhaar(Aadhaar aadharData);
        Task<Voter> CreateVoter(Voter voterData);
        Task<Birth> CreateBirth(Birth birthData);
    }
}