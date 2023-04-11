using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IItemCategoryRepository
    {
        IEnumerable<ItemCategory> GetAllItemCategory(PaginationParameters paginationParameters);
        ItemCategory GetItemCategoryById(Guid itemCategoryId);
        ItemCategory GetItemCategoryWithRelation(Guid itemCategoryId);
        void CreateItemCategory(ItemCategory itemCategory);
        void UpdateItemCategory(ItemCategory itemCategory);
        void DeleteItemCategory(ItemCategory itemCategory);
    }
}
