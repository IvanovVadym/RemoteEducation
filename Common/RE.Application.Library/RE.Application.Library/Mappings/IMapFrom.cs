using AutoMapper;

namespace RE.Application.Library.Mappings
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
