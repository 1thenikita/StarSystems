using System.ComponentModel.DataAnnotations;
using StarSystems.Shared.Models;
using StarSystems.Shared.ViewModels;

namespace StarSystems.Shared.EditModels;

public class SpaceObjectEditModel
{
    [Required] public string Name { get; set; }
    [Required] public long Age { get; set; }
    public SpaceObjectType Type { get; set; }
    [Required] public Guid StarSystemID { get; set; }
    public StarSystemViewModel? StarSystem { get; set; }
}