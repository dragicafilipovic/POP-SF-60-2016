using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP.Model
{
   public  class ProdajaNamjestaja: INotifyPropertyChanged, ICloneable
    {
        private int id;
        private List<int> namjestajProdajaID;
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;
        private List<int> dodatnaUslugaID;
        private double ukupanIznos;
        private double kolicina;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }
        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }
        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }
        public List<int> DodatnaUslugaID
        {
            get { return dodatnaUslugaID; }

            set
            {
                dodatnaUslugaID = value;
                OnPropertyChanged("DodatnaUslugaID");
            }
        }
        public List<int> NamjestajProdajaID
        {
            get { return namjestajProdajaID; }
            set
            {
                namjestajProdajaID = value;
                OnPropertyChanged("NamjestajProdajaID");
            }
        }
        public double Kolicina
        {
            get
            { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }
        }
        public double UkupanIznos
        {
            get { return ukupanIznos; }
            set
            {
                ukupanIznos = value;
                OnPropertyChanged("UkupanIznos");
            }
        }

 
        public const double PDV = 0.02;

        public ProdajaNamjestaja()
        {
            datumProdaje = DateTime.Today;
        }

        private ObservableCollection<Namjestaj> namjestajProdaja;

        [XmlIgnore]
        public ObservableCollection<Namjestaj> NamjestajProdaja

        {
            get
            {
                if (namjestajProdaja == null)
                {
                    namjestajProdaja = NamjestajPoId(namjestajProdajaID);
                }
                return namjestajProdaja;
            }
            set
            {
                namjestajProdaja = value;
                namjestajProdajaID = Idnamjestaja(namjestajProdaja);
                OnPropertyChanged("NamjestajProdaja");
            }
        }

        private ObservableCollection<DodatnaUsluga> dodatneUsluge;

        [XmlIgnore]
        public ObservableCollection<DodatnaUsluga> DodatneUsluge
        {
            get
            {
                if (dodatneUsluge == null)
                {
                    dodatneUsluge = DodatnaUslugaId(dodatnaUslugaID);
                }
                return dodatneUsluge;
            }
            set
            {
                dodatneUsluge = value;
                dodatnaUslugaID = Idusluga(dodatneUsluge);
                OnPropertyChanged("DodatneUsluge");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;


        public object Clone()
        {
            return new ProdajaNamjestaja()
            {
                Id = id,
                NamjestajProdajaID = namjestajProdajaID,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                DodatnaUslugaID = dodatnaUslugaID,
                Kolicina = kolicina,
                NamjestajProdaja = namjestajProdaja,
                DodatneUsluge = dodatneUsluge,
                UkupanIznos = ukupanIznos
                
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static ObservableCollection<Namjestaj> NamjestajPoId(List<int> namjestajId)
        {   if (namjestajId != null)
            {
                ObservableCollection<Namjestaj> lista = new ObservableCollection<Namjestaj>();
                foreach (var id in namjestajId)
                {
                    lista.Add(Namjestaj.GetID(id));
                }
                return lista;
            }
            return null;
        }

        public static List<int> Idnamjestaja(ObservableCollection<Namjestaj> namjestaj)
        {
            
            List<int> lista=new List<int>();
            if (namjestaj != null)
            {
                foreach (var n in namjestaj)
                {
                    lista.Add(n.Id);
                }
                return lista;
            }
            return null;
        }

        public static ObservableCollection<DodatnaUsluga> DodatnaUslugaId(List<int> uslugaId)
        {
            ObservableCollection<DodatnaUsluga> lista = new ObservableCollection<DodatnaUsluga>();
            if (uslugaId != null)
            {
                foreach (var id in uslugaId)
                {
                    lista.Add(DodatnaUsluga.GetID(id));
                }
                return lista;
            }
            return null;
        }

        public static List<int> Idusluga(ObservableCollection<DodatnaUsluga> dodatnaUsluga)
        {
            List<int> lista = new List<int>();
            if (dodatnaUsluga != null)
            {
                foreach (var du in dodatnaUsluga)
                {
                    lista.Add(du.Id);
                }
                return lista;
            }
            return null;
        }
    }
}
