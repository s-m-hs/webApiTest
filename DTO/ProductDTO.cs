using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int ID;
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Url { get; set; }

        public int Supply { get; set; }

        public int Price { get; set; }
    }
}
