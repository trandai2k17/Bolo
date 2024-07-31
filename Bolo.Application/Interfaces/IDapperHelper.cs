using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Application.Interfaces
{
    public interface IDapperHelper
    {
        void SetTransaction(IDbTransaction transaction1, IDbTransaction transaction2);
        void Commit();
        void Rollback();

        Task<IEnumerable<T>> QueryAsync<T>(string query, DynamicParameters? param = null, IDbConnection? connection = null);
        Task<T> QuerySingleAsync<T>(string query, DynamicParameters? param = null, IDbConnection? connection = null);
        Task<int> ExecuteAsync(string query, DynamicParameters? param = null, IDbConnection? connection = null);
        Task<IEnumerable<T>> QueryStoreAsync<T>(string query, DynamicParameters? param = null, IDbConnection? connection = null);
        Task<T> QuerySingleStoreAsync<T>(string query, DynamicParameters? param = null, IDbConnection? connection = null);
        Task<int> ExecuteStoreAsync(string query, DynamicParameters? param = null, IDbConnection? connection = null);

        //void ExecuteNoReturn(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text);
        //Task ExecuteNoReturnAsync(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text);
        ////Task<T> ExecuteQueryFirst<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        //T ExecuteQueryFirst<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        //Task<T> ExecuteQueryFirstAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        //Task<IEnumerable<T>> ExecuteQueryIEnumerableAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        //Task<List<T>> ExecuteQueryListAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandType = CommandType.Text);
        //Task<T> ExecuteScalarAsync<T>(string query, DynamicParameters? parameters = null, CommandType commandTypes = CommandType.Text);
    }
}
