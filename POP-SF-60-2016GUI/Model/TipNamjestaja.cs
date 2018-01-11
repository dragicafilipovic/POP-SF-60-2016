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

        #region CRUD
        public static ObservableCollection<TipNamjestaja> GetAll()
        {
            try
            {
                var tipoviNamjestaja = new ObservableCollection<TipNamjestaja>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM TipNamjestaja WHERE Obrisan = 0;";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "TipNamjestaja");

                    foreach (DataRow row in ds.Tables["TipNamjestaja"].Rows)
                    {
                        var tn = new TipNamjestaja();
                        tn.Id = Convert.ToInt32(row["Id"]);
                        tn.Naziv = row["Naziv"].ToString();
                        tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        tipoviNamjestaja.Add(tn);
                    }
                }
                return tipoviNamjestaja;
            }
            catch (Exception)
            {
                MessageBox.Show("Greksa prilikom ucitavanja tipa namjestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static TipNamjestaja Create(TipNamjestaja tn)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "INSERT INTO TipNamjestaja (Naziv, Obrisan) VALUES (@Naziv, @Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                    cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                    tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
                }

                Projekat.Instance.TipoviNamjestaja.Add(tn);
                return tn;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom kreiranja tipa namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }
        public static void Update(TipNamjestaja tn)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "UPDATE TipNamjestaja SET Naziv = @Naziv, Obrisan = @Obrisan WHERE Id = @Id;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("Id", tn.Id);
                    cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                    cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                    cmd.ExecuteNonQuery();
                }

                foreach (var tipNamjestaja in Projekat.Instance.TipoviNamjestaja)
                {
                    if (tn.Id == tipNamjestaja.Id)
                    {
                        tipNamjestaja.Naziv = tn.Naziv;
                        tipNamjestaja.Obrisan = tn.Obrisan;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom izmjenetipa namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static void Delete(TipNamjestaja tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }

        public static ObservableCollection<TipNamjestaja> Order(string text)
        {
            try
            {
                var tipoviNamjestaja = new ObservableCollection<TipNamjestaja>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM TipNamjestaja WHERE Obrisan = 0  ORDER BY " + text;
                    da.SelectCommand = cmd;
                    da.Fill(ds, "TipNamjestaja");

                    foreach (DataRow row in ds.Tables["TipNamjestaja"].Rows)
                    {
                        var tn = new TipNamjestaja();
                        tn.Id = Convert.ToInt32(row["Id"]);
                        tn.Naziv = row["Naziv"].ToString();
                        tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        tipoviNamjestaja.Add(tn);
                    }
                }
                return tipoviNamjestaja;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom sortiranja tipa namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static ObservableCollection<TipNamjestaja> Search(string text)
        {
            try
            {
                var tipoviNamjestaja = new ObservableCollection<TipNamjestaja>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM TipNamjestaja WHERE Obrisan = 0 AND (Naziv LIKE @tekst) ";
                    da.SelectCommand = cmd;
                    cmd.Parameters.AddWithValue("@tekst", '%' + text + '%');
                    da.Fill(ds, "TipNamjestaja");

                    foreach (DataRow row in ds.Tables["TipNamjestaja"].Rows)
                    {
                        var tn = new TipNamjestaja();
                        tn.Id = Convert.ToInt32(row["Id"]);
                        tn.Naziv = row["Naziv"].ToString();
                        tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        tipoviNamjestaja.Add(tn);
                    }
                }
                return tipoviNamjestaja;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom pretrage tipa namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        #endregion
    }
}
