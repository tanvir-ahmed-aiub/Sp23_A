using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Login
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
