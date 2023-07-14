using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class OrderWare
    {
        public int OrderWareId { get; set; }
        public int OrderId { get; set; }
        public int WaresId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Ware Wares { get; set; } = null!;
        public decimal? Price { get; set; }
    }
}
