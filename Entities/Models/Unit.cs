﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Unit
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
