using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POP.Model
{
    public class Salon: INotifyPropertyChanged,ICloneable
    {
        private int id;
        private string brojZiroRacuna;
        private int maticniBr;
        private string pib;
        private string adresaSajta;
        private string email;
        private string brTelefona;
        private string adresa;
        private string naziv;



        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }


        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }


        public string BrTelefona
        {
            get { return brTelefona; }
            set
            {
                brTelefona = value;
                OnPropertyChanged("BrTelefona");
            }
        }


        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }


        public string AdresaSajta
        {
            get { return adresaSajta; }
            set
            {
                adresaSajta = value;
                OnPropertyChanged("AdresaSajta");
            }
        }


        public string Pib
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("Pib");
            }
        }


        public int MaticniBr
        {
            get { return maticniBr; }
            set
            {
                maticniBr = value;
                OnPropertyChanged("MaticniBr");
            }
        }


        public string BrojZiroRacuna
        {
            get { return brojZiroRacuna; }
            set
            {
                brojZiroRacuna = value;
                OnPropertyChanged("BrojZiroRacuna");
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

        public object Clone()
        {
            return new Salon()
            {
                Id = id,
                Naziv = naziv,
                Adresa = adresa,
                BrTelefona = BrTelefona,
                Email = email,
                AdresaSajta = adresaSajta,
                Pib = pib,
                MaticniBr = maticniBr,
                BrojZiroRacuna = brojZiroRacuna,
            };

        }

        #region CRUD

        public static ObservableCollection<Salon> GetAll()
        {
            try
            {
                var salon = new ObservableCollection<Salon>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM Salon ";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Salon");

                    foreach (DataRow row in ds.Tables["Salon"].Rows)
                    {
                        var s = new Salon();
                        s.Id = int.Parse(row["Id"].ToString());
                        s.Naziv = row["Naziv"].ToString();
                        s.Adresa = row["Adresa"].ToString();
                        s.BrTelefona = row["BrTelefona"].ToString();
                        s.Email = row["Email"].ToString();
                        s.AdresaSajta = row["AdresaSajta"].ToString();
                        s.Pib = row["Pib"].ToString();
                        s.MaticniBr = Convert.ToInt32(row["MaticniBr"]);
                        s.BrojZiroRacuna = row["BrojZiroRacuna"].ToString();

                        salon.Add(s);
                    }
                }
                return salon;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska kod ucitavanja salona!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static void Update(Salon s)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                                                             
                    cmd.CommandText = "UPDATE Salon SET  Naziv = @Naziv, Adresa = @Adresa, BrTelefona = @BrTelefona, Email = @Email, AdresaSajta = @AdresaSajta, Pib = @Pib, MaticniBr = @MaticniBr, BrojZiroRacuna = @BrojZiroRacuna;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("NId", s.Id);
                    cmd.Parameters.AddWithValue("Naziv", s.Naziv);
                    cmd.Parameters.AddWithValue("Adresa", s.Adresa);
                    cmd.Parameters.AddWithValue("BrTelefona", s.BrTelefona);
                    cmd.Parameters.AddWithValue("Email", s.Email);
                    cmd.Parameters.AddWithValue("AdresaSajta", s.AdresaSajta);
                    cmd.Parameters.AddWithValue("Pib", s.Pib);
                    cmd.Parameters.AddWithValue("MaticniBr", s.MaticniBr);
                    cmd.Parameters.AddWithValue("BrojZiroRacuna", s.BrojZiroRacuna);

                    cmd.ExecuteNonQuery();
                }

                foreach (var salon in Projekat.Instance.Salon)
                {
                    if (s.Id == salon.Id)
                    {
                        salon.Naziv = s.Naziv;
                        salon.Adresa = s.Adresa;
                        salon.BrTelefona = s.BrTelefona;
                        salon.Email = s.Email;
                        salon.AdresaSajta = s.AdresaSajta;
                        salon.Pib = s.Pib;
                        salon.MaticniBr = s.MaticniBr;
                        salon.BrojZiroRacuna = s.BrojZiroRacuna;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom izmjene salona!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
    }
}
