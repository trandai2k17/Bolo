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
    public class ProductionLineRepository : IProductionLine
    {
        private readonly IDapperHelper _dapper;
        public ProductionLineRepository(IDapperHelper dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<ProductionLine>> LocationsAsync()
        {
            string query = @"SELECT ProductionGroup, ProductionLine ProductionLineName, Location, LocationLine FROM FAC_Location ";
            query += " ORDER BY ProductionGroup, ProductionLine, Location";
            return await _dapper.QueryAsync<ProductionLine>(query, null, null);
        }

    }
}
