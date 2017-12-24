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
                    n.Id = Convert.ToInt32(row["Id"]);
                    n.Naziv = row["Naziv"].ToString();
                    n.Cijena = double.Parse(row["Cijena"].ToString());
                    n.Sifra = row["Sifra"].ToString();
                    n.Kolicina = Convert.ToInt32((row["Kolicina"]));
                    n.tipNamjestajaID = Convert.ToInt32(row["TipNamjestajaID"]);
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namjestaj.Add(n);
                }
            }
            return namjestaj;
        }

        public static Namjestaj Create(Namjestaj n)
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
                cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                n.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.Namjestaj.Add(n);
            return n;
        }

        public static void Update(Namjestaj n)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Namjestaj SET TipNamjestajaID = @TipNamjestajaID Naziv = @Naziv Cijena = @Cijena Kolicina = @Kolicina Obrisan = @Obrisan WHERE Id = @Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("TipNamjestajaID", n.tipNamjestajaID);
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
                    namjestaj.Kolicina = n.Kolicina;
                    namjestaj.TipNamjestaja = n.TipNamjestaja;
                    namjestaj.Obrisan = n.Obrisan;
                }
            }
        }

        public static void Delete(Namjestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }

        public static Namjestaj GetByid(int id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Namjestaj WHERE Obrisan = 0 AND Id=@Dd;";
                cmd.Parameters.AddWithValue("@Id", id);
                da.SelectCommand = cmd;
                da.Fill(ds, "Namjestaj");

                foreach (DataRow row in ds.Tables["Namjestaj"].Rows)
                {
                    var n = new Namjestaj();
                    n.Id = Convert.ToInt32(row["Id"]);
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
        #endregion
    }
}
