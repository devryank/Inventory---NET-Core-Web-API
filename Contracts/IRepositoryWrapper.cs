using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISupplierRepository Supplier { get; }
        IUnitRepository Unit { get; }
        IItemCategoryRepository ItemCategory { get; }
        IItemRepository Item { get; }
        IInboundRepository Inbound { get; }
        IOutboundRepository Outbound { get; }
        void Save();
    }
}
