using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : BaseDM
    {

        public string Name  { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public required string Password {  get; set; }
        
    }
}
