using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItem(PaginationParameters paginationParameters);
        Item GetItemByCode(string code);
        Item GetItemWithRelation(string code);
        void CreateItem(Item Item);
        void UpdateItem(Item Item);
        void DeleteItem(Item Item);
    }
}
