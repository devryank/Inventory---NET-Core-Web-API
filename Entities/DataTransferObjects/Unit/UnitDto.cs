using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Unit
{
    public class UnitDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
