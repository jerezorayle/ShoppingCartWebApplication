using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApplication.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Item Name")]
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Description")]
        [Column(TypeName = "longtext")]
        [Required]
        public string Description { get; set; }
        [DisplayName("Price")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "₱{0:N2}")]
        [Required]
        public double Price { get; set; }
        [DisplayName("Quantity")]
        [Column(TypeName = "smallint")]
        [Required]
        public int Quantity { get; set; }
        [DisplayName("Date Added")]
        [Column(TypeName = "datetime")]
        public DateTime DateAdded { get; set; }
        [DisplayName("Date Modified")]
        [Column(TypeName = "datetime")]
        public DateTime DateModified { get; set; }
    }
}
