using AutoMapper;

namespace LeaveManagementSystem.Application.MappingProfiles
{
    public class LeaveTypeAutoMapperProfile : Profile
    {
        public LeaveTypeAutoMapperProfile()
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>()
                .ReverseMap();
            CreateMap<LeaveType, LeaveTypeCreateVM>()
                .ReverseMap();
            CreateMap<LeaveType, LeaveTypeEditVM>()
                .ReverseMap();
        }
    }
}
