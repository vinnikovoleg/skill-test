using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly DataContext _dbContext;

    public UsersRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAsync(int take, int skip)
    {
        return await _dbContext.Users
            .Include(u => u.Address)
            .Include(u => u.Salary)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<int> AddAsync(User user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }
}