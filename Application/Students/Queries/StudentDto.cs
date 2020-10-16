﻿using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Students.Queries
{
    public class StudentDto : IMapFrom<Student>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDto>();
        }
    }
}
