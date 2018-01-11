using POP.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace POP_SF_60_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for GlavniWindow.xaml
    /// </summary>
    public partial class GlavniWindow : Window
    {
        public GlavniWindow()
        {
            InitializeComponent();
            if (MainWindow.korisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnAkcija.Visibility = Visibility.Hidden;
                btnNamjestaj.Visibility = Visibility.Hidden;
                btnTip.Visibility = Visibility.Hidden;
                btnUsluga.Visibility = Visibility.Hidden;
                btnKorisnik.Visibility = Visibility.Hidden;
            }
        }

        private void Namjestaj_Click(object sender, RoutedEventArgs e)
        {
            NamjestajProzor np = new NamjestajProzor();
            np.ShowDialog();
        }

        private void btnTip_Click(object sender, RoutedEventArgs e)
        {
            TipNamjestajaProzor tnp = new TipNamjestajaProzor();
            tnp.ShowDialog();
        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {
            KorisnikWindow kw = new KorisnikWindow();
            kw.ShowDialog();
        }

        private void btnUsluga_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUslugaWindow duw = new DodatnaUslugaWindow();
            duw.ShowDialog();
        }

        private void btnAkcija_Click(object sender, RoutedEventArgs e)
        {
            AkcijaWindow aw = new AkcijaWindow();
            aw.ShowDialog();
        }

        private void btnProdaja_Click(object sender, RoutedEventArgs e)
        {
            ProdajaWindow pw = new ProdajaWindow();
            pw.ShowDialog();
        }
    }
}
