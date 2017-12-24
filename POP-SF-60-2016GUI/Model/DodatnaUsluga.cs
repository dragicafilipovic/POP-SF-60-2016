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

        #region CRUD
        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var dodatnaUsluga = new ObservableCollection<DodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "DodatnaUsluga");

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = Convert.ToInt32(row["Id"]);
                    du.NazivUsluge = row["NazivUsluge"].ToString();
                    du.CijenaUsluge = double.Parse(row["CijenaUsluge"].ToString());
                    du.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    dodatnaUsluga.Add(du);
                }
            }
            return dodatnaUsluga;
        }

        public static DodatnaUsluga Create(DodatnaUsluga du)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO DodatnaUsluga (NazivUsluge, CijenaUsluge, Obrisan) VALUES (@NazivUsluge, @CijenaUsluge, @Obrisan );";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("NazivUsluge", du.NazivUsluge);
                cmd.Parameters.AddWithValue("CijenaUsluge", du.CijenaUsluge);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                du.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.DodatnaUsluga.Add(du);
            return du;
        }

        public static void Update(DodatnaUsluga du)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE DodatnaUsluga SET NazivUsluge = @NazivUsluge,  CijenaUsluge = @CijenaUsluge, Obrisan = @Obrisan, WHERE Id = @Id; ";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", du.Id);
                cmd.Parameters.AddWithValue("NazivUsluge", du.NazivUsluge);
                cmd.Parameters.AddWithValue("CijenaUsluge", du.CijenaUsluge);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                cmd.ExecuteNonQuery();
            }

            foreach (var dodatnaUsluga in Projekat.Instance.DodatnaUsluga)
            {
                if (du.Id == dodatnaUsluga.Id)
                {
                    dodatnaUsluga.NazivUsluge = du.NazivUsluge;
                    dodatnaUsluga.CijenaUsluge = du.CijenaUsluge;
                    dodatnaUsluga.Obrisan = du.Obrisan;
                }
            }
        }

        public static void Delete(DodatnaUsluga du)
        {
            du.Obrisan = true;
            Update(du);
        }

        #endregion
    }
}
