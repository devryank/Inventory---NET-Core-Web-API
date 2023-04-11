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
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(RepositoryContext repositoryContext) 
            :base(repositoryContext) { }

        public IEnumerable<Supplier> GetSuppliers(PaginationParameters paginationParameters)
        {
            return FindAll()
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();
        }

        public Supplier GetSupplierById(Guid id)
        {
            return FindByCondition(supplier => supplier.Id.Equals(id))
                .FirstOrDefault();
        }

        public void CreateSupplier(Supplier supplier) => Create(supplier);
        public void UpdateSupplier(Supplier supplier) => Update(supplier);
        public void DeleteSupplier(Supplier supplier) => Delete(supplier);
    }
}
