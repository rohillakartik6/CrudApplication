using Assesment_KartikRohilla.Infrastructure.Repositories;
using Assesment_KartikRohilla.Infrastructure.Repository.Interface;
using Assesment_KartikRohilla.SharedLayer.Model;
using Dapper;
using System.Data;

namespace Assesment_KartikRohilla.Infrastructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DapperDbContext context;

        public LoginRepository(DapperDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Login(Login model)
        {
            using (IDbConnection db = context.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmailAddress", model.EmailAddress);
                parameters.Add("@Password", model.Password);
                return db.Query<int>("stp_Emp_LoginUser", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
