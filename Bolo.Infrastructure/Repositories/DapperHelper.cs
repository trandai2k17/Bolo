using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Bolo.Application.Interfaces;

namespace Bolo.Infrastructure.Repositories
{
    public class DapperHelper : IDapperHelper
    {
        private readonly string _connectStr = string.Empty;
        private readonly string _connectAW2019Str = string.Empty;

        private IDbConnection _connection1;
        private IDbConnection _connection2;
        private IDbTransaction _transaction1;
        private IDbTransaction _transaction2;

        public DapperHelper(IDbConnection connection1, IDbConnection connection2)
        {
            _connection1 = connection1;
            _connection2 = connection2;
        }

        public void SetTransaction(IDbTransaction transaction1, IDbTransaction transaction2)
        {
            _transaction1 = transaction1;
            _transaction2 = transaction2;
        }

        public void Commit()
        {
            _transaction1?.Commit();
            _transaction2?.Commit();
        }

        public void Rollback()
        {
            _transaction1?.Rollback();
            _transaction2?.Rollback();
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, DynamicParameters? param = null, IDbConnection? connection = null)
        {
            using (var conn = connection ?? _connection1)
            {
                return await conn.QueryAsync<T>(query, param, _transaction1);
            }
        }

        public async Task<T> QuerySingleAsync<T>(string query, DynamicParameters? param = null, IDbConnection? connection = null)
        {
            using (var conn = connection ?? _connection1)
            {
                return await conn.QuerySingleAsync<T>(query, param, _transaction1);
            }
        }

        public async Task<int> ExecuteAsync(string query, DynamicParameters? param = null, IDbConnection? connection = null)
        {
            using (var conn = connection ?? _connection1)
            {
                return await conn.ExecuteAsync(query, param, _transaction1);
            }
        }

        public async Task<IEnumerable<T>> QueryStoreAsync<T>(string query, DynamicParameters? param = null, IDbConnection? connection = null)
        {
            using (var conn = connection ?? _connection1)
            {
                return await conn.QueryAsync<T>(query, param, _transaction1, commandType:CommandType.StoredProcedure);
            }
        }

        public async Task<T> QuerySingleStoreAsync<T>(string query, DynamicParameters? param = null, IDbConnection? connection = null)
        {
            using (var conn = connection ?? _connection1)
            {
                return await conn.QuerySingleAsync<T>(query, param, _transaction1, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> ExecuteStoreAsync(string query, DynamicParameters? param = null, IDbConnection? connection = null)
        {
            using (var conn = connection ?? _connection1)
            {
                return await conn.ExecuteAsync(query, param, _transaction1, commandType: CommandType.StoredProcedure);
            }
        }

        //public void ExecuteNoReturn(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text)
        //{
        //    using (var dbConnection = new SqlConnection(_connectStr))
        //    {
        //        dbConnection.Execute(query, parameters, commandType: commandTypes);
        //    }
        //}
        //public async Task ExecuteNoReturnAsync(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text)
        //{
        //    using (var dbConnection = new SqlConnection(_connectStr))
        //    {
        //        await dbConnection.ExecuteAsync(query, parameters, commandType: commandTypes);
        //    }
        //}

        //public async Task<IEnumerable<T>> ExecuteQueryIEnumerableAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text)
        //{
        //    using (var dbConnection = new SqlConnection(_connectStr))
        //    {
        //        return await dbConnection.QueryAsync<T>(query, parameters, commandType: commandType);
        //    }
        //}

        //public async Task<List<T>> ExecuteQueryListAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text)
        //{
        //    using (var dbConnection = new SqlConnection(_connectStr))
        //    {
        //        return (List<T>)await dbConnection.QueryAsync<T>(query, parameters, commandType: commandType);
        //    }
        //}

        //public async Task<T> ExecuteQueryFirstAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text)
        //{
        //    using (var dbConnection = new SqlConnection(_connectStr))
        //    {
        //        var result = await dbConnection.QueryFirstOrDefaultAsync<T>(query, parameters, commandType: commandType);
        //        return result;
        //    }
        //}
        //public T ExecuteQueryFirst<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text)
        //{
        //    using (var dbConnection = new SqlConnection(_connectStr))
        //    {
        //        return dbConnection.QueryFirstOrDefault<T>(query, parameters, commandType: commandType);
        //    }
        //}
        //public async Task<T> ExecuteScalarAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text)
        //{
        //    using (var dbConnection = new SqlConnection(_connectStr))
        //    {
        //        var result = await dbConnection.ExecuteScalarAsync(query, parameters, commandType: commandTypes);
        //        if (Convert.IsDBNull(result) || result == null)
        //        {
        //            return default(T);
        //        }
        //        return (T)Convert.ChangeType(result, typeof(T));
        //    }
        //}
    }
}
