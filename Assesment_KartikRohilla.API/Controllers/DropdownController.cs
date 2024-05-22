using Assesment_KartikRohilla.Model;
using Assesment_KartikRohilla.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_KartikRohilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        private readonly IDropdownService service;
        public DropdownController(IDropdownService service)
        {
            this.service = service;
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse> Countries()
        {
            try
            {
                ApiResponse response = new ApiResponse();
                response.StatusCode = 200;
                response.IsError = false;
                response.Result = await service.Countries();
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse { IsError = true, Result = "Something went wrong. " + ex.Message, StatusCode = 500, Message = "Something Went Wrong. Please try again later." };
            }
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse> States(int countryId)
        {
            try
            {

                ApiResponse response = new ApiResponse();
                response.StatusCode = 200;
                response.IsError = false;
                response.Result = await service.States(countryId);
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse { IsError = true, Result = "Something went wrong. " + ex.Message, StatusCode = 500, Message = "Something Went Wrong. Please try again later." };
            }
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse> Cities(int stateId)
        {
            try
            {

                ApiResponse response = new ApiResponse();
                response.StatusCode = 200;
                response.IsError = false;
                response.Result = await service.Cities(stateId);
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse { IsError = true, Result = "Something went wrong. " + ex.Message, StatusCode = 500, Message = "Something Went Wrong. Please try again later." };

            }
        }
    }
}
