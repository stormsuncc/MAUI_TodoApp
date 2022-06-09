using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TodoApp.Extensions;
using TodoApp.Models;
using TodoApp.Services;
using TodoApp.Services.DataTables;
using TodoApp.Pages;

namespace TodoApp.ViewModels
{

    [INotifyPropertyChanged]
    public partial class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<TaskModel> TaskModels { private set; get; }
            = new ObservableCollection<TaskModel>();

        public MainPageViewModel()
        {

        }

        [RelayCommand]
        async void TaskTapped(TaskModel taskModel)
        {
            if (IsBusy) return;
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(TaskDetailPage), true, 
                new Dictionary<string, object>() 
                {
                    ["TaskModel"] = taskModel,
                });
            IsBusy = false;
        }

        [RelayCommand]
        void IsCompleteTapped(TaskModel taskModel)
        {
            Task.Run(async () =>
            {
                var service = await TodoService.Instance;
                await service.SaveTask(taskModel.Tasktable);
            });
        }
        [RelayCommand]
        async void AddTapped()
        {
            if (IsBusy) return;
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(TaskDetailPage));
            IsBusy = false;
        }

        internal void Refresh()
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            Task.Run<List<TaskTable>>(async () =>
            {
                var service = await TodoService.Instance;
                var tasks = await service.GetTasks();
                tasks.Sort((t1, t2) =>
                {
                    if (t1.IsComplete == t2.IsComplete)
                    {
                        return t1.Id < t2.Id ? -1 : 1;
                    }
                    else if (t1.IsComplete)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                });
                return tasks;
            }).
            ContinueInMainThreadWith((taskTables) =>
            {
                TaskModels.Clear();
                if (taskTables != null && taskTables.Count > 0)
                {
                    taskTables.ForEach((t) => { TaskModels.Add(new TaskModel(t)); });
                }

                IsBusy = false;
            });



        }
    }
}
