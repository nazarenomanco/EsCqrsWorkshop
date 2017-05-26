using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Domain.ValueObjects
{
    public class Order
    {
        public Guid Id { get; set; }
        public  string CustomerName { get; set; } 
        public string PizzaTaste { get; set; }
        public Guid PizzeriaId { get; set; }
        public  DateTime CreatedAt { get; set; }
        public bool Completed { get; set; }

        public Order()
        {
            
        }

        public Order(Guid pizzeriaId, string customerName, string pizzaTaste)
        {
            this.Id = Guid.NewGuid();
            this.PizzeriaId = pizzeriaId;
            this.CustomerName = customerName;
            this.PizzaTaste = pizzaTaste;
            this.CreatedAt = DateTime.Now;
            this.Completed = false;
        }
    }
}
