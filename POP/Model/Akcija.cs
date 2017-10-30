using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    public class Akcija
    {
        public int ID  { get; set; }
        public DateTime PocetakAkcije { get; set; }
        public DateTime ZavrsetakAkcije { get; set; }
        public decimal Popust { get; set; }
        public bool Obrisan { get; set; }
        public  List<Namjestaj> NamjestajNaAkciji { get; set; }
}
}
