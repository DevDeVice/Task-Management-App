using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetTasks();
        Task<TaskItem> GetTaskItem(int id);
        Task<TaskItem> AddTaskItem(TaskItem taskItem);
        Task<TaskItem> UpdateTaskItem(int id, TaskItem taskItem);
        Task<bool> DeleteTaskItem(int id);
    }
}
