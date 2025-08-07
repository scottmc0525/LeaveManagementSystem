using AutoMapper;

namespace LeaveManagementSystem.Application.MappingProfiles
{
    public class LeaveAllocationAutoMapperProfile : Profile
    {
        public LeaveAllocationAutoMapperProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>();
            CreateMap<Period, PeriodVM>().ReverseMap();
            CreateMap<ApplicationUser, EmployeeListVM>().ReverseMap();
        }
    }
}
