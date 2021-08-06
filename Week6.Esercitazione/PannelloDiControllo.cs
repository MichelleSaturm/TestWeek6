using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6
{
    public class PannelloDiControllo
    {
        public static void Start()
        {
            bool continuare = true;
            do
            {
                Console.Clear();
                Console.WriteLine("==== WELCOME ====");
                Console.WriteLine();
                Console.WriteLine("1 - Aggiungi Conto");
                Console.WriteLine("2 - Stampa Dati Conto e Movimenti");
                Console.WriteLine("3 - Effettua un Movimento");

                Console.WriteLine();
                Console.WriteLine("---- Uscita ----");
                Console.WriteLine("0 - Exit");

                Console.WriteLine();
                Console.Write("Inserisci la tua scelta: ");

                int choice = Helpers.CheckInt();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        GestioneConti.CreaConto();
                        break;
                    case 2:
                        Console.Clear();
                        GestioneConti.StampaDati();
                        break;
                    case 3:
                        Console.Clear();
                        PannelloDiControllo.Movimenti();
                        break;
                    case 0:
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata. Riprova.");
                        break;
                }
            } while (continuare);

        }

        public static void Movimenti()
        {
            bool continuare = true;
            do
            {
                Console.Clear();
                Console.WriteLine("==== MOVIMENTO ====");
                Console.WriteLine();
                Console.WriteLine("1 - Cash Movement");
                Console.WriteLine("2 - Transfert Movement");
                Console.WriteLine("3 - Credit Card Movement");
                Console.WriteLine("0 - Menù Principale");

                Console.WriteLine();
                Console.Write("Inserisci la tua scelta: ");

                int choice = Helpers.CheckInt();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        GestioneConti.CashMovement();
                        break;
                    case 2:
                        Console.Clear();
                        GestioneConti.TransfertMovement();
                        break;
                    case 3:
                        Console.Clear();
                        GestioneConti.CreditCardMovement();
                        break;
                    case 0:
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata. Riprova.");
                        break;
                }
            } while (continuare);
        }
    }
}
