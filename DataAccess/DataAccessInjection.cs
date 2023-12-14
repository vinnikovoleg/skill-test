using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessInjection
{
    public static void RegisterDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
    services.AddScoped<IUsersRepository, UsersRepository>();
    }
}