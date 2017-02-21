using System.ComponentModel.DataAnnotations;

namespace Catalogia_WebMVC.Models
{
    public class CatalogObject
    {
        public int ID { get; set; }

        [Required, StringLength(50), Display(Name="Object Name")]
        public string ObjectName { get; set; }

        [StringLength(50), Display(Name = "Secondary Name")]
        public string OtherName { get; set; }

        public int? Quantity { get; set; }

        [DataType(DataType.Currency), Display(Name = "Unit Price")]
        public decimal Price  { get; set; }

        [Display(Name = "Date Obtained")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateAcquired { get; set; }
    }
    
}