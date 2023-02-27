using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirst.EF.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public int Amount { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public Order() {
            OrderDetails = new List<OrderDetails>();
        }
    }
}