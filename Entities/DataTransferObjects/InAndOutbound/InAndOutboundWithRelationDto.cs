using Entities.DataTransferObjects.Item;
using Entities.DataTransferObjects.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.InAndOutbound
{
    public class InAndOutboundWithRelationDto
    {
        public Guid Id { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }

        public Guid SupplierId { get; set; }
        public SupplierDto Supplier { get; set; }

        public string Code { get; set; }
        public ItemDto Item { get; set; }
    }
}
