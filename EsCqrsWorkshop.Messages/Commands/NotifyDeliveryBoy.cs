using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Messages.Commands
{
    public class NotifyDeliveryBoy
    {
        public readonly Guid PizzeriaId;
        public readonly Guid OrderId;
        public readonly string CustomerName;
        public readonly string PizzaTaste;

        public NotifyDeliveryBoy(Guid pizzeriaId, Guid orderId, string customerName, string pizzaTaste)
        {
            PizzeriaId = pizzeriaId;
            OrderId = orderId;
            CustomerName = customerName;
            PizzaTaste = pizzaTaste;
        }
    }
}
