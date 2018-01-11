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
    /// Interaction logic for EditSalonWindow.xaml
    /// </summary>
    /// 
    public partial class EditSalonWindow : Window
    {

        private Salon salon;

        public EditSalonWindow(Salon salon)
        {
            InitializeComponent();

            this.salon = salon;

            tbNaziv.DataContext = salon;
            tbAdresa.DataContext = salon;
            tbBrTel.DataContext = salon;
            tbEmail.DataContext = salon;
            tbAdresaS.DataContext = salon;
            tbPib.DataContext = salon;
            tbMaticniBr.DataContext = salon;
            tbRacun.DataContext = salon;    
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            Salon.Update(salon);
            this.Close();
        }
    }
}
