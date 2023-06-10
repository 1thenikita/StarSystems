using System.ComponentModel.DataAnnotations;

namespace StarSystems.Shared.Models;


/// <summary>
/// Перечисление типов космических объектов.
/// </summary>
public enum SpaceObjectType
{
    [Display(Name = "Звезда")]
    Star,
    // [Display(Name = "Планета")]
    // Planet,
    [Display(Name = "Чёрная дыра")]
    DarkHole,
}