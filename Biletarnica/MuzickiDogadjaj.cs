using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletarnica
{
    public class MuzickiDogadjaj : Dogadjaj
    {
        public string Izvodjac { set; get; }
        public string Zanr { set; get; }
        public MuzickiDogadjaj(int id, string naziv, string mesto, string vreme, string izvodjac, string zanr) : base(id, naziv, mesto, vreme)
        {
            Izvodjac = izvodjac;
            Zanr = zanr;
        }
        public static MuzickiDogadjaj FromFileToObject(string tekst)
        {
            string[] tokeni = tekst.Split(',');

            if (tokeni.Length != 6)
            {
                Console.WriteLine("Greska pri ocitavanju osobe " + tekst);
                Environment.Exit(0);
            }
            return new MuzickiDogadjaj(int.Parse(tokeni[0]), tokeni[1], tokeni[2], tokeni[3], tokeni[4], tokeni[5]);

        }

        public string ToFileString()
        {
            return $"{Id},{Naziv},{Mesto},{Vreme},{Izvodjac},{Zanr}";
        }
        public override string ToString()
        {
            return $"{base.ToString()}, muzicki izvodjac je {Izvodjac}, muzicki zanr - {Zanr}";
        }
    }
}
