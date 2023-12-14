using AutoMapper;
using Business.Models;
using Web.Models;

namespace Web.Mapping;

public class WebProfile: Profile
{
    public WebProfile()
    {
        CreateMap<AddEmployeeRequest, Employee>();
        CreateMap<AddManagerRequest, Manager>();
    }
}