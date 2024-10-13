using API.DBOs;
using AutoMapper;
using API.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        }
    }
}
