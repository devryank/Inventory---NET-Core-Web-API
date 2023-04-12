using Contracts;
using Entities.Models;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OutboundRepository : RepositoryBase<Outbound>, IOutboundRepository
    {
        public OutboundRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Outbound> GetAllOutbound(PaginationParameters paginationParameters)
        {
            return RepositoryContext.Outbounds
                .Include(i => i.Supplier)
                .Include(i => i.Item)
                .ToArray();
        }
        public Outbound GetOutboundById(Guid id)
        {
            return FindByCondition(inbound => inbound.Id.Equals(id))
                .FirstOrDefault();
        }
        public Outbound GetOutboundWithRelation(Guid id)
        {
            return RepositoryContext.Outbounds
                .Include(i => i.Supplier)
                .Include(i => i.Item)
                .FirstOrDefault();
        }
        public void CreateOutbound(Outbound Outbound) => Create(Outbound);
        public void UpdateOutbound(Outbound Outbound) => Update(Outbound);
        public void DeleteOutbound(Outbound Outbound) => Delete(Outbound);
    }
}
