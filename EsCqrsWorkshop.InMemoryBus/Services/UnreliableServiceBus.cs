using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EsCqrsWorkshop.InMemoryBus.Services
{
    public class UnreliableServiceBus
    {
        Timer timer;

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

                    }
                }
            }
            finally
            {
                timer.Start();
            }
        }
    }
}
