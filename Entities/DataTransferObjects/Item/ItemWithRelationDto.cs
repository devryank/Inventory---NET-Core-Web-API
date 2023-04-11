using Entities.DataTransferObjects.ItemCategory;
using Entities.DataTransferObjects.Supplier;
using Entities.DataTransferObjects.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Item
{
    public class ItemWithRelationDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] photo { get; set; }
        public string Desc { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }

        public Guid UnitId { get; set; }
        public UnitDto Unit { get; set; }

        public Guid ItemCategoryId { get; set; }
        public ItemCategoryDto ItemCategory { get; set; }

        public Guid SupplierId { get; set; }
        public SupplierDto Supplier { get; set; }
    }
}
