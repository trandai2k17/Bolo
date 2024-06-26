using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Infrastructure.DapperContext
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectStr;
        public DapperDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectStr = configuration.GetConnectionString("DBConnectionString");
        }

        public IDbConnection Connection() => new SqlConnection(_connectStr);
    }
}
