using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> GetAllUnit(PaginationParameters paginationParameters);
        Unit GetUnitById(Guid unitId);
        void CreateUnit(Unit unit);
        void UpdateUnit(Unit unit);
        void DeleteUnit(Unit unit);
    }
}
