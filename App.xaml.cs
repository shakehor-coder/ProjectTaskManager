namespace ProjectManager;

/// <summary>
/// Основной класс приложения, представляющий точку входа.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Инициализирует новый экземпляр класса App.
    /// </summary>
    public App()
    {
        InitializeComponent();

        // Установка главной страницы приложения через Shell.
        MainPage = new AppShell();
    }
}