using AutoMapper;
using Domain.Entities;
using RE.Application.Library.Mappings;
using System;

namespace Application.Schedules.Queries
{
    public class ScheduleDto : IMapFrom<Schedule>
    {
        public int Id { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string GroupName { get; set; }
        public string SubjectName { get; set; }
        public DateTime DateTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Schedule, ScheduleDto>()
                .ForMember(o => o.TeacherFirstName, opt => opt.MapFrom(m => m.Teacher.FirstName))
                .ForMember(o => o.TeacherLastName, opt => opt.MapFrom(m => m.Teacher.LastName))
                .ForMember(o => o.GroupName, opt => opt.MapFrom(m => m.Group.Name))
                .ForMember(o => o.SubjectName, opt => opt.MapFrom(m => m.Subject.Name));
        }
    }
}
