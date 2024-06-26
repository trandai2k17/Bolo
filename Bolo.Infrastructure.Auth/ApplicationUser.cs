using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Infrastructure.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string EmployeeID { get; set; }
        public string? EmplName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public string? ProfilePicture { get; set; }
    }
}
