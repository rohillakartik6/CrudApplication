using Assesment_KartikRohilla.Model;
using Assesment_KartikRohilla.Repository.Interface;
using Assesment_KartikRohilla.Services.Interface;

namespace Assesment_KartikRohilla.Services
{
    public class DropdownService : IDropdownService
    {
        private readonly IDropdownRepository repo;
        public DropdownService(IDropdownRepository repo)
        {
            this.repo = repo;
        }
        public async Task<List<Countries>> Countries()
        {
            return await repo.Countries();
        }
        public async Task<List<States>> States(int countryId)
        {
            return await repo.States(countryId);
        }
        public async Task<List<Cities>> Cities(int stateId)
        {
            return await repo.Cities(stateId);
        }
    }
}
