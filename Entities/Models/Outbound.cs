using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Outbound
    {
        public Guid Id { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Total { get; set; }
        [DataType(DataType.Text)]
        public string Notes { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public Guid SupplierId { get; set; }    
        public Supplier Supplier { get; set; }

        [ForeignKey("Item")]
        public string Code { get; set; }
        public Item Item { get; set; }
    }
}
