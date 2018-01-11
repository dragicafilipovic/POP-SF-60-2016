using POP_SF_60_2016GUI.Model;
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
   public  class ProdajaNamjestaja: INotifyPropertyChanged, ICloneable
    {
        private int id;
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;
        private double ukupanIznos;
        private ObservableCollection<Stavke> namjestajPro;
        private ObservableCollection<DodatnaUsluga> dodatnaU;
        private bool obrisan;

   

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        public ObservableCollection<DodatnaUsluga> DodatnaU
        {
            get { return dodatnaU; }
            set
            {
                dodatnaU = value;
                OnPropertyChanged("DodatnaU");
            }
        }



        public ObservableCollection<Stavke> NamjestajPro
        {
            get { return namjestajPro; }
            set
            {
                namjestajPro = value;
                OnPropertyChanged("NamjestajPro");
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
        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }
        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }
        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }

        public double UkupanIznos
        {
            get { return ukupanIznos; }
            set
            {
                ukupanIznos = value;
                OnPropertyChanged("UkupanIznos");
            }
        }

 
        public const double PDV = 0.02;

        public ProdajaNamjestaja()
        {
            datumProdaje = DateTime.Today;
            NamjestajPro = new ObservableCollection<Stavke>();
            DodatnaU = new ObservableCollection<DodatnaUsluga>();
        }

        


        public event PropertyChangedEventHandler PropertyChanged;


        public object Clone()
        {
            return new ProdajaNamjestaja()
            {
                Id = id,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                NamjestajPro = namjestajPro,
                DodatnaU = dodatnaU,
                UkupanIznos = ukupanIznos
                
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static ObservableCollection<Namjestaj> NamjestajPoId(List<int> namjestajId)
        {   if (namjestajId != null)
            {
                ObservableCollection<Namjestaj> lista = new ObservableCollection<Namjestaj>();
                foreach (var id in namjestajId)
                {
                    lista.Add(Namjestaj.GetID(id));
                }
                return lista;
            }
            return null;
        }

        public static List<int> Idnamjestaja(ObservableCollection<Namjestaj> namjestaj)
        {
            
            List<int> lista=new List<int>();
            if (namjestaj != null)
            {
                foreach (var n in namjestaj)
                {
                    lista.Add(n.Id);
                }
                return lista;
            }
            return null;
        }

        public static ObservableCollection<DodatnaUsluga> DodatnaUslugaId(List<int> uslugaId)
        {
            ObservableCollection<DodatnaUsluga> lista = new ObservableCollection<DodatnaUsluga>();
            if (uslugaId != null)
            {
                foreach (var id in uslugaId)
                {
                    lista.Add(DodatnaUsluga.GetID(id));
                }
                return lista;
            }
            return null;
        }

        public static List<int> Idusluga(ObservableCollection<DodatnaUsluga> dodatnaUsluga)
        {
            List<int> lista = new List<int>();
            if (dodatnaUsluga != null)
            {
                foreach (var du in dodatnaUsluga)
                {
                    lista.Add(du.Id);
                }
                return lista;
            }
            return null;
        }

        #region CRUD
        public static ObservableCollection<ProdajaNamjestaja> GetAll()
        {
            try
            {
                var prodaja = new ObservableCollection<ProdajaNamjestaja>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM Prodaja WHERE Obrisan = 0;";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Prodaja");

                    foreach (DataRow row in ds.Tables["Prodaja"].Rows)
                    {
                        var p = new ProdajaNamjestaja();
                        p.Id = int.Parse(row["Id"].ToString());
                        p.DatumProdaje = DateTime.Parse(row["DatumProdaje"].ToString());
                        p.BrojRacuna = row["BrojRacuna"].ToString();
                        p.Kupac = row["Kupac"].ToString();
                        p.UkupanIznos = double.Parse(row["UkupanIznos"].ToString());
                        p.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        DataSet ds3 = new DataSet();
                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandText = "SELECT UslugaId FROM ProdateUsluge WHERE PId=@Id;";
                        cmd3.Parameters.AddWithValue("@Id", p.Id);
                        da.SelectCommand = cmd3;
                        da.Fill(ds3, "ProdateUsluge");
                        ObservableCollection<DodatnaUsluga> usluga = new ObservableCollection<DodatnaUsluga>();
                        foreach (DataRow dr1 in ds3.Tables["ProdateUsluge"].Rows)
                        {
                            int id = int.Parse(dr1["UslugaId"].ToString());
                            usluga.Add(DodatnaUsluga.GetById(id));
                        }
                        p.DodatnaU = usluga;

                        prodaja.Add(p);

                        DataSet ds2 = new DataSet();
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandText = "SELECT NId FROM Stavka WHERE PId=@Id;";
                        cmd2.Parameters.AddWithValue("@Id", p.Id);
                        da.SelectCommand = cmd2;
                        da.Fill(ds2, "Stavka");
                        foreach (DataRow dr in ds2.Tables["Stavka"].Rows)
                        {
                            Stavke s = new Stavke()
                            {
                                Id = int.Parse(dr["StId"].ToString()),
                                Kolicina = int.Parse(dr["Kolicina"].ToString()),
                                NamjestajID = int.Parse(dr["NId"].ToString()),
                                Obrisan = bool.Parse(dr["Obrisan"].ToString())
                            };
                            p.NamjestajPro.Add(s);
                        }

                        prodaja.Add(p);
                    }
                }
                return prodaja;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom ucitavanja prodaje namjestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static ProdajaNamjestaja Create(ProdajaNamjestaja p)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Prodaja (DatumProdaje, BrojRacuna, Kupac, UkupanIznos, Obrisan) VALUES(@DatumProdaje, @BrojRacuna, @Kupac, @UkupanIznos, @Obrisan); ";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("DatumProdaje", p.DatumProdaje);
                    cmd.Parameters.AddWithValue("BrojRacuna", p.BrojRacuna);
                    cmd.Parameters.AddWithValue("Kupac", p.Kupac);
                    cmd.Parameters.AddWithValue("UkupanIznos", p.UkupanIznos);
                    cmd.Parameters.AddWithValue("Obrisan", p.Obrisan);

                    p.Id = int.Parse(cmd.ExecuteScalar().ToString());

                    for (int i = 0; i < p.NamjestajPro.Count; i++)
                    {
                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandText = "INSERT INTO Stavka(PId, Kolicina, NId, Obrisan) VALUES(@PId, @Kolicina, @NId, @Obrisan2)";
                        cmd2.Parameters.AddWithValue("@PId", p.Id);
                        cmd2.Parameters.AddWithValue("@Kolicina", p.NamjestajPro[i].Kolicina);
                        cmd2.Parameters.AddWithValue("@NId", p.NamjestajPro[i].Namjestaj.Id);
                        cmd2.Parameters.AddWithValue("@Obrisan2", p.Obrisan);
                        cmd2.ExecuteNonQuery();
                    }

                    foreach (var item in p.NamjestajPro)
                    {
                        item.Namjestaj.Kolicina = item.Namjestaj.Kolicina - item.Kolicina;
                        Namjestaj.Update(item.Namjestaj);
                    }

                    for (int i = 0; i < p.DodatnaU.Count; i++)
                    {
                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandText = "INSERT INTO ProdateUsluge(PId, UslugaId, Obrisan) VALUES(@PId, @UslugaId, @Obrisan3)";
                        cmd3.Parameters.AddWithValue("@PId", p.Id);
                        cmd3.Parameters.AddWithValue("@UslugaId", p.DodatnaU[i].Id);
                        cmd3.Parameters.AddWithValue("@Obrisan3", p.Obrisan);
                        cmd3.ExecuteNonQuery();
                    }

                }

                Projekat.Instance.ProdajaNamjestaja.Add(p);
                return p;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom kreiranja prodaje namjestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static void Update(ProdajaNamjestaja p)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "UPDATE Prodaja SET DatumProdaje=@DatumProdaje, BrojRacuna=@BrojRacuna, Kupac=@Kupac, UkupanIznos=@UkupanIznos, Obrisan=@Obrisan WHERE Id=@Id;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Id", p.Id);
                    cmd.Parameters.AddWithValue("DatumProdaje", p.DatumProdaje);
                    cmd.Parameters.AddWithValue("BrojRacuna", p.BrojRacuna);
                    cmd.Parameters.AddWithValue("Kupac", p.Kupac);
                    cmd.Parameters.AddWithValue("UkupanIznos", p.UkupanIznos);
                    cmd.Parameters.AddWithValue("Obrisan", p.Obrisan);


                    cmd.ExecuteNonQuery();
                }
                foreach (var item in Projekat.Instance.ProdajaNamjestaja)
                {
                    if (item.Id == p.Id)
                    {
                        item.DatumProdaje = p.DatumProdaje;
                        item.BrojRacuna = p.BrojRacuna;
                        item.Kupac = p.Kupac;
                        item.UkupanIznos = p.UkupanIznos;
                        item.Obrisan = p.Obrisan;

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom izmjene prodaje namjestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }


        #endregion
    }
}
