using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public class CreditCardMovement : Movimento
    {
        public Tipo TipoCarta { get; set; }
        public string NumeroCarta { get; set; }

        public override string ToString()
        {
            return $"[Credit Card Movement]\nTipo Carta: {TipoCarta}\t\tNumero Carta: {NumeroCarta}\n" +
                $"Importo: {Importo}\t\tData Movimento: {DataMovimento.ToString("dd-MMM-yyyy")}";
        }
    }

    public enum Tipo
    {
        AMEX,
        Visa,
        MasterCard,
        Other
    }
}
