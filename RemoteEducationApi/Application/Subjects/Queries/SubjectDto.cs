﻿using AutoMapper;
using Domain.Entities;
using RE.Application.Library.Mappings;

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
