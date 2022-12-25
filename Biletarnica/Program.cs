using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletarnica
{
    internal class Program
    {
        private static readonly string dataDir = "data";
        private static readonly string osobeDat = "osobe.csv";
        private static readonly string ulazniceDat = "ulaznice.csv";
        private static readonly string muzickiDat = "muzicki.csv";
        private static readonly string sportskiDat = "sportski.csv";
        private static readonly char sep = Path.DirectorySeparatorChar;

        private static string PodesiPutanju()
        {
            DirectoryInfo dir = new DirectoryInfo($".{sep}..{sep}..{sep}{dataDir}{sep}");
            string putanja = dir.FullName;
            return putanja;
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string putanjaDataDir = PodesiPutanju();
            OsobaUI.UcitajIzFajla(putanjaDataDir + osobeDat);
            MuzickiUI.UcitajIzFajla(putanjaDataDir + muzickiDat);
            SportskiUI.UcitajIzFajla(putanjaDataDir+ sportskiDat);
            UlaznicaUI.UcitajIzFajla(putanjaDataDir + ulazniceDat);
            int izbor = -1;
            while (izbor != 0)
            {
                GlavniMeni();
                izbor = int.Parse(Console.ReadLine());
                switch (izbor)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        MeniIspis();
                        break;
                    case 2:
                        MeniIzmena();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda");
                        break;
                }
            }
            OsobaUI.SacuvajPodatke(putanjaDataDir + osobeDat);
            MuzickiUI.SacuvajPodatke(putanjaDataDir + muzickiDat);
            SportskiUI.SacuvajPodatke(putanjaDataDir + sportskiDat);
            UlaznicaUI.SacuvajPodatke(putanjaDataDir + ulazniceDat);

            Console.ReadKey(true);
        }


        private static void MeniIzmena()
        {
            int izbor = -1;
            while (izbor != 0)
            {
                Console.WriteLine("1 - Dodavanje osoba\n" +
                    "2 - Dodavanje dogadjaja\n" +
                    "3 - Dodavanje ulaznica\n" +
                    "4 - Brisanje osoba\n" +
                    "5 - Brisanje dogadjaja\n" +
                    "6 - Brisanje ulaznica\n" +
                    "0 - NAZAD\n" +
                    "Odaberi opciju: ");
                izbor = int.Parse(Console.ReadLine());
                switch (izbor)
                {
                    case 0:
                        Console.WriteLine("Povratak na glavni meni");
                        break;
                    case 1:
                        OsobaUI.DodajOsobu();
                        break;
                    case 2:
                        DodajDogadjaj();
                        break;
                    case 3:
                        UlaznicaUI.DodajUlaznicu();
                        break;
                    case 4:
                        OsobaUI.ObrisiOsobu();
                        break;
                    case 5:
                        ObrisiDogadjaj();
                        break;
                    case 6:
                        UlaznicaUI.ObrisiUlaznicu();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda");
                        break;
                }
            }
        }

        private static void DodajDogadjaj()
        {
            int izbor = -1;
            while (izbor != 0)
            {
                Console.WriteLine("1 - Dodaj Muzicki Dogadjaj\n" +
                    "2 - Dodaj Sportski Dogadjaj\n" +
                    "0 - NAZAD\n" +
                    "Odaberi opciju: ");
                izbor = int.Parse(Console.ReadLine());
                switch (izbor)
                {
                    case 0:
                        Console.WriteLine("Povratak paradajza ubojice");
                        break;
                    case 1:
                        MuzickiUI.DodajMuzDogadjaj();
                        break;
                    case 2:
                        SportskiUI.DodajSpDogadjaj();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda");
                        break;
                }
            }
        }

        private static void ObrisiDogadjaj()
        {
            Console.WriteLine("Unesite ID dogadjaja koji zelite obrisati:");
            int idDogadjaja = int.Parse(Console.ReadLine());
            foreach (Dogadjaj dog in Liste.dogadjaji)
            {
                if (dog.Id == idDogadjaja)
                {
                    if (dog is SportskiDogadjaj)
                    {
                        foreach (SportskiDogadjaj sd in Liste.sportskiDogadjaji)
                        {
                            if (sd.Id == idDogadjaja)
                            {
                                Liste.sportskiDogadjaji.Remove(sd);
                                break;
                            }
                        }
                    }
                    else if (dog is MuzickiDogadjaj)
                    {
                        foreach (MuzickiDogadjaj sd in Liste.muzickiDogadjaji)
                        {
                            if (sd.Id == idDogadjaja)
                            {
                                Liste.muzickiDogadjaji.Remove(sd);
                                break;
                            }
                        }
                    }
                    Liste.dogadjaji.Remove(dog);
                    break;
                }
            }
        }

        private static void MeniIspis()
        {
            int izbor = -1;
            while (izbor != 0)
            {
                Console.WriteLine("1 - Ispis osoba\n" +
                    "2 - Ispis dogadjaja\n" +
                    "3 - Ispis ulaznica\n" +
                    "0 - NAZAD\n" +
                    "Odaberi opciju: ");
                izbor = int.Parse(Console.ReadLine());
                switch (izbor)
                {
                    case 0:
                        Console.WriteLine("Povratak na glavni meni");
                        break;
                    case 1:
                        OsobaUI.IspisiSveOsobe();
                        break;
                    case 2:
                        IspisiSveDogadjaje();
                        break;
                    case 3:
                        UlaznicaUI.IspisiSveUlaznice();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda");
                        break;
                }
            }
        }

        private static void IspisiSveDogadjaje()
        {
            foreach (Dogadjaj dog in Liste.dogadjaji)
            {
                Console.WriteLine(dog);
            }
        }

        private static void GlavniMeni()
        {
            Console.WriteLine("1 - Ispis podataka\n" +
                "2 - Izmena podataka\n" +
                "0 - IZLAZ\n" +
                "Izaberi Opciju:");
        }
    }
}
