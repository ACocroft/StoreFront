using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StoreFront.DATA.EF.Models/*Metadata*/
{
    //internal class Metadata
    //{
    //}


    #region TypeMetadata

    public class TypeMetadata //Type is the "Category" for this store
    {
        //public int TypeId { get; set; }

        [Required(ErrorMessage = "*Type is required")]
        [StringLength(50, ErrorMessage = "*Max 50 characters")]
        public string Type { get; set; } = null!;

        [Required(ErrorMessage = "*Description is required")]
        [StringLength(150, ErrorMessage = "*Max 150 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;
    }

    #endregion

    #region WaresMetadata

    public class WaresMetadata //Wares is the "Product" for this store
    {
        //public int WaresId { get; set; }

        [Required(ErrorMessage = "Wares is required")]
        [StringLength(200, ErrorMessage = "*Max 200 characters")]
        [Display(Name = "Wares")]
        public string WaresName { get; set; } = null!;

        [Required(ErrorMessage = "*Price is required")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        [Range(0, (double)decimal.MaxValue)]
        public decimal WaresPrice { get; set; }

        [StringLength(500, ErrorMessage = "*500 characters max")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string? WaresDescription { get; set; }

        [Required(ErrorMessage = "*In Stock is required")]
        [Display(Name = "In Stock")]
        public short UnitsInStock { get; set; }

        [Required(ErrorMessage = "*On Order is required")]
        [Display(Name = "On Order")]
        public short UnitsOnOrder { get; set; }

        [Display(Name = "Discontinued?")]
        public bool IsDiscontinued { get; set; }
        public int TypeId { get; set; }
        public int? ManufacturerId { get; set; }

        [StringLength(75, ErrorMessage = "*Cannot exceed 75 characters")]
        [Display(Name = "Image")]
        public string? WaresImage { get; set; }
    }

    #endregion

    #region Manufacturer
    public class ManufacturerMetadata
    {
        public int ManufacturerId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Manufacturer")]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string? Country { get; set; } = null!;
    }
    #endregion

    public class OrderMetadata
    {
        
        public int OrderId { get; set; }

        
        public string UserId { get; set; } = null!;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Order Date")]
        [Required]
        public DateTime OrderDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Ship To")]
        [Required]
        public string ShipToName { get; set; } = null!;

        [StringLength(50)]
        [Display(Name = "City")]
        [Required]
        public string ShipCity { get; set; } = null!;

        [StringLength(2)]
        [Display(Name = "State")]
        public string? ShipCountry { get; set; }

    }

    #region UserDetail
    public class UserDetailMetadata
    {
        public string UserId { get; set; } = null!;
        [StringLength(50)]
        [Display(Name = "Full Name")]
        [Required]
        public string UserName { get; set; } = null!;
        [StringLength(100)]
        
        public string? Address { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(2)]
        public string? State { get; set; }
        [StringLength(5)]
        [DataType(DataType.PostalCode)]
        public string? Zip { get; set; }
        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
    }
    #endregion


}
