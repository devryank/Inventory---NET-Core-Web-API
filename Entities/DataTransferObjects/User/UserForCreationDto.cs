﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.User
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(45, ErrorMessage = "Name can't be longger than 45 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(60, ErrorMessage = "Email can't be longger than 60 characters")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Password can't be longger than 255 characters")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [EnumDataType(typeof(RoleNames))]
        public string? Role { get; set; }

        public enum RoleNames
        {
            Admin,
            Member
        }
    }
}
