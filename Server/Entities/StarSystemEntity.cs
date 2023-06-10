using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarSystems.Server.Entities;

/// <summary>
/// Сущность звёздной системы.
/// </summary>
public class StarSystemEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Возраст.
    /// </summary>
    [Required]
    public long Age { get; set; }

    /// <summary>
    /// ID центра масс.
    /// </summary>
    public Guid? CenterOfMassesID { get; set; }

    /// <summary>
    /// Сущность центра масс.
    /// </summary>
    [ForeignKey(nameof(CenterOfMassesID))]
    public SpaceObjectEntity? CenterOfMasses { get; set; }

    /// <summary>
    /// Список космических объектов.
    /// </summary>
    public HashSet<SpaceObjectEntity> SpaceObjects { get; set; } = new();
}