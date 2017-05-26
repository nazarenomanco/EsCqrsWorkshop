using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsCqrsWorkshop.Messages.Commands;
using Jason.Handlers.Commands;

namespace EsCqrsWorkshop.Domain.Handlers
{
    class NotifyDeliveryBoyHandler: AbstractCommandHandler<NotifyDeliveryBoy>
    {
        protected override object OnExecute(NotifyDeliveryBoy command)
        {
             // Handler Code HERE
            return null;
        }
    }
}
