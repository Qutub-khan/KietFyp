using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRAdminPanel.Models
{
    public class ProductsModel
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [DisplayName("Product Number")]
        [Required(ErrorMessage = "This Field is required.")]
        public string ProductNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "This Field is required.")]
        public string ProductName { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [DisplayName("Product Description")]
        [Required(ErrorMessage = "This Field is required.")]
        public string ProductDescription { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [DisplayName("Product Category")]
        [Required(ErrorMessage = "This Field is required.")]
        public string ProductCategory { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "This Field is required.")]
        public int Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
