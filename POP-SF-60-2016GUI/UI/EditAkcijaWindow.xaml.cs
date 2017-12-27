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

            dgNAkcija.ItemsSource = Projekat.Instance.Namjestaj;

            tbPopust.DataContext = akcija;
            dpPocetak.DataContext = akcija;
            dpKraj.DataContext = akcija;
            
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Akcija;
            var selekrovani = dgNAkcija.SelectedItem as Namjestaj;
            if (operacija == Operacija.DODAVANJE)
            {
                Akcija.Create(akcija);
            }
            Akcija.Update(akcija);
                

            GenericSerializer.Serialize("akcija.xml", lista);
            Close();
        }

        private void dgNAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }
    }
}
