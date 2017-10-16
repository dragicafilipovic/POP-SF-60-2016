using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Model
{
    class DodatnaUsluga
    {
        public int ID { get; set; }
        public string NazivUsluge { get; set; }
        public double CijenaUsluge { get; set; }
        public bool Obrisan { get; set; }
    }
}
