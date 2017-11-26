using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }
   public class Korisnik: INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private TipKorisnika tipKorisnika;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyCgabged("Obrisan");
            }
        }


        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyCgabged("TipKorisnika");
            }
        }


        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyCgabged("Lozinka");
            }
        }


        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyCgabged("KorisnickoIme");
            }
        }


        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyCgabged("Prezime");
            }
        }


        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyCgabged("Ime");
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

        public object Clone()
        {
            return new Korisnik()
            {
                Id = id,
                Ime = ime,
                Prezime = prezime,
                KorisnickoIme = korisnickoIme,
                Lozinka = lozinka,
                TipKorisnika = tipKorisnika,
                Obrisan = obrisan
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
