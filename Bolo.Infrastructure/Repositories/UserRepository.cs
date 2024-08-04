using Bolo.Application.Interfaces;
using Bolo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Infrastructure.Repositories
{
    public class UserRepository:  IUserRepository
    {
        private readonly IDapperHelper _dapper;
        public UserRepository(IDapperHelper dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<ErpUser>> AccountsAsync()
        {
            string query = @"SELECT U.EmployeeID, U.EmplName, U.UserName, U.NormalizedUserName, U.NormalizedEmail, U.Email FROM MyDB1021.dbo.Web_User U
            OUTER APPLY (SELECT * FROM MyDB1021.dbo.HR_Employee WHERE U.EmployeeID=EmployeeID ) H ";
            return await _dapper.QueryAsync<ErpUser>(query,null, null);
        }

    }
}
