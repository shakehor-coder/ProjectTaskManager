using ProjectManager.ViewModels;

namespace ProjectManager.Views;

/// <summary>
/// Главная страница приложения для отображения и управления списком задач.
/// </summary>
public partial class MainPage : ContentPage
{
    /// <summary>
    /// Инициализирует новый экземпляр класса MainPage.
    /// </summary>
    /// <param name="viewModel">Экземпляр ViewModel, внедряемый через DI-контейнер.</param>
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}