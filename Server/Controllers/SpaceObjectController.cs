using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarSystems.Server.Entities;
using StarSystems.Shared.EditModels;
using StarSystems.Shared.ViewModels;

namespace StarSystems.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpaceObjectController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public SpaceObjectController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    // GET: api/SpaceObject
    [HttpGet]
    public ActionResult<List<SpaceObjectViewModel>> Get()
    {
        var datas = Context.SpaceObjects.ToList();
        var results = datas.Select(x => Mapper.Map<SpaceObjectViewModel>(x)).ToList();
        return results;
    }

    // GET: api/SpaceObject/5
    [HttpGet("{id}")]
    public ActionResult<SpaceObjectViewModel> GetByID(Guid id)
    {
        var data = Context.SpaceObjects.Find(id);
        if (data == null)
        {
            return NotFound();
        }

        return Mapper.Map<SpaceObjectViewModel>(data);
    }

    // POST: api/SpaceObject
    [HttpPost]
    public ActionResult<SpaceObjectViewModel> Post([FromBody] SpaceObjectEditModel editModel)
    {
        var entity = Mapper.Map<SpaceObjectEntity>(editModel);
        entity.StarSystem = null;
        
        Context.SpaceObjects.Add(entity);
        Context.SaveChanges();

        return Mapper.Map<SpaceObjectViewModel>(entity);
    }

    // PUT: api/SpaceObject/5
    [HttpPut("{id}")]
    public ActionResult<SpaceObjectViewModel> Put(Guid id, [FromBody] SpaceObjectEditModel editModel)
    {
        var entity = Mapper.Map<SpaceObjectEntity>(editModel);
        entity.ID = id;
        
        entity.StarSystem = null;
        
        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();

        return Mapper.Map<SpaceObjectViewModel>(entity);
    }

    // DELETE: api/SpaceObject/5
    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var data = Context.SpaceObjects.Find(id);
        if (data == null)
        {
            return NotFound();
        }

        Context.SpaceObjects.Remove(data);
        Context.SaveChanges();
        
        return NoContent();
    }
}