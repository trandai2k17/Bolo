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
        public UnitOfWork(IDapperHelper helper)
        {
            _helper = helper;
        }

        IProductionLine _ProductLineRepository;
        IUserRepository _userRepository;
        public IProductionLine ProductLineRepository { get { return _ProductLineRepository ??= new ProductionLineRepository(_helper); } }
        public IUserRepository userRepository { get { return _userRepository ??= new UserRepository(_helper); } }

        IRepository _repository;
        public IRepository Repository { get { return _repository ??= new Repository(_helper); } }

        public void BeginTransaction()
        {
            _helper.BeginTransaction();
        }

        public void Commit()
        {
            _helper.Commit();
        }

        public void Rollback()
        {
            _helper.Rollback();
        }

        public void Dispose()
        {
            _helper.Dispose();   
        }

        //IEmployeeRepository _employeeRepository;
        //IAccountRepository _AccountRepo;
        //public IEmployeeRepository EmployeeRepository { get { return _employeeRepository ??= new EmployeeRepository(_helper); } }
        //public IAccountRepository AccountRepo { get { return _AccountRepo ??= new AccountRepository(_helper); } }


    }
}
