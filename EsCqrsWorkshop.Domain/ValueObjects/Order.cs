using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Domain.ValueObjects
{
    public class Order
    {
        public readonly string CustomerName;
        public readonly string PizzaTaste;
        public readonly DateTime CreatedAt;

        public Order(string customerName, string pizzaTaste)
        {
            this.CustomerName = customerName;
            this.PizzaTaste = pizzaTaste;
            this.CreatedAt = DateTime.Now;
        }
    }
}
