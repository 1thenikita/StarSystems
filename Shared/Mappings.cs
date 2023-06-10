using AutoMapper;
using StarSystems.Shared.EditModels;
using StarSystems.Shared.ViewModels;

namespace StarSystems.Shared;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<SpaceObjectViewModel, SpaceObjectEditModel>().ReverseMap();

        CreateMap<StarSystemViewModel, StarSystemEditModel>().ReverseMap();
    }
}