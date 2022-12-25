using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletarnica
{
    public enum TipUlaznice { OBICNA, VIP };
    internal class Ulaznica
    {
        public int Id { set; get; }
        public double Cena { set; get; }
        public TipUlaznice Tip { set; get; }
        public Dogadjaj Dogadjaj { set; get; }
        public Osoba Osoba { set; get; }

        public Ulaznica(int id, double cena, TipUlaznice tip, Dogadjaj dogadjaj, Osoba osoba)
        {
            Id = id;
            Cena = cena;
            Tip = tip;
            Dogadjaj = dogadjaj;
            Osoba = osoba;
        }
        public static Ulaznica FromFileToObject(string tekst)
        {
            string[] tokeni = tekst.Split(',');

            if (tokeni.Length != 5)
            {
                Console.WriteLine("Greska pri ocitavanju osobe " + tekst);
                Environment.Exit(0);
            }
            TipUlaznice tip = TipUlaznice.OBICNA;
            if (tokeni[2] == "V")
                tip = TipUlaznice.VIP;
            Dogadjaj tempDog = null;
            foreach (MuzickiDogadjaj md in Liste.muzickiDogadjaji)
            {
                if (md.Id == int.Parse(tokeni[3])) 
                {
                    tempDog = md;
                    break;
                }
            }
            foreach (SportskiDogadjaj sd in Liste.sportskiDogadjaji)
            {
                if (sd.Id == int.Parse(tokeni[3]))
                {
                    tempDog = sd;
                    break;
                }
            }
            Osoba osoba = null;
            foreach (Osoba o in Liste.osobe)
            {
                if (o.JMBG == tokeni[4])
                {
                    osoba = o;
                    break;
                }
            }
            return new Ulaznica(int.Parse(tokeni[0]), double.Parse(tokeni[1]), tip, tempDog, osoba);
        }

        public string ToFileString()
        {
            string tipUl = "O";
            if (Tip == TipUlaznice.VIP)
                tipUl = "V";

            return $"{Id},{Cena},{tipUl},{Dogadjaj.Id},{Osoba.JMBG}";
        }

        public override string ToString()
        {
            string tipString;
            if (Tip == TipUlaznice.OBICNA)
            {
                tipString = "Obicna";
            }
            else
            {
                tipString = "VIP";
            }
            return $"id:{Id},cena:{Cena},tip:{tipString},naziv dogadjaja:{Dogadjaj.Naziv},osoba:{Osoba}";
        }
    }
}
