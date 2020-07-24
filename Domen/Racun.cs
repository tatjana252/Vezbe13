using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Racun
    {
        public int Id { get; set; }

        public DateTime Datum { get; set; }

        public Korisnik Korisnik { get; set; }

        public List<StavkaRacuna> StavkeRacuna { get; set; }

    }
}
