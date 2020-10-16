using Application.Common.Mappings;
using AutoMapper;
using Domain.Common;

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
