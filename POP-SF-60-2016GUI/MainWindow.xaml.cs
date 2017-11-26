using POP.Model;
using POP.Util;
using POP_SF_60_2016GUI.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF_60_2016GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         /*   var listUredjaja = Projekat.Instance.DodatnaUsluga;
            var listaUID = new List<int>();
            listaUID.Add(listUredjaja[0].Id);
            var listaNamjestaja = Projekat.Instance.Namjestaj;
            var listaNID = new List<int>();
            listaNID.Add(listaNamjestaja[0].Id);
            var prodaja = new ProdajaNamjestaja()
            {
                Id = 1,
                BrojRacuna = "123456",
                DatumProdaje = DateTime.Parse("1.1.2017"),
              //  DodatnaUslugaID = listaUID,
                Kupac = "Pera",
                NamjestajProdajaID = listaNID,
                UkupnIznos = 1000


            };

            ObservableCollection<ProdajaNamjestaja> listaProdaja =new  ObservableCollection<ProdajaNamjestaja>();
            listaProdaja.Add(prodaja);
            GenericSerializer.Serialize("prodajaNamjestaja.xml", listaProdaja); */
        }

        private void Prijava_Click(object sender, RoutedEventArgs e)
        {
            var korisnici = Projekat.Instance.Korisnik;
            foreach (var k in korisnici)
            {
                var korisnickoIme = tbKIme.Text;
                var lozinka = pbLozinka.Password;
                if (korisnickoIme == "" || lozinka == "")
                {
                    MessageBox.Show("Morate popuniti sva polja!", "Greska", MessageBoxButton.OK,MessageBoxImage.Warning);
                    return;
                } else if (korisnickoIme == k.KorisnickoIme || lozinka == k.Lozinka)
                {
                    GlavniWindow gw = new GlavniWindow();
                    gw.ShowDialog();
                    this.Close();
                    return;
                }
            }

        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
