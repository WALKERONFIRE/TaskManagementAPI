using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DAL.Data;
using TaskManagement.DAL.Interfaces;
using TaskManagement.DAL.Models;
using Task = TaskManagement.DAL.Models.Task;

namespace TaskManagement.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context , IBaseRepository<Task> tasks , IAuthRepository users , IBaseRepository<Category> categories)
        {
            _context = context;
            Tasks = tasks;
            Users = users;
            Categories = categories;
        }

        public IBaseRepository<Category> Categories { get; private set; }
        public IBaseRepository<Task> Tasks { get; private set; }
        public IAuthRepository Users { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
