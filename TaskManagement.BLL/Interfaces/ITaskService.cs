﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.DTOs;

namespace TaskManagement.BLL.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDTO> GetTaskByIdAsync(string id);
        Task<int> CountAsync (); 
        Task<IEnumerable<TaskDTO>> GetAllTasksAsync();
        Task<IEnumerable<TaskDTO>> SearchTasksAsync(string keyword, bool? isCompleted = null);
        Task<IEnumerable<TaskDTO>> GetTasksByCategoryIdAsync(string categoryId);
        Task<TaskDTO> AddTaskAsync(TaskDTO taskDto);
        Task<EditTaskDTO> UpdateTaskAsync(string id, EditTaskDTO taskDto);
        Task DeleteTaskAsync(string id);
    }
}
