using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}   