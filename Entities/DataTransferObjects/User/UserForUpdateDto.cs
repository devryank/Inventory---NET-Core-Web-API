﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.User
{
    public class UserForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(45, ErrorMessage = "Name can't be longger than 45 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(60, ErrorMessage = "Email can't be longger than 60 characters")]
        public string? Email { get; set; }
    }
}
