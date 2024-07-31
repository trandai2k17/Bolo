using Bolo.Application.Interfaces;
using Bolo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Bolo.Infrastructure.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDapperHelper _helper;
        private readonly IDbConnection _connection1;
        private readonly IDbConnection _connection2;
        private IDbTransaction _transaction1;
        private IDbTransaction _transaction2;

        public UnitOfWork(IDapperHelper helper)
        {
            _helper = helper;
        }

        public void BeginTransaction()
        {
            _connection1.Open();
            _connection2.Open();

            _transaction1 = _connection1.BeginTransaction();
            _transaction2 = _connection2.BeginTransaction();

            _helper.SetTransaction(_transaction1, _transaction2);

        }

        public void Commit()
        {
            try
            {
                _transaction1?.Commit();
                _transaction2?.Commit();
            }
            finally
            {
                _connection1.Close();
                _connection2.Close();
                _transaction1 = null;
                _transaction2 = null;
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction1?.Rollback();
                _transaction2?.Rollback();
            }
            finally
            {
                _connection1.Close();
                _connection2.Close();
                _transaction1 = null;
                _transaction2 = null;
            }
        }

        public async Task ExecuteStoredProceduresAsync()
        {
            // Execute stored procedure on the first database
            await _helper.ExecuteStoredProcedureAsync("sp_DoSomethingInDb1", new { Param1 = "Value1" }, connection: _connection1);

            // Execute stored procedure on the second database
            await _helper.ExecuteStoredProcedureAsync("sp_DoSomethingInDb2", new { Param2 = "Value2" }, connection: _connection2);
        }

        public void Dispose()
        {
            _connection1?.Dispose();
            _connection2?.Dispose();
            _transaction1?.Dispose();
            _transaction2?.Dispose();
        }

        private bool disposedValue;
        IProductionLine _ProductionLine;
        public IProductionLine ProductionLineRepo { get { return _ProductionLine ??= new ProductionLineRepository(_helper); } }

        //IEmployeeRepository _employeeRepository;
        //IAccountRepository _AccountRepo;
        //public IEmployeeRepository EmployeeRepository { get { return _employeeRepository ??= new EmployeeRepository(_helper); } }
        //public IAccountRepository AccountRepo { get { return _AccountRepo ??= new AccountRepository(_helper); } }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposedValue)
        //    {
        //        if (disposing)
        //        {
        //            // TODO: dispose managed state (managed objects)
        //        }

        //        // TODO: free unmanaged resources (unmanaged objects) and override finalizer
        //        // TODO: set large fields to null
        //        disposedValue = true;
        //    }
        //}

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        //public void Dispose()
        //{
        //    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //    Dispose(disposing: true);
        //    GC.SuppressFinalize(this);
        //}

        
    }
}
