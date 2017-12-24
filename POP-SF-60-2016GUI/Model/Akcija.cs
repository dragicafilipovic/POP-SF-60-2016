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
    public class Akcija: INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;
        private decimal popust;
        private DateTime pocetakAkcije;
        private DateTime zavrsetakAkcije;
        private ObservableCollection<Namjestaj> namjestajNaAkciji;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public ObservableCollection<Namjestaj> NamjestajNaAkciji
        {
            get { return namjestajNaAkciji; }
            set
            {
                namjestajNaAkciji = value;
                OnPropertyChanged("NamjestajaNaAkciji");
            }
        }
        



        public decimal Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }

        public DateTime PocetakAkcije
        {
            get { return pocetakAkcije; }
            set
            {
                pocetakAkcije = value;
                OnPropertyChanged("PocetakAkcije");
            }
        }
        public Akcija()
        {
            pocetakAkcije = DateTime.Today;
            zavrsetakAkcije = DateTime.Today;
        }

        public DateTime ZavrsetakAkcije
        {
            get { return zavrsetakAkcije; }
            set
            {
                zavrsetakAkcije = value;
                OnPropertyChanged("ZavrsetakAkcije");
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

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Akcija()
            {
                Id = id,
                NamjestajNaAkciji = namjestajNaAkciji,
                Popust = popust,
                PocetakAkcije = pocetakAkcije,
                ZavrsetakAkcije = zavrsetakAkcije,
                Obrisan = obrisan
            };
        }

        #region CRUD
        public static ObservableCollection<Akcija> GetAll()
        {
            var akcija = new ObservableCollection<Akcija>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija");

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    var a = new Akcija();
                    a.Id = Convert.ToInt32(row["Id"]);
                    a.PocetakAkcije = DateTime.Parse(row["PocetakAkcije"].ToString());
                    a.ZavrsetakAkcije = DateTime.Parse(row["ZavrsetakAkcije"].ToString());
                    a.Popust = decimal.Parse(row["Popust"].ToString());
                    a.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    DataSet ds2 = new DataSet();
                    cmd.CommandText = "SELECT NId FROM NaAkciji WHERE AkId=@id;";
                    cmd.Parameters.AddWithValue("@id", a.Id);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Akcija");
                    ObservableCollection<Namjestaj> namejestaj = new ObservableCollection<Namjestaj>();
                    foreach (DataRow dr in ds2.Tables["NaAkciji"].Rows)
                    {
                        int id = int.Parse(dr["NId"].ToString());
                        namejestaj.Add(Namjestaj.GetByid(id));
                    }
                    a.NamjestajNaAkciji = namejestaj;
                    akcija.Add(a);
                }
            }
            return akcija;
        }

        public static Akcija Create(Akcija a)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Akcija (PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan)  VALUES (@PocetakAkcije, @ZavrsetakAkcije, @Popust, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                

                cmd.Parameters.AddWithValue("PocetakAkcije", a.PocetakAkcije);
                cmd.Parameters.AddWithValue("ZavrsetakAkcije", a.ZavrsetakAkcije);
                cmd.Parameters.AddWithValue("Popust", a.Popust);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                a.Id = int.Parse(cmd.ExecuteScalar().ToString());

                foreach(var item in a.NamjestajNaAkciji)
                {
                    cmd.CommandText = "INSERT INTO NaAkciji(NId,AkId,Obrisan) VALUES(@NId,@AId,@Obrisan)";
                    cmd.Parameters.AddWithValue("@NId", item.Id);
                    cmd.Parameters.AddWithValue("@AId", a.Id);
                    cmd.Parameters.AddWithValue("@Obrisan", '0');
                    cmd.ExecuteNonQuery();
                }
            }

            Projekat.Instance.Akcija.Add(a);
            return a;
        }

        public static void Update(Akcija a)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Akcija SET PocetakAkcije = @PocetakAkcije, ZavrsetakAkcije = @ZavrsetakAkcije, Popust = @Popust, Obrisan = @Obrisan WHERE Id = @Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", a.Id);
                cmd.Parameters.AddWithValue("PocetakAkcije", a.PocetakAkcije);
                cmd.Parameters.AddWithValue("ZavrsetakAkcije", a.ZavrsetakAkcije);
                cmd.Parameters.AddWithValue("Popust", a.Popust);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                cmd.ExecuteNonQuery();
            }

            foreach (var akcija in Projekat.Instance.Akcija)
            {
                if (a.Id == akcija.Id)
                {
                    akcija.PocetakAkcije = a.PocetakAkcije;
                    akcija.ZavrsetakAkcije = a.ZavrsetakAkcije;
                    akcija.Popust = a.Popust;
                    akcija.Obrisan = a.Obrisan;
                }
            }
        }

        public static void Delete(Akcija a)
        {
            a.Obrisan = true;
            Update(a);
        }
        #endregion
    }
}
