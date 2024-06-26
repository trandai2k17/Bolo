using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Domain.Entities
{
    public class UserInfo
    {
        public string? UserName { get; set; }
        [NotMapped]
        public string? EmplName { get; set; }
        public string? EmployeeID { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? GroupID { get; set; }
        public bool Active { get; set; } = true;
        public string? EmplID { get; set; }
    }
}
