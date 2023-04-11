using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliers(PaginationParameters paginationParameters);
        Supplier GetSupplierById(Guid id);
        void CreateSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
