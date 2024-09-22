using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DAL.Enums;

namespace TaskManagement.BLL.DTOs
{
    public class ApplicationUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public IFormFile? ProfilePictureUrl { get; set; }
        public UserType? UserType { get; set; }
    }
}
