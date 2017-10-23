using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    class ProdajaNamjestaja
    {
        public int ID { get; set; }
        public List<Namjestaj> NamjestajZaProdaju { get; set; }
        public DateTime DatumProdaje { get; set; }
        public string BrojRacuna { get; set; }
        public string Kupac { get; set; }
        public double PDV { get; set; }
        public List<DodatnaUsluga> DodatnaUsluga { get; set; }
        public const double PDV = 0.02;
        public double UkupnIznos { get; set; }
    }
}
