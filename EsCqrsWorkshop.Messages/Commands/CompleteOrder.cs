using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Messages.Commands
{
    public class CompleteOrder
    {
        public readonly Guid PizzeriaId;
        public readonly Guid OrderId;

        public CompleteOrder( Guid pizzeriaId, Guid orderId)
        {
            this.PizzeriaId = pizzeriaId;
            this.OrderId = orderId;
        }

    }
}
