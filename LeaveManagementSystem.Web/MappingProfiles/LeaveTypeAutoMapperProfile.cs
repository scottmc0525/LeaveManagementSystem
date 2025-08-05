using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.MappingProfiles
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
