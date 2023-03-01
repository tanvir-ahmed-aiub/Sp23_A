using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCodeFirst.EF.Models
{
    public class User
    {
        [Key]
        [StringLength(10)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required,StringLength(10)]
        public string Type { get; set; }
        [Required,StringLength(50)]
        public string Password { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public User() {
            Orders = new List<Order>();
        }
    }
}