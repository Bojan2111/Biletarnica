using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletarnica
{
    internal class UlaznicaUI
    {
        internal static void DodajUlaznicu()
        {
            Console.WriteLine("Unesite ID ulaznice:");
            int noviId = int.Parse(Console.ReadLine());
            while (ProveraIdUlaznice(noviId))
            {
                Console.WriteLine("Ulaznica sa ovim ID vec postoji. Unesite drugi broj.");
                noviId = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Unesite cenu ulaznice:");
            double novaCena = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite tip ulaznice (O - obicna/V - VIP):");
            string noviTip = Console.ReadLine();
            Console.WriteLine("Unesite ID dogadjaja:");
            int noviIdDogadjaja = int.Parse(Console.ReadLine());
            while (!ProveraIdDogadjaja(noviIdDogadjaja))
            {
                Console.WriteLine("Ne postoji dogadjaj sa navedenim ID. Unesite drugi broj:");
                noviIdDogadjaja = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Unesite JMBG:");
            string noviJMBG = Console.ReadLine();
            while (!OsobaUI.ProveraJMBG(noviJMBG))
            {
                Console.WriteLine("Ne postoji registrovana osoba sa ovim JMBG. Unesite drugi JMBG:");
                noviJMBG = Console.ReadLine();
            }
            string linija = $"{noviId},{novaCena},{noviTip},{noviIdDogadjaja},{noviJMBG}";

            Liste.ulaznice.Add(Ulaznica.FromFileToObject(linija));
        }

        private static bool ProveraIdUlaznice(int unos)
        {
            foreach (Ulaznica ul in Liste.ulaznice)
            {
                if (ul.Id == unos)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool ProveraIdDogadjaja(int unos)
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

        internal static void IspisiSveUlaznice()
        {
            foreach (Ulaznica ul in Liste.ulaznice)
            {
                Console.WriteLine(ul);
            }
        }

        internal static void ObrisiUlaznicu()
        {
            Console.WriteLine("Unesite ID ulaznice koju zelite obrisati:");
            int idZaBrisanje = int.Parse(Console.ReadLine());
            foreach (Ulaznica ul in Liste.ulaznice)
            {
                if (ul.Id == idZaBrisanje)
                {
                    Liste.ulaznice.Remove(ul);
                }
            }
        }

        internal static void SacuvajPodatke(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamWriter writer = new StreamWriter(adresa, false, Encoding.UTF8))
                {
                    foreach (Ulaznica ul in Liste.ulaznice)
                    {
                        writer.WriteLine(ul.ToFileString());
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
                        Liste.ulaznice.Add(Ulaznica.FromFileToObject(linija));
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
