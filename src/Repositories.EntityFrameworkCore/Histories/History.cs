using System;

namespace KamiSama.Repositories.EntityFrameworkCore.Histories;

/// <summary>
/// Representing the history of an entity
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class History<TEntity>
{
    /// <summary>
    /// Unique Id for entity history
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Modification Time (UTC Time)
    /// </summary>
    public DateTime ModificationUtcTime { get; set; }
    /// <summary>
    /// Modification Time
    /// </summary>
    public DateTime ModificationTime { get; set; }
    /// <summary>
    /// Modification Type
    /// </summary>
    public DbModificationType ModificationType { get; set; }
    /// <summary>
    /// Original Entity
    /// </summary>
    public required TEntity Entity { get; set; }
    /// <summary>
    /// Creates an History item from <paramref name="entity"/>
    /// </summary>
    /// <param name="entity">the entity for history</param>
    /// <param name="modificationType">modification type</param>
    /// <returns></returns>
    public static History<TEntity> CreateFrom(TEntity entity, DbModificationType modificationType)
    {
        return new History<TEntity>
        {
            Id = Guid.NewGuid(),
            ModificationUtcTime = DateTime.UtcNow,
            ModificationTime = DateTime.Now,
            Entity = entity,
            ModificationType = modificationType
        };
    }
}
