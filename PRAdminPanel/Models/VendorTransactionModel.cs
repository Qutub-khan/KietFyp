using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRAdminPanel.Models
{
    public class VendorTransactionModel
    {
        [Key]
        public int TransactionId { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Vendor Number")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]
        public string VendorNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Vendor Name")]
        [Required(ErrorMessage = "This Field is required.")]
        public string VendorName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Vendor Address")]
        [Required(ErrorMessage = "This Field is required.")]
        public string VendorAddress { get; set; }

       

        [DisplayName("Amount")]
        [Required(ErrorMessage = "This Field is required.")]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
