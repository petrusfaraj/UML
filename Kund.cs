using System;
using System.Collections.Generic;

namespace BiluthyrningApp
{
    public class Kund
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Personnummer { get; set; }
        public string Mobilnummer { get; set; }
        public List<Hyra> Hyror { get; } = new();
        public bool Registrerad { get; private set; }

        public Kund(int id, string namn, string personnummer, string mobilnummer)
        {
            Id = id;
            Namn = namn;
            Personnummer = personnummer;
            Mobilnummer = mobilnummer;
        }

        public void Registrera()
        {
            Registrerad = true;
            Console.WriteLine($"{Namn} är nu registrerad som kund.");
        }

        public Hyra BokaBil(Bil bil, DateTime startdatum, DateTime slutdatum, double prisPerDag)
        {
            if (bil.ÄrUthyrd)
                throw new InvalidOperationException("Bilen är redan uthyrd.");

            bil.Uthyrning();
            var hyra = new Hyra(this, bil, startdatum, slutdatum, prisPerDag);
            Hyror.Add(hyra);
            return hyra;
        }

        public override string ToString()
        {
            return $"{Namn} ({Personnummer})";
        }
    }
}
