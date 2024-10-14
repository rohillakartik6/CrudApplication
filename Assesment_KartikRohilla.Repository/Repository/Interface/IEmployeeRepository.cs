using Assesment_KartikRohilla.Infrastructure.Entities;
using Assesment_KartikRohilla.Model;

namespace Assesment_KartikRohilla.Repository.Interface
{
    public interface IEmployeeRepository
    {
        public Task<List<stp_Emp_GetEmployeesResult>> Get();
        public Task<int> Add(Employees model);
        public Task<Employees> GetById(int id);
        public Task<int> Update(Employees model);
        public Task<int> UploadImage(int id, string fileName);
        public Task<int> Delete(int id);
        public Task<int> CheckDuplicate(string fieldName, string value);
        public Task<string> GetProfileImageFileName(int id);
    }
}
