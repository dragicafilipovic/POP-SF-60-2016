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

        public double UkupanIznos
        {
            get { return ukupanIznos; }
            set
            {
                ukupanIznos = value;
                OnPropertyCgabged("UkupanIznos");
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


        public List<int> NamjestajProdajaID
        {
            get { return namjestajProdajaID; }
            set
            {
                namjestajProdajaID = value;
                OnPropertyCgabged("NamjestajProdajaID");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyCgabged("Id");
            }
        }

        public const double PDV = 0.02;

        private ObservableCollection<Namjestaj> namjestajProdaja;

        [XmlIgnore]
        public ObservableCollection<Namjestaj> NamjestajProdaja

        {
            get
            {
                if (namjestajProdaja == null)
                {
                    foreach (var id in namjestajProdajaID)
                    {
                        namjestajProdaja.Add(Namjestaj.GetID(id));
                    }
                }
                return namjestajProdaja;
            }
            set
            {
                namjestajProdaja = value;
                foreach (var namjestaj in namjestajProdaja)
                {
                    namjestajProdajaID.Add(namjestaj.Id);
                }
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
                    foreach (var id in dodatnaUslugaID)
                    {
                        dodatneUsluge.Add(DodatnaUsluga.GetID(id));
                    }
                }
                return dodatneUsluge;
            }
            set
            {
                dodatneUsluge = value;
                foreach (var usluga in dodatneUsluge)
                {
                    dodatnaUslugaID.Add(usluga.Id);
                }
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
    }
}
