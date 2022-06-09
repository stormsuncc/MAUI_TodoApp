using TodoApp.Pages;

namespace TodoApp;

public partial class App : Application
{
    public App(AppShell shell)
    {
        InitializeComponent();

        MainPage = shell;

        Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
    }
}
