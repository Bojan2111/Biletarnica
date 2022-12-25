using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletarnica
{
    internal class OsobaUI
    {
        internal static void DodajOsobu()
        {
            Console.WriteLine("Unesite JMBG osobe:");
            string noviJmbg = Console.ReadLine();
            while (ProveraJMBG(noviJmbg))
            {
                Console.WriteLine("Dogadjaj sa ovim ID vec postoji. Unesite drugi broj.");
                noviJmbg = Console.ReadLine();
            }
            Console.WriteLine("Unesite ime osobe:");
            string novoIme = Console.ReadLine();
            Console.WriteLine("Unesite prezime osobe:");
            string novoPrezime = Console.ReadLine();
            Liste.osobe.Add(new Osoba(novoIme, novoPrezime, noviJmbg));
        }
        public static bool ProveraJMBG(string unos)
        {
            foreach (Osoba o in Liste.osobe)
            {
                if (o.JMBG == unos)
                {
                    return true;
                }
            }
            return false;
        }

        internal static void IspisiSveOsobe()
        {
            foreach (Osoba o in Liste.osobe)
            {
                Console.WriteLine(o);
            }
        }

        internal static void ObrisiOsobu()
        {
            Console.WriteLine("Unesite JMBG osobe koju zelite obrisati:");
            string jmbg = Console.ReadLine();
            foreach (Osoba o in Liste.osobe)
            {
                if (o.JMBG == jmbg)
                {
                    Liste.osobe.Remove(o);
                    break;
                }
            }
        }

        internal static void SacuvajPodatke(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamWriter writer = new StreamWriter(adresa, false, Encoding.UTF8))
                {
                    foreach (Osoba o in Liste.osobe)
                    {
                        writer.WriteLine(o.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }
        }

        internal static void UcitajIzFajla(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamReader sr = new StreamReader(adresa))
                {
                    string linija;
                    while ((linija = sr.ReadLine()) != null)
                    {
                        Liste.osobe.Add(Osoba.FromFileToObject(linija));
                    }
                }
            }
            else
            {
                Console.WriteLine("Fajl ne postoji");
            }
        }
    }
}
