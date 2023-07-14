using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace StoreFront.DATA.EF.Models/*Metadata*/
{
    [ModelMetadataType(typeof(TypeMetadata))]
    public partial class Type
    {

    }

    [ModelMetadataType(typeof(WaresMetadata))]
    public partial class Wares
    {
        public int WaresPrice { get; set; }
    }

}
