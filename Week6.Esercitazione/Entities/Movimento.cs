using System;

namespace TestWeek6.Entities
{
    public abstract class Movimento
    {
        public decimal Importo { get; set; }
        public DateTime DataMovimento { get { return DateTime.Now; } }
        public TipoMovimento TipoMovimento { get; set; }


        public override string ToString()
        {

            return $"Tipo Movimento: {TipoMovimento}\t\tImporto: {Importo}\t\tData Movimento: {DataMovimento.ToString("dd-MMM-yyyy")}";

        }
    }
    public enum TipoMovimento
    {
        Prelievo,
        Versamento
    }
}
