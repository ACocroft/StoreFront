using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Type
    {
        public Type()
        {
            Wares = new HashSet<Ware>();
        }

        public string Type1 { get; set; } = null!;
        public int TypeId { get; set; }

        public virtual ICollection<Ware> Wares { get; set; }
    }
}
