using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Messages.Commands
{
   public  class CreatePizzeria
   {
       public readonly String Name;

       public CreatePizzeria(string name)
       {
           Name = name;
       }
   }
}
