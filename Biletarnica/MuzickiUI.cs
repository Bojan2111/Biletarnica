using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletarnica
{
    internal class MuzickiUI
    {
        internal static void DodajMuzDogadjaj()
        {
            Console.WriteLine("Unesite ID dogadjaja:");
            int noviId = int.Parse(Console.ReadLine());
            while (ProveraID(noviId))
            {
                Console.WriteLine("Dogadjaj sa ovim ID vec postoji. Unesite drugi broj.");
                noviId = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Unesite naziv dogadjaja:");
            string noviNaziv = Console.ReadLine();
            Console.WriteLine("Unesite mesto dogadjaja:");
            string novoMesto = Console.ReadLine();
            Console.WriteLine("Unesite vreme dogadjaja:");
            string novoVreme = Console.ReadLine();
            Console.WriteLine("Unesite ime izvodjaca:");
            string noviIzvodjac = Console.ReadLine();
            Console.WriteLine("Unesite muzicki zanr:");
            string noviZanr = Console.ReadLine();

            MuzickiDogadjaj noviDogadjaj = new MuzickiDogadjaj(noviId, noviNaziv, novoMesto, novoVreme, noviIzvodjac, noviZanr);
            Liste.muzickiDogadjaji.Add(noviDogadjaj);
            Liste.dogadjaji.Add(noviDogadjaj);
        }

        private static bool ProveraID(int unos)
        {
            foreach (Dogadjaj dog in Liste.dogadjaji)
            {
                if (dog.Id == unos)
                {
                    return true;
                }
            }
            return false;
        }

        internal static void SacuvajPodatke(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamWriter writer = new StreamWriter(adresa, false, Encoding.UTF8))
                {
                    foreach (MuzickiDogadjaj md in Liste.muzickiDogadjaji)
                    {
                        writer.WriteLine(md.ToFileString());
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
                        Liste.muzickiDogadjaji.Add(MuzickiDogadjaj.FromFileToObject(linija));
                        Liste.dogadjaji.Add(MuzickiDogadjaj.FromFileToObject(linija));
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
