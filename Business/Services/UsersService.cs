using AutoMapper;
using Business.Mapping;
using Business.Models;
using Business.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace Business.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(
        IUsersRepository usersRepository,
        IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<List<UserBase>> GetAsync(int take, int skip)
    {
        var users = await _usersRepository.GetAsync(take, skip);
        return users.Select(_mapper.Map<UserBase>).ToList();
    }

    public async Task<int> AddEmployee(Employee employee)
    {
        var user = _mapper.Map<User>(employee);
        return await _usersRepository.AddAsync(user);
    }

    public async Task<int> AddManager(Manager manager)
    {
        var user = _mapper.Map<User>(manager);
        return await _usersRepository.AddAsync(user);
    }
}