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
using System.Xml.Serialization;

namespace POP.Model
{
    public class Namjestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private double cijena;
        private bool obrisan;
        private string sifra;
        private int kolicina;
        private int tipNamjestajaID;
        private TipNamjestaja tipNamjestaja;
        private double akcijskaCijena;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int TipNamjestajaID
        {
            get { return tipNamjestajaID; }
            set
            {
                tipNamjestajaID = value;
                OnPropertyChanged("TipNamjestajaID");
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

        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        public double Cijena
        {
            get { return cijena; }
            set
            {
                cijena = value;
                OnPropertyChanged("JedinicnaCijena");
            }
        }


        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("KolicinaUMagacinu");
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

        public double AkcijskaCijena
        {
            get { return akcijskaCijena; }
            set
            {
                akcijskaCijena = value;
                OnPropertyChanged("AkcijskaCijena");
            }
        }

        [XmlIgnore]
        public TipNamjestaja TipNamjestaja
        {
            get
            {
                if (tipNamjestaja == null)
                {
                    tipNamjestaja = TipNamjestaja.GetID(TipNamjestajaID);
                }
                return tipNamjestaja;
            }
            set
            {
                tipNamjestaja = value;
                TipNamjestajaID = tipNamjestaja.Id;
                OnPropertyChanged("TipNamjestaja");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Naziv}";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Namjestaj()
            {
                Id = id,
                Naziv = naziv,
                Cijena = cijena,
                Kolicina = kolicina,
                Obrisan = obrisan,
                Sifra = sifra,
                AkcijskaCijena = akcijskaCijena,
                TipNamjestaja = tipNamjestaja,
                TipNamjestajaID = tipNamjestajaID
            };
        }

        public static Namjestaj GetID(int ID)
        {
            foreach (var namjestaj in Projekat.Instance.Namjestaj)
            {
                if (namjestaj.Id.Equals(ID))
                {
                    return namjestaj;
                }
            }
            return null;
        }

        #region CRUD
        public static ObservableCollection<Namjestaj> GetAll()
        {
            try
            {
                var namjestaj = new ObservableCollection<Namjestaj>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM Namjestaj WHERE Obrisan = 0;";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Namjestaj");

                    foreach (DataRow row in ds.Tables["Namjestaj"].Rows)
                    {
                        var n = new Namjestaj();
                        n.Id = Convert.ToInt32(row["NId"]);
                        n.Naziv = row["Naziv"].ToString();
                        n.Cijena = double.Parse(row["Cijena"].ToString());
                        n.Sifra = row["Sifra"].ToString();
                        n.Kolicina = Convert.ToInt32((row["Kolicina"]));
                        n.akcijskaCijena = double.Parse(row["AkcijskaCijena"].ToString());
                        n.tipNamjestajaID = Convert.ToInt32(row["TipNamjestajaID"]);
                        n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        namjestaj.Add(n);
                    }
                }
                return namjestaj;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska kod ucitavanja namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static Namjestaj Create(Namjestaj n)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "INSERT INTO Namjestaj (TipNamjestajaID, Naziv, Sifra, Cijena, Kolicina, Obrisan) VALUES (@TipNamjestajaID, @Naziv, @Sifra, @Cijena, @Kolicina, @Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("TipNamjestajaID", n.TipNamjestaja.Id);
                    cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                    cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                    cmd.Parameters.AddWithValue("Cijena", n.Cijena);
                    cmd.Parameters.AddWithValue("AkcisjkaCijena", n.AkcijskaCijena);
                    cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);
                    cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                    n.Id = int.Parse(cmd.ExecuteScalar().ToString());
                }

                Projekat.Instance.Namjestaj.Add(n);
                return n;

            }
            catch (Exception)
            {
                MessageBox.Show("Greska kod dodavanja namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static void Update(Namjestaj n)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "UPDATE Namjestaj SET  Naziv = @Naziv, TipNamjestajaID = @TipNamjestajaID, Sifra = @Sifra, Cijena = @Cijena, Kolicina = @Kolicina, Obrisan = @Obrisan WHERE NId = @NId;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("NId", n.Id);
                    cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                    cmd.Parameters.AddWithValue("TipNamjestajaID", n.tipNamjestajaID);
                    cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                    cmd.Parameters.AddWithValue("Cijena", n.Cijena);
                    cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);
                    cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                    cmd.ExecuteNonQuery();
                }

                foreach (var namjestaj in Projekat.Instance.Namjestaj)
                {
                    if (n.Id == namjestaj.Id)
                    {
                        namjestaj.tipNamjestajaID = n.TipNamjestajaID;
                        namjestaj.Naziv = n.Naziv;
                        namjestaj.Cijena = n.Cijena;
                        namjestaj.Sifra = n.Sifra;
                        namjestaj.Kolicina = n.Kolicina;
                        namjestaj.Obrisan = n.Obrisan;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom izmjene namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static void Delete(Namjestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }

        public static Namjestaj GetByid(int id)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM Namjestaj WHERE Obrisan = 0 AND NId=@Id;";
                    cmd.Parameters.AddWithValue("@Id", id);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Namjestaj");

                    foreach (DataRow row in ds.Tables["Namjestaj"].Rows)
                    {
                        var n = new Namjestaj();
                        n.Id = Convert.ToInt32(row["NId"]);
                        n.Naziv = row["Naziv"].ToString();
                        n.Cijena = double.Parse(row["Cijena"].ToString());
                        n.Sifra = row["Sifra"].ToString();
                        n.Kolicina = Convert.ToInt32((row["Kolicina"]));
                        n.tipNamjestajaID = Convert.ToInt32(row["TipNamjestajaID"]);
                        n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        return n;

                    }

                }
                return null;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static ObservableCollection<Namjestaj> Order(string text)
        {
            try
            {
                var namjestaj = new ObservableCollection<Namjestaj>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM Namjestaj  JOIN TipNamjestaja ON Namjestaj.TipNamjestajaID=TipNamjestaja.Id WHERE Namjestaj.Obrisan = 0 ORDER BY " + text;
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Namjestaj");

                    foreach (DataRow row in ds.Tables["Namjestaj"].Rows)
                    {
                        var n = new Namjestaj();
                        n.Id = Convert.ToInt32(row["NId"]);
                        n.Naziv = row["Naziv"].ToString();
                        n.Cijena = double.Parse(row["Cijena"].ToString());
                        n.Sifra = row["Sifra"].ToString();
                        n.Kolicina = Convert.ToInt32((row["Kolicina"]));
                        n.akcijskaCijena = double.Parse(row["AkcijskaCijena"].ToString());
                        n.tipNamjestajaID = Convert.ToInt32(row["TipNamjestajaID"]);
                        n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        namjestaj.Add(n);
                    }
                }
                return namjestaj;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom sortiranja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static ObservableCollection<Namjestaj> Search(string text)
        {
            try
            {
                var namjestaj = new ObservableCollection<Namjestaj>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM Namjestaj JOIN TipNamjestaja ON Namjestaj.TipNamjestajaID=TipNamjestaja.Id WHERE Namjestaj.Obrisan=0 AND (Namjestaj.Naziv LIKE @tekst OR Sifra LIKE @tekst OR Kolicina LIKE @tekst OR Cijena LIKE @tekst OR TipNamjestaja.Naziv LIKE @tekst)";
                    da.SelectCommand = cmd;
                    cmd.Parameters.AddWithValue("@tekst", '%' + text + '%');
                    da.Fill(ds, "Namjestaj");

                    foreach (DataRow row in ds.Tables["Namjestaj"].Rows)
                    {
                        var n = new Namjestaj();
                        n.Id = Convert.ToInt32(row["NId"]);
                        n.Naziv = row["Naziv"].ToString();
                        n.Cijena = double.Parse(row["Cijena"].ToString());
                        n.Sifra = row["Sifra"].ToString();
                        n.Kolicina = Convert.ToInt32((row["Kolicina"]));
                        n.akcijskaCijena = double.Parse(row["AkcijskaCijena"].ToString());
                        n.tipNamjestajaID = Convert.ToInt32(row["TipNamjestajaID"]);
                        n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        namjestaj.Add(n);
                    }
                }
                return namjestaj;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom pretrage!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        #endregion
    }
}
