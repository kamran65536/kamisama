namespace KamiSama.Repositories.EntityFrameworkCore.Histories;

/// <summary>
/// Database Modification type
/// </summary>
public enum DbModificationType
{
    /// <summary>
    /// A new item is added 
    /// </summary>
    Add,
    /// <summary>
    /// An item is updated
    /// </summary>
    Update,
    /// <summary>
    /// An item is deleted
    /// </summary>
    Delete,
}
