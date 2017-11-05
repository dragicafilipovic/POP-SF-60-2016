using POP.Model;
using POP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP
{
    class Program
    {
        public static List<Namjestaj> listaNamestaj { get; set; } = new List<Namjestaj>();
        public static List<TipNamjestaja> TipNamestaj { get; set; } = new List<TipNamjestaja>();
        static void Main(string[] args)
        {
            var korisnik = new List<Korisnik>();
            var k = new Korisnik {ID = 1, Ime = "Pera", Prezime = "Peric", KorisnickoIme = "pera", Lozinka = "12345", TipKorisnika = TipKorisnika.Administrator };
            korisnik.Add(k);
            Projekat.Instance.Korisnik = korisnik;

            var usluga = new List<DodatnaUsluga>();
            var u = new DodatnaUsluga { ID = 1, NazivUsluge = "Prevoz", CijenaUsluge = 2000 };
            usluga.Add(u);
            Projekat.Instance.DodatnaUsluga = usluga;

            var tipNamjestaja = Projekat.Instance.TipNamjestaja;
            tipNamjestaja.Add(new TipNamjestaja() { ID = 12, Naziv = "Garnitura" });
            Projekat.Instance.TipNamjestaja = tipNamjestaja;
            foreach (var tip in tipNamjestaja)
            {
                Console.WriteLine($"{tip.Naziv}");
            }
            var NamjestajNaAkciji = Projekat.Instance.Namjestaj;
            var praznaLista = new List<Namjestaj>();
            praznaLista.Add(NamjestajNaAkciji[0]);
            var akcija = new List<Akcija>();
            akcija.Add(new Akcija() { ID = 1, PocetakAkcije = DateTime.Now, ZavrsetakAkcije = DateTime.Parse("1.12.2017"), Popust = 20, NamjestajNaAkciji = praznaLista});
            Projekat.Instance.Akcija = akcija;
            foreach (var popust in akcija)
            {
                Console.WriteLine($"{popust.NamjestajNaAkciji}");
            }
            Console.ReadLine();

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
            listaNamestaj.Add(n1);
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
                case 3:
                    BrisanjeNamjestaja();
                    break;
                case 2:
                    DodavanjeNamjestaja();
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
            for (int i = 0; i < listaNamestaj.Count; i++)
            {
                if (listaNamestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1 }.{listaNamestaj[i].Naziv}, cena: {listaNamestaj[i].JedinicnaCijena}");
                }
            }
            IspisMenijaNamjestaja();
        }
        private static void DodavanjeNamjestaja()
        {
            var tipoviNamestaja = Projekat.Instance.TipNamjestaja;
            var ukupanNamjestaj = Projekat.Instance.Namjestaj;
            var noviNamjestaj = new Namjestaj();
            noviNamjestaj.ID = ukupanNamjestaj.Count + 1;
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
            bool indikator = false;
            int idNamjestaja = 0;
            TipNamjestaja trazeniTipNamjestaja = null;
            do
            {
                Console.WriteLine("Unesite tip namjestaja: ");
                idNamjestaja = int.Parse(Console.ReadLine());
                foreach (var tipNamjestaja in tipoviNamestaja)
                {
                    if (tipNamjestaja.ID == idNamjestaja)
                    {
                        trazeniTipNamjestaja = tipNamjestaja;
                        indikator = true;
                    }
                }
            } while (indikator);
            ukupanNamjestaj.Add(noviNamjestaj);
            Projekat.Instance.Namjestaj = ukupanNamjestaj;
        }

        private static void IzmjenaNamjestaja()
        {
            var ukupanNamjestaj = Projekat.Instance.Namjestaj;
            Namjestaj trazeniNamjestaj = null;
            int idNamjestaja = 0;
            bool indikator = false;

            do
            {
                Console.WriteLine("Unesite id namjestaja koji mjenjate: ");
                idNamjestaja = int.Parse(Console.ReadLine());

                foreach (var n in ukupanNamjestaj)
                {
                    if (idNamjestaja == n.ID)
                    {
                        trazeniNamjestaj = n;
                        indikator = true;
                    }
                }

            } while (indikator);
            Console.WriteLine("Odaberite izmjenu koju zelite da izvrsite: ");
            Console.WriteLine("1.Izmjena naziva/n 2.Izmjena sifre/n 3.Izmjena cijene/n 4.Izmjena kolicine u magacinu/n 5.Izmjena tipa namjestaja");
            int izbor = int.Parse(Console.ReadLine());
            switch (izbor)
            {
                case 1:
                    Console.WriteLine("Unesite naziv za izmjenu:");
                    trazeniNamjestaj.Naziv = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Unesite sifru za izmjenu: ");
                    trazeniNamjestaj.Sifra = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Unesite cijenu za izmjenu: ");
                    trazeniNamjestaj.JedinicnaCijena = double.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("Unesite kolicinu za izmjenu: ");
                    trazeniNamjestaj.KolicinaUMagacina = int.Parse(Console.ReadLine());
                    break;
                case 5:
                    Console.WriteLine("Unesite tip za izmjenu: ");
                    var tipoviNamestaja = Projekat.Instance.TipNamjestaja;
                    bool indikator2 = false;
                    TipNamjestaja trazeniTipNamjestaja = null;
                    do
                    {
                        Console.WriteLine("Unesite tip namjestaja: ");
                        idNamjestaja = int.Parse(Console.ReadLine());
                        foreach (var tipN in tipoviNamestaja)
                        {
                            if (tipN.ID == idNamjestaja)
                            {
                                trazeniTipNamjestaja = tipN;
                                indikator = true;
                            }
                        }
                    } while (indikator2);
                    trazeniNamjestaj.TipNamjestaja = trazeniTipNamjestaja;
                    Projekat.Instance.Namjestaj = ukupanNamjestaj;
                    break;

            }

        }

            private static void BrisanjeNamjestaja()
        {
            var ukupanNamjestaj = Projekat.Instance.Namjestaj;
            Console.WriteLine("Unesite id namjestaja koji zelite da obrisete: ");
            int ID = int.Parse(Console.ReadLine());
            foreach (Namjestaj n in ukupanNamjestaj)
            {
               if (n.ID == ID)
                {
                    n.Obrisan = true;
                }
            }
            Projekat.Instance.Namjestaj = ukupanNamjestaj;

        }
        
  
    }

}


    


