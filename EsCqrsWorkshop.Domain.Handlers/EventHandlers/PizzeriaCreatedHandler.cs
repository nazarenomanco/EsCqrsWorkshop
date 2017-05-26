using EsCqrsWorkshop.Domain.Pizzerie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Domain.Handlers.EventHandlers
{
    class PizzeriaCreatedHandler : ComponentModel.IHandleEvent<IPizzeriaCreated>
    {
        public void Handle(IPizzeriaCreated @event)
        {

        }
    }
}
