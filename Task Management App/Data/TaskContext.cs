﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagementApp.Models;

namespace TaskManagementApp.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}