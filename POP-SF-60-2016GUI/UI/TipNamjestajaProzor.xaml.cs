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
    /// Interaction logic for TipNamjestajaProzor.xaml
    /// </summary>
    public partial class TipNamjestajaProzor : Window
    {
        public TipNamjestajaProzor()
        {
            InitializeComponent();
            dgTipNamjestaj.ItemsSource = Projekat.Instance.TipoviNamjestaja;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            TipNamjestaja tn = new TipNamjestaja();
            EditTipNamjestajaWindow etn = new EditTipNamjestajaWindow(tn, EditTipNamjestajaWindow.Operacija.DODAVANJE);
            etn.ShowDialog();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            TipNamjestaja tn = dgTipNamjestaj.SelectedItem as TipNamjestaja;
            EditTipNamjestajaWindow etn = new EditTipNamjestajaWindow(tn, EditTipNamjestajaWindow.Operacija.IZMJENA);
            etn.ShowDialog();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.TipoviNamjestaja;
            TipNamjestaja tn = dgTipNamjestaj.SelectedItem as TipNamjestaja;
            tn.Obrisan = true;
            GenericSerializer.Serialize("tipNamjestaja.xml", lista);
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
