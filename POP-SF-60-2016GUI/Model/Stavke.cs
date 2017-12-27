using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_60_2016GUI.Model
{
    public class Stavke : INotifyPropertyChanged
    {
        private int id;
        private int kolicina;
        private int prodajaID;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        public int ProdajaID
        {
            get { return prodajaID; }
            set
            {
                prodajaID = value;
                OnPropertyChanged("ProdajaID");
            }
        }


        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }
        }


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
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
    }
}
