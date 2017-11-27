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
                    this.Close();
                    gw.ShowDialog();
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
