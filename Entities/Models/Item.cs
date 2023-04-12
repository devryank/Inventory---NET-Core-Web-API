using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Item
    {
        [Key]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        //[Required(ErrorMessage = "Image is required")]
        //[FileExtensions(Extensions = "jpg,jpeg,png")]
        public byte[] Photo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Desc { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Stock { get; set; }

        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }

        public Guid ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }

        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<Inbound> Inbounds { get; set; }
        public ICollection<Outbound> Outbounds { get; set; }
    }
}
