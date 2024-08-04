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
    public class Repository : IRepository
    {
        private readonly IDapperHelper _dapperHelper;

        public Repository(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            string sql = "SELECT * FROM MyTable";
            return await _dapperHelper.QueryAsync<Employee>(sql, null);
        }

        public async Task<Employee> GetBusinessDataAsync()
        {
            _dapperHelper.BeginTransaction();

            try
            {
                // Execute operations on the first database
                var data1 = await _dapperHelper.QueryAsync<Employee>("SELECT * FROM Table1");

                // Execute operations on the second database
                var data2 = await _dapperHelper.QueryAsync<Employee>("SELECT * FROM Table2");

                _dapperHelper.Commit();
                var obj = data1.Concat(data2);
                // Combine data from both databases
                return new Employee();
            }
            catch (Exception)
            {
                _dapperHelper.Rollback();
                throw;
            }
        }


        //public async Task<Employee> GetByIdAsync(int id,)
        //{
        //    string sql = "SELECT * FROM MyTable WHERE Id = @Id";
        //    return await _dapperHelper.QuerySingleAsync<Employee>(sql,);
        //}

        //public async Task<int> AddAsync(Employee entity, IDbConnection connection = null)
        //{
        //    string sql = "INSERT INTO MyTable (Column1, Column2) VALUES (@Value1, @Value2)";
        //    return await _dapperHelper.ExecuteAsync(sql, , connection);
        //}

        //public async Task<int> UpdateAsync(T entity, IDbConnection connection = null)
        //{
        //    string sql = "UPDATE MyTable SET Column1 = @Value1, Column2 = @Value2 WHERE Id = @Id";
        //    return await _dapperHelper.ExecuteAsync(sql, entity, connection);
        //}

        //public async Task<int> DeleteAsync(int id, IDbConnection connection = null)
        //{
        //    string sql = "DELETE FROM MyTable WHERE Id = @Id";
        //    return await _dapperHelper.ExecuteAsync(sql, new { Id = id }, connection);
        //}
    }
}
