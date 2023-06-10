using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarSystems.Server.Entities;
using StarSystems.Shared.EditModels;
using StarSystems.Shared.ViewModels;

namespace StarSystems.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StarSystemController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public StarSystemController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    // GET: api/StarSystem
    [HttpGet]
    public ActionResult<List<StarSystemViewModel>> Get()
    {
        var datas = Context.StarSystems.ToList();
        var results = datas.Select(x => Mapper.Map<StarSystemViewModel>(x)).ToList();
        return results;
    }

    // GET: api/StarSystem/5
    [HttpGet("{id}")]
    public ActionResult<StarSystemViewModel> GetByID(Guid id)
    {
        var data = Context.StarSystems.Find(id);
        if (data == null)
        {
            return NotFound();
        }

        return Mapper.Map<StarSystemViewModel>(data);
    }

    // POST: api/StarSystem
    [HttpPost]
    public ActionResult<StarSystemViewModel> Post([FromBody] StarSystemEditModel editModel)
    {
        var entity = Mapper.Map<StarSystemEntity>(editModel);
        entity.CenterOfMasses = null;
        entity.SpaceObjects.Clear();

        Context.StarSystems.Add(entity);
        Context.SaveChanges();

        return Mapper.Map<StarSystemViewModel>(entity);
    }

    // PUT: api/StarSystem/5
    [HttpPut("{id}")]
    public ActionResult<StarSystemViewModel> Put(Guid id, [FromBody] StarSystemEditModel editModel)
    {
        var entity = Mapper.Map<StarSystemEntity>(editModel);
        entity.ID = id;
        
        entity.CenterOfMasses = null;
        entity.SpaceObjects.Clear();
  
        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();

        return Mapper.Map<StarSystemViewModel>(entity);
    }

    // DELETE: api/StarSystem/5
    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var data = Context.StarSystems.Find(id);
        if (data == null)
        {
            return NotFound();
        }

        Context.StarSystems.Remove(data);
        Context.SaveChanges();
        
        return NoContent();
    }
}