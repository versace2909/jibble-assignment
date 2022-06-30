using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDTO, Employee>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}