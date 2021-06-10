using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApplication.Models
{
    public class UserItem
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ItemId { get; set; }
    }
}
