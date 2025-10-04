using System;

namespace BiluthyrningApp
{
    public class Bil
    {
        public int Id { get; set; }
        public string Modell { get; set; }
        public int År { get; set; }
        public bool ÄrUthyrd { get; private set; }

        public Bil(int id, string modell, int år)
        {
            Id = id;
            Modell = modell;
            År = år;
            ÄrUthyrd = false;
        }

        public void Uthyrning()
        {
            if (ÄrUthyrd)
                throw new InvalidOperationException($"Bilen {Modell} är redan uthyrd.");
            ÄrUthyrd = true;
        }

        public void LämnaTillbaka()
        {
            ÄrUthyrd = false;
        }

        public override string ToString()
        {
            return $"{Modell} ({År}) - {(ÄrUthyrd ? "Uthyrd" : "Tillgänglig")}";
        }
    }
}
