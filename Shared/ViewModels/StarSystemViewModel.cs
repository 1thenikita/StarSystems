namespace StarSystems.Shared.ViewModels;

public class StarSystemViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public long Age { get; set; }
    public Guid? CenterOfMassesID { get; set; }
    public SpaceObjectViewModel? CenterOfMasses { get; set; }
    public HashSet<SpaceObjectViewModel> SpaceObjects { get; set; } = new();

    public override string ToString()
    {
        return Name;
    }
}