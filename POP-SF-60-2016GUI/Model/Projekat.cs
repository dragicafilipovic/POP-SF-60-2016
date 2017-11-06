using POP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        private List<Namjestaj> namjestaj;
        private List<TipNamjestaja> tipNamjestaja;
        private List<Akcija> akcija;
        private List<Korisnik> korisnik;
        private List<DodatnaUsluga> usluga;

        public List<DodatnaUsluga> DodatnaUsluga 
        {
            get
            {
                this.usluga = GenericSerializer.Deserialize<DodatnaUsluga>("usluga.xml");
                return this.usluga;
            }
            set
            {
                this.usluga = value;
                GenericSerializer.Serialize<DodatnaUsluga>("usluga.xml", usluga);
            }
        }


        public List<Korisnik> Korisnik
        {
            get
            {
                this.korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
                return this.korisnik;
            }
            set
            {
                this.korisnik = value;
                GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnik);
            }
        }


        public List<Namjestaj> Namjestaj
        {
            get
            {
                this.namjestaj = GenericSerializer.Deserialize<Namjestaj>("namjestaj.xml");
                return this.namjestaj;
            }
            set
            {
                this.namjestaj = value;
                GenericSerializer.Serialize<Namjestaj>("namjestaj.xml", namjestaj);
            }
        }

        public List<TipNamjestaja> TipNamjestaja
        {
            get
            {
                this.tipNamjestaja = GenericSerializer.Deserialize<TipNamjestaja>("tipNamjestaja.xml");
                return this.tipNamjestaja;
            }
            set
            {
                this.tipNamjestaja = value;
                GenericSerializer.Serialize<TipNamjestaja>("tipNamjestaja.xml", tipNamjestaja);
            }
        }

        public List<Akcija> Akcija
        {
            get
            {
                this.akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
                return this.akcija;
            }
            set
            {
                this.akcija = value;
                GenericSerializer.Serialize<Akcija>("akcija.xml", akcija);
            }
        }

     

    }
}
