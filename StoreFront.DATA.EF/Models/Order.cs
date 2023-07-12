using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public virtual UserDetail Customer { get; set; } = null!;
        public virtual OrderWare? OrderWare { get; set; }
    }
}
