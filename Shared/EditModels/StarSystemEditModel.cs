using System.ComponentModel.DataAnnotations;
using StarSystems.Shared.ViewModels;

namespace StarSystems.Shared.EditModels;

public class StarSystemEditModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public long Age { get; set; }
    public Guid? CenterOfMassesID { get; set; }
    public SpaceObjectViewModel? CenterOfMasses { get; set; }
    public HashSet<SpaceObjectViewModel> SpaceObjects { get; set; } = new();
}