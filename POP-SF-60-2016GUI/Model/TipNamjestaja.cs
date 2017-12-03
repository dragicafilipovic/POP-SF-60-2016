using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public class TipNamjestaja: INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private bool obrisan;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
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

        public static TipNamjestaja GetID(int ID)
        {
            foreach (var TipNamjestaja in Projekat.Instance.TipoviNamjestaja)
            {
                if (TipNamjestaja.Id.Equals(ID))
                {
                    return TipNamjestaja;
                }
            }
            return null;
        }

        public object Clone()
        {
            return new TipNamjestaja()
            {
                Id = id,
                Naziv = naziv,
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
        public override string ToString()
        {
            return $"{Naziv}";
        }
    }
}
