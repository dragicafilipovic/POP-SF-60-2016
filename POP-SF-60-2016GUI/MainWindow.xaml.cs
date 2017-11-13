using POP.Model;
using POP_SF_60_2016GUI.UI;
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

            OsvjeziPrikaz();
        }

        private void OsvjeziPrikaz()
        {
            lbNamjestaj.Items.Clear();

            foreach (var namjestaj in Projekat.Instance.Namjestaj)
            {
                lbNamjestaj.Items.Add(namjestaj);
            }

            lbNamjestaj.SelectedIndex = 0;
        }
        public void DodajNamjestaj(object sender, RoutedEventArgs e)
        {
            var noviNamjestaj = new Namjestaj()
            {
                Naziv = ""
            };

            var namjestajProzor = new NamjestajWindow(noviNamjestaj, NamjestajWindow.Operacija.DODAVANJE);
            namjestajProzor.Show();
           
        }

        private void WindowActivate(object sender, EventArgs e)
        {
            OsvjeziPrikaz();
        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IzmjenaNamjestaja(object sender, RoutedEventArgs e)
        {
            var izaberiNamjestaj = (Namjestaj)lbNamjestaj.SelectedItem;
            var namjestajProzor = new NamjestajWindow(izaberiNamjestaj, NamjestajWindow.Operacija.IZMJENA);
            namjestajProzor.Show();
        }
    }
}
