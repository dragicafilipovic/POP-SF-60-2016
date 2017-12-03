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
    public class Akcija: INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;
        private decimal popust;
        private DateTime pocetakAkcije;
        private DateTime zavrsetakAkcije;
        private int namjestajNaAkcijiID;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int NamjestajNaAkcijiID
        {
            get { return namjestajNaAkcijiID; }
            set
            {
                namjestajNaAkcijiID = value;
                OnPropertyChanged("NamjestajaNaAkcijiID");
            }
        }

        private Namjestaj namjestajAkcija;

        [XmlIgnore]
        public Namjestaj NamjestajAkcija

        {
            get
            {
                return namjestajAkcija;
            }
            set
            {
                namjestajAkcija = value;

                namjestajNaAkcijiID = namjestajAkcija.Id;

            }
        }

        public decimal Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }

        public DateTime PocetakAkcije
        {
            get { return pocetakAkcije; }
            set
            {
                pocetakAkcije = value;
                OnPropertyChanged("PocetakAkcije");
            }
        }
        public Akcija()
        {
            pocetakAkcije = DateTime.Today;
            zavrsetakAkcije = DateTime.Today;
        }

        public DateTime ZavrsetakAkcije
        {
            get { return zavrsetakAkcije; }
            set
            {
                zavrsetakAkcije = value;
                OnPropertyChanged("ZavrsetakAkcije");
            }
        }

 
        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }
        



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Akcija()
            {
                Id = id,
                NamjestajNaAkcijiID = namjestajNaAkcijiID,
                Popust = popust,
                PocetakAkcije = pocetakAkcije,
                ZavrsetakAkcije = zavrsetakAkcije,
                Obrisan = obrisan
            };
        }
    }
}
