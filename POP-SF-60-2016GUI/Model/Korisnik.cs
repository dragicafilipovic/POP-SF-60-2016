﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }
        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }
        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }
        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
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
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region CRUD
        public static ObservableCollection<Korisnik> GetAll()
        {
            var korisnik = new ObservableCollection<Korisnik>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik");

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var k = new Korisnik();
                    k.Id = Convert.ToInt32(row["Id"]);
                    k.Ime = row["Ime"].ToString();
                    k.Prezime = row["Prezime"].ToString();
                    k.KorisnickoIme = row["KorisnickoIme"].ToString();
                    k.Lozinka = row["Lozinka"].ToString();
                    k.TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), row["TipKorisnika"].ToString());
                    k.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    korisnik.Add(k);
                }
            }
            return korisnik;
        }

        public static Korisnik Create(Korisnik k)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan)  VALUES (@Ime, @Prezime, @KorisnickoIme, @Lozinka, @TipKorisnika, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", k.TipKorisnika);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);

                k.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.Korisnik.Add(k);
            return k;
        }

        public static void Update(Korisnik k)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Korisnik SET Naziv = @Naziv, Obrisan = @Obrisan WHERE Id = @Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", k.Id);
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", k.TipKorisnika);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);

                cmd.ExecuteNonQuery();
            }

            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                if (k.Id == korisnik.Id)
                {
                    korisnik.Ime = k.Ime;
                    korisnik.Prezime = k.Prezime;
                    korisnik.KorisnickoIme = k.KorisnickoIme;
                    korisnik.Lozinka = k.Lozinka;
                    korisnik.TipKorisnika = k.TipKorisnika;
                    korisnik.Obrisan = k.Obrisan;
                }
            }
        }

        public static void Delete(Korisnik k)
        {
            k.Obrisan = true;
            Update(k);
        }
        #endregion
    }
}
