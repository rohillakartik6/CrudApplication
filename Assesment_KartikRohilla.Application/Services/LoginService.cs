using Application.Helpers;
using Assesment_KartikRohilla.Application.Services.Interface;
using Assesment_KartikRohilla.Infrastructure.Repository;
using Assesment_KartikRohilla.Infrastructure.Repository.Interface;
using Assesment_KartikRohilla.Model;
using Assesment_KartikRohilla.SharedLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Assesment_KartikRohilla.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository repo;
        public readonly IConfiguration configuration;
        private readonly IOptions<JWTSettings> jwtSettings;
        public LoginService(ILoginRepository repo, IConfiguration configuration, IOptions<JWTSettings> jwtSettings)
        {
            this.configuration = configuration;
            this.jwtSettings = jwtSettings;
            this.repo = repo;
        }
        public async Task<ApiResponse> Login(Login model)
        {
            ApiResponse response = new ApiResponse();
            var res = await repo.Login(model);
            if (res != null)
            {
                if (res == 1)
                {
                    response.Message = "Successfully Login";
                    TokenUtil tokenUtil = new TokenUtil(configuration, jwtSettings);
                    JwtTokenResponse jwtToken = new JwtTokenResponse();
                    LoginResponse loginResponse = new LoginResponse() { Id = res, Email = model.EmailAddress };
                    jwtToken.Token = tokenUtil.GenerateJwtToken(loginResponse);
                    response.Result = jwtToken;
                    response.StatusCode = 200;
                }
                else
                {
                    response.Message = "User not found";
                    response.StatusCode = 404;
                    response.IsError = false;
                }
            }
            else
            {
                response.IsError = false;
                response.Message = "Something went wrong, please try again";
                response.StatusCode= 500;
            }
            return response;
        }
    }
}
