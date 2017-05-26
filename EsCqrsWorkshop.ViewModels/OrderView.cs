using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.ViewModels
{
    public class OrderView
    {
        private OrderView()
        {

        }

        public Guid OrderId { get; private set; }
        public Guid PizzeriaId { get; private set; }
        public string PizzeriaName { get; private set; }
        public String CustomerName { get; private set; }
        public String PizzaTaste { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}
