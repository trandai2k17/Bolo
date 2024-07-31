using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Application.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        //IAccountRepository AccountRepo { get; }
        //IEmployeeRepository EmployeeRepository { get; }
        //IProductionLine ProductionLineRepo { get; }
        //IEmployeeRepository EmployeeRepository { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
