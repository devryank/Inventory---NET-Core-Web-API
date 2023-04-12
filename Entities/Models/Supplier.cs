using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(13)]
        public string Phone { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<Inbound> Inbounds { get; set; }
        public ICollection<Outbound> Outbounds { get; set; }
    }
}
