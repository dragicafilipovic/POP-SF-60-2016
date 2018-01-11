using POP.Model;
using POP.Util;
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
    /// Interaction logic for EditAkcijaWindow.xaml
    /// </summary>
    /// 
    public partial class EditAkcijaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMJENA
        }
        private Akcija akcija;
        private Operacija operacija;

        public EditAkcijaWindow(Akcija akcija,Operacija operacija)
        {
            InitializeComponent();
            this.akcija = akcija;
            this.operacija = operacija;

            dgNAkcija.ItemsSource=akcija.NamjestajNaAkciji;

            tbPopust.DataContext = akcija;
            dpPocetak.DataContext = akcija;
            dpKraj.DataContext = akcija;
            
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Akcija;
            double cijenaN = 0;
            for (int i = 0; i < akcija.NamjestajNaAkciji.Count; i++)
            {
                cijenaN += akcija.NamjestajNaAkciji[i].Cijena;
            }

            if (operacija == Operacija.DODAVANJE)
            {
                akcija.Id = lista.Count + 1;
                foreach (var item in akcija.NamjestajNaAkciji)
                {
                    item.AkcijskaCijena = item.Cijena - ((item.Cijena * akcija.Popust) / 100);
                    Namjestaj.Update(item);
                }
                Akcija.Create(akcija);
            }
            Akcija.Update(akcija);
               

            GenericSerializer.Serialize("akcija.xml", lista);
            Close();
        }

        private void dgNAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "Sifra"
            || (string)e.Column.Header == "TipNamjestajaID")
            {
                e.Cancel = true;
            }
        }

        private void btnPreuzmi_Click(object sender, RoutedEventArgs e)
        {
            PreuzmiNamjestaj pn = new PreuzmiNamjestaj(PreuzmiNamjestaj.TipOperacije.Akcija);
            if(pn.ShowDialog() == true)
            akcija.NamjestajNaAkciji.Add(pn.IzabraniN);
        }
    }
}
