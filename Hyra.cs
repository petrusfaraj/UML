using System;

namespace BiluthyrningApp
{
    public class Hyra
    {
        public int Id { get; }
        private static int counter = 1;

        public Kund Kund { get; }
        public Bil Bil { get; }
        public DateTime Startdatum { get; }
        public DateTime Slutdatum { get; }
        public double PrisPerDag { get; }
        public double? TotalPris { get; private set; }
        public bool Avslutad { get; private set; }

        public Hyra(Kund kund, Bil bil, DateTime startdatum, DateTime slutdatum, double prisPerDag)
        {
            if (startdatum > slutdatum)
                throw new ArgumentException("Startdatum måste vara före slutdatum.");

            Id = counter++;
            Kund = kund;
            Bil = bil;
            Startdatum = startdatum;
            Slutdatum = slutdatum;
            PrisPerDag = prisPerDag;
            Avslutad = false;
        }

        public double BeräknaKostnad()
        {
            var dagar = (Slutdatum - Startdatum).Days + 1;
            TotalPris = dagar * PrisPerDag;
            return TotalPris.Value;
        }

        public void Avsluta()
        {
            if (Avslutad) return;
            Bil.LämnaTillbaka();
            Avslutad = true;
            if (TotalPris == null)
                BeräknaKostnad();
        }

        public override string ToString()
        {
            return $"Hyra #{Id}: {Kund.Namn} hyr {Bil.Modell} ({Startdatum:yyyy-MM-dd} → {Slutdatum:yyyy-MM-dd})";
        }
    }
}
