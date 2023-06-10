using Refit;
using StarSystems.Shared.EditModels;
using StarSystems.Shared.ViewModels;

namespace StarSystems.Shared.Apis;

public interface IStarSystemController
{
    [Get("/api/StarSystem")]
    public Task<List<StarSystemViewModel>> Get();

    [Get("/api/StarSystem/{id}")]
    public Task<StarSystemViewModel> GetByID(Guid id);

    [Post("/api/StarSystem/")]
    public Task<StarSystemViewModel> Post(StarSystemEditModel editModel);

    [Put("/api/StarSystem/{id}")]
    public Task<StarSystemViewModel> Put(Guid id, StarSystemEditModel editModel);

    [Delete("/api/StarSystem/{id}")]
    public Task Delete(Guid id);
}