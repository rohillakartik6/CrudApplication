using Assesment_KartikRohilla.Model;

namespace Assesment_KartikRohilla.Repository.Interface
{
    public interface IDropdownRepository
    {
        public Task<List<Countries>> Countries();
        public Task<List<States>> States(int countryId);
        public Task<List<Cities>> Cities(int stateId);
    }
}
