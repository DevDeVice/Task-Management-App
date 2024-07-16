using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskContext _context;

        public TaskService(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetTasks()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem> GetTaskItem(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task<TaskItem> AddTaskItem(TaskItem taskItem)
        {
            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<TaskItem> UpdateTaskItem(int id, TaskItem taskItem)
        {
            _context.Entry(taskItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<bool> DeleteTaskItem(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return false;
            }

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
