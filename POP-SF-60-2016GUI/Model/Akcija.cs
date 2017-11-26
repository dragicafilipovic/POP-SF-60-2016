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
    public class Akcija: INotifyPropertyChanged
    {
        private int id;
        private bool obrisan;
        private decimal popust;
        private DateTime pocetakAkcije;
        private DateTime zavrsetakAkcije;
        private List<int> namjestajNaAkcijiID;

        public List<int> NamjestajNaAkcijiID
        {
            get { return namjestajNaAkcijiID; }
            set
            {
                namjestajNaAkcijiID = value;
                OnPropertyCgabged("NamjestajaNaAkcijiID");
            }
        }


        public DateTime ZavrsetakAkcije
        {
            get { return zavrsetakAkcije; }
            set
            {
                zavrsetakAkcije = value;
                OnPropertyCgabged("ZavrsetakAkcija");
            }
        }


        public DateTime PocetakAkcije
        {
            get { return pocetakAkcije; }
            set
            {
                pocetakAkcije = value;
                OnPropertyCgabged("PocetakAkcije");
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

 
        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyCgabged("Obrisan");
            }
        }


        public decimal Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyCgabged("Popust");
            }
        }
        


        private ObservableCollection<Namjestaj> namjestajAkcija;

        [XmlIgnore]
        public ObservableCollection<Namjestaj> NamjestajAkcija

        {
            get
            {
                if(namjestajAkcija == null)
                {
                    foreach (var id in namjestajNaAkcijiID)
                    {
                        namjestajAkcija.Add(Namjestaj.GetID(id));
                    }
                }
                return namjestajAkcija;
            }
            set
            {
                namjestajAkcija = value;
                foreach (var namjestaj in namjestajAkcija)
                {
                    namjestajNaAkcijiID.Add(namjestaj.Id);
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyCgabged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
