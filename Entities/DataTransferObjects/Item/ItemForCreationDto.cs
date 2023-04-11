using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Item
{
    public class ItemForCreationDto
    {
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public byte[]? Photo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Desc { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public Guid UnitId { get; set; }

        [Required]
        public Guid ItemCategoryId { get; set; }

        [Required]
        public Guid SupplierId { get; set; }

    }
}
