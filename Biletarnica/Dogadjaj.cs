using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletarnica
{
    public class Dogadjaj
    {
        public int Id { set; get; }
        public string Naziv { set; get; }
        public string Mesto { set; get; }
        public string Vreme { set; get; }

        public Dogadjaj(int id, string naziv, string mesto, string vreme)
        {
            Id = id;
            Naziv = naziv;
            Mesto = mesto;
            Vreme = vreme;
        }

        public override string ToString()
        {
            return $"Dogadjaj sa ID {Id}, pod nazivom {Naziv} odrzava se {Vreme} na lokaciji {Mesto}";
        }
    }
}
