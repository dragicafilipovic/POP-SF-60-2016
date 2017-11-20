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
        public int ID { get; set; }
        public string Naziv { get; set; }
        public bool Obrisan { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static TipNamjestaja GetID(int ID)
        {
            foreach (var TipNamjestaja in Projekat.Instance.TipNamjestajaID)
            {
                if (TipNamjestaja.ID.Equals(ID))
                {
                    return TipNamjestaja;
                }
            }
            return null;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        protected void OnPropertyCgabged(string propertyName)
        {
            if (PropertyChanged != null)
            {
               
            }
        }
    }
}
