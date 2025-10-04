using System;

namespace BiluthyrningApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var personal = new Personal(1, "Lisa Admin");
            var bil = new Bil(1, "Volvo V60", 2020);
            var kund = new Kund(1, "Anna Svensson", "19900101-1234", "0701234567");

            personal.RegistreraBil(bil);
            kund.Registrera();

            var start = new DateTime(2025, 10, 10);
            var slut = new DateTime(2025, 10, 12);

            var hyra = kund.BokaBil(bil, start, slut, 400.0);
            personal.HanteraBokning(hyra);

            Console.WriteLine(hyra);
            Console.WriteLine($"Total kostnad: {hyra.BeräknaKostnad()} kr");

            hyra.Avsluta();
            Console.WriteLine($"Hyra avslutad: {hyra.Avslutad}");
            Console.WriteLine($"Bilstatus: {(bil.ÄrUthyrd ? "Uthyrd" : "Tillgänglig")}");
        }
    }
}
