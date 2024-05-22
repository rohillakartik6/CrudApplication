using Assesment_KartikRohilla.Application.Services;
using Assesment_KartikRohilla.Application.Services.Interface;
using Assesment_KartikRohilla.Infrastructure.Repositories;
using Assesment_KartikRohilla.Infrastructure.Repository;
using Assesment_KartikRohilla.Infrastructure.Repository.Interface;
using Assesment_KartikRohilla.Repository;
using Assesment_KartikRohilla.Repository.Interface;
using Assesment_KartikRohilla.Services;
using Assesment_KartikRohilla.Services.Interface;

namespace Assesment_KartikRohilla.API.Injectable
{
    public class InjectableServices
    {
        public static void Services(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DapperDbContext, DapperDbContext>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDropdownService, DropdownService>();
            builder.Services.AddScoped<IDropdownRepository, DropdownRepository>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<ILoginService, LoginService>();
        }
    }
}
