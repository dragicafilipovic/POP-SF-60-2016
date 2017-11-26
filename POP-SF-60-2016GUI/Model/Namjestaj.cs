using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP.Model
{
    public class Namjestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private double jedinicnaCijena;
        private bool obrisan;
        private string sifra;
        private int kolicinaUMagacinu;
        private int tipNamjestajaID;
        private TipNamjestaja tipNamjestaja;

        [XmlIgnore]
        public TipNamjestaja TipNamjestaja
        {
            get
            {
                if (tipNamjestaja == null)
                {
                    tipNamjestaja = TipNamjestaja.GetID(TipNamjestajaID);
                }
                return tipNamjestaja;
            }
            set
            {
                tipNamjestaja = value;
                TipNamjestajaID = tipNamjestaja.Id;
                OnPropertyCgabged("TipNamjestaja");
            }
        }


        public int TipNamjestajaID
        {
            get { return tipNamjestajaID; }
            set
            {
                tipNamjestajaID = value;
                OnPropertyCgabged("TipNamjestajaID");
            }
        }


        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyCgabged("KolicinaUMagacinu");
            }
        }


        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyCgabged("Sifra");
            }
        }


        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyCgabged("Obrisan");
            }
        }


        public double JedinicnaCijena
        {
            get { return jedinicnaCijena; }
            set
            {
                jedinicnaCijena = value;
                OnPropertyCgabged("JedinicnaCijena");
            }
        }


        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyCgabged("Naziv");
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


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"Naziv{Naziv}, Cena{JedinicnaCijena} tipNamestaja {TipNamjestaja.GetID(tipNamjestajaID)}";
        }

        protected void OnPropertyCgabged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Namjestaj()
            {
                Id = id,
                Naziv = naziv,
                JedinicnaCijena = jedinicnaCijena,
                Obrisan = obrisan,
                TipNamjestaja = tipNamjestaja,
                TipNamjestajaID = tipNamjestajaID
            };
        }

        public static Namjestaj GetID(int ID)
        {
            foreach (var namjestaj in Projekat.Instance.Namjestaj)
            {
                if (namjestaj.Id.Equals(ID))
                {
                    return namjestaj;
                }
            }
            return null;
        }
    }
}
