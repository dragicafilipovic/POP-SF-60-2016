using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    class Akcija
    {
        public int ID  { get; set; }
        public DateTime PocetakAkcije { get; set; }
        public DateTime ZavrsetakAkcije { get; set; }
        public double Popust { get; set; }
        public bool Obrisan { get; set; }
        public  List<Namjestaj> NamjestajNaAkciji { get; set; }
}
}
