using Assesment_KartikRohilla.Infrastructure.Repositories;
using Assesment_KartikRohilla.Model;
using Assesment_KartikRohilla.Repository.Interface;
using Dapper;
using System.Data;

namespace Assesment_KartikRohilla.Repository
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly DapperDbContext context;
        public DropdownRepository(DapperDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Countries>> Countries()
        {
            using (IDbConnection db = context.GetConnection())
            {
                return db.Query<Countries>("stp_Emp_GetCountries", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public async Task<List<States>> States(int countryId)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@countryId", countryId);
                return db.Query<States>("stp_Emp_GetStates", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public async Task<List<Cities>> Cities(int stateId)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@stateId", stateId);
                return db.Query<Cities>("stp_Emp_GetCities", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
