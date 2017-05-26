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

}
