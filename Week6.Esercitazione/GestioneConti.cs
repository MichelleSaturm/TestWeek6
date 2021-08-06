using System;
using System.Collections.Generic;
using TestWeek6.Entities;

namespace TestWeek6
{
    public static class GestioneConti
    {
        static List<ContoBancario> conto = new List<ContoBancario>();
        static List<Movimento> movimento = new List<Movimento>();
        public static void CreaConto()
        {
            Console.Clear();
            ContoBancario cb = new ContoBancario();
            Console.WriteLine("==== CREA CONTO ====");
            cb.NumeroConto = GeneratoreNumeroConto();
            Console.WriteLine($"Conto N° {cb.NumeroConto}");
            Console.WriteLine($"Ultima Operazione: {cb.DataUltimaOperazione.ToString("dd-MMM-yyyy")} (data creazione)");
            Console.WriteLine("Inserisci Nome Banca");
            cb.NomeBanca = Console.ReadLine();
            Console.WriteLine("Inserisci Saldo");
            cb.Saldo = Helpers.CheckDecimal();

            conto.Add(cb);
        }

        public static int GeneratoreNumeroConto()
        {
            List<int> numerirandom = new List<int>();
            int numrandom;
            bool flag = false;
            do
            {
                Random random = new Random();
                numrandom = random.Next(100, 200);

                if (numerirandom.Contains(numrandom))
                {
                    flag = false;
                }
                else
                {
                    numerirandom.Add(numrandom);
                    flag = true;
                }
            } while (!flag);
            return numrandom;
        }

        public static void StampaDati()
        {
            Console.WriteLine("==== STAMPA DATI CONTO ====");
            Console.WriteLine();
            foreach (ContoBancario cb in conto)
            {
                Console.WriteLine("{0,-10}{1,-30}{2,-20}", "N° Conto", "Nome Banca", "Saldo");
                Console.WriteLine(new String('-', 70));
                Console.WriteLine("{0,-10}{1,-30}{2,-20}", cb.NumeroConto, cb.NomeBanca, cb.Saldo);
                Console.WriteLine(new String('-', 70));
            }
            Console.WriteLine();
            Console.WriteLine("==== STAMPA MOVIMENTI ====");
            foreach (Movimento mov in movimento)
            {
                Console.WriteLine(mov.ToString());
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Premi un tasto per tornare al menù principale");
            Console.ReadLine();
        }

        public static void CashMovement()
        {
            CashMovement cm = new();
            Console.WriteLine("==== CASH MOVEMENT ====");
            Console.WriteLine("Inserisci Esecutore");
            cm.Esecutore = Console.ReadLine();
            Console.WriteLine("Inserisci Importo");
            cm.Importo = Helpers.CheckDecimal();
            Console.WriteLine();
            TipoMovimento tipoMovimento = ScegliTipoMovimento();
            foreach (ContoBancario cb in conto)
            {
                if (tipoMovimento == TipoMovimento.Prelievo)
                {
                    if (cm.Importo > cb.Saldo)
                        Console.WriteLine("Non puoi prelevare un importo più alto del tuo saldo corrente");
                    else
                    {
                        cb.Saldo = cb.Saldo - cm.Importo;
                        movimento.Add(cm);
                    }

                }
                else
                {
                    cb.Saldo = cb.Saldo + cm.Importo;
                    movimento.Add(cm);
                }
            }
            Console.WriteLine("Operazione effettuata.\nPremi un tasto per tornare al menù");
            Console.ReadLine();
        }

        public static void CreditCardMovement()
        {
            CreditCardMovement ccm = new();
            Console.WriteLine("==== CASH MOVEMENT ====");
            Console.WriteLine("Inserisci la Carta di Credito");
            ccm.TipoCarta = ScegliTipoCarta();
            Console.WriteLine("Inserisci il Numero della Carta");
            ccm.NumeroCarta = Console.ReadLine();
            Console.WriteLine("Inserisci Importo");
            ccm.Importo = Helpers.CheckDecimal();
            Console.WriteLine();
            TipoMovimento tipoMovimento = ScegliTipoMovimento();
            foreach (ContoBancario cb in conto)
            {
                if (tipoMovimento == TipoMovimento.Prelievo)
                {
                    if (ccm.Importo > cb.Saldo)
                        Console.WriteLine("Non puoi prelevare un importo più alto del tuo saldo corrente");
                    else
                    {
                        cb.Saldo = cb.Saldo - ccm.Importo;
                        movimento.Add(ccm);
                    }

                }
                else
                {
                    cb.Saldo = cb.Saldo + ccm.Importo;
                    movimento.Add(ccm);
                }
            }
            Console.WriteLine("Operazione effettuata.\nPremi un tasto per tornare al menù");
            Console.ReadLine();
        }

        public static Tipo ScegliTipoCarta()
        {
            Console.WriteLine($"Premi {(int)Tipo.AMEX} per utilizzare una carta di credito {Tipo.AMEX}");
            Console.WriteLine($"Premi {(int)Tipo.Visa} per utilizzare una carta di credito {Tipo.Visa}");
            Console.WriteLine($"Premi {(int)Tipo.MasterCard} per utilizzare una carta di credito {Tipo.MasterCard}");
            Console.WriteLine($"Premi {(int)Tipo.Other} per utilizzare una carta di credito diversa da quelle elencate");

            bool isInt;
            int tipoCard;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out tipoCard);
            } while (!isInt || tipoCard < 0 || tipoCard > 4);
            return (Tipo)tipoCard;
        }

        public static void TransfertMovement()
        {
            TransfertMovement tm = new();
            Console.WriteLine("==== TRANSFERT MOVEMENT ====");
            Console.WriteLine("Inserisci Banca di Origine");
            tm.BancaOrigine = Console.ReadLine();
            Console.WriteLine("Inserisci Banca di Destinazione");
            tm.BancaDestinazione = Console.ReadLine();
            Console.WriteLine("Inserisci Importo");
            tm.Importo = Helpers.CheckDecimal();
            Console.WriteLine();
            TipoMovimento tipoMovimento = ScegliTipoMovimento();
            foreach (ContoBancario cb in conto)
            {
                if (tipoMovimento == TipoMovimento.Prelievo)
                {
                    if (tm.Importo > cb.Saldo)
                        Console.WriteLine("Non puoi prelevare un importo più alto del tuo saldo corrente");
                    else
                    {
                        cb.Saldo = cb.Saldo - tm.Importo;
                        movimento.Add(tm);
                    }

                }
                else
                {
                    cb.Saldo = cb.Saldo + tm.Importo;
                    movimento.Add(tm);
                }
            }
            Console.WriteLine("Operazione effettuata.\nPremi un tasto per tornare al menù");
            Console.ReadLine();
        }

        public static TipoMovimento ScegliTipoMovimento()

        {
            Console.WriteLine($"Premi {(int)TipoMovimento.Prelievo} per effettuare un {TipoMovimento.Prelievo}");
            Console.WriteLine($"Premi {(int)TipoMovimento.Versamento} per effettuare un {TipoMovimento.Versamento}");

            bool isInt;
            int tipoMov;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out tipoMov);
            } while (!isInt || tipoMov < 0 || tipoMov > 1);
            return (TipoMovimento)tipoMov;
        }
    }
}
