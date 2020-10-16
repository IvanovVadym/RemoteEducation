using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Schedules.Queries
{
    public class ScheduleDto : IMapFrom<Schedule>
    {
        public int Id { get; set; }
        public int TeacherFirstName { get; set; }
        public int TeacherLastName { get; set; }
        public int GroupName { get; set; }
        public int SubjectName { get; set; }
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
