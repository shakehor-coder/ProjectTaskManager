using Microsoft.Extensions.Logging;
using ProjectManager.Services;
using ProjectManager.ViewModels;
using ProjectManager.Views;

namespace ProjectManager;

/// <summary>
/// Класс конфигурации приложения, отвечающий за инициализацию DI-контейнера и сервисов.
/// </summary>
public static class MauiProgram
{
    /// <summary>
    /// Создает и настраивает экземпляр приложения.
    /// </summary>
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Регистрация сервисов согласно требованиям: DatabaseService как Singleton, страницы как Transient.
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}