using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DAL.Enums;

namespace TaskManagement.DAL.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Country { get; set; }
        public UserType? UserType { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
