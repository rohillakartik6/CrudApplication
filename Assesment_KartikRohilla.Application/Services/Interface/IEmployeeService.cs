using Assesment_KartikRohilla.Model;
using Microsoft.AspNetCore.Http;

namespace Assesment_KartikRohilla.Services.Interface
{
    public interface IEmployeeService
    {
        public Task<List<GetEmployees>> Employees();
        public Task<ApiResponse> AddEmployee(Employees model);
        public Task<Employees> GetEmployeeById(int id);
        public Task<ApiResponse> UploadImage(ProfilePicture model);
        public Task<ApiResponse> DeleteEmployee(int id);
        public Task<ApiResponse> CheckDuplicate(string fieldName, string value);
        public Task<ApiResponse> DeleteProfileImage(string fileName);
    }
}
