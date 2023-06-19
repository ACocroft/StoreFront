using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class StockStatus
    {
        public StockStatus()
        {
            Wares = new HashSet<Ware>();
        }

        public int Id { get; set; }
        public string StockStatus1 { get; set; } = null!;

        public virtual ICollection<Ware> Wares { get; set; }
    }
}
