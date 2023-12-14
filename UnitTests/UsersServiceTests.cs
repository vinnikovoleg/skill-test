using AutoMapper;
using Business.Mapping;
using Business.Models;
using Business.Services;
using Business.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Moq;
using Web.Mapping;

namespace UnitTests;

public class UsersServiceTests
{
    private IUsersService _usersService;
    private Mock<IUsersRepository> _employeesRepository;

    [SetUp]
    public void Setup()
    {
        var mapper = new Mapper(new MapperConfiguration(c =>
        {
            c.AddProfile(new BusinessProfile());
            c.AddProfile(new WebProfile());
        }));
        _employeesRepository = new Mock<IUsersRepository>();
        _usersService = new UsersService(_employeesRepository.Object, mapper);
    }

    [Test]
    public async Task Test_EmployeeService_Get_Success()
    {
        // Setup
        var users = new List<User>()
        {
            new()
            {
                Id = 1,
                Type = UserType.Employee,
                FirstName = "John",
                LastName = "D",
                Address = new Address
                {
                    Line = "New York"
                },
                Salary = new Salary
                {
                    Type = SalaryType.PayPerHour,
                    Amount = 1500
                }
            },
            new()
            {
                Id = 2,
                Type = UserType.Manager,
                FirstName = "David",
                LastName = "B",
                Address = new Address
                {
                    Line = "London 15"
                },
                Salary = new Salary
                {
                    Type = SalaryType.Annual,
                    Amount = 150000
                },
                MaxExpenseAmount = 185
            },
            new()
            {
                Id = 3,
                Type = UserType.Supervisor,
                FirstName = "Ban",
                LastName = "D",
                Address = new Address
                {
                    Line = "Texas"
                },
                Salary = new Salary
                {
                    Type = SalaryType.Annual,
                    Amount = 100000
                }
            }
        };
        _employeesRepository.Setup(e => e.GetAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(users);

        // Act

        var employees = await _usersService.GetAsync(20, 0);


        Assert.IsInstanceOf(typeof(Employee), employees[0]);

        Assert.IsInstanceOf(typeof(Manager), employees[1]);
        var manager = employees[1] as Manager;
        Assert.That(185, Is.EqualTo(manager.MaxExpenseAmount));
        Assert.That(users[1].Salary.Amount, Is.EqualTo(manager.AnnualSalary));

        Assert.IsInstanceOf(typeof(Supervisor), employees[2]);
        // TODO: check other relative properties
    }
}