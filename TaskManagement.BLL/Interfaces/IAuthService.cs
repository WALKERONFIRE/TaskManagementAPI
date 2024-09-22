using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.DTOs;
using TaskManagement.DAL.Models;

namespace TaskManagement.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(ApplicationUserDTO model);
        Task<AuthModel> GetJwtToken(LoginDTO model);
        Task<string> AddToRoleAsync(AddToRoleModel model);
        Task<string> SaveUserPhotoFileAsync(IFormFile file);
        Task<AuthModel> UpdateUserAsync(string id, EditUserDTO model, IFormFile imageFile);
        Task<string> ChangePasswordAsync(string id, string currentPassword, string newPassword);
        Task<string> DeleteUserAsync(string userId);
        Task<ApplicationUserDisplayDTO> GetUserByIdAsync(string id);
        Task<IEnumerable<ApplicationUserDisplayDTO>> SearchUsersByRoleAsync(string role);
        Task<IEnumerable<ApplicationUserDisplayDTO>> SearchUsersByNameAsync(string name);
    }
}
