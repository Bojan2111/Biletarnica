using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletarnica
{
    internal class Osoba
    {
        public string Ime { set; get; }
        public string Prezime { set; get; }
        public string JMBG { set; get; }

        public Osoba(string ime, string prezime, string jmbg)
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = jmbg;
        }
        public static Osoba FromFileToObject(string tekst)
        {
            string[] tokeni = tekst.Split(',');

            if (tokeni.Length != 3)
            {
                Console.WriteLine("Greska pri ocitavanju osobe " + tekst);
                Environment.Exit(0);
            }
            return new Osoba(tokeni[0], tokeni[1], tokeni[2]);

        }

        public string ToFileString()
        {
            return $"{Ime},{Prezime},{JMBG}";
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime}, JMBG: {JMBG}";
        }
    }
}
