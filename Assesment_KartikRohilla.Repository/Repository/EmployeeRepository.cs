using Assesment_KartikRohilla.Infrastructure.Repositories;
using Assesment_KartikRohilla.Model;
using Assesment_KartikRohilla.Repository.Interface;
using Dapper;
using System.Data;

namespace Assesment_KartikRohilla.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperDbContext context;

        public EmployeeRepository(DapperDbContext context)
        {
            this.context = context;
        }
        public async Task<List<GetEmployees>> Get()
        {
            using (IDbConnection db = context.GetConnection())
            {
                return db.Query<GetEmployees>("stp_Emp_GetEmployees", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public async Task<int> Add(Employees model)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@LastName", model.LastName);
                parameters.Add("@CountryId", model.CountryId);
                parameters.Add("@StateId", model.StateId);
                parameters.Add("@CityId", model.CityId);
                parameters.Add("@EmailAddress", model.EmailAddress);
                parameters.Add("@MobileNumber", model.MobileNumber);
                parameters.Add("@PanNumber", model.PanNumber);
                parameters.Add("@PassportNumber", model.PassportNumber);
                parameters.Add("@ProfileImage", model.ProfileImage);
                parameters.Add("@Gender", model.Gender);
                parameters.Add("@IsActive", model.IsActive);
                parameters.Add("@DateOfBirth", model.DateOfBirth);
                parameters.Add("@DateOfJoinee", model.DateOfJoinee);
                return db.Query<int>("stp_Emp_AddEmployee", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public async Task<int> Update(Employees model)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RowId", model.Row_Id);
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@LastName", model.LastName);
                parameters.Add("@CountryId", model.CountryId);
                parameters.Add("@StateId", model.StateId);
                parameters.Add("@CityId", model.CityId);
                parameters.Add("@EmailAddress", model.EmailAddress);
                parameters.Add("@MobileNumber", model.MobileNumber);
                parameters.Add("@PanNumber", model.PanNumber);
                parameters.Add("@PassportNumber", model.PassportNumber);
                parameters.Add("@ProfileImage", model.ProfileImage);
                parameters.Add("@Gender", model.Gender);
                parameters.Add("@IsActive", model.IsActive);
                parameters.Add("@DateOfBirth", model.DateOfBirth);
                parameters.Add("@DateOfJoinee", model.DateOfJoinee);
                return db.Query<int>("stp_Emp_UpdateEmployee", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public async Task<Employees> GetById(int id)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", id);
                return db.Query<Employees>("stp_Emp_GetEmployeeById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public async Task<int> UploadImage(int Id, string FileName)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                parameters.Add("@ProfilePicture", FileName);
                return db.Query<int>("stp_Emp_UploadImage", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public async Task<int> Delete(int id)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return db.Query<int>("stp_Emp_DeleteEmployee", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public async Task<int> CheckDuplicate(string fieldName, string value)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ColumnName", fieldName);
                parameters.Add("@Value", value);
                return db.Query<int>("stp_Emp_CheckDuplicateValue", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public async Task<string> GetProfileImageFileName(int id)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return db.Query<string>("stp_Emp_GetProfileImageName", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
