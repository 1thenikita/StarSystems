using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarSystems.Shared.Models;

namespace StarSystems.Server.Entities;

/// <summary>
/// Космический объект.
/// </summary>
public class SpaceObjectEntity
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
    /// Тип.
    /// </summary>
    public SpaceObjectType Type { get; set; }

    /// <summary>
    /// ID звёздной системы.
    /// </summary>
    [Required]
    public Guid StarSystemID { get; set; }

    /// <summary>
    /// Сущность звёздной системы.
    /// </summary>
    [ForeignKey(nameof(StarSystemID))]
    public StarSystemEntity? StarSystem { get; set; }
}