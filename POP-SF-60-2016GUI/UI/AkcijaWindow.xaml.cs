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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        public AkcijaWindow()
        {
            InitializeComponent();
            dgAkcija.ItemsSource = Projekat.Instance.Akcija;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Akcija a = new Akcija();
            EditAkcijaWindow eaw = new EditAkcijaWindow(a, EditAkcijaWindow.Operacija.DODAVANJE);
            eaw.ShowDialog();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            Akcija a = dgAkcija.SelectedItem as Akcija;
            EditAkcijaWindow eaw = new EditAkcijaWindow(a, EditAkcijaWindow.Operacija.IZMJENA);
            eaw.ShowDialog();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Akcija;
            Akcija a= dgAkcija.SelectedItem as Akcija;
            a.Obrisan = true;
            GenericSerializer.Serialize("akcija.xml", lista);
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "NamjestajNaAkcijiID"
                ||(string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
