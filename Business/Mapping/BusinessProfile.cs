using AutoMapper;
using Business.Models;
using DataAccess.Entities;

namespace Business.Mapping;

public class BusinessProfile : Profile
{
    public BusinessProfile()
    {
        CreateMap<Employee, User>()
            .ForMember(u => u.Type, e => e.MapFrom(em => UserType.Employee))
            .ForMember(u => u.Address, e => e.MapFrom(em => new Address
            {
                Line = em.Address
            }))
            .ForMember(u => u.Salary, e => e.MapFrom(em => new Salary
            {
                Type = SalaryType.PayPerHour,
                Amount = em.PayPerHour
            }));
        CreateMap<Manager, User>()
            .ForMember(u => u.Type, e => e.MapFrom(em => UserType.Manager))
            .ForMember(u => u.Address, e => e.MapFrom(em => new Address
            {
                Line = em.Address
            }))
            .ForMember(u => u.Salary, e => e.MapFrom(em => new Salary
            {
                Type = SalaryType.Annual,
                Amount = em.AnnualSalary
            }));

        CreateMap<User, UserBase>()
            .ConstructUsing((e, context) => context.Mapper.Map(e, UserFactory.GetInstance(e.Type)))
            .IncludeAllDerived();
        CreateMap<User, Employee>();
        CreateMap<User, Manager>()
            .ForMember(m => m.MaxExpenseAmount, u => u.MapFrom(p => p.MaxExpenseAmount))
            .ForMember(m => m.AnnualSalary, u => u.MapFrom(p => p.Salary.Amount));
        CreateMap<User, Supervisor>();
    }

    private static class UserFactory
    {
        public static UserBase GetInstance(UserType userType)
        {
            switch (userType)
            {
                case UserType.Employee:
                    return new Employee();
                case UserType.Manager:
                    return new Manager();
                case UserType.Supervisor:
                    return new Supervisor();
                default:
                    throw new ArgumentOutOfRangeException(nameof(userType), userType, null);
            }
        }
    }
}