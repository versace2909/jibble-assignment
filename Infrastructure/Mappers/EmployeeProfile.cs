using System;
using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDTO, Employee>().ForMember(x => x.Id, opt => opt.Ignore())
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.CreatedBy = "ADMIN")
                ;
        }
    }
}