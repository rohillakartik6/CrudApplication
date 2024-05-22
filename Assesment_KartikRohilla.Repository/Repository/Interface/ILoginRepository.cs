using Assesment_KartikRohilla.SharedLayer.Model;

namespace Assesment_KartikRohilla.Infrastructure.Repository.Interface
{
    public interface ILoginRepository
    {
        public Task<int> Login(Login login);
    }
}
