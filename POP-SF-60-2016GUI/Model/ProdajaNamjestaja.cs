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

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyCgabged("Id");
            }
        }
        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyCgabged("Kupac");
            }
        }
        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyCgabged("BrojRacuna");
            }
        }
        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyCgabged("DatumProdaje");
            }
        }
        public List<int> DodatnaUslugaID
        {
            get { return dodatnaUslugaID; }

            set
            {
                dodatnaUslugaID = value;
                OnPropertyCgabged("DodatnaUslugaID");
            }
        }
        public List<int> NamjestajProdajaID
        {
            get { return namjestajProdajaID; }
            set
            {
                namjestajProdajaID = value;
                OnPropertyCgabged("NamjestajProdajaID");
            }
        }
        public double UkupanIznos
        {
            get { return ukupanIznos; }
            set
            {
                ukupanIznos = value;
                OnPropertyCgabged("UkupanIznos");
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
                UkupanIznos = ukupanIznos
            };
        }

        protected void OnPropertyCgabged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static ObservableCollection<Namjestaj> NamjestajPoId(List<int> namjestajId)
        {
            ObservableCollection<Namjestaj> lista = new ObservableCollection<Namjestaj>();
            foreach (var id in namjestajId)
            {
                lista.Add(Namjestaj.GetID(id));
            }
            return lista;
        }

        public static List<int> Idnamjestaja(ObservableCollection<Namjestaj> namjestaj)
        {
            List<int> lista=new List<int>();
            foreach (var n in namjestaj)
            {
                lista.Add(n.Id);
            }
            return lista;
        }

        public static ObservableCollection<DodatnaUsluga> DodatnaUslugaId(List<int> uslugaId)
        {
            ObservableCollection<DodatnaUsluga> lista = new ObservableCollection<DodatnaUsluga>();
            foreach (var id in uslugaId)
            {
                lista.Add(DodatnaUsluga.GetID(id));
            }
            return lista;
        }

        public static List<int> Idusluga(ObservableCollection<DodatnaUsluga> dodatnaUsluga)
        {
            List<int> lista = new List<int>();
            foreach (var du in dodatnaUsluga)
            {
                lista.Add(du.Id);
            }
            return lista;
        }
    }
}
