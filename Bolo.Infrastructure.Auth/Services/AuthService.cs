using Bolo.Application.Interfaces;
using Bolo.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Infrastructure.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<bool> SignInAsync(ErpUser account)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = account.Email,
                UserName = account.EmployeeID,
                EmployeeID = account.EmployeeID,
            };
            var result = await _signInManager.PasswordSignInAsync(user.UserName, account.Password, true, false);
            return result.Succeeded;
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<bool> RegisterAsync(ErpUser account)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = account.Email,
                UserName = account.EmployeeID,
                EmployeeID = account.EmployeeID,
                EmplName = account.EmployeeName,
            };
            IdentityResult result = await _userManager.CreateAsync(user, account.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return false;
        }

        public async Task<Employee> FindByNameAsync(ErpUser account)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = account.Email,
                UserName = account.EmployeeID,
                EmployeeID = account.EmployeeID,
            };
            user = await _userManager.FindByNameAsync(user.UserName);
            Employee employee = new Employee()
            {
                EmployeeID = user.EmployeeID,
                EmployeeName = user.EmplName,
            };
            return employee;
        }
        public async Task<bool> AddRoleAsync(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            return result.Succeeded;
        }
        public async Task<List<IdentityRole>> Roles()
        {
            return await _roleManager.Roles.ToListAsync();
        }
        public async Task<IdentityRole> GetRoleByName(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }
        public async Task<IdentityRole> GetRoleByID(string RoleID)
        {
            return await _roleManager.FindByIdAsync(RoleID);
        }
        public async Task<bool> UpdateRoleAsync(IdentityRole role)
        {
            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
        public async Task<bool> DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id.Trim());
            if (role == null) { return false; }
            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

    }
}
