using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.BLL.DTOs
{
    public class CategoryDisplayDTO
    {
        public string Name { get; set; }
        public List<TaskModel> Tasks { get; set; }
    }
}
