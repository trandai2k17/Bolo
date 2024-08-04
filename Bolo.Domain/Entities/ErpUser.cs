using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Domain.Entities
{
    public class ErpUser
    {
        public string ReturnUrl { get; set; }
        public string UserName { get; set; }
        public string? EmployeeName { get; set; }
        [Required]
        public string EmployeeID { get; set; }
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; } = false;
        public string? NormalizedUserName { get; set; }
        public bool Active { get; set; } = true;

    }
}
