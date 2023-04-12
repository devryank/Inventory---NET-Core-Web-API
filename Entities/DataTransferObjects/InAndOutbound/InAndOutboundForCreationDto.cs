using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.InAndOutbound
{
    public class InAndOutboundForCreationDto
    {
        public Guid Id { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Total { get; set; }
        public string? Notes { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid SupplierId { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
