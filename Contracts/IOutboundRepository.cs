using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOutboundRepository
    {
        IEnumerable<Outbound> GetAllOutbound(PaginationParameters paginationParameters);
        Outbound GetOutboundById(Guid id);
        Outbound GetOutboundWithRelation(Guid id);
        void CreateOutbound(Outbound Outbound);
        void UpdateOutbound(Outbound Outbound);
        void DeleteOutbound(Outbound Outbound);
    }
}
