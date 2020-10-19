using AutoMapper;
using Domain.Entities;
using RE.Application.Library.Mappings;

namespace Application.Teachers.Queries
{
    public class TeacherDto : IMapFrom<Teacher>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, TeacherDto>();
        }
    }
}
