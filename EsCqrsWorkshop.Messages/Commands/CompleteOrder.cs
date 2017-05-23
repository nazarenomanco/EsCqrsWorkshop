using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Messages.Commands
{
    public class CompleteOrder
    {
        public readonly string CustomerName;
        public readonly Guid PizzeriaId;
        public readonly string PizzaTaste;
        public readonly DateTime OrderCreatedAt;

        public CompleteOrder(Guid pizzeriaId, string customerName, string pizzaTaste, DateTime orderCreatedAt)
        {
            this.CustomerName = customerName;
            this.PizzeriaId = pizzeriaId;
            this.PizzaTaste = pizzaTaste;
            this.OrderCreatedAt = orderCreatedAt;
        }


    }
}
