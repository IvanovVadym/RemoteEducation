using AutoMapper;
using Domain.Entities;
using RE.Application.Library.Mappings;

namespace Application.Groups.Queries
{
    public class GroupDto : IMapFrom<Group>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupDto>();
        }
    }
}
