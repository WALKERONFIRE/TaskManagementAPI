using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagement.BLL.Interfaces;
using TaskManagement.BLL.Mapper;
using TaskManagement.BLL.Services;
using TaskManagement.DAL.Data;
using TaskManagement.DAL.Interfaces;
using TaskManagement.DAL.Repositories;
using TaskManagement.LL.Interfaces;
using TaskManagement.LL.Services;

namespace TaskManagement.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
           

        }

        public static void AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMapper, Mapper>();            
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddHttpContextAccessor();
        }
    }
}
