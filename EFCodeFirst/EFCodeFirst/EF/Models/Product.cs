using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirst.EF.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
    }
}