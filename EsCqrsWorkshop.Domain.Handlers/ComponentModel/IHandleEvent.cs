using Radical.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Domain.Handlers.ComponentModel
{
    public interface IHandleEvent<T> where T : IDomainEvent
    {
        void Handle(T orderCompletedEvent);
    }
}
