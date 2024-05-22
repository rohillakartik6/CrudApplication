using Assesment_KartikRohilla.Model;
using Assesment_KartikRohilla.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = API.Filters.AuthorizeAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assesment_KartikRohilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<ValuesController>
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("Employees")]
        public async Task<ApiResponse> Employees()
        {
            try
            {

                ApiResponse response = new ApiResponse();
                response.StatusCode = 200;
                response.IsError = false;
                response.Result = await service.Employees();
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse { IsError = true, Result = "Something went wrong. " + ex.Message, StatusCode = 500, Message = "Something Went Wrong. Please try again later." };
            }
        }

        [HttpGet("CheckDuplicate")]
        public async Task<ApiResponse> CheckDuplicate(string fieldName, string? value)
        {
            try
            {
                return await service.CheckDuplicate(fieldName, value);
            }
            catch (Exception ex)
            {
                return new ApiResponse { IsError = true, Result = "Something went wrong. " + ex.Message, StatusCode = 500, Message = "Something Went Wrong. Please try again later." };
            }
        }

        [HttpGet("Employee/{id}")]
        public async Task<ApiResponse> GetEmployees(int id)
        {
            try
            {
                ApiResponse response = new ApiResponse();
                response.Result = await service.GetEmployeeById(id);
                response.IsError = false;
                response.StatusCode = 200;
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse { IsError = true, Result = "Something went wrong. " + ex.Message, StatusCode = 500, Message = "Something Went Wrong. Please try again later." };
            }
        }

        [HttpPost("Employee")]
        public async Task<ApiResponse> AddEmployees([FromBody] Employees model)
        {
            try
            {
                return await service.AddEmployee(model);
            }
            catch (Exception ex)
            {
                return new ApiResponse { IsError = true, Result = ex.Message, StatusCode = 500, Message = "Something Went Wrong. Please try again later." };
            }
        }

        [HttpPost("UploadProfileImage")]
        public async Task<ActionResult<ApiResponse>> UploadImage(ProfilePicture model)
        {
            try
            {
                var data = await service.UploadImage(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                ApiResponse response = new ApiResponse() { IsError = true, Message = "Something went wrong.", StatusCode = 500 };
                return StatusCode(500, response);
            }
        }

        [HttpDelete("Employee/{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            try
            {
                var data = await service.DeleteEmployee(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                ApiResponse response = new ApiResponse() { IsError = true, Message = "Something went wrong.", StatusCode = 500 };
                return StatusCode(500, response);
            }
        }

        [HttpDelete("DeleteProfileImage")]
        public async Task<ActionResult<ApiResponse>> DeleteProfileImage(string fileName)
        {
            try
            {
                var data = await service.DeleteProfileImage(fileName);
                if (!data.IsError)
                {
                    return NoContent();
                }
                else
                {
                    return data;
                }
            }
            catch (Exception ex)
            {
                ApiResponse response = new ApiResponse() { IsError = true, Message = "Something went wrong.", StatusCode = 500 };
                return StatusCode(500, response);
            }
        }


    }
}
