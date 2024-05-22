using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Assesment_KartikRohilla.Infrastructure.Repositories
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection connection;

        public DapperDbContext(IConfiguration configuration)
        {
            this.connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
