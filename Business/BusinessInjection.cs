using AutoMapper;
using Business.Mapping;
using Business.Services;
using Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class BusinessInjection
{
    public static void RegisterBusiness(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();
    }
}