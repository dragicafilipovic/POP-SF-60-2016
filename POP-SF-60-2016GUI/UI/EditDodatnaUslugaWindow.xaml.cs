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
    /// Interaction logic for EditDodatnaUslugaWindow.xaml
    /// </summary>
    public partial class EditDodatnaUslugaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMJENA
        }
        private DodatnaUsluga usluga;
        private Operacija operacija;
        public EditDodatnaUslugaWindow(DodatnaUsluga usluga,Operacija operacija)
        {
            InitializeComponent();

            this.usluga = usluga;
            this.operacija = operacija;
            tbNaziv.DataContext = usluga;
            tbCijena.DataContext = usluga;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.DodatnaUsluga;
            if (operacija == Operacija.DODAVANJE)
            {
                usluga.Id = lista.Count + 1;
                lista.Add(usluga);
            }
            GenericSerializer.Serialize("usluga.xml", lista);
            Close();
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
