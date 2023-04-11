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
    public class ItemCategoryRepository : RepositoryBase<ItemCategory>, IItemCategoryRepository
    {
        public ItemCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<ItemCategory> GetAllItemCategory(PaginationParameters paginationParameters)
        {
            return FindAll()
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();
        }

        public ItemCategory GetItemCategoryById(Guid itemCategoryId)
        {
            return FindByCondition(category => category.Id.Equals(itemCategoryId))
                .FirstOrDefault();
        }
        public ItemCategory GetItemCategoryWithRelation(Guid itemCategoryId)
        {
            return RepositoryContext.ItemCategory
                .Where(category => category.Id.Equals(itemCategoryId))
                .Include(c => c.Items)
                .FirstOrDefault();
        }
        public void CreateItemCategory(ItemCategory itemCategory) => Create(itemCategory);
        public void UpdateItemCategory(ItemCategory itemCategory) => Update(itemCategory);
        public void DeleteItemCategory(ItemCategory itemCategory) => Delete(itemCategory);
    }
}
