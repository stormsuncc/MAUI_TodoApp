using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp.Pages;

public partial class TaskDetailPage : ContentPage
{
    public TaskDetailPage(TaskDetailPageViewModel vm)
    {
        InitializeComponent();
        var hash = vm.GetHashCode();
        BindingContext = vm;
    }
}