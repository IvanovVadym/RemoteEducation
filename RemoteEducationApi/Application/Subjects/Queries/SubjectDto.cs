using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Subjects.Queries
{
    public class SubjectDto : IMapFrom<Subject>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subject, SubjectDto>();
        }
    }
}
