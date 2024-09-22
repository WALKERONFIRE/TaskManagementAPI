using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DAL.Models;

namespace TaskManagement.DAL.Interfaces
{
    public interface IAuthRepository : IBaseRepository<ApplicationUser>
    {
        Task<AuthModel> RegisterAsync(ApplicationUser model);
        Task<AuthModel> GetJwtTokenAsync(string identifier, string password);
        Task<string> AddToRoleAsync(AddToRoleModel model);
        Task<string> SaveUserPhotoFileAsync(IFormFile file);
        Task<AuthModel> UpdateUserAsync(string id, ApplicationUser model, IFormFile imageFile);
        Task<string> ChangePasswordAsync(string id, string currentPassword, string newPassword);
        Task<string> DeleteUserAsync(string userId);
    }
}
