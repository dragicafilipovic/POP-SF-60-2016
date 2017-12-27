using POP.Model;
using POP.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        ICollectionView view;
        public DodatnaUslugaWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUsluga);
            view.Filter = DodatnaUFilter;

            dgUsluga.ItemsSource = Projekat.Instance.DodatnaUsluga;
        }
        private bool DodatnaUFilter(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga du = new DodatnaUsluga();
            EditDodatnaUslugaWindow duw = new EditDodatnaUslugaWindow(du,EditDodatnaUslugaWindow.Operacija.DODAVANJE);
            duw.ShowDialog();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga du = dgUsluga.SelectedItem as DodatnaUsluga;
            EditDodatnaUslugaWindow duw = new EditDodatnaUslugaWindow(du, EditDodatnaUslugaWindow.Operacija.IZMJENA);
            duw.ShowDialog();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.DodatnaUsluga;
            DodatnaUsluga du = dgUsluga.SelectedItem as DodatnaUsluga;
            DodatnaUsluga.Delete(du);
            GenericSerializer.Serialize("usluga.xml", lista);
            view.Refresh();
         }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgUsluga_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
