using Castle.Windsor;
using EsCqrsWorkshop.Domain.Handlers.ComponentModel;
using Radical.CQRS.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topics.Radical;

namespace EsCqrsWorkshop.InMemoryBus.Services
{
    public class UnreliableServiceBus
    {
        Timer timer;
        IWindsorContainer container;

        public UnreliableServiceBus(IWindsorContainer container)
        {
            //horrible ServiceLocator...
            this.container = container;
        }

        public void StartPolling()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true;
            timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                timer.Stop();
                using (var db = new EventCommitsDomainContext())
                {
                    var query = db.DomainEventCommits.Where(c => c.IsDispatched == false);
                    foreach (var item in query)
                    {
                        //hardcoding a lot of assumptions in this crappy code, it's a sample.
                        var evt = item.Event;
                        var evtTypeString = ConcreteProxyCreator.GetValidTypeName(evt.GetType());
                        var evtType = Type.GetType(evtTypeString);
                        var handlerType = typeof(IHandleEvent<>).MakeGenericType(evtType);
                        var handlers = this.container.ResolveAll(handlerType);
                        foreach (var handler in handlers)
                        {
                            var method = handler.GetType()
                                .GetMethod("Handle");
                            method.Invoke(handler, new[] { evt });
                        }

                        item.IsDispatched = true;
                    }

                    db.SaveChanges();
                }
            }
            finally
            {
                timer.Start();
            }
        }
    }
}
