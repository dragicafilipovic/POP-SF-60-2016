using POP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF_60_2016GUI.Model
{
    public class Stavke : INotifyPropertyChanged
    {
        private int id;
        private int kolicina;
        private bool obrisan;
        private int namjestajId;

        public int NamjestajID
        {
            get { return namjestajId; }
            set
            {
                namjestajId = value;
                OnPropertyChanged("namjestajId");
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

        private Namjestaj namjestaj;
        public Namjestaj Namjestaj
        {
            get
            {
                if (namjestaj == null)
                {
                    namjestaj = Namjestaj.GetID(NamjestajID);
                }
                return namjestaj;
            }
            set
            {
                namjestaj = value;
                NamjestajID = namjestaj.Id;
                OnPropertyChanged("Namjestaji");
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
