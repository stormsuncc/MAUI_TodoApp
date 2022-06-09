using TodoApp.Services.DataTables;

namespace TodoApp.Services
{
    internal interface ITodoRepository
    {
        Task<List<TaskTable>> GetTasks();
        Task<TaskTable> GetTask(int id);
        Task<int> DeleteTask(int id);
        Task<int> SaveTask(TaskTable taskTable);
    }
}
