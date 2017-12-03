using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public class DodatnaUsluga: INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string nazivUsluge;
        private bool obrisan;
        private double cijenaUsuge;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string NazivUsluge
        {
            get { return nazivUsluge; }
            set
            {
                nazivUsluge = value;
                OnPropertyChanged("NazivUsluge");
            }
        }

        public double CijenaUsluge
        {
            get { return cijenaUsuge; }
            set
            {
                cijenaUsuge = value;
                OnPropertyChanged("CijenaUsluge");
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

        public override string ToString()
        {
            return $"{NazivUsluge}";
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return new DodatnaUsluga()
            {
                Id = id,
                NazivUsluge = nazivUsluge,
                CijenaUsluge = cijenaUsuge,
                Obrisan = obrisan
            };

        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static DodatnaUsluga GetID(int ID)
        {
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (usluga.Id.Equals(ID))
                {
                    return usluga;
                }
            }
            return null;
        }
    }
}
