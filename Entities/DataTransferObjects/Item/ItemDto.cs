using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Item
{
    public class ItemDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] photo { get; set; }
        public string Desc { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }
    }
}
