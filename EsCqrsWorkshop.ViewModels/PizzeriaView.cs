using System;
using System.Collections.Generic;

namespace EsCqrsWorkshop.ViewModels
{
    public class PizzeriaView
    {
        private PizzeriaView()
        {

        }

        public Guid PizzeriaId { get; private set; }

        public String Name { get; private set; }
    }

    public class OrderView
    {
        private OrderView()
        {

        }

        public Guid OrderId { get; private set; }

        public Guid PizzeriaId { get; private set; }

        public String CustomerName { get; private set; }

        public String PizzaTaste { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }

}
