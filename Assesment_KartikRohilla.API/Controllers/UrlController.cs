using Assesment_KartikRohilla.Application.Services.Interface;
using Assesment_KartikRohilla.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_KartikRohilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController
    {
        private readonly IUrlService service;
        public UrlController(IUrlService service)
        {
            this.service = service;
        }

        [HttpGet("ShortenUrl")]
        public async Task<ActionResult<ApiResponse>> ShortenUrl(string url)
        {
            try
            {
                var data = await service.ShortenUrl(url);

                if (data == null)
                {
                    return new ApiResponse { IsError = true, Message = "Something went wrong.", StatusCode = 400 };
                }
                else
                {
                    return new ApiResponse { IsError = false, Result = data, StatusCode = 200, Message = "Success" };
                }
            }
            catch (Exception ex)
            {
                ApiResponse response = new ApiResponse() { IsError = true, Message = "Something went wrong.", StatusCode = 500 };
                return response;
            }
        }
    }
}
