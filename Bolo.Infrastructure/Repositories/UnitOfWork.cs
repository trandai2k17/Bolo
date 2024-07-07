using Bolo.Application.Interfaces;
using Bolo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Infrastructure.Repositories
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly IDapperHelper _helper;
        public UnitOfWork(IDapperHelper helper)
        {
            _helper = helper;
        }
        private bool disposedValue;
        IProductionLine _ProductionLine;
        public IProductionLine ProductionLineRepo { get { return _ProductionLine ??= new ProductionLineRepository(_helper); } }

        //IEmployeeRepository _employeeRepository;
        //IAccountRepository _AccountRepo;
        //public IEmployeeRepository EmployeeRepository { get { return _employeeRepository ??= new EmployeeRepository(_helper); } }
        //public IAccountRepository AccountRepo { get { return _AccountRepo ??= new AccountRepository(_helper); } }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
