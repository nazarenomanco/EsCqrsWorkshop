using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCqrsWorkshop.Domain.ValueObjects
{
    public class Ordine
    {
        public readonly string NomeCliente;
        public readonly string GustoPizza;

        public Ordine(string nomeCliente, string gustoPizza)
        {
            this.NomeCliente = nomeCliente;
            this.GustoPizza = gustoPizza;
        }
    }
}
