using StarSystems.Shared.Models;

namespace StarSystems.Shared.ViewModels;

public class SpaceObjectViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public long Age { get; set; }
    public SpaceObjectType Type { get; set; }
    public Guid StarSystemID { get; set; }
    public StarSystemViewModel? StarSystem { get; set; }

    public override string ToString()
    {
        return Name;
    }
}