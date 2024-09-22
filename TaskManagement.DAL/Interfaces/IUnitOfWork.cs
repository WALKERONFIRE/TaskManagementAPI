using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DAL.Models;
using Task = TaskManagement.DAL.Models.Task;

namespace TaskManagement.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable

    {
        IAuthRepository Users { get; }
        IBaseRepository<Task> Tasks { get; }
        IBaseRepository<Category> Categories { get; }
        int Complete();

    }
}
