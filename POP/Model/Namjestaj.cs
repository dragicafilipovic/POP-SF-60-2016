﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public class Namjestaj
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double JedinicnaCijena { get; set; }
        public int KolicinaUMagacina { get; set; }
        public bool Obrisan { get; set; }
        public TipNamjestaja TipNamjestaja { get; set; }
        public override string ToString()
        {
            return $"{ Naziv }, { JedinicnaCijena },{TipNamjestaja.GetByID()}";
        }
    }
}
