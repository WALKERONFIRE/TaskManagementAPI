using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TaskManagement.BLL.DTOs;
using TaskManagement.BLL.Interfaces;
using TaskManagement.DAL.Enums;
using TaskManagement.DAL.Interfaces;
using TaskManagement.DAL.Models;

namespace TaskManagement.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IMapper mapper, IUnitOfWork unitOfWork)
        {

   
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthModel> RegisterAsync(ApplicationUserDTO dto)
        {
            try
            {
                var user = _mapper.Map<ApplicationUser>(dto);
                if (user.ProfilePictureUrl != null)
                {
                    user.ProfilePictureUrl = await _unitOfWork.Users.SaveUserPhotoFileAsync(dto.ProfilePictureUrl);
                }
                user.UserType = UserType.User;


                return await _unitOfWork.Users.RegisterAsync(user);
            }
            catch (Exception ex)
            {
                return new AuthModel { Massage = "An error occurred while registering the user: " + ex.Message };
            }
        }

        public async Task<AuthModel> GetJwtToken(LoginDTO dto)
        {
            try
            {
                return await _unitOfWork.Users.GetJwtTokenAsync(dto.Identifier, dto.Password);
            }
            catch (Exception ex)
            {
                return new AuthModel { Massage = "An error occurred while retrieving the token: " + ex.Message };
            }
        }

        public async Task<string> AddToRoleAsync(AddToRoleModel dto)
        {
            try
            {
                return await _unitOfWork.Users.AddToRoleAsync(dto);
            }
            catch (Exception ex)
            {
                return "An error occurred while adding the user to the role: " + ex.Message;
            }
        }

        public async Task<string> SaveUserPhotoFileAsync(IFormFile file)
        {
            try
            {
                return await _unitOfWork.Users.SaveUserPhotoFileAsync(file);
            }
            catch (Exception ex)
            {
                return "An error occurred while saving the user photo: " + ex.Message;
            }
        }

        public async Task<AuthModel> UpdateUserAsync(string id, EditUserDTO dto, IFormFile imageFile)
        {
            try
            {
                var user = _mapper.Map<ApplicationUser>(dto);

                return await _unitOfWork.Users.UpdateUserAsync(id, user, imageFile);
            }
            catch (Exception ex)
            {
                return new AuthModel { Massage = "An error occurred while updating the user: " + ex.Message };
            }
        }

        public async Task<string> ChangePasswordAsync(string id, string currentPassword, string newPassword)
        {
            try
            {
                return await _unitOfWork.Users.ChangePasswordAsync(id, currentPassword, newPassword);
            }
            catch (Exception ex)
            {
                return "An error occurred while changing the password: " + ex.Message;
            }
        }

        public async Task<string> DeleteUserAsync(string userId)
        {
            try
            {
                return await _unitOfWork.Users.DeleteUserAsync(userId);
            }
            catch (Exception ex)
            {
                return "An error occurred while deleting the user: " + ex.Message;
            }
        }

        public async Task<ApplicationUserDisplayDTO> GetUserByIdAsync(string id)
        {
            var user = await _unitOfWork.Users.FindAsync(
            x=>x.Id == id,
            includes : new[] { "Tasks" }          
            );
            if (user == null) throw new Exception("User not found.");
            return _mapper.Map<ApplicationUserDisplayDTO>(user);
        }

        public async Task<IEnumerable<ApplicationUserDisplayDTO>> SearchUsersByRoleAsync(string role)
        {
            if (!Enum.TryParse<UserType>(role, out var userType))
            {
                throw new ArgumentException($"Invalid role: {role}");
            }
            var users = await _unitOfWork.Users.FindAllAsync(user => user.UserType == userType);
            var userDTOs = _mapper.Map<IEnumerable<ApplicationUserDisplayDTO>>(users);

            return userDTOs;
        }

        public async Task<IEnumerable<ApplicationUserDisplayDTO>> SearchUsersByNameAsync(string name)
        {
            var users =  await _unitOfWork.Users.FindAllAsync(user => user.Name.Contains(name));
            return _mapper.Map<IEnumerable<ApplicationUserDisplayDTO>>(users);

        }
    }
}
