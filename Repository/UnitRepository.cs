using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Unit> GetAllUnit(PaginationParameters paginationParameters)
        {
            return FindAll()
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();
        }

        public Unit GetUnitById(Guid id)
        {
            return FindByCondition(unit => unit.Id.Equals(id))
                .FirstOrDefault();
        }

        public void CreateUnit(Unit unit) => Create(unit);
        public void UpdateUnit(Unit unit) => Update(unit);
        public void DeleteUnit(Unit unit) => Delete(unit);
    }
}
