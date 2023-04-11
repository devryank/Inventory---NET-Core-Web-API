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
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public IEnumerable<Item> GetAllItem(PaginationParameters paginationParameters)
        {
            return RepositoryContext.Items
                .Include(i => i.ItemCategory)
                .Include(i => i.Supplier)
                .Include(i => i.Unit)
                .ToArray();
        }
        public Item GetItemByCode(string code)
        {
            return FindByCondition(item => item.Code.Equals(code))
                .FirstOrDefault();
        }
        public Item GetItemWithRelation(string code)
        {
            return RepositoryContext.Items
                .Include(i => i.ItemCategory)
                .Include(i => i.Supplier)
                .Include(i => i.Unit)
                .FirstOrDefault();
        }
        public void CreateItem(Item Item) => Create(Item);
        public void UpdateItem(Item Item) => Update(Item);
        public void DeleteItem(Item Item) => Delete(Item);
    }
}
