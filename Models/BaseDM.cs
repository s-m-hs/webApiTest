using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaseDM
    {
        public virtual int ID { get; set; }
        [DefaultValue("true")]
        public virtual bool IsVisible { get; set; }


        public virtual DateTime CreateDate { get; set; }

        [DefaultValue("null")]
        public virtual DateTime? LastModified { get; set; }
    }
}
