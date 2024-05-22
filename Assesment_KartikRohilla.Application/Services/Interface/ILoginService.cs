using Assesment_KartikRohilla.Model;
using Assesment_KartikRohilla.SharedLayer.Model;

namespace Assesment_KartikRohilla.Application.Services.Interface
{
    public interface ILoginService
    {
        public Task<ApiResponse> Login(Login login);
    }
}
