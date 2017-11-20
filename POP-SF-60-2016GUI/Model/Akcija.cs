using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public class Akcija: INotifyPropertyChanged
    {
        private int id;
        private bool obrisan;
        private decimal popust;
        private DateTime pocetakAkcije;
        private DateTime zavrsetakAkcije;

        public DateTime ZavrsetakAkcije
        {
            get { return zavrsetakAkcije; }
            set
            {
                zavrsetakAkcije = value;
                OnPropertyCgabged("ZavrsenaAkcija");
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


        public  List<Namjestaj> NamjestajNaAkciji { get; set; }

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
