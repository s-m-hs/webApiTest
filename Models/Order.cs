using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order: BaseDM
    {
        public required int customerID { get; set; }
        public required virtual Customer customer { get; set; }

        public ICollection<Order_Product>? OrderProducts { get; set; }

    }
}
