using System;

namespace BiluthyrningApp
{
    public class Personal
    {
        public int Id { get; set; }
        public string Namn { get; set; }

        public Personal(int id, string namn)
        {
            Id = id;
            Namn = namn;
        }

        public void HanteraBokning(Hyra hyra)
        {
            Console.WriteLine($"Personal {Namn} hanterar bokningen för {hyra.Kund.Namn}.");
        }

        public void RegistreraBil(Bil bil)
        {
            Console.WriteLine($"Bil {bil.Modell} ({bil.År}) registrerad av {Namn}.");
        }
    }
}
