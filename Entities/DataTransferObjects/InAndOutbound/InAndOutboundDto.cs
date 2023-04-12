using Entities.DataTransferObjects.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.InAndOutbound
{
    public class InAndOutboundDto
    {
        public Guid Id { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public int Price { get; set; }
        public int Total { get; set; }
        [Required]
        public string Notes { get; set; }
        public DateTime Date { get; set; }

        public Guid SupplierId { get; set; }
        public string Code { get; set; }
    }
}
