using POP.Util;
using POP_SF_60_2016GUI.Model;
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
        public ObservableCollection<Stavke> Stavke { get; set; }
        public ObservableCollection<Salon> Salon { get; set; }


        private Projekat()
        {
            TipoviNamjestaja = TipNamjestaja.GetAll();
            Namjestaj = Model.Namjestaj.GetAll();
            Korisnik = Model.Korisnik.GetAll();
            DodatnaUsluga = Model.DodatnaUsluga.GetAll();

            Akcija = Model.Akcija.GetAll();
    //        ProdajaNamjestaja = Model.ProdajaNamjestaja.GetAll();
           
        }

     

    }
}
