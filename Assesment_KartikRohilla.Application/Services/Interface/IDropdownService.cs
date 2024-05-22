using Assesment_KartikRohilla.Model;

namespace Assesment_KartikRohilla.Services.Interface
{
    public interface IDropdownService
    {
        public Task<List<Countries>> Countries();
        public Task<List<States>> States(int countryId);
        public Task<List<Cities>> Cities(int stateId);
    }
}
