using SQLite;
using ProjectManager.Models;

namespace ProjectManager.Services;

/// <summary>
/// Сервис для работы с базой данных SQLite.
/// </summary>
public class DatabaseService
{
    private SQLiteAsyncConnection? _database;
    private readonly string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "Tasks.db3");

    /// <summary>
    /// Инициализирует соединение с базой данных.
    /// </summary>
    private async Task InitializeAsync()
    {
        if (_database is not null) return;
        _database = new SQLiteAsyncConnection(_dbPath);
        await _database.CreateTableAsync<ProjectTask>();
    }

    /// <summary>
    /// Получает список всех задач из базы данных.
    /// </summary>
    public async Task<List<ProjectTask>> GetTasksAsync()
    {
        await InitializeAsync();
        return await _database!.Table<ProjectTask>().ToListAsync();
    }

    /// <summary>
    /// Добавляет новую задачу в базу данных.
    /// </summary>
    public async Task AddTaskAsync(ProjectTask task)
    {
        await InitializeAsync();
        await _database!.InsertAsync(task);
    }

    /// <summary>
    /// Обновляет существующую задачу в базу данных.
    /// </summary>
    public async Task UpdateTaskAsync(ProjectTask task)
    {
        await InitializeAsync();
        await _database!.UpdateAsync(task);
    }

    /// <summary>
    /// Удаляет задачу из базы данных.
    /// </summary>
    public async Task DeleteTaskAsync(ProjectTask task)
    {
        await InitializeAsync();
        await _database!.DeleteAsync(task);
    }
}