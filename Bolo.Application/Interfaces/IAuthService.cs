using Bolo.Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace Bolo.Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> AddRoleAsync(string roleName);
        Task<Employee> FindByNameAsync(Account account);
        Task<bool> RegisterAsync(Account account);
        Task<List<IdentityRole>> Roles();
        Task<bool> SignInAsync(Account account);
        Task SignOutAsync();
        Task<bool> DeleteRoleAsync(string id);
        Task<bool> UpdateRoleAsync(IdentityRole role);
        Task<IdentityRole> GetRoleByName(string roleName);
        Task<IdentityRole> GetRoleByID(string RoleID);
    }
}
