using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoApp.Extensions;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.ViewModels
{

    [INotifyPropertyChanged]
    [QueryProperty(nameof(TaskModel), nameof(TaskModel))]
    public partial class TaskDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private TaskModel taskModel;

        public TaskDetailPageViewModel()
        {
            TaskModel = new TaskModel();
        }

        [RelayCommand]
        void Save()
        {
            var t = Task.Run(async () =>
            {
                var service = await TodoService.Instance;
                await service.SaveTask(TaskModel.Tasktable);
            }).
                ContinueInMainThreadWith(async () =>
                {
                    await Shell.Current.GoToAsync("..");
                });
        }
        [RelayCommand]
        void Delete()
        {
            Task.Run(async () =>
            {
                var service = await TodoService.Instance;
                await service.DeleteTask(TaskModel.Id);

            }).ContinueInMainThreadWith(async () =>
            {
                await Shell.Current.GoToAsync("..");
            });
        }

        [RelayCommand]
        async void Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
