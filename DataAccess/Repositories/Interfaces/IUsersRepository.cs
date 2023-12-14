using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IUsersRepository
{
    Task<List<User>> GetAsync(int take, int skip);
    Task<int> AddAsync(User user);
}