using API.DBOs;
using API.DTOs;
using AutoMapper;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDBO, StudentDTO>().ReverseMap();
            CreateMap<GradesDBO, GradesDTO>().ReverseMap();
            CreateMap<StudentDBO, StudentRequestDTO>().ReverseMap();
            CreateMap<GradesDBO, GradesRequestDTO>().ReverseMap();
            CreateMap<AttendanceDBO, AttendanceDTO>().ReverseMap();
            CreateMap<AttendanceDBO, AttendanceRequestDTO>().ReverseMap();
        }
    }
}
