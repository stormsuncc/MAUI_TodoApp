using CommunityToolkit.Mvvm.ComponentModel;

namespace TodoApp.ViewModels
{
    public abstract class BaseViewModel
    {
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
            }
        }

    }
}
