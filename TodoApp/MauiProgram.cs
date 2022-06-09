using CommunityToolkit.Maui;
using TodoApp.ViewModels;
using TodoApp.Pages;

namespace TodoApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // Initialise the toolkit
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        

        builder.Services.AddSingleton<AppShell>();

        builder.ConfigureViewModels();
        builder.ConfigurePages();

        return builder.Build();
    }
}
