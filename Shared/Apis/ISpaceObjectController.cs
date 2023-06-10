using Refit;
using StarSystems.Shared.EditModels;
using StarSystems.Shared.ViewModels;

namespace StarSystems.Shared.Apis;

public interface ISpaceObjectController
{
    [Get("/api/SpaceObject")]
    public Task<List<SpaceObjectViewModel>> Get();

    [Get("/api/SpaceObject/{id}")]
    public Task<SpaceObjectViewModel> GetByID(Guid id);

    [Post("/api/SpaceObject/")]
    public Task<SpaceObjectViewModel> Post(SpaceObjectEditModel editModel);

    [Put("/api/SpaceObject/{id}")]
    public Task<SpaceObjectViewModel> Put(Guid id, SpaceObjectEditModel editModel);

    [Delete("/api/SpaceObject/{id}")]
    public Task Delete(Guid id);
}