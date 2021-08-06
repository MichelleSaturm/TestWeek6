using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public class TransfertMovement : Movimento
    {
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }

        public override string ToString()
        {
            return $"[Transfert Movement]\nBanca di Origine: {BancaOrigine}\t\tBanca di Destinazione: {BancaDestinazione}\n" +
                $"Importo: {Importo}\t\tData Movimento: {DataMovimento.ToString("dd-MMM-yyyy")}";
        }
    }
}
