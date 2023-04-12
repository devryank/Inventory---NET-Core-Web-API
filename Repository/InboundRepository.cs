using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InboundRepository : RepositoryBase<Inbound>, IInboundRepository
    {
        public InboundRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Inbound> GetAllInbound(PaginationParameters paginationParameters)
        {
            return RepositoryContext.Inbounds
                .Include(i => i.Supplier)
                .Include(i => i.Item)
                .ToArray();
        }
        public Inbound GetInboundById(Guid id)
        {
            return FindByCondition(inbound => inbound.Id.Equals(id))
                .FirstOrDefault();
        }
        public Inbound GetInboundWithRelation(Guid id)
        {
            return RepositoryContext.Inbounds
                .Include(i => i.Supplier)
                .Include(i => i.Item)
                .FirstOrDefault();
        }
        public void CreateInbound(Inbound Inbound) => Create(Inbound);
        public void UpdateInbound(Inbound Inbound) => Update(Inbound);
        public void DeleteInbound(Inbound Inbound) => Delete(Inbound);
    }
}
