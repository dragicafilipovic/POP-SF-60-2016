using POP.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        public ObservableCollection<TipNamjestaja> TipoviNamjestaja { get; set; }
        public ObservableCollection<Namjestaj> Namjestaj { get; set; }
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection<Akcija> Akcija { get; set; }
        public ObservableCollection<ProdajaNamjestaja> ProdajaNamjestaja { get; set; }


        private Projekat()
        {
            TipoviNamjestaja = GenericSerializer.Deserialize<TipNamjestaja>("tipNamjestaja.xml");
            Namjestaj = GenericSerializer.Deserialize<Namjestaj>("namjestaj.xml");
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            DodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("usluga.xml");
            Akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
            //ProdajaNamjestaja = GenericSerializer.Deserialize<ProdajaNamjestaja>("prodajaNamjestaja.xml");
           
        }

     

    }
}
