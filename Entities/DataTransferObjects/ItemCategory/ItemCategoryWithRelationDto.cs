﻿using Entities.DataTransferObjects.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ItemCategory
{
    public class ItemCategoryWithRelationDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public ICollection<ItemDto> Items { get; set; }
    }
}
