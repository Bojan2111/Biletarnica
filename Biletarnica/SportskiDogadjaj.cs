using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletarnica
{
    public class SportskiDogadjaj : Dogadjaj
    {
        public string VrstaSporta { set; get; }

        public SportskiDogadjaj(int id, string naziv, string mesto, string vreme, string vrstaSporta) : base(id, naziv, mesto, vreme)
        {
            VrstaSporta = vrstaSporta;
        }
        public static SportskiDogadjaj FromFileToObject(string tekst)
        {
            string[] tokeni = tekst.Split(',');

            if (tokeni.Length != 5)
            {
                Console.WriteLine("Greska pri ocitavanju osobe " + tekst);
                Environment.Exit(0);
            }
            return new SportskiDogadjaj(int.Parse(tokeni[0]), tokeni[1], tokeni[2], tokeni[3], tokeni[4]);
        }

        public string ToFileString()
        {
            return $"{Id},{Naziv},{Mesto},{Vreme},{VrstaSporta}";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, sportski dogadjaj: {VrstaSporta}";
        }
    }
}
