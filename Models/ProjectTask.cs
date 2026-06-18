using SQLite;

namespace ProjectManager.Models;

/// <summary>
/// Представляет задачу в рамках проекта.
/// </summary>
public class ProjectTask
{
    /// <summary>
    /// Уникальный идентификатор задачи.
    /// </summary>
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    /// <summary>
    /// Заголовок задачи.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Описание задачи.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Статус выполнения задачи.
    /// </summary>
    public bool IsCompleted { get; set; }
}