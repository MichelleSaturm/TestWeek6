using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public class CashMovement : Movimento
    {
        public string Esecutore { get; set; }

        public override string ToString()
        {
            return $"[Cash Movement]\nEsecutore: {Esecutore}\n" +
                $"Importo: {Importo}\t\tData Movimento: {DataMovimento.ToString("dd-MMM-yyyy")}";
        }
    }
}
