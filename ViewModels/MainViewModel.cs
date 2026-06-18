using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Models;
using ProjectManager.Services;

namespace ProjectManager.ViewModels;

/// <summary>
/// ViewModel для управления списком задач проекта.
/// Реализует логику взаимодействия с базой данных и обновление UI.
/// </summary>
public partial class MainViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    /// <summary>
    /// Коллекция задач, отображаемая в интерфейсе.
    /// </summary>
    public ObservableCollection<ProjectTask> Tasks { get; } = new();

    [ObservableProperty]
    private string _newTaskTitle = string.Empty;

    /// <summary>
    /// Инициализирует новый экземпляр ViewModel.
    /// </summary>
    /// <param name="databaseService">Сервис для работы с БД.</param>
    public MainViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        _ = LoadTasksAsync();
    }

    /// <summary>
    /// Команда для загрузки всех задач из базы данных.
    /// </summary>
    [RelayCommand]
    private async Task LoadTasksAsync()
    {
        var tasks = await _databaseService.GetTasksAsync();
        Tasks.Clear();
        foreach (var task in tasks)
        {
            Tasks.Add(task);
        }
    }

    /// <summary>
    /// Команда для добавления новой задачи.
    /// </summary>
    [RelayCommand]
    private async Task AddTaskAsync()
    {
        if (string.IsNullOrWhiteSpace(NewTaskTitle))
            return;

        var newTask = new ProjectTask
        {
            Title = NewTaskTitle,
            Description = "Новая задача",
            IsCompleted = false
        };

        await _databaseService.AddTaskAsync(newTask);
        Tasks.Add(newTask);
        NewTaskTitle = string.Empty;
    }

    /// <summary>
    /// Команда для удаления задачи.
    /// </summary>
    /// <param name="task">Задача для удаления.</param>
    [RelayCommand]
    private async Task DeleteTaskAsync(ProjectTask task)
    {
        if (task == null) return;

        await _databaseService.DeleteTaskAsync(task);
        Tasks.Remove(task);
    }

    /// <summary>
    /// Команда для переключения статуса выполнения задачи.
    /// </summary>
    /// <param name="task">Задача для обновления.</param>
    [RelayCommand]
    private async Task ToggleTaskAsync(ProjectTask task)
    {
        if (task == null) return;

        task.IsCompleted = !task.IsCompleted;
        await _databaseService.UpdateTaskAsync(task);
        
        int index = Tasks.IndexOf(task);
        if (index != -1)
        {
            Tasks[index] = task;
        }
    }
}