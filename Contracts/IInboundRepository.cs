using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IInboundRepository
    {
        IEnumerable<Inbound> GetAllInbound(PaginationParameters paginationParameters);
        Inbound GetInboundById(Guid id);
        Inbound GetInboundWithRelation(Guid id);
        void CreateInbound(Inbound Inbound);
        void UpdateInbound(Inbound Inbound);
        void DeleteInbound(Inbound Inbound);
    }
}
