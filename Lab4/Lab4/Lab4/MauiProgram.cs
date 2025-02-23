using Lab4.Service;
using Lab4.View;
using Lab4.ViewModel;
using Microsoft.Extensions.Logging;

namespace Lab4
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Регистрация сервисов
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Todo.db3");
            builder.Services.AddSingleton<DatabaseService>(s => new DatabaseService(dbPath));

            builder.Services.AddTransient<MainPageVM>();


            // Регистрация ViewModel
            builder.Services.AddTransient<MainPageVM>();


            // Регистрация страницы
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
