using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Messages.Commands
{
    public class AddOrder
    {
        public readonly string CustomerName;
        public readonly Guid PizzeriaId;
        public readonly string PizzaTaste;

        public AddOrder(Guid pizzeriaId, string customerName, string pizzaTaste)
        {
            this.CustomerName = customerName;
            this.PizzeriaId = pizzeriaId;
            this.PizzaTaste = pizzaTaste;
        }

    }
}
