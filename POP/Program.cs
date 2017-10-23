using POP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP
{
    class Program
    {
        static List<Namjestaj> Namjestaj { get; set; } = new List<Namjestaj>();
        static List<TipNamjestaja> TipNamestaj { get; set; } = new List<TipNamjestaja>();
        static void Main(string[] args)
        {
            var s1 = new Salon()
            {
                ID = 1,
                Naziv = "Forma FTNale",
                Adresa = "Trg Dositeja Obradovica 6",
                BrojZiroRacuna = "840-1000020-232",
                Email = "kontakt@ftn.uns.ac.rs",
                MaticniBroj = 123456789,
                PIB = 321654,
                BrojTelefona = "021/123-456",
                AdresaSajta = "https://www.ftn.uns.ac.rs"
            };

            var t1 = new TipNamjestaja()
            {
                ID = 1,
                Naziv = "Garnitura"
            };

            var n1 = new Namjestaj()
            {
                ID = 1,
                Naziv = "Super sofa",
                Sifra = "1234",
                TipNamjestaja = t1,
                KolicinaUMagacina = 6

            };
           Namjestaj.Add(n1);
           TipNamestaj.Add(t1);
            IspisGlavnogMenija();
        }

        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== GLAVNI MENI ===");
                Console.WriteLine("1. Rad sa namjestajem");
                Console.WriteLine("2. Rad sa tipom namjestaja");
                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 2);
            switch (izbor)
            {
                case 1:
                    IspisMenijaNamjestaja();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }
        private static void IspisMenijaNamjestaja()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== MENI NAMJESTAJA ===");
                Console.WriteLine("1. Izlistaj namjestaj");
                Console.WriteLine("2. Dodaj novi namjestaj");
                Console.WriteLine("3. Izmeni postojeci namjestaj");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("0. Povratak u glavni meni");
                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 2:
            //        DodavanjeNamjestaja();
                    break;
                case 1:
                    IzlistajNamjestaj();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;
                default:
                    break;
            }
        }

        private static void IzlistajNamjestaj()
        {
            for (int i = 0; i < Namjestaj.Count; i++)
            {
                if (Namjestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1 }.{Namjestaj[i].Naziv}, cena: {Namjestaj[i].JedinicnaCijena}");
                } 
            }
            IspisMenijaNamjestaja();
        }

    }

    private static void DodavanjeNamjestaja()
    {
        var noviNamjestaj = new Namjestaj();
        noviNamjestaj.ID = Namjestaj.Count + 1;
        Console.WriteLine("Unesite naziv namestaja: ");
        noviNamjestaj.Naziv = Console.ReadLine();
        Console.WriteLine("Unesite siftu namestaja: ");
        noviNamjestaj.Sifra = Console.ReadLine();
        Console.WriteLine("Unesite cijenu namestaja: ");
        noviNamjestaj.JedinicnaCijena = double.Parse(Console.ReadLine());
        Console.WriteLine("Koliko komada namjestaja se nalazi u magacinu: ");
        noviNamjestaj.KolicinaUMagacina = int.Parse(Console.ReadLine());
        Console.WriteLine("Unesite tip namjestaja: ");
        String nazivTipaNamjetaja = Console.ReadLine();

        string nazivNamjestaja = "";
        TipNamjestaja trazeniTipNamjestaja;
        do
        {
            Console.WriteLine("Unesite tip namjestaja: ");
            nazivNamjestaja = Console.ReadLine();
            foreach (var tipNamjestaja in  )
            { }
        }
        Namjestaj.Add(nazivNamjestaja);

    }

    private static void IzmjenaNamjestaja()
    {
        Namjestaj trazeniNamjestaj = null;
        string nazivTrazenogNamjestaja = ""
        do
        {
            Console.WriteLine("Unesite naziv namjestaja koji mjenjate: ");
            nazivTrazenogNamjestaja = Console.ReadLine();

            foreach(var namjestaj in Namjestaj)
            {
                if()
            }

        } while():
    }
    
}
    


