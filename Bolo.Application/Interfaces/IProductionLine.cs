using Bolo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Application.Interfaces
{
    public interface IProductionLine
    {
        Task<List<ProductionLine>> LocationsAsync();
    }
}
