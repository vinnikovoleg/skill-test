using Business.Models;

namespace Business.Services.Interfaces;

public interface IUsersService
{
    Task<List<UserBase>> GetAsync(int take, int skip);
    Task<int> AddEmployee(Employee employee);
    Task<int> AddManager(Manager manager);
}