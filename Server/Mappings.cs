using AutoMapper;
using StarSystems.Server.Entities;
using StarSystems.Shared.EditModels;
using StarSystems.Shared.ViewModels;

namespace StarSystems.Server;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<SpaceObjectViewModel, SpaceObjectEditModel>().ReverseMap();
        CreateMap<SpaceObjectViewModel, SpaceObjectEntity>().ReverseMap();
        CreateMap<SpaceObjectEntity, SpaceObjectEditModel>().ReverseMap();

        CreateMap<StarSystemViewModel, StarSystemEditModel>().ReverseMap();
        CreateMap<StarSystemViewModel, StarSystemEntity>().ReverseMap();
        CreateMap<StarSystemEntity, StarSystemEditModel>().ReverseMap();
    }
}