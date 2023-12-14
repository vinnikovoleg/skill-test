using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Mapping;
using Web.Models;

namespace Web.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly IMapper _mapper;

    public UsersController(
        IUsersService usersService, IMapper mapper)
    {
        _usersService = usersService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(int skip, int take)
    {
        var employees = await _usersService.GetAsync(take, skip);
        return Ok(employees);
    }

    [HttpPost("employee")]
    public async Task<IActionResult> AddEmployeeAsync([FromBody] AddEmployeeRequest request)
    {
        var employee = _mapper.Map<Employee>(request);
        var id = await _usersService.AddEmployee(employee);

        return Ok(id);
    }
    
    [HttpPost("manager")]
    public async Task<IActionResult> AddManagerAsync([FromBody] AddManagerRequest request)
    {
        var manager = _mapper.Map<Manager>(request);
        var id = await _usersService.AddManager(manager);

        return Ok(id);
    }
}