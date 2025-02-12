using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order_Product : BaseDM
    {
        public int OrderId { get; set; }
        public required virtual Order Order { get; set; }


        public int ProductId { get; set; }
        public required virtual Product Product { get; set; }

        public int Quntity { get; set; }
        public int Price { get; set; }

         
    }
}
