using Application.Common.Mappings;
using AutoMapper;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

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
